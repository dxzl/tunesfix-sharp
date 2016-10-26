using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MediaTags;

namespace TunesFiX
{
  public partial class FormEdit : Form
  {
    // Unique string that lets us recognize our info on the Windows clipboard...
    private const string CLIPBOARD_QUAL_STRING = "TunesFiX_1.0";
    private const int CLIPBOARD_COUNT =  15; // count of tab-separated strings on the clipboard
    private const string STR1 = "No TunesFiX data on the Windows clipboard!";

    private bool bEscape = false;

    private SongInfo songInfo = new SongInfo();
    private SongInfo saveSongInfo = new SongInfo();

    public SongInfo SI
    {
      get { return this.songInfo; }
      set { this.songInfo = value; }
    }

    public TimeSpan Duration { get; set; }

    public const string helpMenu =
      "Click the label above each field for additional help. Pres \"Esc\" to quit or \"Enter\" to Save and exit.\r\n\r\n" +
      "A \"*\" will appear in a field if more than one item was selected and the field is not the same " +
      "for all items.\r\n\r\n" +
      "If more than one item is selected and you change a text-field, the text-field will be changed for all " +
      "of the selected songs if you press \"Enter\" then select \"Yes\"\r\n\r\n" +
      "\"*\" is a wildcard... If you put \"*(new)\" in the Title field all song's titles will have " +
      "\"(new)\" appended to them after you press \"Enter\" then \"Yes\".\r\n\r\n" +
      "\"?\" is a wildcard... If you put \"(new)?\" in the Title field all song's titles will be set " +
      "to \"(new)\" plus the song's file-name (without the extension).";

    public const string helpPath =
      "USE THIS FEATURE AT YOUR OWN RISK! EXPERIMENTAL!\r\n\r\n" +
      "This box shows the part of the path common to all selected files:\r\n\r\n" +
      "Type COPY in front of a new path to copy the selected files to a new " +
      "directory. Type MOVE in front of a new path to move the selected files " +
      "to a new directory. You can specify a new filename if copying or " +
      "moving just one file.\r\n\r\n" +
      "If more than one file is selected, the new name must have a wildcard. \"*\" " +
      "will be replaced with the old filename. \"?\" will be replaced with the song- " +
      "title. \"<010>\" will print 010, 011, 012... \"<0>\" prints 0, 1, 2...\r\n\r\n" +
      "Examples:\r\n" +
      "G:\\Music\\Steely Dan\\Can't Buy A Thrill.mp3 => Katy Lied.mp3 changes the " +
      "file name from Can't Buy A Thrill to Katy Lied.mp3\r\n\r\n" +
      "G:\\Music\\ => COPY G:\\New Music\\ copies all selected files to G:\\New Music\\ " +
      "and preserves the subfolders.\r\n\r\n" +
      "G:\\Music\\ => ?<01>.* renames all selected files with the Title of the song and " +
      "a number 01,02,03...\r\n\r\n" +
      "G:\\Music\\ => MOVE C:\\Latin Music\\LAT *.* moves selected files to C:\\Latin " +
      "Music\\ and prefixes them with \"LAT \".\r\n\r\n" +
      "G:\\Music\\ => COPY \\XYZ copies selected files to G:\\Music\\XYZ but DOES NOT " +
      "preserve the original subfolders!\r\n\r\n" +
      "G:\\Music\\ => *<> removes outermost trailing digits from selected file names.\r\n\r\n" +
      "G:\\Music\\ => <>* removes outermost leading digits from selected file names.\r\n\r\n" +
      "G:\\Music\\ => *<>* removes all digits from selected file names.\r\n\r\n" +
      "G:\\Music\\ => MOVE \\* will move every selected song into G:\\Music\\ with no " +
      "subfolders...";

    public const string helpTitle =
      "You can use three types of wildcard in the Title. \"?\" is replaced " +
      "with the filename without the extension. \"*\" is replaced with the " +
      "present Title. \"<###>\" is replaced with a sequence of numbers " +
      "starting at the number you put in place of ###.\r\n\r\n" +
      "For example: \"<0>\" is replaced with 0, 1, 2, 3... \"<010>\" is " +
      "replaced with 010, 011, 012... \"<01>\" is replaced with 01, 02, 03...\r\n\r\n" +
      "Use \"<>\" as a title prefix or suffix to remove the outermost " +
      "pre-existing digits. Only one set of \"<>\" in the title is recognized " +
      "at a time.\r\n\r\n" +
      "If you have: First Song 10 001, Second Song 11 002, Third Song 12 003, " +
      "and type \"*<>\", the song titles will be changed to: First Song 10, " +
      "Second Song 11, Third Song 12. Put in \"*<>\" again and you will get " +
      "First Song, Second Song, Third Song.";

