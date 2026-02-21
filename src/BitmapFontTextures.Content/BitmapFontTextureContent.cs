using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.Collections.Generic;

namespace BitmapFontTextures.Content;

/// <summary>
/// Provides properties for maintaining a bitmap font texture.
/// </summary>
public sealed class BitmapFontTextureContent(TextureContent baseContent, List<char> characters) : Texture2DContent
{
  public TextureContent BaseContent => baseContent;
  public List<char> Characters => characters;
}