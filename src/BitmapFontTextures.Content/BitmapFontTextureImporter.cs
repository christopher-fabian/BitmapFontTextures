using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.IO;

namespace BitmapFontTextures.Content;

/// <summary>
/// Provides methods for reading bitmap font textures for use in the Content Pipeline.
/// </summary>
[ContentImporter(".png", DefaultProcessor = nameof(BitmapFontTextureProcessor), DisplayName = "Bitmap Font Texture - Importer")]
public sealed class BitmapFontTextureImporter : TextureImporter
{
  public override TextureContent Import(string filename, ContentImporterContext context)
  {
    TextureContent baseContent = base.Import(filename, context);

    // Read the characters of the text file with the same name as the bitmap.
    string textFileName = Path.ChangeExtension(filename, ".txt");
    string characters = File.ReadAllText(textFileName);

    return new BitmapFontTextureContent(baseContent, characters);
  }
}