    public const string helpOther =
      "You can use two types of wildcard here. \"*\" is replaced with the " +
      "present Album or Artist. \"<###>\" is replaced with a sequence of numbers " +
      "starting at the number you put in place of ###.\r\n\r\n" +
      "For example: \"<0>\" is replaced with 0, 1, 2, 3... \"<010>\" is " +
      "replaced with 010, 011, 012... \"<01>\" is replaced with 01, 02, 03...\r\n\r\n" +
      "Replace the Album/Artist with \"<>*\" to remove the outermost digits from the " +
      "beginning. Use \"*<>\" to remove digits from the end of every selected song. " +
      "Only one set of \"<>\" is recognized at a time.";

    public const string helpTrack =
      "Here, the most useful wildcard is \"<1>\". This will re-number all selected " +
      "song's track-numbers to 1, 2, 3... Etc.";

    private int selectedItemCount = 0;
    public int SelectedItemCount
    {
      set { this.selectedItemCount = value; }
    }

    public FormEdit()
    {
      InitializeComponent();
      pasteToolStripMenuItem.Enabled = haveClipboardData();
    }

    private void FormEdit_Shown(object sender, EventArgs e)
    {
      PutFields(songInfo); // Show the info

      saveSongInfo = songInfo; // back up info we put in before showing the dialog...

//        "? will be replaced with the filename. Use <###> to auto-number\r\n" +
//        "each song-title. Example: \"? <05>\" would generate titles from\r\n" +
//        "the filename and add 05, 06, 07, etc.");
      toolTips.SetToolTip(textTitle, textTitle.Text);
      toolTips.SetToolTip(textAlbum, textAlbum.Text);
      toolTips.SetToolTip(textArtist, textArtist.Text);
      toolTips.SetToolTip(textPerformer, textPerformer.Text);
      toolTips.SetToolTip(textComposer, textComposer.Text);
      toolTips.SetToolTip(textGenre, textGenre.Text);
      toolTips.SetToolTip(textPublisher, textPublisher.Text);
      toolTips.SetToolTip(textConductor, textConductor.Text);
      toolTips.SetToolTip(textYear, textYear.Text);
      toolTips.SetToolTip(textTrack, textTrack.Text);
      toolTips.SetToolTip(textDuration, textDuration.Text);
      toolTips.SetToolTip(textComments, textComments.Text);
      toolTips.SetToolTip(textLyrics, textLyrics.Text);
      toolTips.SetToolTip(textPath, textPath.Text);
      toolTips.Active = true;
      toolTips.ReshowDelay = 0;

      if (selectedItemCount > 1) Text = "TunesFiX: Edit " + selectedItemCount.ToString() + " Selected Items (ESC key quits)";
      else Text = "TunesFiX: Edit Selected Item (ESC key quits)";

      // Add handlers after text boxes loaded...
      // NOTE: Make sure all text-fields have "Accepts Tab" set to false
      // (we use tabs in in copy/paste to clipboard!)
      textAlbum.TextChanged += text_Changed;
      textAlbum.ContextMenuStrip = ctxMenu;
      textArtist.TextChanged += text_Changed;
      textArtist.ContextMenuStrip = ctxMenu;
      textTitle.TextChanged += text_Changed;
      textTitle.ContextMenuStrip = ctxMenu;
      textPerformer.TextChanged += text_Changed;
      textPerformer.ContextMenuStrip = ctxMenu;
      textComposer.TextChanged += text_Changed;
      textComposer.ContextMenuStrip = ctxMenu;
      textGenre.TextChanged += text_Changed;
      textGenre.ContextMenuStrip = ctxMenu;
      textPublisher.TextChanged += text_Changed;
      textPublisher.ContextMenuStrip = ctxMenu;
      textConductor.TextChanged += text_Changed;
      textConductor.ContextMenuStrip = ctxMenu;
      textYear.TextChanged += text_Changed;
      textYear.ContextMenuStrip = ctxMenu;
      textTrack.TextChanged += text_Changed;
      textTrack.ContextMenuStrip = ctxMenu;
      textDuration.TextChanged += text_Changed;
      textDuration.ContextMenuStrip = ctxMenu;
      textComments.TextChanged += text_Changed;
      textComments.ContextMenuStrip = ctxMenu;
      textLyrics.TextChanged += text_Changed;
      textLyrics.ContextMenuStrip = ctxMenu;
      textPath.TextChanged += text_Changed;
      textPath.ContextMenuStrip = ctxMenu;
    }

