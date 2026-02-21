using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using System.Collections.Generic;
using System.ComponentModel;

namespace BitmapFontTextures.Content;

[ContentProcessor(DisplayName = "Bitmap Font Texture - Processor")]
public sealed class BitmapFontTextureProcessor : FontTextureProcessor
{
  private readonly List<char> characters = [];

  [DefaultValue('?')]
  public char DefaultCharacter { get; set; } = '?';

  protected override char GetCharacterForIndex(int index)
    => characters[index];

  public override SpriteFontContent Process(Texture2DContent input, ContentProcessorContext context)
  {
    // Cast the input to custom format
    BitmapFontTextureContent content = (BitmapFontTextureContent)input;
    characters.AddRange(content.Characters);

    // Our localized texture input just contains the base Texture2DContent and the list of characters
    Texture2DContent textureContent = (Texture2DContent)content.BaseContent;
    SpriteFontContent spriteFontContent = base.Process(textureContent, context);
    // Set the default character for this kind of font as well
    spriteFontContent.DefaultCharacter = DefaultCharacter;

    return spriteFontContent;
  }
}