using BitmapFontTextures.Fonts;
using BitmapFontTextures.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BitmapFontTextures;

public partial class MainForm : Form
{
  private readonly CustomFontService customFontService = new();
  private readonly BitmapFontTextureService bitmapFontTextureService = new();
  private Font? selectedFont;
  private string? fontError;

  public MainForm()
  {
    InitializeComponent();

    // Load installed font families
    foreach (FontFamily fontFamily in FontFamily.Families)
      comboBoxFontName.Items.Add(fontFamily.Name);

    // Load settings
    LoadSettings();

    SelectionChanged();
  }

  private void LoadSettings()
  {
    comboBoxFontName.Text = Settings.Default.FontName;
    pictureBoxTextColor.BackColor = Settings.Default.TextColor;
    pictureBoxOutlineColor.BackColor = Settings.Default.OutlineColor;
    pictureBoxShadowColor.BackColor = Settings.Default.ShadowColor;
    textBoxSampleText.Text = Settings.Default.SampleText;
    numericUpDownZoom.Value = Math.Clamp(Settings.Default.PreviewZoom, (int)numericUpDownZoom.Minimum, (int)numericUpDownZoom.Maximum);
    numericUpDownSpacing.Value = Math.Clamp((decimal)Settings.Default.PreviewSpacing, numericUpDownSpacing.Minimum, numericUpDownSpacing.Maximum);
    numericUpDownLineSpacing.Value = Math.Clamp(Settings.Default.PreviewLineSpacing, (int)numericUpDownLineSpacing.Minimum, (int)numericUpDownLineSpacing.Maximum);

    // Text files
    if (Settings.Default.TextFiles is not null)
    {
      foreach (string? fileName in Settings.Default.TextFiles)
      {
        if (fileName is not null)
          TextFilesListBox.Items.Add(fileName);
      }
    }

    // Font files
    if (Settings.Default.FontFiles is not null)
    {
      customFontService.Load([.. Settings.Default.FontFiles!]);

      foreach (CustomFont customFont in customFontService.Fonts)
        comboBoxFontName.Items.Add(customFont.FontName);
    }
  }

  private void SaveSettings()
  {
    // Preview
    Settings.Default.SampleText = textBoxSampleText.Text;
    Settings.Default.PreviewZoom = (int)numericUpDownZoom.Value;
    Settings.Default.PreviewSpacing = (float)numericUpDownSpacing.Value;
    Settings.Default.PreviewLineSpacing = (int)numericUpDownLineSpacing.Value;

    // Text files
    Settings.Default.TextFiles = [];

    foreach (string fileName in TextFilesListBox.Items)
      Settings.Default.TextFiles.Add(fileName);

    // Font files
    Settings.Default.FontFiles = [];

    foreach (CustomFont customFont in customFontService.Fonts)
      Settings.Default.FontFiles.Add(customFont.FilePath);

    // Save
    Settings.Default.Save();
  }

  private void SelectionChanged()
  {
    UpdateSelectedFont();
    UpdatePreview();
  }

  private void UpdateSelectedFont()
  {
    try
    {
      // Parse the font size selection
      if (!float.TryParse(comboBoxFontSize.Text, out float size) || (size <= 0))
      {
        fontError = $"Invalid font size '{comboBoxFontSize.Text}'";
        return;
      }

      // Parse the font style selection
      if (!Enum.TryParse(comboBoxFontStyle.Text, out FontStyle style))
      {
        fontError = $"Invalid font style '{comboBoxFontStyle.Text}'";
        return;
      }

      string fontFamilyName = comboBoxFontName.Text;
      Font font = customFontService.TryGetFontFamily(fontFamilyName, out FontFamily? fontFamily)
        ? new(fontFamily, size, style, GraphicsUnit.Pixel)
        : new(fontFamilyName, size, style, GraphicsUnit.Pixel);

      selectedFont?.Dispose();

      selectedFont = font;

      fontError = null;
    }
    catch (Exception ex)
    {
      fontError = ex.Message;
    }
  }

  private BitmapFontTextureParameters CreateParameters(string text)
    => new(
      text,
      selectedFont!,
      pictureBoxTextColor.BackColor,
      int.Parse(AlphaAmount.Text),
      Antialias.Checked,
      int.Parse(ShadowOffset.Text),
      pictureBoxShadowColor.BackColor,
      int.Parse(OutlineSize.Text),
      pictureBoxOutlineColor.BackColor);

