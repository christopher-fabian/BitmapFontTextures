using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace BitmapFontTextures.Fonts;

internal sealed class BitmapFontTextureService
{
  // SpriteFont Importer only expects characters from the ranges defined in <CharacterRegions>
  // (typically from Space (32) to Tilde (126)).
  private const int FirstCharacterUnicode = 32;
  private const int LastCharacterUnicode = 126;

  private const PixelFormat OutputPixelFormat = PixelFormat.Format32bppArgb;
  private static readonly ImageFormat OutputImageFormat = ImageFormat.Png;

  private readonly Bitmap bitmap;
  private readonly Graphics graphics;

  public BitmapFontTextureService()
  {
    bitmap = new(1, 1, OutputPixelFormat);
    graphics = Graphics.FromImage(bitmap);
  }

  public void Save(string fileName, BitmapFontTextureParameters parameters)
  {
    HashSet<char> characterSet = [];

    if (string.IsNullOrEmpty(parameters.Text))
    {
      // Add each valid character.
      for (int i = FirstCharacterUnicode; i < LastCharacterUnicode; i++)
        characterSet.Add((char)i);
    }
    else
    {
      // Validate each character of the text.
      foreach (char character in parameters.Text)
      {
        if (character < FirstCharacterUnicode || character > LastCharacterUnicode)
          continue;

        characterSet.Add(character);
      }
    }

    // Character map must be in ascending order.
    List<char> characters = [.. characterSet];
    characters.Sort();

    // Build up a list of all the glyphs to be output.
    List<Bitmap> bitmaps = [];
    List<int> xPositions = [];
    List<int> yPositions = [];

    try
    {
      const int padding = 8;

      int width = padding;
      int height = padding;
      int lineWidth = padding;
      int lineHeight = padding;
      int count = 0;

      // Rasterize each character in turn,
      // and add it to the output list.
      foreach (char character in characters)
      {
        Bitmap bitmap = RasterizeCharacter(character, parameters);
        bitmaps.Add(bitmap);

        xPositions.Add(lineWidth);
        yPositions.Add(height);

        lineWidth += bitmap.Width + padding;
        lineHeight = Math.Max(lineHeight, bitmap.Height + padding);

        // Output 16 glyphs per line, then wrap to the next line.
        if (++count == 16)
        {
          width = Math.Max(width, lineWidth);
          height += lineHeight;
          lineWidth = padding;
          lineHeight = padding;
          count = 0;
        }
      }

      using (Bitmap bitmap = new(width, height + lineHeight, PixelFormat.Format32bppArgb))
      {
        // Arrage all the glyphs onto a single larger bitmap.
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
          graphics.Clear(Color.Magenta);
          graphics.CompositingMode = CompositingMode.SourceCopy;

          for (int i = 0; i < bitmaps.Count; i++)
            graphics.DrawImage(bitmaps[i], xPositions[i], yPositions[i]);

          graphics.Flush();
        }

        // Save out the combined bitmap.
        bitmap.Save(fileName, OutputImageFormat);
      }
    }
    finally
    {
      // Clean up temporary objects.
      foreach (Bitmap bitmap in bitmaps)
        bitmap.Dispose();
    }

    // Output the characters we just rendered to a text file
    string charOutput = Path.ChangeExtension(fileName, ".txt");
    using StreamWriter writer = new(charOutput);
    for (int i = 0; i < characters.Count; i++)
      writer.Write(characters[i]);
  }

  private Bitmap RasterizeCharacter(char character, BitmapFontTextureParameters parameters)
  {
    string text = character.ToString();

    SizeF size = graphics.MeasureString(text, parameters.Font);
    int width = (int)Math.Ceiling(size.Width);
    int height = (int)Math.Ceiling(size.Height);

    Bitmap bitmap = new(width, height, PixelFormat.Format32bppArgb);

    using (Graphics graphics = Graphics.FromImage(bitmap))
    {
      graphics.TextRenderingHint = parameters.Antialias ? TextRenderingHint.ClearTypeGridFit : TextRenderingHint.SingleBitPerPixelGridFit;
      graphics.Clear(Color.Transparent);

      // Validate alpha value and clamp it to the range [0, 255].
      int alpha = Math.Clamp(parameters.Alpha, 0, 255);

      Color customColor = Color.FromArgb(alpha, parameters.ShadowColor);
      using (Brush brush = new SolidBrush(Color.White))
      using (Brush brushOutline = new SolidBrush(parameters.OutlineColor))
      using (Brush brushShadow = new SolidBrush(customColor))
      using (StringFormat format = new())
      {
        format.Alignment = StringAlignment.Near;
        format.LineAlignment = StringAlignment.Near;

        int shadow = parameters.Shadow;
        int outline = parameters.Outline;

        // Draw the shadow
        if (shadow > 0)
          graphics.DrawString(text, parameters.Font, brushShadow, shadow, shadow, format);

        // Draw the outline
        if (outline > 0)
        {
          for (int i = 1; i <= outline; ++i)
          {
            graphics.DrawString(text, parameters.Font, brushOutline, -1 * i, -1 * i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, 0, -1 * i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, 1 * i, -1 * i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, -1 * i, 0, format);
            graphics.DrawString(text, parameters.Font, brushOutline, 1 * i, 0, format);
            graphics.DrawString(text, parameters.Font, brushOutline, -1 * i, 1 * i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, 0, 1 * i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, 1 * i, 1 * i, format);
          }
        }

        // Draw the text
        graphics.DrawString(text, parameters.Font, brush, 0, 0, format);
      }

      graphics.Flush();
    }

    return CropCharacter(bitmap);
  }

  private static Bitmap CropCharacter(Bitmap bitmap)
  {
    int cropLeft = 0;
    int cropRight = bitmap.Width - 1;

    // Remove unused space from the left.
    while ((cropLeft < cropRight) && (BitmapIsEmpty(bitmap, cropLeft)))
      cropLeft++;

    // If the entire glyph is blank, output the full blank glyph.
    if (cropLeft == cropRight)
    {
      return bitmap;
    }

    // Remove unused space from the right.
    while ((cropRight > cropLeft) && (BitmapIsEmpty(bitmap, cropRight)))
      cropRight--;

    // Don't crop if that would reduce the glyph down to nothing at all!
    if (cropLeft > cropRight) // Note: cropRight is inclusive, so for letter's like I, l, |, etc, cropLeft == cropRight.
      return bitmap;

    // Add some padding back in.
    cropLeft = Math.Max(cropLeft - 1, 0);
    cropRight = Math.Min(cropRight + 1, bitmap.Width - 1);

    int width = cropRight - cropLeft + 1;

    // Crop the glyph.
    Bitmap croppedBitmap = new(width, bitmap.Height, bitmap.PixelFormat);

    using (Graphics graphics = Graphics.FromImage(croppedBitmap))
    {
      graphics.CompositingMode = CompositingMode.SourceCopy;
      graphics.DrawImage(bitmap, 0, 0, new(cropLeft, 0, width, bitmap.Height), GraphicsUnit.Pixel);
      graphics.Flush();
    }

    bitmap.Dispose();

    return croppedBitmap;
  }

  private static bool BitmapIsEmpty(Bitmap bitmap, int x)
  {
    for (int y = 0; y < bitmap.Height; y++)
    {
      if (bitmap.GetPixel(x, y).A != 0)
        return false;
    }

    return true;
  }
}