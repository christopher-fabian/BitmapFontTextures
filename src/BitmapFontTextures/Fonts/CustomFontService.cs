using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace BitmapFontTextures.Fonts;

internal sealed class CustomFontService : IDisposable
{
  private readonly List<PrivateFontCollection> customFontCollections = [];
  private readonly Dictionary<string, CustomFont> customFonts = [];
  private bool disposed;

  public IEnumerable<CustomFont> Fonts => customFonts.Values;

  public IEnumerable<CustomFont> Load(IEnumerable<string> filePaths)
  {
    ArgumentNullException.ThrowIfNull(filePaths, nameof(filePaths));

    List<CustomFont> customFonts = [];

    foreach (string filePath in filePaths)
    {
      if (TryLoad(filePath, out CustomFont? customFont))
        customFonts.Add(customFont);
    }

    return customFonts;
  }

  public bool TryLoad(string filePath, [NotNullWhen(true)] out CustomFont? customFont)
  {
    ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

    if (!File.Exists(filePath))
    {
      customFont = null;
      return false;
    }

    PrivateFontCollection customFontCollection = new();
    customFontCollections.Add(customFontCollection);

    customFontCollection.AddFontFile(filePath);

    string fontName = Path.GetFileNameWithoutExtension(filePath);
    FontFamily fontFamily = customFontCollection.Families[0];

    customFont = new(filePath, fontName, fontFamily);
    customFonts[customFont.FontName] = customFont;
    return true;
  }

  public bool TryGetFontFamily(string customFontName, [NotNullWhen(true)] out FontFamily? fontFamily)
  {
    if (customFonts.TryGetValue(customFontName, out CustomFont? customFont))
    {
      fontFamily = customFont.FontFamily;
      return true;
    }

    fontFamily = null;
    return false;
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  private void Dispose(bool disposing)
  {
    if (disposed)
      return;

    if (disposing)
    {
      foreach (PrivateFontCollection customFontCollection in customFontCollections)
        customFontCollection.Dispose();

      disposed = true;
    }
  }
}