    private void FormEdit_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!bEscape)
      {
        songInfo = GetFields();

        SetChangeFlags();

        if (songInfo.FilePath.Length == 0)
        {
          songInfo.FilePath = saveSongInfo.FilePath;
          songInfo.bFilepathTag = false; // clear "path changed" flag
        }

        if (songInfo.AnyMainFlags())
        {
          this.DialogResult = MessageBox.Show("Save edited song-tag(s)?", "TunesFiX Editor",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

          // If the user plans to move, copy or rename files - be extra cautious!
          if (this.DialogResult.HasFlag(DialogResult.Yes) && songInfo.bFilepathTag)
          {
            if (MessageBox.Show("Caution! File MOVE, COPY or RENAME command:\n\n" +
                        "\"" + songInfo.FilePath + "\"\n\n" + "Are you sure?", "TunesFiX Editor",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.No)
              songInfo.bFilepathTag = false;
          }
        }
        else
        {
          if (songInfo.bFilepathTag)
            this.DialogResult = MessageBox.Show("File MOVE, COPY or RENAME command:\n\n" +
                        "\"" + songInfo.FilePath + "\"\n\n" + "Are you sure?", "TunesFiX Editor",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
          else
            this.DialogResult = MessageBox.Show("No changes were made. Add/Save tag(s) anyway?", "TunesFiX Editor",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
      }
      else
        this.DialogResult = DialogResult.No; // User hit escape key
    }

    private void FormEdit_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        bEscape = false;
        Close();
      }
      else if (e.KeyCode == Keys.Escape)
      {
        bEscape = true;
        Close();
      }
    }

    private void text_Changed(object sender, EventArgs e)
    {
      TextBox tb = sender as TextBox;

      // Slightly change color of any box that gets edited
      if (tb != null && tb.BackColor != SystemColors.Window)
        tb.BackColor = SystemColors.Window;
    }

    private void menuCut_Click(object sender, EventArgs e)
    {
      // menuCut
      try
      {
        ToolStripMenuItem mi = sender as ToolStripMenuItem;
        ContextMenuStrip cms = mi.Owner as ContextMenuStrip;
        TextBox tb = cms.SourceControl as TextBox;
        tb.Cut();
      }
      catch { }
    }

    private void menuCopy_Click(object sender, EventArgs e)
    {
      // menuCopy
      try
      {
        ToolStripMenuItem mi = sender as ToolStripMenuItem;
        ContextMenuStrip cms = mi.Owner as ContextMenuStrip;
        TextBox tb = cms.SourceControl as TextBox;
        tb.Copy();
      }
      catch { }
    }

    private void menuPaste_Click(object sender, EventArgs e)
    {
      // menuPaste
      try
      {
        ToolStripMenuItem mi = sender as ToolStripMenuItem;
        ContextMenuStrip cms = mi.Owner as ContextMenuStrip;
        TextBox tb = cms.SourceControl as TextBox;
        tb.Paste();
      }
      catch { }
    }

    private void menuSelectAll_Click(object sender, EventArgs e)
    {
      // menuSelectAll
      try
      {
        ToolStripMenuItem mi = sender as ToolStripMenuItem;
        ContextMenuStrip cms = mi.Owner as ContextMenuStrip;
        TextBox tb = cms.SourceControl as TextBox;
        tb.SelectAll();
      }
      catch { }
    }

    private void menuClear_Click(object sender, EventArgs e)
    {
      // menuClear
      try
      {
        ToolStripMenuItem mi = sender as ToolStripMenuItem;
        ContextMenuStrip cms = mi.Owner as ContextMenuStrip;
        TextBox tb = cms.SourceControl as TextBox;
        tb.Clear();
      }
      catch { }
    }

    private void helpToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // menuHelp
      try
      {
        ToolStripMenuItem mi = sender as ToolStripMenuItem;
        ContextMenuStrip cms = mi.Owner as ContextMenuStrip;
        TextBox tb = cms.SourceControl as TextBox;

        string helpString;

        if (tb == textPath) helpString = helpPath;
        else if (tb == textTitle) helpString = helpTitle;
        else helpString = helpOther;

        MessageBox.Show(helpString, "TunesFiX");
      }
      catch { }
    }

    private void labelHelp_Click(object sender, EventArgs e)
    {
      // labelHelp
      try
      {
        Label l = sender as Label;

        string helpString;

        if (l == labelPath) helpString = helpPath;
        else if (l == labelTitle) helpString = helpTitle;
        else if (l == labelTrack) helpString = helpTrack;
        else helpString = helpOther;

        MessageBox.Show(helpString, "TunesFiX");
      }
      catch
      {
      }
    }

    private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      MessageBox.Show(helpMenu, "TunesFiX");
    }

