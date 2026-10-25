namespace BitmapFontTextures;

partial class MainForm
{
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
    Properties.Settings settings1 = new Properties.Settings();
    Properties.Settings settings2 = new Properties.Settings();
    Antialias = new System.Windows.Forms.CheckBox();
    label2 = new System.Windows.Forms.Label();
    label3 = new System.Windows.Forms.Label();
    labelSampleText = new System.Windows.Forms.Label();
    Export = new System.Windows.Forms.Button();
    label5 = new System.Windows.Forms.Label();
    label6 = new System.Windows.Forms.Label();
    label7 = new System.Windows.Forms.Label();
    colorDialog = new System.Windows.Forms.ColorDialog();
    pictureBoxTextColor = new System.Windows.Forms.PictureBox();
    groupBox1 = new System.Windows.Forms.GroupBox();
    pictureBoxOutlineColor = new System.Windows.Forms.PictureBox();
    OutlineSize = new System.Windows.Forms.TextBox();
    groupBox2 = new System.Windows.Forms.GroupBox();
    AlphaAmount = new System.Windows.Forms.TextBox();
    label8 = new System.Windows.Forms.Label();
    pictureBoxShadowColor = new System.Windows.Forms.PictureBox();
    ShadowOffset = new System.Windows.Forms.TextBox();
    TextFilesListBox = new System.Windows.Forms.ListBox();
    ChooseTextFilesButton = new System.Windows.Forms.Button();
    comboBoxFontSize = new System.Windows.Forms.ComboBox();
    comboBoxFontStyle = new System.Windows.Forms.ComboBox();
    comboBoxFontName = new System.Windows.Forms.ComboBox();
    checkBoxExportDefault = new System.Windows.Forms.CheckBox();
    buttonChooseFontFiles = new System.Windows.Forms.Button();
    label1 = new System.Windows.Forms.Label();
    ((System.ComponentModel.ISupportInitialize)pictureBoxTextColor).BeginInit();
    groupBox1.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)pictureBoxOutlineColor).BeginInit();
    groupBox2.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)pictureBoxShadowColor).BeginInit();
    SuspendLayout();
    // 
    // Antialias
    // 
    Antialias.AutoSize = true;
    settings1.AlphaAmount = "128";
    settings1.Antialias = false;
    settings1.ExportDir = "";
    settings1.FontFiles = null;
    settings1.FontFilesDir = "";
    settings1.FontName = "";
    settings1.FontSize = "8";
    settings1.FontStyle = "Regular";
    settings1.OutlineColor = System.Drawing.Color.Black;
    settings1.OutlineSize = "0";
    settings1.SettingsKey = "";
    settings1.ShadowColor = System.Drawing.Color.Gray;
    settings1.ShadowOffset = "0";
    settings1.TextColor = System.Drawing.Color.White;
    settings1.TextFiles = null;
    settings1.TextFilesDir = "";
    Antialias.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "Antialias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    Antialias.Location = new System.Drawing.Point(384, 342);
    Antialias.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    Antialias.Name = "Antialias";
    Antialias.Size = new System.Drawing.Size(105, 24);
    Antialias.TabIndex = 10;
    Antialias.Text = "&Antialiased";
    Antialias.UseVisualStyleBackColor = true;
    // 
    // label2
    // 
    label2.AutoSize = true;
    label2.Location = new System.Drawing.Point(285, 20);
    label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label2.Name = "label2";
    label2.Size = new System.Drawing.Size(72, 20);
    label2.TabIndex = 2;
    label2.Text = "Font s&tyle";
    // 
    // label3
    // 
    label3.AutoSize = true;
    label3.Location = new System.Drawing.Point(415, 20);
    label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label3.Name = "label3";
    label3.Size = new System.Drawing.Size(66, 20);
    label3.TabIndex = 4;
    label3.Text = "&Size (px)";
    // 
    // labelSampleText
    // 
    labelSampleText.AutoEllipsis = true;
    labelSampleText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
    labelSampleText.Location = new System.Drawing.Point(20, 571);
    labelSampleText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    labelSampleText.Name = "labelSampleText";
    labelSampleText.Size = new System.Drawing.Size(600, 200);
    labelSampleText.TabIndex = 12;
    labelSampleText.Text = "The quick brown fox jumped over the LAZY camel";
    labelSampleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    // 
    // Export
    // 
    Export.Location = new System.Drawing.Point(526, 335);
    Export.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    Export.Name = "Export";
    Export.Size = new System.Drawing.Size(101, 36);
    Export.TabIndex = 11;
    Export.Text = "&Export";
    Export.UseVisualStyleBackColor = true;
    Export.Click += ButtonExport_Click;
    // 
    // label5
    // 
    label5.AutoSize = true;
    label5.Location = new System.Drawing.Point(15, 20);
    label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label5.Name = "label5";
    label5.Size = new System.Drawing.Size(38, 20);
    label5.TabIndex = 0;
    label5.Text = "&Font";
    // 
    // label6
    // 
    label6.AutoSize = true;
    label6.Location = new System.Drawing.Point(10, 65);
    label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label6.Name = "label6";
    label6.Size = new System.Drawing.Size(36, 20);
    label6.TabIndex = 14;
    label6.Text = "Size";
    // 
    // label7
    // 
    label7.AutoSize = true;
    label7.Location = new System.Drawing.Point(9, 68);
    label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label7.Name = "label7";
    label7.Size = new System.Drawing.Size(49, 20);
    label7.TabIndex = 15;
    label7.Text = "Offset";
    // 
    // pictureBoxTextColor
    // 
    pictureBoxTextColor.BackColor = System.Drawing.Color.White;
    pictureBoxTextColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
    pictureBoxTextColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "TextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    pictureBoxTextColor.Location = new System.Drawing.Point(371, 267);
    pictureBoxTextColor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    pictureBoxTextColor.Name = "pictureBoxTextColor";
    pictureBoxTextColor.Size = new System.Drawing.Size(107, 31);
    pictureBoxTextColor.TabIndex = 41;
    pictureBoxTextColor.TabStop = false;
    pictureBoxTextColor.Click += PictureBoxTextColor_Click;
    // 
    // groupBox1
    // 
    groupBox1.Controls.Add(label6);
    groupBox1.Controls.Add(pictureBoxOutlineColor);
    groupBox1.Controls.Add(OutlineSize);
    groupBox1.Location = new System.Drawing.Point(488, 20);
    groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    groupBox1.Name = "groupBox1";
    groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
    groupBox1.Size = new System.Drawing.Size(136, 100);
    groupBox1.TabIndex = 19;
    groupBox1.TabStop = false;
    groupBox1.Text = "Outline";
    // 
    // pictureBoxOutlineColor
    // 
    pictureBoxOutlineColor.BackColor = System.Drawing.Color.Black;
    pictureBoxOutlineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
    pictureBoxOutlineColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "OutlineColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    pictureBoxOutlineColor.Location = new System.Drawing.Point(10, 25);
    pictureBoxOutlineColor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    pictureBoxOutlineColor.Name = "pictureBoxOutlineColor";
    pictureBoxOutlineColor.Size = new System.Drawing.Size(117, 31);
    pictureBoxOutlineColor.TabIndex = 18;
    pictureBoxOutlineColor.TabStop = false;
    pictureBoxOutlineColor.Click += PictureBoxOutlineColor_Click;
    // 
    // OutlineSize
    // 
    settings2.AlphaAmount = "128";
    settings2.Antialias = false;
    settings2.ExportDir = "";
    settings2.FontFiles = null;
    settings2.FontFilesDir = "";
    settings2.FontName = "";
    settings2.FontSize = "8";
    settings2.FontStyle = "Regular";
    settings2.OutlineColor = System.Drawing.Color.Black;
    settings2.OutlineSize = "0";
    settings2.SettingsKey = "";
    settings2.ShadowColor = System.Drawing.Color.Gray;
    settings2.ShadowOffset = "0";
    settings2.TextColor = System.Drawing.Color.White;
    settings2.TextFiles = null;
    settings2.TextFilesDir = "";
    OutlineSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings2, "OutlineSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    OutlineSize.Location = new System.Drawing.Point(57, 58);
    OutlineSize.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    OutlineSize.Name = "OutlineSize";
    OutlineSize.Size = new System.Drawing.Size(70, 27);
    OutlineSize.TabIndex = 13;
    OutlineSize.Text = "0";
    // 
    // groupBox2
    // 
    groupBox2.Controls.Add(AlphaAmount);
    groupBox2.Controls.Add(label8);
    groupBox2.Controls.Add(pictureBoxShadowColor);
    groupBox2.Controls.Add(label7);
    groupBox2.Controls.Add(ShadowOffset);
    groupBox2.Location = new System.Drawing.Point(490, 125);
    groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    groupBox2.Name = "groupBox2";
    groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
    groupBox2.Size = new System.Drawing.Size(135, 175);
    groupBox2.TabIndex = 20;
    groupBox2.TabStop = false;
    groupBox2.Text = "Shadow";
    // 
    // AlphaAmount
    // 
    AlphaAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "AlphaAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    AlphaAmount.Location = new System.Drawing.Point(65, 100);
    AlphaAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    AlphaAmount.Name = "AlphaAmount";
    AlphaAmount.Size = new System.Drawing.Size(60, 27);
    AlphaAmount.TabIndex = 21;
    AlphaAmount.Text = "128";
    // 
    // label8
    // 
    label8.AutoSize = true;
    label8.Location = new System.Drawing.Point(9, 103);
    label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label8.Name = "label8";
    label8.Size = new System.Drawing.Size(48, 20);
    label8.TabIndex = 20;
    label8.Text = "Alpha";
    // 
    // pictureBoxShadowColor
    // 
    pictureBoxShadowColor.BackColor = System.Drawing.Color.Gray;
    pictureBoxShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
    pictureBoxShadowColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "ShadowColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    pictureBoxShadowColor.Location = new System.Drawing.Point(10, 25);
    pictureBoxShadowColor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    pictureBoxShadowColor.Name = "pictureBoxShadowColor";
    pictureBoxShadowColor.Size = new System.Drawing.Size(115, 31);
    pictureBoxShadowColor.TabIndex = 19;
    pictureBoxShadowColor.TabStop = false;
    pictureBoxShadowColor.Click += PictureBoxShadowColor_Click;
    // 
    // ShadowOffset
    // 
    ShadowOffset.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "ShadowOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    ShadowOffset.Location = new System.Drawing.Point(65, 64);
    ShadowOffset.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    ShadowOffset.Name = "ShadowOffset";
    ShadowOffset.Size = new System.Drawing.Size(60, 27);
    ShadowOffset.TabIndex = 16;
    ShadowOffset.Text = "0";
    // 
    // TextFilesListBox
    // 
    TextFilesListBox.AllowDrop = true;
    TextFilesListBox.FormattingEnabled = true;
    TextFilesListBox.Location = new System.Drawing.Point(20, 380);
    TextFilesListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
    TextFilesListBox.Name = "TextFilesListBox";
    TextFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
    TextFilesListBox.Size = new System.Drawing.Size(600, 184);
    TextFilesListBox.TabIndex = 36;
    TextFilesListBox.TabStop = false;
    // 
    // ChooseTextFilesButton
    // 
    ChooseTextFilesButton.Location = new System.Drawing.Point(21, 335);
    ChooseTextFilesButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    ChooseTextFilesButton.Name = "ChooseTextFilesButton";
    ChooseTextFilesButton.Size = new System.Drawing.Size(146, 36);
    ChooseTextFilesButton.TabIndex = 37;
    ChooseTextFilesButton.Text = "Choose Text Files";
    ChooseTextFilesButton.UseVisualStyleBackColor = true;
    ChooseTextFilesButton.Click += ButtonChooseTextFiles_Click;
    // 
    // comboBoxFontSize
    // 
    comboBoxFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "FontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    comboBoxFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
    comboBoxFontSize.FormattingEnabled = true;
    comboBoxFontSize.Items.AddRange(new object[] { "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "18", "20", "24", "32", "40", "48", "64", "96" });
    comboBoxFontSize.Location = new System.Drawing.Point(415, 45);
    comboBoxFontSize.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    comboBoxFontSize.Name = "comboBoxFontSize";
    comboBoxFontSize.Size = new System.Drawing.Size(63, 228);
    comboBoxFontSize.TabIndex = 5;
    comboBoxFontSize.Text = "8";
    comboBoxFontSize.SelectedIndexChanged += FontSize_SelectedIndexChanged;
    comboBoxFontSize.TextUpdate += FontSize_TextUpdate;
    // 
    // comboBoxFontStyle
    // 
    comboBoxFontStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
    comboBoxFontStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
    comboBoxFontStyle.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    comboBoxFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
    comboBoxFontStyle.FormattingEnabled = true;
    comboBoxFontStyle.Items.AddRange(new object[] { "Regular", "Italic", "Bold", "Bold, Italic" });
    comboBoxFontStyle.Location = new System.Drawing.Point(290, 45);
    comboBoxFontStyle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    comboBoxFontStyle.Name = "comboBoxFontStyle";
    comboBoxFontStyle.Size = new System.Drawing.Size(106, 228);
    comboBoxFontStyle.TabIndex = 3;
    comboBoxFontStyle.Text = "Regular";
    comboBoxFontStyle.SelectedIndexChanged += FontStyle_SelectedIndexChanged;
    // 
    // comboBoxFontName
    // 
    comboBoxFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
    comboBoxFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
    comboBoxFontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "FontName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    comboBoxFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
    comboBoxFontName.FormattingEnabled = true;
    comboBoxFontName.Location = new System.Drawing.Point(20, 45);
    comboBoxFontName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    comboBoxFontName.Name = "comboBoxFontName";
    comboBoxFontName.Size = new System.Drawing.Size(251, 219);
    comboBoxFontName.TabIndex = 1;
    comboBoxFontName.SelectedIndexChanged += FontName_SelectedIndexChanged;
    // 
    // checkBoxExportDefault
    // 
    checkBoxExportDefault.AutoSize = true;
    checkBoxExportDefault.Location = new System.Drawing.Point(175, 342);
    checkBoxExportDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
    checkBoxExportDefault.Name = "checkBoxExportDefault";
    checkBoxExportDefault.Size = new System.Drawing.Size(199, 24);
    checkBoxExportDefault.TabIndex = 38;
    checkBoxExportDefault.Text = "Export Default ( 32 .. 126)";
    checkBoxExportDefault.UseVisualStyleBackColor = true;
    checkBoxExportDefault.CheckedChanged += CheckBoxExportDefault_CheckedChanged;
    // 
    // buttonChooseFontFiles
    // 
    buttonChooseFontFiles.Location = new System.Drawing.Point(21, 267);
    buttonChooseFontFiles.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    buttonChooseFontFiles.Name = "buttonChooseFontFiles";
    buttonChooseFontFiles.Size = new System.Drawing.Size(251, 36);
    buttonChooseFontFiles.TabIndex = 39;
    buttonChooseFontFiles.Text = "Choose Font Files";
    buttonChooseFontFiles.UseVisualStyleBackColor = true;
    buttonChooseFontFiles.Click += ButtonChooseFontFiles_Click;
    // 
    // label1
    // 
    label1.AutoSize = true;
    label1.Location = new System.Drawing.Point(285, 275);
    label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
    label1.Name = "label1";
    label1.Size = new System.Drawing.Size(45, 20);
    label1.TabIndex = 41;
    label1.Text = "Color";
    // 
    // MainForm
    // 
    AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    ClientSize = new System.Drawing.Size(642, 788);
    Controls.Add(pictureBoxTextColor);
    Controls.Add(label1);
    Controls.Add(buttonChooseFontFiles);
    Controls.Add(checkBoxExportDefault);
    Controls.Add(ChooseTextFilesButton);
    Controls.Add(TextFilesListBox);
    Controls.Add(groupBox2);
    Controls.Add(groupBox1);
    Controls.Add(Export);
    Controls.Add(labelSampleText);
    Controls.Add(label3);
    Controls.Add(label2);
    Controls.Add(label5);
    Controls.Add(Antialias);
    Controls.Add(comboBoxFontSize);
    Controls.Add(comboBoxFontStyle);
    Controls.Add(comboBoxFontName);
    Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
    Name = "MainForm";
    Text = "Bitmap Font Textures";
    FormClosing += MainForm_FormClosing;
    Load += MainForm_Load;
    ((System.ComponentModel.ISupportInitialize)pictureBoxTextColor).EndInit();
    groupBox1.ResumeLayout(false);
    groupBox1.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)pictureBoxOutlineColor).EndInit();
    groupBox2.ResumeLayout(false);
    groupBox2.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)pictureBoxShadowColor).EndInit();
    ResumeLayout(false);
    PerformLayout();

  }

  #endregion

  private System.Windows.Forms.ComboBox comboBoxFontName;
  private System.Windows.Forms.ComboBox comboBoxFontStyle;
  private System.Windows.Forms.ComboBox comboBoxFontSize;
  private System.Windows.Forms.CheckBox Antialias;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Label labelSampleText;
  private System.Windows.Forms.Button Export;
  private System.Windows.Forms.Label label5;
  private System.Windows.Forms.TextBox OutlineSize;
  private System.Windows.Forms.Label label6;
  private System.Windows.Forms.Label label7;
  private System.Windows.Forms.TextBox ShadowOffset;
  private System.Windows.Forms.ColorDialog colorDialog;
  private System.Windows.Forms.PictureBox pictureBoxOutlineColor;
  private System.Windows.Forms.GroupBox groupBox1;
  private System.Windows.Forms.GroupBox groupBox2;
  private System.Windows.Forms.PictureBox pictureBoxShadowColor;
  private System.Windows.Forms.TextBox AlphaAmount;
  private System.Windows.Forms.Label label8;
  private System.Windows.Forms.ListBox TextFilesListBox;
  private System.Windows.Forms.Button ChooseTextFilesButton;
  private System.Windows.Forms.CheckBox checkBoxExportDefault;
  private System.Windows.Forms.Button buttonChooseFontFiles;
  private System.Windows.Forms.PictureBox pictureBoxTextColor;
  private System.Windows.Forms.Label label1;
}
