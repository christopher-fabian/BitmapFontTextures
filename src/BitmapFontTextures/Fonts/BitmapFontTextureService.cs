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
  public static readonly Color BackgroundColor = Color.Magenta;

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

      using (Bitmap bitmap = new(width, height + lineHeight, OutputPixelFormat))
      {
        // Arrage all the glyphs onto a single larger bitmap.
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
          graphics.Clear(BackgroundColor);
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

  /// <summary>
  /// Renders the text with the same glyphs that are exported, laid out like SpriteFont.DrawString would draw them.
  /// </summary>
  /// <param name="spacing">The SpriteFont.Spacing, added between two characters of a line.</param>
  /// <param name="lineSpacing">The SpriteFont.LineSpacing, 0 uses the value of the content processor (the height of the highest glyph).</param>
  public Bitmap? RenderText(string text, BitmapFontTextureParameters parameters, float spacing, int lineSpacing)
  {
    Dictionary<char, Bitmap> glyphs = [];

    try
    {
      Bitmap GetGlyph(char character)
      {
        if (!glyphs.TryGetValue(character, out Bitmap? glyph))
          glyphs[character] = glyph = RasterizeCharacter(character, parameters);

        return glyph;
      }

      string[] lines = text.ReplaceLineEndings("\n").Split('\n');

      // Position every glyph like SpriteFont.DrawString does.
      // Bitmap font textures have no bearings, so a glyph advances by its width plus the spacing.
      List<(Bitmap Glyph, int X, int Line)> placements = [];
      int glyphHeight = GetGlyph(' ').Height;

      for (int line = 0; line < lines.Length; line++)
      {
        float x = 0;
        bool firstGlyphOfLine = true;

        foreach (char character in lines[line])
        {
          // Skip characters that would not be exported.
          if (character < FirstCharacterUnicode || character > LastCharacterUnicode)
            continue;

          if (!firstGlyphOfLine)
            x += spacing;

          firstGlyphOfLine = false;

          Bitmap glyph = GetGlyph(character);
          placements.Add((glyph, (int)MathF.Round(x), line));
          glyphHeight = Math.Max(glyphHeight, glyph.Height);
          x += glyph.Width;
        }
      }

      if (placements.Count == 0)
        return null;

      if (lineSpacing <= 0)
        lineSpacing = glyphHeight;

      // A negative spacing can move glyphs to the left of the origin.
      int left = 0;
      int right = 0;
      int bottom = 0;

      foreach ((Bitmap glyph, int x, int line) in placements)
      {
        left = Math.Min(left, x);
        right = Math.Max(right, x + glyph.Width);
        bottom = Math.Max(bottom, (line * lineSpacing) + glyph.Height);
      }

      Bitmap bitmap = new(right - left, Math.Max(bottom, lines.Length * lineSpacing), OutputPixelFormat);

      using (Graphics graphics = Graphics.FromImage(bitmap))
      {
        graphics.Clear(Color.Transparent);

        // Overlapping glyphs are blended, like SpriteBatch does.
        foreach ((Bitmap glyph, int x, int line) in placements)
          graphics.DrawImageUnscaled(glyph, x - left, line * lineSpacing);

        graphics.Flush();
      }

      return bitmap;
    }
    finally
    {
      // Clean up temporary objects.
      foreach (Bitmap glyph in glyphs.Values)
        glyph.Dispose();
    }
  }

  private Bitmap RasterizeCharacter(char character, BitmapFontTextureParameters parameters)
  {
    string text = character.ToString();

    SizeF size = graphics.MeasureString(text, parameters.Font);
    int outline = parameters.Outline;
    // Grows the glyph by the outline on every side, so the margins stay the same as without outline.
    int width = (int)Math.Ceiling(size.Width) + (2 * outline);
    int height = (int)Math.Ceiling(size.Height) + (2 * outline);

    Bitmap bitmap = new(width, height, OutputPixelFormat);

    using (Graphics graphics = Graphics.FromImage(bitmap))
    {
      graphics.TextRenderingHint = parameters.Antialias
        ? TextRenderingHint.ClearTypeGridFit
        : TextRenderingHint.SingleBitPerPixelGridFit;
      graphics.Clear(Color.Transparent);

      // Validate alpha value and clamp it to the range [0, 255].
      int alpha = Math.Clamp(parameters.Alpha, 0, 255);

      Color customColor = Color.FromArgb(alpha, parameters.ShadowColor);
      using (SolidBrush brush = new(parameters.TextColor))
      using (SolidBrush brushOutline = new(parameters.OutlineColor))
      using (SolidBrush brushShadow = new(customColor))
      using (StringFormat format = new())
      {
        format.Alignment = StringAlignment.Near;
        format.LineAlignment = StringAlignment.Near;

        int shadow = parameters.Shadow;

        // Draw the shadow
        if (shadow > 0)
          graphics.DrawString(text, parameters.Font, brushShadow, outline + shadow, outline + shadow, format);

        // Draw the outline
        if (outline > 0)
        {
          for (int i = 1; i <= outline; ++i)
          {
            graphics.DrawString(text, parameters.Font, brushOutline, outline - i, outline - i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline, outline - i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline + i, outline - i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline - i, outline, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline + i, outline, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline - i, outline + i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline, outline + i, format);
            graphics.DrawString(text, parameters.Font, brushOutline, outline + i, outline + i, format);
          }
        }

        // Draw the text
        graphics.DrawString(text, parameters.Font, brush, outline, outline, format);
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
    while (cropLeft < cropRight && BitmapIsEmpty(bitmap, cropLeft))
      cropLeft++;

    // If the entire glyph is blank, output the full blank glyph.
    if (cropLeft == cropRight)
      return bitmap;

    // Remove unused space from the right.
    while (cropRight > cropLeft && BitmapIsEmpty(bitmap, cropRight))
      cropRight--;

    // Don't crop if that would reduce the glyph down to nothing at all.
    // cropRight is inclusive, so for letter's like I, l, |, etc, cropLeft == cropRight.
    if (cropLeft > cropRight)
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