    /// <summary>
    /// Copy text fields to the clipboard as tab-separated text
    /// (need CLIPBOARD_COUNT tab-separated strings!)
    /// </summary>
    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        SongInfo si = GetFields();

        // Put all fields into one tab-separated string
        string s = CLIPBOARD_QUAL_STRING + "\t" +
          si.Title + "\t" +
          si.Artist + "\t" +
          si.Album + "\t" +
          si.Performer + "\t" +
          si.Composer + "\t" +
          si.Genre + "\t" +
          si.Publisher + "\t" +
          si.Conductor + "\t" +
          si.Year + "\t" +
          si.Track + "\t" +
          si.Duration.ToString("c") + "\t" + // use constant (invarient) time format (all .NET versions!)
          si.Comments + "\t" +
          si.Lyrics + "\t" +
          si.FilePath;

        // Write our tag-data to the windows clipboard
        Clipboard.SetText(s, TextDataFormat.CommaSeparatedValue);
        pasteToolStripMenuItem.Enabled = true;
      }
      catch { }
    }

    /// <summary>
    /// Paste tab-separated text from the clipboard to the dialog's text-fields
    /// </summary>
    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        string[] parts = Clipboard.GetText(TextDataFormat.CommaSeparatedValue).Split('\t');
        List<string> sl = new List<string>(parts);

        if (sl.Count == CLIPBOARD_COUNT && sl[0].ToLower() == CLIPBOARD_QUAL_STRING.ToLower())
        {
          var si = new SongInfo();

          si.Title = sl[1];
          si.Artist = sl[2];
          si.Album = sl[3];
          si.Performer = sl[4];
          si.Composer = sl[5];
          si.Genre = sl[6];
          si.Publisher = sl[7];
          si.Conductor = sl[8];
          si.Year = sl[9];
          si.Track = sl[10];

          // search "msdn standard timespan format strings"
          try { si.Duration = TimeSpan.Parse(sl[11]); } // we pass time in invarient "c" format...
          catch { si.Duration = TimeSpan.FromSeconds(0); }

          si.Comments = sl[12];
          si.Lyrics = sl[13];
          si.FilePath = sl[14];

          PutFields(si, true); // paste into all fields except the file-path!
        }
        else
          MessageBox.Show(STR1);
      }
      catch
      {
        MessageBox.Show(STR1);
      }
    }

    /// <summary>
    /// Set the text-was-edited flag true or false for each field
    /// </summary>
    private void SetChangeFlags()
    {
      try
      {
        // Base change on window-color change from text_Changed events - don't use saveSongInfo because
        // the text written to the text-box may not be identical to the value in saveSongInfo or songInfo!
        songInfo.bTitleTag = (textTitle.BackColor == SystemColors.Window) ? true : false;
        songInfo.bArtistTag = (textArtist.BackColor == SystemColors.Window) ? true : false;
        songInfo.bAlbumTag = (textAlbum.BackColor == SystemColors.Window) ? true : false;
        songInfo.bPerformerTag = (textPerformer.BackColor == SystemColors.Window) ? true : false;
        songInfo.bComposerTag = (textComposer.BackColor == SystemColors.Window) ? true : false;
        songInfo.bGenreTag = (textGenre.BackColor == SystemColors.Window) ? true : false;
        songInfo.bPublisherTag = (textPublisher.BackColor == SystemColors.Window) ? true : false;
        songInfo.bConductorTag = (textConductor.BackColor == SystemColors.Window) ? true : false;
        songInfo.bYearTag = (textYear.BackColor == SystemColors.Window) ? true : false;
        songInfo.bTrackTag = (textTrack.BackColor == SystemColors.Window) ? true : false;
        songInfo.bDurationTag = (textDuration.BackColor == SystemColors.Window) ? true : false;
        songInfo.bCommentsTag = (textComments.BackColor == SystemColors.Window) ? true : false;
        songInfo.bLyricsTag = (textLyrics.BackColor == SystemColors.Window) ? true : false;
        songInfo.bFilepathTag = (textPath.BackColor == SystemColors.Window) ? true : false;
      }
      catch { }
    }

    /// <summary>
    /// Read the text boxes into a SongInfo struct
    /// </summary>
    private SongInfo GetFields()
    {
      var si = new SongInfo();

      try
      {
        si.Title = textTitle.Text;
        si.Artist = textArtist.Text;
        si.Album = textAlbum.Text;
        si.Performer = textPerformer.Text;
        si.Composer = textComposer.Text;
        si.Genre = textGenre.Text;
        si.Publisher = textPublisher.Text;
        si.Conductor = textConductor.Text;
        si.Year = textYear.Text;
        si.Track = textTrack.Text;
        si.Duration = this.Duration; // textDuration.Text is read-only!
        si.Comments = textComments.Text;
        si.Lyrics = textLyrics.Text;
        si.FilePath = textPath.Text;
      }
      catch { }

      return si;
    }

    /// <summary>
    /// Write a SongInfo struct to the text boxes
    /// </summary>
    private bool PutFields(SongInfo si, bool bSkipPath = false)
    {
      try
      {
        textTitle.Text = si.Title;
        textArtist.Text = si.Artist;
        textAlbum.Text = si.Album;
        textPerformer.Text = si.Performer;
        textComposer.Text = si.Composer;
        textGenre.Text = si.Genre;
        textPublisher.Text = si.Publisher;
        textConductor.Text = si.Conductor;
        textYear.Text = si.Year;
        textTrack.Text = si.Track;

        // this field is read-only! (remove leading 00: and trailing fraction)
        if (si.Duration.TotalSeconds == 0)
          textDuration.Text = "*";
        else
        {
          string s = si.Duration.ToString("g"); // short-format, culture-sensitive
          while (s.Length > 1 && (s.StartsWith("0") || s.StartsWith(":")))
            s = s.Remove(0, 1);
          int pos = s.LastIndexOf(".");
          if (pos >= 0)
            s = s.Substring(0, pos);
          textDuration.Text = s;
        }

        textComments.Text = si.Comments;
        textLyrics.Text = si.Lyrics;
        if (!bSkipPath) textPath.Text = si.FilePath;

        // If the field is empty set it Gray
        if (textTitle.Text == "") textTitle.BackColor = Color.LightGray;
        if (textArtist.Text == "") textArtist.BackColor = Color.LightGray;
        if (textAlbum.Text == "") textAlbum.BackColor = Color.LightGray;
        if (textPerformer.Text == "") textPerformer.BackColor = Color.LightGray;
        if (textComposer.Text == "") textComposer.BackColor = Color.LightGray;
        if (textGenre.Text == "") textGenre.BackColor = Color.LightGray;
        if (textPublisher.Text == "") textPublisher.BackColor = Color.LightGray;
        if (textConductor.Text == "") textConductor.BackColor = Color.LightGray;
        if (textYear.Text == "") textYear.BackColor = Color.LightGray;
        if (textTrack.Text == "") textTrack.BackColor = Color.LightGray;
        if (textDuration.Text == "") textDuration.BackColor = Color.LightGray;
        if (textComments.Text == "") textComments.BackColor = Color.LightGray;
        if (textLyrics.Text == "") textLyrics.BackColor = Color.LightGray;
        if (textPath.Text == "") textPath.BackColor = Color.LightGray;

        return true;
      }
      catch { return false; }
    }

    /// <summary>
    /// Check to see if we have any tag-data on the clipboard
    /// </summary>
    private bool haveClipboardData()
    {
      try
      {
        string[] parts = Clipboard.GetText(TextDataFormat.CommaSeparatedValue).Split('\t');
        List<string> sl = new List<string>(parts);

        if (sl.Count != CLIPBOARD_COUNT || sl[0].ToLower() != CLIPBOARD_QUAL_STRING.ToLower()) return false;
      }
      catch { return false; }

      return true;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
