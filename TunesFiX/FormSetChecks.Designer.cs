namespace TunesFiX
{
  partial class FormSetChecks
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetChecks));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.labelMinPercent = new System.Windows.Forms.Label();
      this.labelMinArtists = new System.Windows.Forms.Label();
      this.upDownMinSongs = new System.Windows.Forms.NumericUpDown();
      this.upDownPercent = new System.Windows.Forms.NumericUpDown();
      this.textBoxPrefix = new System.Windows.Forms.TextBox();
      this.checkBoxIgnorePrefix = new System.Windows.Forms.CheckBox();
      this.checkBoxExcludeComp = new System.Windows.Forms.CheckBox();
      this.radioButtonDBTAP = new System.Windows.Forms.RadioButton();
      this.radioButtonCompillations = new System.Windows.Forms.RadioButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOk = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.upDownMinSongs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.upDownPercent)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.upDownMinSongs);
      this.groupBox1.Controls.Add(this.upDownPercent);
      this.groupBox1.Controls.Add(this.textBoxPrefix);
      this.groupBox1.Controls.Add(this.checkBoxIgnorePrefix);
      this.groupBox1.Controls.Add(this.checkBoxExcludeComp);
      this.groupBox1.Controls.Add(this.radioButtonDBTAP);
      this.groupBox1.Controls.Add(this.radioButtonCompillations);
      this.groupBox1.Controls.Add(this.labelMinPercent);
      this.groupBox1.Controls.Add(this.labelMinArtists);
      this.groupBox1.Location = new System.Drawing.Point(0, 80);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(409, 93);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Select Mode:";
      // 
      // labelMinPercent
      // 
      this.labelMinPercent.AutoSize = true;
      this.labelMinPercent.Location = new System.Drawing.Point(197, 13);
      this.labelMinPercent.Name = "labelMinPercent";
      this.labelMinPercent.Size = new System.Drawing.Size(200, 26);
      this.labelMinPercent.TabIndex = 10;
      this.labelMinPercent.Text = "Minimum percentage of different artists in\r\nan album that defines it as a \"collec" +
    "tion\".";
      // 
      // labelMinArtists
      // 
      this.labelMinArtists.AutoSize = true;
      this.labelMinArtists.Location = new System.Drawing.Point(197, 56);
      this.labelMinArtists.Name = "labelMinArtists";
      this.labelMinArtists.Size = new System.Drawing.Size(202, 26);
      this.labelMinArtists.TabIndex = 9;
      this.labelMinArtists.Text = "Minimum number of different artists on the\r\nsame album to call it a \"collection\"." +
    "";
      // 
      // upDownMinSongs
      // 
      this.upDownMinSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.upDownMinSongs.Location = new System.Drawing.Point(131, 62);
      this.upDownMinSongs.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.upDownMinSongs.Name = "upDownMinSongs";
      this.upDownMinSongs.ReadOnly = true;
      this.upDownMinSongs.Size = new System.Drawing.Size(57, 20);
      this.upDownMinSongs.TabIndex = 8;
      this.upDownMinSongs.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
      this.upDownMinSongs.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
      // 
      // upDownPercent
      // 
      this.upDownPercent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.upDownPercent.Location = new System.Drawing.Point(131, 19);
      this.upDownPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.upDownPercent.Name = "upDownPercent";
      this.upDownPercent.ReadOnly = true;
      this.upDownPercent.Size = new System.Drawing.Size(57, 20);
      this.upDownPercent.TabIndex = 7;
      this.upDownPercent.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
      this.upDownPercent.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // textBoxPrefix
      // 
      this.textBoxPrefix.Location = new System.Drawing.Point(255, 22);
      this.textBoxPrefix.Name = "textBoxPrefix";
      this.textBoxPrefix.Size = new System.Drawing.Size(100, 20);
      this.textBoxPrefix.TabIndex = 4;
      this.textBoxPrefix.Text = "The";
      this.toolTip1.SetToolTip(this.textBoxPrefix, "Ignore these prefix strings when comparing the artist tag to the\r\nartist subdirec" +
        "tory in the file\'s path. Separate strings with a semicolin.");
      // 
      // checkBoxIgnorePrefix
      // 
      this.checkBoxIgnorePrefix.AutoSize = true;
      this.checkBoxIgnorePrefix.Checked = true;
      this.checkBoxIgnorePrefix.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxIgnorePrefix.Location = new System.Drawing.Point(255, 54);
      this.checkBoxIgnorePrefix.Name = "checkBoxIgnorePrefix";
      this.checkBoxIgnorePrefix.Size = new System.Drawing.Size(85, 17);
      this.checkBoxIgnorePrefix.TabIndex = 3;
      this.checkBoxIgnorePrefix.Text = "Ignore Prefix";
      this.toolTip1.SetToolTip(this.checkBoxIgnorePrefix, resources.GetString("checkBoxIgnorePrefix.ToolTip"));
      this.checkBoxIgnorePrefix.UseVisualStyleBackColor = true;
      this.checkBoxIgnorePrefix.CheckedChanged += new System.EventHandler(this.checkBoxIgnorePrefix_CheckedChanged);
      // 
      // checkBoxExcludeComp
      // 
      this.checkBoxExcludeComp.AutoSize = true;
      this.checkBoxExcludeComp.Checked = true;
      this.checkBoxExcludeComp.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxExcludeComp.Location = new System.Drawing.Point(105, 54);
      this.checkBoxExcludeComp.Name = "checkBoxExcludeComp";
      this.checkBoxExcludeComp.Size = new System.Drawing.Size(128, 17);
      this.checkBoxExcludeComp.TabIndex = 2;
      this.checkBoxExcludeComp.Text = "Exclude Compillations";
      this.toolTip1.SetToolTip(this.checkBoxExcludeComp, "Set this to skip checkmarks on songs that are deemed\r\nto be part of a compillatio" +
        "n album.");
      this.checkBoxExcludeComp.UseVisualStyleBackColor = true;
      // 
      // radioButtonDBTAP
      // 
      this.radioButtonDBTAP.AutoSize = true;
      this.radioButtonDBTAP.Location = new System.Drawing.Point(15, 54);
      this.radioButtonDBTAP.Name = "radioButtonDBTAP";
      this.radioButtonDBTAP.Size = new System.Drawing.Size(61, 17);
      this.radioButtonDBTAP.TabIndex = 1;
      this.radioButtonDBTAP.TabStop = true;
      this.radioButtonDBTAP.Text = "DBTAP";
      this.toolTip1.SetToolTip(this.radioButtonDBTAP, "Put a check on songs where there is a difference in ARTIST/ALBUM\r\nbetween the tag" +
        " and the path.");
      this.radioButtonDBTAP.UseVisualStyleBackColor = true;
      this.radioButtonDBTAP.CheckedChanged += new System.EventHandler(this.radioButtonCompillations_CheckedChanged);
      // 
      // radioButtonCompillations
      // 
      this.radioButtonCompillations.AutoSize = true;
      this.radioButtonCompillations.Location = new System.Drawing.Point(15, 22);
      this.radioButtonCompillations.Name = "radioButtonCompillations";
      this.radioButtonCompillations.Size = new System.Drawing.Size(86, 17);
      this.radioButtonCompillations.TabIndex = 0;
      this.radioButtonCompillations.TabStop = true;
      this.radioButtonCompillations.Text = "Compillations";
      this.toolTip1.SetToolTip(this.radioButtonCompillations, "Applies an algorithm to deduce which songs are likley to be part\r\nof a compillati" +
        "on album.");
      this.radioButtonCompillations.UseVisualStyleBackColor = true;
      this.radioButtonCompillations.CheckedChanged += new System.EventHandler(this.radioButtonCompillations_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.textBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(409, 74);
      this.panel1.TabIndex = 1;
      // 
      // textBox1
      // 
      this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox1.Location = new System.Drawing.Point(0, 0);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(409, 74);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.buttonCancel);
      this.panel2.Controls.Add(this.buttonOk);
      this.panel2.Location = new System.Drawing.Point(0, 179);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(409, 44);
      this.panel2.TabIndex = 2;
      // 
      // buttonCancel
      // 
      this.buttonCancel.AutoSize = true;
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(233, 11);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(122, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "&Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOk
      // 
      this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOk.Location = new System.Drawing.Point(50, 11);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(122, 23);
      this.buttonOk.TabIndex = 0;
      this.buttonOk.Text = "&OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // toolTip1
      // 
      this.toolTip1.ToolTipTitle = "TunesFiX";
      // 
      // FormSetChecks
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(409, 228);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormSetChecks";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Set Song Check Boxes";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetChecks_FormClosing);
      this.Shown += new System.EventHandler(this.FormSetChecks_Shown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.upDownMinSongs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.upDownPercent)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radioButtonDBTAP;
    private System.Windows.Forms.RadioButton radioButtonCompillations;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.CheckBox checkBoxExcludeComp;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.CheckBox checkBoxIgnorePrefix;
    private System.Windows.Forms.TextBox textBoxPrefix;
    private System.Windows.Forms.NumericUpDown upDownPercent;
    private System.Windows.Forms.NumericUpDown upDownMinSongs;
    private System.Windows.Forms.Label labelMinPercent;
    private System.Windows.Forms.Label labelMinArtists;
  }
}