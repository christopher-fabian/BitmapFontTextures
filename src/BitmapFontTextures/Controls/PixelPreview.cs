using BitmapFontTextures.Fonts;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BitmapFontTextures.Controls;

/// <summary>
/// Shows a bitmap scaled up without smoothing, on top of a grid that marks every single pixel.
/// </summary>
internal sealed class PixelPreview : ScrollableControl
{
  // The grid is only drawn from this zoom on, below the lines would cover the pixels.
  private const int MinimumGridZoom = 3;

  private Bitmap? image;
  private int zoom = 4;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Bitmap? Image
  {
    get => image;
    set
    {
      // The preview owns the image.
      image?.Dispose();
      image = value;
      UpdateScrollSize();
    }
  }

  [DefaultValue(4)]
  public int Zoom
  {
    get => zoom;
    set
    {
      zoom = Math.Max(value, 1);
      UpdateScrollSize();
    }
  }

  [Category("Appearance")]
  public Color GridColor { get; set; } = Color.FromArgb(48, 0, 0, 0);

  [Category("Appearance")]
  public Color PixelBorderColor { get; set; } = Color.FromArgb(48, 0, 0, 0);

  public PixelPreview()
  {
    SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
    AutoScroll = true;
    BackColor = BitmapFontTextureService.BackgroundColor;
  }

  private void UpdateScrollSize()
  {
    AutoScrollMinSize = image is null
      ? Size.Empty
      : new((image.Width * zoom) + 1, (image.Height * zoom) + 1);

    Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);

    Graphics graphics = e.Graphics;
    graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

    int width = Math.Max(ClientSize.Width - AutoScrollPosition.X, AutoScrollMinSize.Width);
    int height = Math.Max(ClientSize.Height - AutoScrollPosition.Y, AutoScrollMinSize.Height);
    bool drawGrid = zoom >= MinimumGridZoom;

    // Draw the background grid over the whole visible area.
    if (drawGrid)
      DrawGrid(graphics, GridColor, width, height);

    if (image is null)
      return;

    graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
    graphics.PixelOffsetMode = PixelOffsetMode.Half;
    graphics.DrawImage(image, new(0, 0, image.Width * zoom, image.Height * zoom), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
    graphics.PixelOffsetMode = PixelOffsetMode.Default;

    // Separate the pixels of the image, so every single pixel stays visible.
    if (drawGrid)
      DrawGrid(graphics, PixelBorderColor, image.Width * zoom, image.Height * zoom);
  }

  private void DrawGrid(Graphics graphics, Color color, int width, int height)
  {
    using Pen pen = new(color);

    for (int x = 0; x <= width; x += zoom)
      graphics.DrawLine(pen, x, 0, x, height);

    for (int y = 0; y <= height; y += zoom)
      graphics.DrawLine(pen, 0, y, width, y);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      image?.Dispose();

    base.Dispose(disposing);
  }
}