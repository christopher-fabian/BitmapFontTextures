using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace BitmapFontTextures.Content;

/// <summary>
/// Provides properties for maintaining a bitmap font texture.
/// </summary>
public sealed class BitmapFontTextureContent(TextureContent baseContent, string characters)
  : Texture2DContent
{
  /// <summary>
  /// The base Texture2DContent of the bitmap font texture.
  /// </summary>
  public TextureContent BaseContent => baseContent;
  /// <summary>
  /// The characters of the bitmap font texture.
  /// </summary>
  public string Characters => characters;
}