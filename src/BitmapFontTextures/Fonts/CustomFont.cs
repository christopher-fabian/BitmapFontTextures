using System.Drawing;

namespace BitmapFontTextures.Fonts;

internal sealed record CustomFont(
  string FilePath,
  string FontName,
  FontFamily FontFamily);