  private void UpdatePreview()
  {
    // Events are already raised while the form is being initialized.
    if (pixelPreview is null)
      return;

    try
    {
      pixelPreview.Image = fontError is null && selectedFont is not null
        ? bitmapFontTextureService.RenderText(
          textBoxSampleText.Text,
          CreateParameters(textBoxSampleText.Text),
          (float)numericUpDownSpacing.Value,
          (int)numericUpDownLineSpacing.Value)
        : null;
    }
    catch (Exception)
    {
      // Invalid input (e.g. while typing a number), the preview stays empty until it is valid.
      pixelPreview.Image = null;
    }
  }

  private void Preview_Changed(object sender, EventArgs e)
    => UpdatePreview();

  private void Zoom_ValueChanged(object sender, EventArgs e)
    => pixelPreview.Zoom = (int)numericUpDownZoom.Value;

  private void FontName_SelectedIndexChanged(object sender, EventArgs e)
    => SelectionChanged();

  private void FontStyle_SelectedIndexChanged(object sender, EventArgs e)
    => SelectionChanged();

  private void FontSize_TextUpdate(object sender, EventArgs e)
    => SelectionChanged();

  private void FontSize_SelectedIndexChanged(object sender, EventArgs e)
    => SelectionChanged();

  private void ButtonChooseTextFiles_Click(object sender, EventArgs e)
  {
    // Choose the files to read text from
    using OpenFileDialog openFileDialog = new()
    {
      InitialDirectory = Settings.Default.TextFilesDir,
      Title = "Choose Text Files",
      DefaultExt = "*",
      Filter = "All files (*.*)|*.*",
      Multiselect = true
    };

    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
      TextFilesListBox.Items.Clear();
      foreach (string fileName in openFileDialog.FileNames)
        TextFilesListBox.Items.Add(fileName);

      Settings.Default.TextFilesDir = Path.GetDirectoryName(openFileDialog.FileNames[0]);
    }
  }

  private void ButtonExport_Click(object sender, EventArgs e)
  {
    try
    {
      // If the current font is invalid, report that to the user.
      if (fontError is not null)
        throw new ArgumentException(fontError);

      // Choose the output file.
      using SaveFileDialog saveFileDialog = new()
      {
        InitialDirectory = Settings.Default.ExportDir,
        Title = "Export Font",
        DefaultExt = "png",
        Filter = "Image files (*.png)|*.png|All files (*.*)|*.*"
      };

      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;

      // Get the path to the game text
      Settings.Default.ExportDir = Path.GetDirectoryName(saveFileDialog.FileName)!;

      // Combine every string in every language.
      string text = string.Empty;
      if (!checkBoxExportDefault.Checked && TextFilesListBox.Items.Count > 0)
      {
        foreach (string file in TextFilesListBox.Items)
        {
          string absolutePath = Path.GetFullPath(file);
          string readText = File.ReadAllText(file);
          text += readText;
        }
      }

      bitmapFontTextureService.Save(saveFileDialog.FileName, CreateParameters(text));
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, $"{Text} - Error");
    }
  }

  private void ButtonChooseFontFiles_Click(object sender, EventArgs e)
  {
    using OpenFileDialog openFileDialog = new()
    {
      InitialDirectory = Settings.Default.FontFilesDir,
      Title = "Choose Font Files",
      Filter = "Font Files (*.ttf;*.otf;*.ttc)|*.ttf;*.otf;*.ttc|TrueType Fonts (*.ttf)|*.ttf|OpenType Fonts (*.otf)|*.otf|Font Collections (*.ttc)|*.ttc|All Files (*.*)|*.*",
      Multiselect = true
    };

    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
      foreach (string fileName in openFileDialog.FileNames)
      {
        if (customFontService.TryLoad(fileName, out CustomFont? customFont))
          comboBoxFontName.Items.Add(customFont.FontName);
      }
    }
  }

  private void PictureBoxTextColor_Click(object sender, EventArgs e)
  {
    colorDialog.Color = pictureBoxTextColor.BackColor;
    colorDialog.ShowDialog();
    pictureBoxTextColor.BackColor = colorDialog.Color;
    UpdatePreview();
  }

  private void PictureBoxOutlineColor_Click(object sender, EventArgs e)
  {
    colorDialog.Color = pictureBoxOutlineColor.BackColor;
    colorDialog.ShowDialog();
    pictureBoxOutlineColor.BackColor = colorDialog.Color;
    UpdatePreview();
  }

  private void PictureBoxShadowColor_Click(object sender, EventArgs e)
  {
    colorDialog.Color = pictureBoxShadowColor.BackColor;
    colorDialog.ShowDialog();
    pictureBoxShadowColor.BackColor = colorDialog.Color;
    UpdatePreview();
  }

  private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    => SaveSettings();

  private void CheckBoxExportDefault_CheckedChanged(object sender, EventArgs e)
  {
    TextFilesListBox.Enabled = ChooseTextFilesButton.Enabled = !checkBoxExportDefault.Checked;
  }
}