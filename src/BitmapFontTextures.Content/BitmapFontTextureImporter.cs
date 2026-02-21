using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.IO;

namespace BitmapFontTextures.Content;

/// <summary>
/// Provides methods for reading bitmap font textures for use in the Content Pipeline.
/// </summary>
[ContentImporter(".png", DefaultProcessor = nameof(BitmapFontTextureProcessor), DisplayName = "Bítmap Font Texture - Importer")]
public sealed class BitmapFontTextureImporter : TextureImporter
{
  public override TextureContent Import(string filename, ContentImporterContext context)
  {
    // Use the base MonoGame Texture Importer
    TextureContent baseTextureContent = base.Import(filename, context);

    // Get the text file that should have been generated with the same name as the bitmap
    string textFileName = Path.ChangeExtension(filename, ".txt");
    // Read all the characters
    string allCharacters = File.ReadAllText(textFileName);

    return new BitmapFontTextureContent(baseTextureContent, [.. allCharacters]);
  }
}