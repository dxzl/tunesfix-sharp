//---------------------------------------------------------------------------
// TunesFiX - Reorganize music directory-tree structure by album-artist
// instead of by artist. Reassembles various-artist albums scattered over
// multiple folders. Powerful tag-editor.
//
// Author: Scott Swift
//
// Released to GitHub under GPL v3 October, 2016
//
//---------------------------------------------------------------------------
namespace TunesFiX
{
  partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonSetChecks = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.songView = new TunesFiX.BufferedListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToClipboardAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openMusicFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPerformerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewComposerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGenreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPublisherMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConductorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewYearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTrackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCommentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLyricsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.playSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.removeUncheckedItemsFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.addFileTypesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSongTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEmptyDirectoriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxExcel = new System.Windows.Forms.CheckBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.songView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 310);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 277);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonProcess);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSetChecks);
            this.splitContainer1.Panel1MinSize = 173;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar);
            this.splitContainer1.Size = new System.Drawing.Size(811, 30);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Enabled = false;
            this.buttonProcess.Location = new System.Drawing.Point(90, 2);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 26);
            this.buttonProcess.TabIndex = 9;
            this.buttonProcess.Text = "&Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // buttonSetChecks
            // 
            this.buttonSetChecks.Enabled = false;
            this.buttonSetChecks.Location = new System.Drawing.Point(9, 2);
            this.buttonSetChecks.Name = "buttonSetChecks";
            this.buttonSetChecks.Size = new System.Drawing.Size(75, 26);
            this.buttonSetChecks.TabIndex = 8;
            this.buttonSetChecks.Text = "&Set Checks";
            this.buttonSetChecks.UseVisualStyleBackColor = true;
            this.buttonSetChecks.Click += new System.EventHandler(this.buttonSetChecks_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(575, 30);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 9;
            // 
            // songView
            // 
            this.songView.AllowDrop = true;
            this.songView.CheckBoxes = true;
            this.songView.ContextMenuStrip = this.contextMenuStrip1;
            this.songView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songView.FullRowSelect = true;
            this.songView.HideSelection = false;
            this.songView.Location = new System.Drawing.Point(3, 67);
            this.songView.Name = "songView";
            this.songView.Size = new System.Drawing.Size(811, 204);
            this.songView.TabIndex = 5;
            this.songView.UseCompatibleStateImageBehavior = false;
            this.songView.View = System.Windows.Forms.View.Details;
            this.songView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.songView_ColumnClick);
            this.songView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.songView_ItemChecked);
            this.songView.DragDrop += new System.Windows.Forms.DragEventHandler(this.songView_DragDrop);
            this.songView.DragOver += new System.Windows.Forms.DragEventHandler(this.songView_DragOver);
            this.songView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.songView_MouseDown);
            this.songView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.songView_MouseMove);
            this.songView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.songView_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.toolStripMenuItem4,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.toolStripMenuItem2,
            this.copyToClipboardAllMenuItem,
            this.copyToClipboardSelectedMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(271, 242);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.clearToolStripMenuItem.Text = "C&lear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(267, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.editToolStripMenuItem.Text = "&Edit Song Tag(s)";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.findToolStripMenuItem.Text = "&Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.findNextToolStripMenuItem.Text = "Find &Next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(267, 6);
            // 
            // copyToClipboardAllMenuItem
            // 
            this.copyToClipboardAllMenuItem.Name = "copyToClipboardAllMenuItem";
            this.copyToClipboardAllMenuItem.Size = new System.Drawing.Size(270, 22);
            this.copyToClipboardAllMenuItem.Text = "Copy To Clipboard (All)";
            this.copyToClipboardAllMenuItem.Click += new System.EventHandler(this.copyToClipboardAllMenuItem_Click);
            // 
            // copyToClipboardSelectedMenuItem
            // 
            this.copyToClipboardSelectedMenuItem.Name = "copyToClipboardSelectedMenuItem";
            this.copyToClipboardSelectedMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToClipboardSelectedMenuItem.Size = new System.Drawing.Size(270, 22);
            this.copyToClipboardSelectedMenuItem.Text = "&Copy To Clipboard (Selected)";
            this.copyToClipboardSelectedMenuItem.Click += new System.EventHandler(this.copyToClipboardSelectedMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy To Clipboard (Checked)";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardCheckedMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.checkAllToolStripMenuItem.Text = "Check All";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.menuCheckAll_Click);
            // 
            // uncheckAllToolStripMenuItem
            // 
            this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.uncheckAllToolStripMenuItem.Text = "&Uncheck All";
            this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.menuUncheckAll_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(3, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox.Size = new System.Drawing.Size(811, 58);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMusicFolderMenuItem,
            this.exitToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // openMusicFolderMenuItem
            // 
            this.openMusicFolderMenuItem.Name = "openMusicFolderMenuItem";
            this.openMusicFolderMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openMusicFolderMenuItem.Text = "&Open Music Folder";
            this.openMusicFolderMenuItem.Click += new System.EventHandler(this.menuOpenMusicFolder_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPerformerMenuItem,
            this.viewComposerMenuItem,
            this.viewGenreMenuItem,
            this.viewPublisherMenuItem,
            this.viewConductorMenuItem,
            this.viewYearMenuItem,
            this.viewTrackMenuItem,
            this.viewDurationMenuItem,
            this.viewCommentsMenuItem,
            this.viewLyricsMenuItem,
            this.viewPathMenuItem});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // viewPerformerMenuItem
            // 
            this.viewPerformerMenuItem.CheckOnClick = true;
            this.viewPerformerMenuItem.Name = "viewPerformerMenuItem";
            this.viewPerformerMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewPerformerMenuItem.Text = "Per&former";
            this.viewPerformerMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewComposerMenuItem
            // 
            this.viewComposerMenuItem.CheckOnClick = true;
            this.viewComposerMenuItem.Name = "viewComposerMenuItem";
            this.viewComposerMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewComposerMenuItem.Text = "&Composer";
            this.viewComposerMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewGenreMenuItem
            // 
            this.viewGenreMenuItem.CheckOnClick = true;
            this.viewGenreMenuItem.Name = "viewGenreMenuItem";
            this.viewGenreMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewGenreMenuItem.Text = "&Genre";
            this.viewGenreMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewPublisherMenuItem
            // 
            this.viewPublisherMenuItem.CheckOnClick = true;
            this.viewPublisherMenuItem.Name = "viewPublisherMenuItem";
            this.viewPublisherMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewPublisherMenuItem.Text = "P&ublisher";
            this.viewPublisherMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewConductorMenuItem
            // 
            this.viewConductorMenuItem.CheckOnClick = true;
            this.viewConductorMenuItem.Name = "viewConductorMenuItem";
            this.viewConductorMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewConductorMenuItem.Text = "Co&nductor";
            this.viewConductorMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewYearMenuItem
            // 
            this.viewYearMenuItem.CheckOnClick = true;
            this.viewYearMenuItem.Name = "viewYearMenuItem";
            this.viewYearMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewYearMenuItem.Text = "&Year";
            this.viewYearMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewTrackMenuItem
            // 
            this.viewTrackMenuItem.CheckOnClick = true;
            this.viewTrackMenuItem.Name = "viewTrackMenuItem";
            this.viewTrackMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewTrackMenuItem.Text = "&Track";
            this.viewTrackMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewDurationMenuItem
            // 
            this.viewDurationMenuItem.CheckOnClick = true;
            this.viewDurationMenuItem.Name = "viewDurationMenuItem";
            this.viewDurationMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewDurationMenuItem.Text = "&Time";
            this.viewDurationMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewCommentsMenuItem
            // 
            this.viewCommentsMenuItem.CheckOnClick = true;
            this.viewCommentsMenuItem.Name = "viewCommentsMenuItem";
            this.viewCommentsMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewCommentsMenuItem.Text = "Co&mments";
            this.viewCommentsMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewLyricsMenuItem
            // 
            this.viewLyricsMenuItem.CheckOnClick = true;
            this.viewLyricsMenuItem.Name = "viewLyricsMenuItem";
            this.viewLyricsMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewLyricsMenuItem.Text = "&Lyrics";
            this.viewLyricsMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // viewPathMenuItem
            // 
            this.viewPathMenuItem.CheckOnClick = true;
            this.viewPathMenuItem.Name = "viewPathMenuItem";
            this.viewPathMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewPathMenuItem.Text = "&Path";
            this.viewPathMenuItem.Click += new System.EventHandler(this.menuViewItem_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playSongToolStripMenuItem,
            this.toolStripMenuItem5,
            this.removeUncheckedItemsFromListToolStripMenuItem,
            this.toolStripMenuItem3,
            this.addFileTypesMenuItem,
            this.toolStripMenuItem8,
            this.deleteSongTagsToolStripMenuItem,
            this.removeEmptyDirectoriesMenuItem});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "&Tools";
            // 
            // playSongToolStripMenuItem
            // 
            this.playSongToolStripMenuItem.Name = "playSongToolStripMenuItem";
            this.playSongToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.playSongToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.playSongToolStripMenuItem.Text = "&Play Selected Songs";
            this.playSongToolStripMenuItem.Click += new System.EventHandler(this.playSongToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(305, 6);
            // 
            // removeUncheckedItemsFromListToolStripMenuItem
            // 
            this.removeUncheckedItemsFromListToolStripMenuItem.Name = "removeUncheckedItemsFromListToolStripMenuItem";
            this.removeUncheckedItemsFromListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.removeUncheckedItemsFromListToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.removeUncheckedItemsFromListToolStripMenuItem.Text = "Remove Unchecked Songs From List";
            this.removeUncheckedItemsFromListToolStripMenuItem.Click += new System.EventHandler(this.removeUncheckedItemsFromListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(305, 6);
            // 
            // addFileTypesMenuItem
            // 
            this.addFileTypesMenuItem.Name = "addFileTypesMenuItem";
            this.addFileTypesMenuItem.Size = new System.Drawing.Size(308, 22);
            this.addFileTypesMenuItem.Text = "&Add &New File-Types";
            this.addFileTypesMenuItem.Click += new System.EventHandler(this.menuAddFileTypes_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(305, 6);
            // 
            // deleteSongTagsToolStripMenuItem
            // 
            this.deleteSongTagsToolStripMenuItem.Name = "deleteSongTagsToolStripMenuItem";
            this.deleteSongTagsToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.deleteSongTagsToolStripMenuItem.Text = "&Remove ALL Tags From Selected Songs";
            this.deleteSongTagsToolStripMenuItem.Click += new System.EventHandler(this.deleteSongTagsToolStripMenuItem_Click);
            // 
            // removeEmptyDirectoriesMenuItem
            // 
            this.removeEmptyDirectoriesMenuItem.Name = "removeEmptyDirectoriesMenuItem";
            this.removeEmptyDirectoriesMenuItem.Size = new System.Drawing.Size(308, 22);
            this.removeEmptyDirectoriesMenuItem.Text = "&Remove Empty Directories";
            this.removeEmptyDirectoriesMenuItem.Click += new System.EventHandler(this.menuRemoveEmptyDirectories_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenuItem,
            this.restoreMenuItem,
            this.toolStripSep1,
            this.aboutMenuItem});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(158, 22);
            this.helpMenuItem.Text = "&Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpTagEditorTitleAlbumBoxesToolStripMenuItem_Click);
            // 
            // restoreMenuItem
            // 
            this.restoreMenuItem.Name = "restoreMenuItem";
            this.restoreMenuItem.Size = new System.Drawing.Size(158, 22);
            this.restoreMenuItem.Text = "Restore &Settings";
            this.restoreMenuItem.Click += new System.EventHandler(this.restoreMenuItem_Click);
            // 
            // toolStripSep1
            // 
            this.toolStripSep1.Name = "toolStripSep1";
            this.toolStripSep1.Size = new System.Drawing.Size(155, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutMenuItem.Text = "&About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // checkBoxExcel
            // 
            this.checkBoxExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxExcel.AutoSize = true;
            this.checkBoxExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.checkBoxExcel.Checked = true;
            this.checkBoxExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExcel.Location = new System.Drawing.Point(651, 3);
            this.checkBoxExcel.Name = "checkBoxExcel";
            this.checkBoxExcel.Size = new System.Drawing.Size(134, 17);
            this.checkBoxExcel.TabIndex = 3;
            this.checkBoxExcel.Text = "Excel Clipboard Format";
            this.checkBoxExcel.UseVisualStyleBackColor = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 334);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.checkBoxExcel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(489, 39);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TunesFiX 1.90";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem copyToClipboardAllMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToClipboardSelectedMenuItem;
    private System.Windows.Forms.CheckBox checkBoxExcel;
    private System.Windows.Forms.Button buttonSetChecks;
    private System.Windows.Forms.ToolTip toolTips;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem openMusicFolderMenuItem;
    private BufferedListView songView;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem menuEdit;
    private System.Windows.Forms.RichTextBox richTextBox;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem menuHelp;
    private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
    private System.Windows.Forms.ToolStripMenuItem restoreMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSep1;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
    internal System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.ToolStripMenuItem menuView;
    private System.Windows.Forms.ToolStripMenuItem viewYearMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewComposerMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewPublisherMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewCommentsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewTrackMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewDurationMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewPathMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewGenreMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewConductorMenuItem;
    private System.Windows.Forms.ToolStripMenuItem menuTools;
    private System.Windows.Forms.ToolStripMenuItem playSongToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.ToolStripMenuItem removeUncheckedItemsFromListToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem addFileTypesMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
    private System.Windows.Forms.ToolStripMenuItem deleteSongTagsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeEmptyDirectoriesMenuItem;
    private System.Windows.Forms.Button buttonProcess;
    private System.Windows.Forms.ToolStripMenuItem viewPerformerMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewLyricsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.IO.FileSystemWatcher fileSystemWatcher1;
  }
}

