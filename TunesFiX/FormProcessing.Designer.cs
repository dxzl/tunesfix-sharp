namespace TunesFiX
{
  partial class FormProcessing
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessing));
      this.panel1 = new System.Windows.Forms.Panel();
      this.checkBoxOverwriteTags = new System.Windows.Forms.CheckBox();
      this.checkBoxTransferArt = new System.Windows.Forms.CheckBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.checkBoxArtist = new System.Windows.Forms.CheckBox();
      this.checkBoxAlbum = new System.Windows.Forms.CheckBox();
      this.checkBoxTitle = new System.Windows.Forms.CheckBox();
      this.groupBoxMode = new System.Windows.Forms.GroupBox();
      this.radioButtonPathToTag = new System.Windows.Forms.RadioButton();
      this.radioButtonTagToPath = new System.Windows.Forms.RadioButton();
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBoxMode.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Controls.Add(this.groupBoxMode);
      this.panel1.Controls.Add(this.checkBoxOverwriteTags);
      this.panel1.Controls.Add(this.checkBoxTransferArt);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(333, 117);
      this.panel1.TabIndex = 0;
      // 
      // checkBoxOverwriteTags
      // 
      this.checkBoxOverwriteTags.AutoSize = true;
      this.checkBoxOverwriteTags.Location = new System.Drawing.Point(14, 83);
      this.checkBoxOverwriteTags.Name = "checkBoxOverwriteTags";
      this.checkBoxOverwriteTags.Size = new System.Drawing.Size(106, 17);
      this.checkBoxOverwriteTags.TabIndex = 3;
      this.checkBoxOverwriteTags.Text = "Overwrite old tag";
      this.toolTip1.SetToolTip(this.checkBoxOverwriteTags, "Set this to always overwrite the Title, Album or Artist\r\nwith new info from the p" +
        "ath.\r\n\r\nClea this to only overwrite the Title, Album or Artist\r\nif the tag is em" +
        "pty.\r\n");
      this.checkBoxOverwriteTags.UseVisualStyleBackColor = true;
      // 
      // checkBoxTransferArt
      // 
      this.checkBoxTransferArt.AutoSize = true;
      this.checkBoxTransferArt.Location = new System.Drawing.Point(14, 83);
      this.checkBoxTransferArt.Name = "checkBoxTransferArt";
      this.checkBoxTransferArt.Size = new System.Drawing.Size(147, 17);
      this.checkBoxTransferArt.TabIndex = 2;
      this.checkBoxTransferArt.Text = "Transfer album art images";
      this.toolTip1.SetToolTip(this.checkBoxTransferArt, "Check this to transfer album art files");
      this.checkBoxTransferArt.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.checkBoxArtist);
      this.panel2.Controls.Add(this.checkBoxAlbum);
      this.panel2.Controls.Add(this.checkBoxTitle);
      this.panel2.Location = new System.Drawing.Point(250, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(80, 74);
      this.panel2.TabIndex = 1;
      // 
      // checkBoxArtist
      // 
      this.checkBoxArtist.AutoSize = true;
      this.checkBoxArtist.Location = new System.Drawing.Point(3, 49);
      this.checkBoxArtist.Name = "checkBoxArtist";
      this.checkBoxArtist.Size = new System.Drawing.Size(49, 17);
      this.checkBoxArtist.TabIndex = 2;
      this.checkBoxArtist.Text = "Artist";
      this.toolTip1.SetToolTip(this.checkBoxArtist, "Check this to include the song\'s Artist tag");
      this.checkBoxArtist.UseVisualStyleBackColor = true;
      // 
      // checkBoxAlbum
      // 
      this.checkBoxAlbum.AutoSize = true;
      this.checkBoxAlbum.Location = new System.Drawing.Point(3, 26);
      this.checkBoxAlbum.Name = "checkBoxAlbum";
      this.checkBoxAlbum.Size = new System.Drawing.Size(55, 17);
      this.checkBoxAlbum.TabIndex = 1;
      this.checkBoxAlbum.Text = "Album";
      this.toolTip1.SetToolTip(this.checkBoxAlbum, "Check this to include the song\'s Album tag");
      this.checkBoxAlbum.UseVisualStyleBackColor = true;
      // 
      // checkBoxTitle
      // 
      this.checkBoxTitle.AutoSize = true;
      this.checkBoxTitle.Location = new System.Drawing.Point(3, 3);
      this.checkBoxTitle.Name = "checkBoxTitle";
      this.checkBoxTitle.Size = new System.Drawing.Size(46, 17);
      this.checkBoxTitle.TabIndex = 0;
      this.checkBoxTitle.Text = "Title";
      this.toolTip1.SetToolTip(this.checkBoxTitle, "Check this to include the song\'s Title tag");
      this.checkBoxTitle.UseVisualStyleBackColor = true;
      // 
      // groupBoxMode
      // 
      this.groupBoxMode.Controls.Add(this.radioButtonPathToTag);
      this.groupBoxMode.Controls.Add(this.radioButtonTagToPath);
      this.groupBoxMode.Location = new System.Drawing.Point(3, 3);
      this.groupBoxMode.Name = "groupBoxMode";
      this.groupBoxMode.Size = new System.Drawing.Size(241, 66);
      this.groupBoxMode.TabIndex = 0;
      this.groupBoxMode.TabStop = false;
      this.groupBoxMode.Text = "Mode";
      // 
      // radioButtonPathToTag
      // 
      this.radioButtonPathToTag.AutoSize = true;
      this.radioButtonPathToTag.Location = new System.Drawing.Point(6, 42);
      this.radioButtonPathToTag.Name = "radioButtonPathToTag";
      this.radioButtonPathToTag.Size = new System.Drawing.Size(186, 17);
      this.radioButtonPathToTag.TabIndex = 1;
      this.radioButtonPathToTag.TabStop = true;
      this.radioButtonPathToTag.Text = "Break apart file path to use in tags";
      this.toolTip1.SetToolTip(this.radioButtonPathToTag, resources.GetString("radioButtonPathToTag.ToolTip"));
      this.radioButtonPathToTag.UseVisualStyleBackColor = true;
      this.radioButtonPathToTag.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
      // 
      // radioButtonTagToPath
      // 
      this.radioButtonTagToPath.AutoSize = true;
      this.radioButtonTagToPath.Location = new System.Drawing.Point(6, 19);
      this.radioButtonTagToPath.Name = "radioButtonTagToPath";
      this.radioButtonTagToPath.Size = new System.Drawing.Size(175, 17);
      this.radioButtonTagToPath.TabIndex = 0;
      this.radioButtonTagToPath.TabStop = true;
      this.radioButtonTagToPath.Text = "Use tag info. to rename file path";
      this.toolTip1.SetToolTip(this.radioButtonTagToPath, "Move selected files into a new directory of the form:\r\n\r\n        C:\\MusicFolderPa" +
        "th\\Artist\\Album\\Title.wma\r\n\r\nFiles will be renamed and directories created as ne" +
        "eded.");
      this.radioButtonTagToPath.UseVisualStyleBackColor = true;
      this.radioButtonTagToPath.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
      // 
      // buttonOk
      // 
      this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOk.Location = new System.Drawing.Point(55, 135);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 1;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(213, 135);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // FormProcessing
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(357, 170);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormProcessing";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Processing Options";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProcessing_FormClosing);
      this.Shown += new System.EventHandler(this.FormProcessing_Shown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.groupBoxMode.ResumeLayout(false);
      this.groupBoxMode.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.CheckBox checkBoxArtist;
    private System.Windows.Forms.CheckBox checkBoxAlbum;
    private System.Windows.Forms.CheckBox checkBoxTitle;
    private System.Windows.Forms.GroupBox groupBoxMode;
    private System.Windows.Forms.RadioButton radioButtonPathToTag;
    private System.Windows.Forms.RadioButton radioButtonTagToPath;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.CheckBox checkBoxTransferArt;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.CheckBox checkBoxOverwriteTags;
  }
}