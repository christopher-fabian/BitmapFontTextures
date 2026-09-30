using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace BitmapFontTextures.Content;

[ContentProcessor(DisplayName = "Bitmap Font Texture - Processor")]
public sealed class BitmapFontTextureProcessor : FontTextureProcessor
{
  private string characters = string.Empty;

  protected override char GetCharacterForIndex(int index)
    => characters[index];

  public override SpriteFontContent Process(Texture2DContent input, ContentProcessorContext context)
  {
    BitmapFontTextureContent content = (BitmapFontTextureContent)input;
    characters = content.Characters;

    Texture2DContent textureContent = (Texture2DContent)content.BaseContent;
    return base.Process(textureContent, context);
  }
}