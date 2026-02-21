//-----------------------------------------------------------------------------
// MainForm.Designer.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

namespace BitmapFontTextures
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Properties.Settings settings1 = new Properties.Settings();
      Antialias = new System.Windows.Forms.CheckBox();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      labelSampleText = new System.Windows.Forms.Label();
      Export = new System.Windows.Forms.Button();
      label5 = new System.Windows.Forms.Label();
      label6 = new System.Windows.Forms.Label();
      label7 = new System.Windows.Forms.Label();
      colorDialog = new System.Windows.Forms.ColorDialog();
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
      settings1.FontName = "";
      settings1.FontSize = "8";
      settings1.FontStyle = "Regular";
      settings1.OutlineColor = System.Drawing.Color.Black;
      settings1.OutlineSize = "0";
      settings1.SettingsKey = "";
      settings1.ShadowColor = System.Drawing.Color.Gray;
      settings1.ShadowOffset = "0";
      settings1.TextFiles = null;
      settings1.TextFilesDir = "";
      Antialias.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "Antialias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      Antialias.Location = new System.Drawing.Point(336, 247);
      Antialias.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      Antialias.Name = "Antialias";
      Antialias.Size = new System.Drawing.Size(84, 19);
      Antialias.TabIndex = 10;
      Antialias.Text = "&Antialiased";
      Antialias.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(251, 16);
      label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(61, 15);
      label2.TabIndex = 2;
      label2.Text = "Font s&tyle:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(362, 16);
      label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(30, 15);
      label3.TabIndex = 4;
      label3.Text = "&Size:";
      // 
      // Sample
      // 
      labelSampleText.AutoEllipsis = true;
      labelSampleText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
      labelSampleText.Location = new System.Drawing.Point(14, 433);
      labelSampleText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      labelSampleText.Name = "Sample";
      labelSampleText.Size = new System.Drawing.Size(533, 187);
      labelSampleText.TabIndex = 12;
      labelSampleText.Text = "The quick brown fox jumped over the LAZY camel";
      labelSampleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Export
      // 
      Export.Location = new System.Drawing.Point(460, 242);
      Export.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      Export.Name = "Export";
      Export.Size = new System.Drawing.Size(88, 27);
      Export.TabIndex = 11;
      Export.Text = "&Export";
      Export.UseVisualStyleBackColor = true;
      Export.Click += ButtonExport_Click;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new System.Drawing.Point(14, 16);
      label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(34, 15);
      label5.TabIndex = 0;
      label5.Text = "&Font:";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new System.Drawing.Point(7, 18);
      label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(30, 15);
      label6.TabIndex = 14;
      label6.Text = "Size:";
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Location = new System.Drawing.Point(7, 18);
      label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(42, 15);
      label7.TabIndex = 15;
      label7.Text = "Offset:";
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(label6);
      groupBox1.Controls.Add(pictureBoxOutlineColor);
      groupBox1.Controls.Add(OutlineSize);
      groupBox1.Location = new System.Drawing.Point(428, 35);
      groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      groupBox1.Name = "groupBox1";
      groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      groupBox1.Size = new System.Drawing.Size(119, 78);
      groupBox1.TabIndex = 19;
      groupBox1.TabStop = false;
      groupBox1.Text = "Outline:";
      // 
      // OutlineColorSample
      // 
      pictureBoxOutlineColor.BackColor = System.Drawing.Color.Black;
      pictureBoxOutlineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      pictureBoxOutlineColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "OutlineColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      pictureBoxOutlineColor.Location = new System.Drawing.Point(10, 46);
      pictureBoxOutlineColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      pictureBoxOutlineColor.Name = "OutlineColorSample";
      pictureBoxOutlineColor.Size = new System.Drawing.Size(94, 24);
      pictureBoxOutlineColor.TabIndex = 18;
      pictureBoxOutlineColor.TabStop = false;
      pictureBoxOutlineColor.Click += PictureBoxOutlineColor_Click;
      // 
      // OutlineSize
      // 
      OutlineSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "OutlineSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      OutlineSize.Location = new System.Drawing.Point(49, 15);
      OutlineSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      OutlineSize.Name = "OutlineSize";
      OutlineSize.Size = new System.Drawing.Size(55, 23);
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
      groupBox2.Location = new System.Drawing.Point(429, 135);
      groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      groupBox2.Name = "groupBox2";
      groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
      groupBox2.Size = new System.Drawing.Size(118, 103);
      groupBox2.TabIndex = 20;
      groupBox2.TabStop = false;
      groupBox2.Text = "Shadow:";
      // 
      // AlphaAmount
      // 
      AlphaAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "AlphaAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      AlphaAmount.Location = new System.Drawing.Point(55, 77);
      AlphaAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      AlphaAmount.Name = "AlphaAmount";
      AlphaAmount.Size = new System.Drawing.Size(50, 23);
      AlphaAmount.TabIndex = 21;
      AlphaAmount.Text = "128";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Location = new System.Drawing.Point(9, 81);
      label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      label8.Name = "label8";
      label8.Size = new System.Drawing.Size(41, 15);
      label8.TabIndex = 20;
      label8.Text = "Alpha:";
      // 
      // ShadowColorSample
      // 
      pictureBoxShadowColor.BackColor = System.Drawing.Color.Gray;
      pictureBoxShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      pictureBoxShadowColor.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "ShadowColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      pictureBoxShadowColor.Location = new System.Drawing.Point(10, 45);
      pictureBoxShadowColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      pictureBoxShadowColor.Name = "ShadowColorSample";
      pictureBoxShadowColor.Size = new System.Drawing.Size(94, 24);
      pictureBoxShadowColor.TabIndex = 19;
      pictureBoxShadowColor.TabStop = false;
      pictureBoxShadowColor.Click += PictureBoxShadowColor_Click;
      // 
      // ShadowOffset
      // 
      ShadowOffset.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "ShadowOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      ShadowOffset.Location = new System.Drawing.Point(58, 15);
      ShadowOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      ShadowOffset.Name = "ShadowOffset";
      ShadowOffset.Size = new System.Drawing.Size(41, 23);
      ShadowOffset.TabIndex = 16;
      ShadowOffset.Text = "0";
      // 
      // TextFilesListBox
      // 
      TextFilesListBox.AllowDrop = true;
      TextFilesListBox.FormattingEnabled = true;
      TextFilesListBox.ItemHeight = 15;
      TextFilesListBox.Location = new System.Drawing.Point(18, 276);
      TextFilesListBox.Margin = new System.Windows.Forms.Padding(2);
      TextFilesListBox.Name = "TextFilesListBox";
      TextFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
      TextFilesListBox.Size = new System.Drawing.Size(529, 139);
      TextFilesListBox.TabIndex = 36;
      TextFilesListBox.TabStop = false;
      // 
      // ChooseTextFilesButton
      // 
      ChooseTextFilesButton.Location = new System.Drawing.Point(18, 242);
      ChooseTextFilesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      ChooseTextFilesButton.Name = "ChooseTextFilesButton";
      ChooseTextFilesButton.Size = new System.Drawing.Size(128, 27);
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
      comboBoxFontSize.Items.AddRange(new object[] { "4", "5", "6", "7", "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "23", "24", "26", "28", "36", "48", "72" });
      comboBoxFontSize.Location = new System.Drawing.Point(364, 35);
      comboBoxFontSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      comboBoxFontSize.Name = "comboBoxFontSize";
      comboBoxFontSize.Size = new System.Drawing.Size(56, 202);
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
      comboBoxFontStyle.Location = new System.Drawing.Point(254, 35);
      comboBoxFontStyle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      comboBoxFontStyle.Name = "comboBoxFontStyle";
      comboBoxFontStyle.Size = new System.Drawing.Size(93, 202);
      comboBoxFontStyle.TabIndex = 3;
      comboBoxFontStyle.Text = "Regular";
      comboBoxFontStyle.SelectedIndexChanged += FontStyle_SelectedIndexChanged;
      // 
      // ComboBoxFontName
      // 
      comboBoxFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      comboBoxFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      comboBoxFontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "FontName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      comboBoxFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
      comboBoxFontName.FormattingEnabled = true;
      comboBoxFontName.Location = new System.Drawing.Point(18, 35);
      comboBoxFontName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      comboBoxFontName.Name = "ComboBoxFontName";
      comboBoxFontName.Size = new System.Drawing.Size(220, 165);
      comboBoxFontName.TabIndex = 1;
      comboBoxFontName.SelectedIndexChanged += FontName_SelectedIndexChanged;
      // 
      // checkBoxExportDefault
      // 
      checkBoxExportDefault.AutoSize = true;
      checkBoxExportDefault.Location = new System.Drawing.Point(153, 247);
      checkBoxExportDefault.Name = "checkBoxExportDefault";
      checkBoxExportDefault.Size = new System.Drawing.Size(157, 19);
      checkBoxExportDefault.TabIndex = 38;
      checkBoxExportDefault.Text = "Export Default ( 32 .. 126)";
      checkBoxExportDefault.UseVisualStyleBackColor = true;
      checkBoxExportDefault.CheckedChanged += CheckBoxExportDefault_CheckedChanged;
      // 
      // buttonChooseFontFiles
      // 
      buttonChooseFontFiles.Location = new System.Drawing.Point(18, 200);
      buttonChooseFontFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      buttonChooseFontFiles.Name = "buttonChooseFontFiles";
      buttonChooseFontFiles.Size = new System.Drawing.Size(220, 27);
      buttonChooseFontFiles.TabIndex = 39;
      buttonChooseFontFiles.Text = "Choose Font Files";
      buttonChooseFontFiles.UseVisualStyleBackColor = true;
      buttonChooseFontFiles.Click += ButtonChooseFontFiles_Click;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(572, 630);
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
      Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      Name = "MainForm";
      Text = "TTF2BMP";
      FormClosing += MainForm_FormClosing;
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
  }
}

