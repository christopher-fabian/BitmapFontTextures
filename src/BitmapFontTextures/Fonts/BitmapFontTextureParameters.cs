using System.Drawing;

namespace BitmapFontTextures.Fonts;

internal sealed record BitmapFontTextureParameters(
  string Text,
  Font Font,
  int Alpha,
  bool Antialias,
  int Shadow,
  Color ShadowColor,
  int Outline,
  Color OutlineColor);