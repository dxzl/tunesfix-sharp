namespace TunesFiX
{
  partial class FormEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.labelGenre = new System.Windows.Forms.Label();
      this.labelTitle = new System.Windows.Forms.Label();
      this.labelArtist = new System.Windows.Forms.Label();
      this.labelAlbum = new System.Windows.Forms.Label();
      this.textAlbum = new System.Windows.Forms.TextBox();
      this.textArtist = new System.Windows.Forms.TextBox();
      this.textTitle = new System.Windows.Forms.TextBox();
      this.labelPublisher = new System.Windows.Forms.Label();
      this.textComposer = new System.Windows.Forms.TextBox();
      this.textGenre = new System.Windows.Forms.TextBox();
      this.textPublisher = new System.Windows.Forms.TextBox();
      this.labelComposer = new System.Windows.Forms.Label();
      this.labelPerformer = new System.Windows.Forms.Label();
      this.labelConductor = new System.Windows.Forms.Label();
      this.textPerformer = new System.Windows.Forms.TextBox();
      this.textConductor = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.labelComments = new System.Windows.Forms.Label();
      this.textComments = new System.Windows.Forms.TextBox();
      this.labelLyrics = new System.Windows.Forms.Label();
      this.textLyrics = new System.Windows.Forms.TextBox();
      this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
      this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTips = new System.Windows.Forms.ToolTip(this.components);
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.textTrack = new System.Windows.Forms.TextBox();
      this.labelTrack = new System.Windows.Forms.Label();
      this.textYear = new System.Windows.Forms.TextBox();
      this.labelYear = new System.Windows.Forms.Label();
      this.labelPath = new System.Windows.Forms.Label();
      this.textPath = new System.Windows.Forms.TextBox();
      this.labelDuration = new System.Windows.Forms.Label();
      this.textDuration = new System.Windows.Forms.TextBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.ctxMenu.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitContainer1.Location = new System.Drawing.Point(0, 26);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
      this.splitContainer1.Size = new System.Drawing.Size(781, 111);
      this.splitContainer1.SplitterDistance = 642;
      this.splitContainer1.TabIndex = 0;
      this.splitContainer1.TabStop = false;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Controls.Add(this.labelGenre, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelArtist, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelAlbum, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.textAlbum, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.textArtist, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.textTitle, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.labelPublisher, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.textComposer, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.textGenre, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.textPublisher, 2, 3);
      this.tableLayoutPanel1.Controls.Add(this.labelComposer, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.labelPerformer, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelConductor, 3, 2);
      this.tableLayoutPanel1.Controls.Add(this.textPerformer, 3, 1);
      this.tableLayoutPanel1.Controls.Add(this.textConductor, 3, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 109);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // labelGenre
      // 
      this.labelGenre.AutoSize = true;
      this.labelGenre.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelGenre.Location = new System.Drawing.Point(163, 54);
      this.labelGenre.Name = "labelGenre";
      this.labelGenre.Size = new System.Drawing.Size(154, 27);
      this.labelGenre.TabIndex = 3;
      this.labelGenre.Text = "Genre";
      this.labelGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.labelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelTitle.Location = new System.Drawing.Point(3, 0);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(154, 27);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "Title";
      this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelTitle.Click += new System.EventHandler(this.labelHelp_Click);
      // 
      // labelArtist
      // 
      this.labelArtist.AutoSize = true;
      this.labelArtist.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.labelArtist.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelArtist.Location = new System.Drawing.Point(163, 0);
      this.labelArtist.Name = "labelArtist";
      this.labelArtist.Size = new System.Drawing.Size(154, 27);
      this.labelArtist.TabIndex = 1;
      this.labelArtist.Text = "Artist";
      this.labelArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelArtist.Click += new System.EventHandler(this.labelHelp_Click);
      // 
      // labelAlbum
      // 
      this.labelAlbum.AutoSize = true;
      this.labelAlbum.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.labelAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelAlbum.Location = new System.Drawing.Point(323, 0);
      this.labelAlbum.Name = "labelAlbum";
      this.labelAlbum.Size = new System.Drawing.Size(154, 27);
      this.labelAlbum.TabIndex = 2;
      this.labelAlbum.Text = "Album";
      this.labelAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelAlbum.Click += new System.EventHandler(this.labelHelp_Click);
      // 
      // textAlbum
      // 
      this.textAlbum.BackColor = System.Drawing.Color.Bisque;
      this.textAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textAlbum.Location = new System.Drawing.Point(323, 30);
      this.textAlbum.Name = "textAlbum";
      this.textAlbum.Size = new System.Drawing.Size(154, 20);
      this.textAlbum.TabIndex = 2;
      this.textAlbum.WordWrap = false;
      // 
      // textArtist
      // 
      this.textArtist.BackColor = System.Drawing.Color.Bisque;
      this.textArtist.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textArtist.Location = new System.Drawing.Point(163, 30);
      this.textArtist.Name = "textArtist";
      this.textArtist.Size = new System.Drawing.Size(154, 20);
      this.textArtist.TabIndex = 1;
      this.textArtist.WordWrap = false;
      // 
      // textTitle
      // 
      this.textTitle.BackColor = System.Drawing.Color.Bisque;
      this.textTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textTitle.Location = new System.Drawing.Point(3, 30);
      this.textTitle.Name = "textTitle";
      this.textTitle.Size = new System.Drawing.Size(154, 20);
      this.textTitle.TabIndex = 0;
      this.textTitle.WordWrap = false;
      // 
      // labelPublisher
      // 
      this.labelPublisher.AutoSize = true;
      this.labelPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelPublisher.Location = new System.Drawing.Point(323, 54);
      this.labelPublisher.Name = "labelPublisher";
      this.labelPublisher.Size = new System.Drawing.Size(154, 27);
      this.labelPublisher.TabIndex = 4;
      this.labelPublisher.Text = "Publisher";
      this.labelPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textComposer
      // 
      this.textComposer.BackColor = System.Drawing.Color.Bisque;
      this.textComposer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textComposer.Location = new System.Drawing.Point(3, 84);
      this.textComposer.Name = "textComposer";
      this.textComposer.Size = new System.Drawing.Size(154, 20);
      this.textComposer.TabIndex = 4;
      this.textComposer.WordWrap = false;
      // 
      // textGenre
      // 
      this.textGenre.BackColor = System.Drawing.Color.Bisque;
      this.textGenre.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textGenre.Location = new System.Drawing.Point(163, 84);
      this.textGenre.Name = "textGenre";
      this.textGenre.Size = new System.Drawing.Size(154, 20);
      this.textGenre.TabIndex = 5;
      this.textGenre.WordWrap = false;
      // 
      // textPublisher
      // 
      this.textPublisher.BackColor = System.Drawing.Color.Bisque;
      this.textPublisher.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textPublisher.Location = new System.Drawing.Point(323, 84);
      this.textPublisher.Name = "textPublisher";
      this.textPublisher.Size = new System.Drawing.Size(154, 20);
      this.textPublisher.TabIndex = 6;
      this.textPublisher.WordWrap = false;
      // 
      // labelComposer
      // 
      this.labelComposer.AutoSize = true;
      this.labelComposer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelComposer.Location = new System.Drawing.Point(3, 54);
      this.labelComposer.Name = "labelComposer";
      this.labelComposer.Size = new System.Drawing.Size(154, 27);
      this.labelComposer.TabIndex = 3;
      this.labelComposer.Text = "Composer";
      this.labelComposer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelPerformer
      // 
      this.labelPerformer.AutoSize = true;
      this.labelPerformer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelPerformer.Location = new System.Drawing.Point(483, 0);
      this.labelPerformer.Name = "labelPerformer";
      this.labelPerformer.Size = new System.Drawing.Size(154, 27);
      this.labelPerformer.TabIndex = 7;
      this.labelPerformer.Text = "Performer";
      this.labelPerformer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelConductor
      // 
      this.labelConductor.AutoSize = true;
      this.labelConductor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelConductor.Location = new System.Drawing.Point(483, 54);
      this.labelConductor.Name = "labelConductor";
      this.labelConductor.Size = new System.Drawing.Size(154, 27);
      this.labelConductor.TabIndex = 8;
      this.labelConductor.Text = "Conductor";
      this.labelConductor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textPerformer
      // 
      this.textPerformer.BackColor = System.Drawing.Color.Bisque;
      this.textPerformer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textPerformer.Location = new System.Drawing.Point(483, 30);
      this.textPerformer.Name = "textPerformer";
      this.textPerformer.Size = new System.Drawing.Size(154, 20);
      this.textPerformer.TabIndex = 3;
      // 
      // textConductor
      // 
      this.textConductor.BackColor = System.Drawing.Color.Bisque;
      this.textConductor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textConductor.Location = new System.Drawing.Point(483, 84);
      this.textConductor.Name = "textConductor";
      this.textConductor.Size = new System.Drawing.Size(154, 20);
      this.textConductor.TabIndex = 7;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.labelComments, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.textComments, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.labelLyrics, 0, 2);
      this.tableLayoutPanel2.Controls.Add(this.textLyrics, 0, 3);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 4;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(133, 109);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // labelComments
      // 
      this.labelComments.AutoSize = true;
      this.labelComments.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.labelComments.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelComments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelComments.Location = new System.Drawing.Point(3, 0);
      this.labelComments.Name = "labelComments";
      this.labelComments.Size = new System.Drawing.Size(127, 27);
      this.labelComments.TabIndex = 3;
      this.labelComments.Text = "Comments";
      this.labelComments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textComments
      // 
      this.textComments.BackColor = System.Drawing.Color.Bisque;
      this.textComments.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textComments.Location = new System.Drawing.Point(3, 30);
      this.textComments.Name = "textComments";
      this.textComments.Size = new System.Drawing.Size(127, 20);
      this.textComments.TabIndex = 8;
      this.textComments.WordWrap = false;
      // 
      // labelLyrics
      // 
      this.labelLyrics.AutoSize = true;
      this.labelLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelLyrics.Location = new System.Drawing.Point(3, 54);
      this.labelLyrics.Name = "labelLyrics";
      this.labelLyrics.Size = new System.Drawing.Size(127, 27);
      this.labelLyrics.TabIndex = 4;
      this.labelLyrics.Text = "Lyrics";
      this.labelLyrics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textLyrics
      // 
      this.textLyrics.BackColor = System.Drawing.Color.Bisque;
      this.textLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textLyrics.Location = new System.Drawing.Point(3, 84);
      this.textLyrics.Name = "textLyrics";
      this.textLyrics.Size = new System.Drawing.Size(127, 20);
      this.textLyrics.TabIndex = 9;
      this.textLyrics.WordWrap = false;
      // 
      // ctxMenu
      // 
      this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.menuSelectAll,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
      this.ctxMenu.Name = "ctxMenu";
      this.ctxMenu.ShowImageMargin = false;
      this.ctxMenu.Size = new System.Drawing.Size(98, 142);
      // 
      // menuCut
      // 
      this.menuCut.Name = "menuCut";
      this.menuCut.Size = new System.Drawing.Size(97, 22);
      this.menuCut.Text = "C&ut";
      this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
      // 
      // menuCopy
      // 
      this.menuCopy.Name = "menuCopy";
      this.menuCopy.Size = new System.Drawing.Size(97, 22);
      this.menuCopy.Text = "&Copy";
      this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
      // 
      // menuPaste
      // 
      this.menuPaste.Name = "menuPaste";
      this.menuPaste.Size = new System.Drawing.Size(97, 22);
      this.menuPaste.Text = "&Paste";
      this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
      // 
      // menuSelectAll
      // 
      this.menuSelectAll.Name = "menuSelectAll";
      this.menuSelectAll.Size = new System.Drawing.Size(97, 22);
      this.menuSelectAll.Text = "&Select All";
      this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
      // 
      // clearToolStripMenuItem
      // 
      this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
      this.clearToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
      this.clearToolStripMenuItem.Text = "C&lear";
      this.clearToolStripMenuItem.Click += new System.EventHandler(this.menuClear_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 6);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
      this.helpToolStripMenuItem.Text = "&Help";
      this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
      // 
      // toolTips
      // 
      this.toolTips.AutomaticDelay = 0;
      this.toolTips.ShowAlways = true;
      this.toolTips.UseAnimation = false;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.tableLayoutPanel3.ColumnCount = 4;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tableLayoutPanel3.Controls.Add(this.textTrack, 2, 1);
      this.tableLayoutPanel3.Controls.Add(this.labelTrack, 2, 0);
      this.tableLayoutPanel3.Controls.Add(this.textYear, 1, 1);
      this.tableLayoutPanel3.Controls.Add(this.labelYear, 1, 0);
      this.tableLayoutPanel3.Controls.Add(this.labelPath, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.textPath, 0, 1);
      this.tableLayoutPanel3.Controls.Add(this.labelDuration, 3, 0);
      this.tableLayoutPanel3.Controls.Add(this.textDuration, 3, 1);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 137);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel3.Size = new System.Drawing.Size(781, 60);
      this.tableLayoutPanel3.TabIndex = 2;
      // 
      // textTrack
      // 
      this.textTrack.BackColor = System.Drawing.Color.Bisque;
      this.textTrack.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textTrack.Location = new System.Drawing.Point(694, 37);
      this.textTrack.Name = "textTrack";
      this.textTrack.Size = new System.Drawing.Size(39, 20);
      this.textTrack.TabIndex = 12;
      this.textTrack.WordWrap = false;
      // 
      // labelTrack
      // 
      this.labelTrack.AutoSize = true;
      this.labelTrack.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelTrack.Location = new System.Drawing.Point(694, 0);
      this.labelTrack.Name = "labelTrack";
      this.labelTrack.Size = new System.Drawing.Size(39, 34);
      this.labelTrack.TabIndex = 9;
      this.labelTrack.Text = "Track";
      this.labelTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelTrack.Click += new System.EventHandler(this.labelHelp_Click);
      // 
      // textYear
      // 
      this.textYear.BackColor = System.Drawing.Color.Bisque;
      this.textYear.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textYear.Location = new System.Drawing.Point(649, 37);
      this.textYear.Name = "textYear";
      this.textYear.Size = new System.Drawing.Size(39, 20);
      this.textYear.TabIndex = 11;
      this.textYear.WordWrap = false;
      // 
      // labelYear
      // 
      this.labelYear.AutoSize = true;
      this.labelYear.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelYear.Location = new System.Drawing.Point(649, 0);
      this.labelYear.Name = "labelYear";
      this.labelYear.Size = new System.Drawing.Size(39, 34);
      this.labelYear.TabIndex = 6;
      this.labelYear.Text = "Year";
      this.labelYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelPath
      // 
      this.labelPath.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelPath.Location = new System.Drawing.Point(3, 0);
      this.labelPath.Name = "labelPath";
      this.labelPath.Size = new System.Drawing.Size(640, 34);
      this.labelPath.TabIndex = 1;
      this.labelPath.Text = "Common Path (Click here for help.)";
      this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labelPath.Click += new System.EventHandler(this.labelHelp_Click);
      // 
      // textPath
      // 
      this.textPath.BackColor = System.Drawing.Color.Bisque;
      this.textPath.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textPath.Location = new System.Drawing.Point(3, 37);
      this.textPath.Name = "textPath";
      this.textPath.Size = new System.Drawing.Size(640, 20);
      this.textPath.TabIndex = 10;
      this.textPath.WordWrap = false;
      // 
      // labelDuration
      // 
      this.labelDuration.AutoSize = true;
      this.labelDuration.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelDuration.Location = new System.Drawing.Point(739, 0);
      this.labelDuration.Name = "labelDuration";
      this.labelDuration.Size = new System.Drawing.Size(39, 34);
      this.labelDuration.TabIndex = 11;
      this.labelDuration.Text = "Time";
      this.labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textDuration
      // 
      this.textDuration.BackColor = System.Drawing.Color.Bisque;
      this.textDuration.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textDuration.Location = new System.Drawing.Point(739, 37);
      this.textDuration.Name = "textDuration";
      this.textDuration.ReadOnly = true;
      this.textDuration.Size = new System.Drawing.Size(39, 20);
      this.textDuration.TabIndex = 13;
      this.textDuration.WordWrap = false;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.helpToolStripMenuItem1});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(781, 24);
      this.menuStrip1.TabIndex = 11;
      this.menuStrip1.TabStop = true;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.exitToolStripMenuItem.Text = "&Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Copy tag info to clipboard";
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.copyToolStripMenuItem.Text = "&Copy";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Paste tag info from clipboard";
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
      this.pasteToolStripMenuItem.Text = "&Paste";
      this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem1
      // 
      this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
      this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem1.Text = "&Help";
      this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
      // 
      // FormEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(781, 197);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.tableLayoutPanel3);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(5000, 236);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(450, 236);
      this.Name = "FormEdit";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEdit_FormClosing);
      this.Shown += new System.EventHandler(this.FormEdit_Shown);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEdit_KeyDown);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ctxMenu.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelArtist;
    private System.Windows.Forms.Label labelAlbum;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label labelComments;
    private System.Windows.Forms.TextBox textAlbum;
    private System.Windows.Forms.TextBox textArtist;
    private System.Windows.Forms.TextBox textTitle;
    private System.Windows.Forms.TextBox textComments;
    private System.Windows.Forms.ContextMenuStrip ctxMenu;
    private System.Windows.Forms.ToolStripMenuItem menuCut;
    private System.Windows.Forms.ToolStripMenuItem menuCopy;
    private System.Windows.Forms.ToolStripMenuItem menuPaste;
    private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
    private System.Windows.Forms.ToolTip toolTips;
    private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Label labelPath;
    private System.Windows.Forms.TextBox textPath;
    private System.Windows.Forms.Label labelGenre;
    private System.Windows.Forms.Label labelPublisher;
    private System.Windows.Forms.TextBox textComposer;
    private System.Windows.Forms.TextBox textGenre;
    private System.Windows.Forms.TextBox textPublisher;
    private System.Windows.Forms.Label labelComposer;
    private System.Windows.Forms.Label labelLyrics;
    private System.Windows.Forms.TextBox textLyrics;
    private System.Windows.Forms.TextBox textYear;
    private System.Windows.Forms.Label labelYear;
    private System.Windows.Forms.Label labelTrack;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    private System.Windows.Forms.Label labelPerformer;
    private System.Windows.Forms.Label labelConductor;
    private System.Windows.Forms.TextBox textPerformer;
    private System.Windows.Forms.TextBox textConductor;
    private System.Windows.Forms.TextBox textTrack;
    private System.Windows.Forms.Label labelDuration;
    private System.Windows.Forms.TextBox textDuration;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
  }
}