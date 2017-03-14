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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Diagnostics; // "Process" needs this...
using System.Windows.Forms;
using MediaTags;
using MsgBoxCheck;
using ColumnSorter;
using Microsoft.Win32; // used for registry access...
using IWshRuntimeLibrary; // used to access shortcut file-paths...
//-----------
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;
using System.Xml.Serialization;
//-----------
//using Hqub.MusicBrainze.API;
//using Hqub.MusicBrainze.API.Entities;
//using AcoustID; //  Chromaprint, Web, Util, Audio
//using AcoustID.Web;

namespace TunesFiX
{
  public interface IMainForm
  {
    List<string> FileFilterList { get; set; }
  }

  public partial class FormMain : Form, IMainForm
  {
    #region Constants

    // Registry key for the "do not show again" custom message box
    internal const string MSGBOXREGKEY = @"Software\Discrete-Time Systems\TunesFiX\MsgBoxCheck";
    internal const string REGKEY = @"Software\Discrete-Time Systems\TunesFiX";

    // Directories used to copy or move files to...
    internal const string CONST_TUNESFIXTEMP = "!TUNESFIX_TEMP"; // Temp directory we use
    internal const string CONST_TUNESFIXCOPY = "!TUNESFIX_COPY"; // Temp directory we use

    internal const string TUNESFIX = "TunesFiX";
    internal const string SHORTCUT_FILE = @"TunesFiX.lnk";
    internal const string HELPSITE = "http://www.yahcolorize.com/TunesFiX/help/TunesFiX.htm";
    internal const string UNINSTALL_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

    // Path to write dynamic play-list to for WMP
    internal const string PLAYLIST_PATH = @"\Discrete-Time Systems\TunesFiX\";
    internal const string PLAYLIST_NAME = @"TunesFiX.wpl";

    // Messages that appear in richTextBox to help the user decide what to do
    internal const string MSG_A = "Importing music via iTunes may leave your compilations scattered " +
          "into many folders \"by artist\" instead of organizing them into one folder. " +
          "TunesFiX restores music compilations to their original folders. TunesFiX can also " +
          "move song files and album art to new file-paths constructed from the tag " +
          "information. You can group edit song tags for both mp3 and wma files. " +
          "Click \"File\" to load your music library...";

    internal const string MSG_B = "Loading music-files (no changes are being made yet!)\r\nplease wait...\r\nPRESS ESC TO CANCEL!";

    internal const string MSG_C = "Press the \"Set Checks\" button to select options for sorting your music... " +
      "Color code: Black = \"have tag info\", Gray = \"no tag info\", Blue = \"info taken from file-path\" " +
      "(Song, Artist and/or Album may be filled in from the file-path names), Red = \"error reading tag\".";

    // Items were auto-selected after checks set...
    internal const string MSG_D = "Items in the list that are checked have some discrepancy " +
           "between the tag's Artist or Album and the expected directory srtucture \\ARTIST\\ALBUM\\SONG. " +
           "If any songs were auto-selected, they are missing the Album and/or Artist tag. Press the PROCESS " +
           "button and press OK to automatically add tags to these songs from the file path... or " +
           "you can double-click a song to edit its tag or press CTRL+E to edit tags for a group of selected songs.";

    // No items were auto-selected after checks set...
    internal const string MSG_E = "Items in the list that are checked have some discrepancy " +
           "between the tag's Artist or Album and the expected directory srtucture \\ARTIST\\ALBUM\\SONG. " +
           "Press the PROCESS button and chose the mode. (need more here!)";

    // Popup messagebox messages the user can check "Do Not Show Again" for
    internal const string MSGBOX_A = "Press the \"Set Checks\" button to continue...";

    internal const string MSGBOX_B1 = "Create new directories for the selected songs and move files?";
    internal const string MSGBOX_B2 = "Create new tags for the selected songs using the file-path and name?";

    internal const string MSGBOX_C = "Next, you will want to use the checked songs as a guide for selecting groups of songs" +
           " and processing them. Usually you will want to select checked songs that all belong to a particular album." +
           " Hold the Ctrl key and click all of the songs you want to perform the same type of operation on. For example," +
           " click every song that:\r\n\r\n" +
           "A) Has accurate tag information such as Title, Artist and Album but\r\n" +
           "   the songs are in the wrong directory.\r\n\r\n" +
           "   or\r\n\r\n" +
           "B) The songs are in a directory of the format \"Artist\\Album\\Title.mp3\"\r\n" +
           "   but the tags are wrong.\r\n\r\n" +
           "Then press the \"Process\" button...";

    internal const string MSGBROWSER = "Select a destination folder for your " +
                         "music. New folders will be created in and songs will be moved into the " +
                         "EXACT folder you select. Usually you want to select your top-level music folder.";

    internal const string MSGTOOLTIP_A = "Check to format clipboard text into rows and columns\r\n" + 
        "you can paste into Microsoft Excel.";

    internal const string MSGTOOLTIP_B = "Click to organize/move your music compilations\r\n" + "by album-title.";

    internal const string MSGDBTAP = "You need to select the songs you want to modify. First press \"Set Checks\"\r\n" +
          "to flag the songs you may want to select for processing. Select songs\r\n" +
          "by pressing Ctrl and clicking them. Then press the Process button.";

    internal const string MSGCOMP = "Items in the list that are checked should belong to compilations. " +
           "Please review the list of songs and manually check/uncheck items that " +
           "you want to change, then press the PROCESS button to organize the " +
           "checked items into directories by ALBUM NAME rather than by ARTIST...";

    // folderBrowserDialog
    internal const string MSGFBD_REMOVEEMPTYDIR = "Select a root folder. All empty folders " +
                      "inside the folder you choose will be removed, including the " +
                      "folder you choose, if it is empty.";

    internal const string MSGFBD_OPENMUSICFOLDER = "Select your root music folder. " +
                        "(For example: My Music\\iTunes\\iTunes Media\\Music)";

    internal const string MSGSTATUS_A = "Transfering album art images and removing empty folders...\r\n" + "PRESS ESC TO CANCEL!";

    internal const string MSGSTATUS_B = "Copying selected files, please wait...\r\n" + "PRESS ESC TO CANCEL!";

    internal const string MSGSTATUS_C = "Removing unchecked items, please wait...\r\n" + "PRESS ESC TO CANCEL!";

    internal const int LV_FIELD_COUNT = 14; // # of fields in SongView

    // Check the uint sFieldVisible to see which fields to show Title Artist and Album are always visible
    // the integer assignments below also represent the actual flag-bit in sFieldVisible
    internal const int LV_FIELD_TITLE = 0;
    internal const int LV_FIELD_ARTIST = 1;
    internal const int LV_FIELD_ALBUM = 2;
    internal const int LV_FIELD_PERFORMER = 3;
    internal const int LV_FIELD_COMPOSER = 4;
    internal const int LV_FIELD_GENRE = 5;
    internal const int LV_FIELD_PUBLISHER = 6;
    internal const int LV_FIELD_CONDUCTOR = 7;
    internal const int LV_FIELD_YEAR = 8;
    internal const int LV_FIELD_TRACK = 9;
    internal const int LV_FIELD_DURATION = 10;
    internal const int LV_FIELD_COMMENTS = 11;
    internal const int LV_FIELD_LYRICS = 12;
    internal const int LV_FIELD_PATH = 13;

    //---------------------------------------------------------------------------
    #endregion

    #region Vars

    // used with fileSystemWatcher1
    private string g_watcherOldPath, g_watcherNewPath;
    private bool g_watcherDeleted, g_watcherRenamed;

    private string g_rootPath;
    private int g_fieldVisible;
    private int g_keyPressed = -1;
    //    private MediaTags.MediaTags g_tagReader = null;
    private ListViewColumnSorter g_lvwColumnSorter;

    private int g_findNextIndex = -1;
    private string g_findNextText = "";

    // This is used after checks have been set and we have auto-selected songs with missing
    // tag-info. When the user presses Process this var determines which mode is set in the
    // processing mode dialog.
    private bool g_initPathToTag = false;

    // These flags are used when we load songView with info and one of these fields was
    // empty and we are able to fill it out by parsing the file-path. We need a flag to
    // determine what color to display in the field.
    private bool g_pathTitle;
    private bool g_pathArtist;
    private bool g_pathAlbum;

    // Declare a Form global boolean to keep the ItemChecked event from being called in an infinite loop
    // (Fix for multi-selecting items causing all the checkboxes to be checked too!)
    bool g_bFirstChange = true;

    // These vars are set from the FormSetChecks.cs properties
    private int g_checkingMode;
    private bool g_excludeCompilations;
    private bool g_ignorePrefix;

    private string g_prefix;
    private double g_ratio = .50; // % of songs in album that define a "collection"
    private int g_minSongs = 4; // Minimum songs in a collection

    // Global counters
    private int g_fileCount = 0;
    private int g_dirCount = 0;
    private int g_copyCount = 0;
    private int g_RemoveCounter = 0;
    private int g_FailCounter = 0;

    // Drag/Drop
    private string g_dragSourcePath;
    private Rectangle g_dragBox;

    #endregion

    #region Properties

    public string Version { get {return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);} }

    // Here the calling program sets the file-filters
    // such as .mp3|.wma|.wav
    private List<string> g_fileFilterList;
    public List<string> FileFilterList
    {
      get { return this.g_fileFilterList; }
      set { this.g_fileFilterList = value; }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Init and Load

    public FormMain()
    {
      InitializeComponent();

      RegistryRead(); // Do this after lists created and before volumes set...

      // Init our songs ListBox
      songView.HeaderStyle = ColumnHeaderStyle.Clickable;
      //songView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      songView.FullRowSelect = true;
      songView.MultiSelect = true;
      songView.AllowColumnReorder = false;
      songView.View = System.Windows.Forms.View.Details;
      //songView.OwnerDraw = true;
      //songView.DrawColumnHeader +=
      //    new DrawListViewColumnHeaderEventHandler(songView_DrawColumnHeader);
      //songView.DrawSubItem +=
      //    new DrawListViewSubItemEventHandler(songView_DrawSubItem);

      // Set up the ToolTip text for the Button and Checkbox.
      toolTips.SetToolTip(checkBoxExcel, MSGTOOLTIP_A);

      toolTips.SetToolTip(buttonSetChecks, MSGTOOLTIP_B);

      SetMenuChecksFromFieldVisible(); // Set the default view-menu checkmarks

      SongViewInit();

      //try
      //{
        // Get our Guid
        //Assembly asm = Assembly.GetExecutingAssembly();
        //var attribute = (GuidAttribute)asm.GetCustomAttributes(typeof(GuidAttribute), true)[0];
        //var id = attribute.Value;
        //UninstallGuid = Guid.Parse(id.ToString());
        //Clipboard.SetText(UninstallGuid.ToString());

        // Add TunesFiX to the Add/Remove programs list
        //if (IsNewRevision()) CreateUninstaller();
      //}
      //catch
      //{
      //}

      // Create an instance of a ListView column sorter and assign it 
      // to the songView control.
      g_lvwColumnSorter = new ListViewColumnSorter();

      this.Text = "TunesFiX: " + Version;

      // Set the main edit menu the same as the pop-up menu...
      menuEdit.DropDown = contextMenuStrip1;

      // The GlobalNotifier class (see below) defines the OnItemDoubleClicked event which
      // is manually fired from BufferedListView when the user double-clicks an item. The
      // purpose is to avoid toggling the listView's checkbox on a double-click...
      GlobalNotifier.ItemDoubleClicked += new DoubleClickedEventHandler(GlobalNotifier_ItemDoubleClicked);
    }
    //---------------------------------------------------------------------------
    private void FormMain_Shown(object sender, EventArgs e)
    {
      // Process command-line option to uninstall
      //string[] args = Environment.GetCommandLineArgs();
      //if (args.Length > 1)
      //{
      //  if (args[1].ToLower() == "/uninstall")
      //    uninstallMenuItem_Click(null, null);
      //}
    }
    //---------------------------------------------------------------------------
    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      RegistryWrite();
    }
    //---------------------------------------------------------------------------
    private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      // Had to add this to keep the sorting thread from perpetually
      // continuing...
      Environment.Exit(1);
    }
    //---------------------------------------------------------------------------
    private void RegistryRead(bool bReset = false)
    {
      string sFileFilters = ".wma .mp3 .wav .aif .aiff";
      int iMinSongs = 4;
      int iPercent = 50;
      string sRootPath = "";
      int iFieldVisible = 4623;
      int iCheckingMode = 1;
      bool bExcludeCompilations = true;
      bool bIgnorePrefix = true;
      string sPrefix = "The";

      if (!bReset)
      {
        RegistryKey key;

        using (key = Registry.CurrentUser.OpenSubKey(REGKEY, false))
        {
          if (key != null)
          {
            try
            {
              sFileFilters = (string)key.GetValue("sFileFilters");
              iMinSongs = (int)key.GetValue("iMinSongs");
              iPercent = (int)key.GetValue("iPercent");
              sRootPath = (string)key.GetValue("sRootPath");
              iFieldVisible = (int)key.GetValue("iFieldVisible");
              iCheckingMode = (int)key.GetValue("iCheckingMode");
              bExcludeCompilations = (bool)key.GetValue("bExcludeCompilations");
              bIgnorePrefix = (bool)key.GetValue("bIgnorePrefix");
              sPrefix = (string)key.GetValue("sPrefix");
            }
            catch { }
          }
        }
      }

      g_fileFilterList = EncodeFilters(sFileFilters);

      g_minSongs = iMinSongs;
      g_ratio = (double)iPercent / 100.0;

      g_rootPath = sRootPath;

      if (string.IsNullOrEmpty(g_rootPath))
        g_rootPath = Environment.SpecialFolder.MyMusic.ToString();

      g_fieldVisible = iFieldVisible;
      g_excludeCompilations = bExcludeCompilations;
      g_checkingMode = iCheckingMode;
      g_ignorePrefix = bIgnorePrefix;
      g_prefix = sPrefix;
    }
    //---------------------------------------------------------------------------
    private bool RegistryWrite()
    {
      RegistryKey key;

      using (key = Registry.CurrentUser.OpenSubKey(REGKEY, true))
      {
        if ((key = Registry.CurrentUser.CreateSubKey(REGKEY)) == null)
          return false;

        try
        {
          key.SetValue("sFileFilters", DecodeFilters(g_fileFilterList));
          key.SetValue("iMinSongs", g_minSongs);
          key.SetValue("iPercent", (int)(g_ratio * 100));
          key.SetValue("sRootPath", g_rootPath);
          key.SetValue("iFieldVisible", g_fieldVisible);
          key.SetValue("iCheckingMode", g_checkingMode);
          key.SetValue("bExcludeCompilations", g_excludeCompilations);
          key.SetValue("bIgnorePrefix", g_ignorePrefix);
          key.SetValue("sPrefix", g_prefix);
        }
        catch
        {
          return false;
        }
      }

      return true;
    }
    //---------------------------------------------------------------------------
    //void songView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    //{
    //  if ((e.ItemState & ListViewItemStates.Focused) == 0)
    //  {
    //    e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
    //    e.Graphics.DrawString(e.Item.Text, songView.Font,
    //        SystemBrushes.HighlightText, e.Bounds);
    //  }
    //  else
    //  {
    //    e.DrawBackground();
    //    e.DrawText();
    //  }
    //}
    ////---------------------------------------------------------------------------

    //void songView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    //{
    //    e.Graphics.FillRectangle(Brushes.GreenYellow, e.Bounds);
    //    e.DrawText();
    //}
    //---------------------------------------------------------------------------
    protected void SongViewInit()
    {
      // Check the uint sFieldVisible to see which fields to show Title Artist and Album are always visible
      // the integer assignments below also represent the actual flag-bit in sFieldVisible
      // LV_FIELD_TITLE = 0;
      // LV_FIELD_ARTIST = 1;
      // LV_FIELD_ALBUM = 2;
      // LV_FIELD_PERFORMER = 3;
      // LV_FIELD_COMPOSER = 4;
      // LV_FIELD_GENRE = 5;
      // LV_FIELD_PUBLISHER = 6;
      // LV_FIELD_CONDUCTOR = 7;
      // LV_FIELD_YEAR = 8;
      // LV_FIELD_TRACK = 9;
      // LV_FIELD_DURATION = 10;
      // LV_FIELD_COMMENTS = 11;
      // LV_FIELD_LYRICS = 12;
      // LV_FIELD_PATH = 13;
      try
      {
        this.songView.ListViewItemSorter = null; // disable sorting

        richTextBox.Text = MSG_A;

        //init songView control
        songView.Clear();		//clear control
        songView.Columns.Add("Song", 140, System.Windows.Forms.HorizontalAlignment.Left);
        songView.Columns.Add("Artist", 110, System.Windows.Forms.HorizontalAlignment.Left);
        songView.Columns.Add("Album", 140, System.Windows.Forms.HorizontalAlignment.Left);

        // Fields the user can choose to be visible or not...
        int iWidth = (g_fieldVisible & (1 << LV_FIELD_PERFORMER)) != 0 ? 110 : 0;
        songView.Columns.Add("Performer", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_COMPOSER)) != 0 ? 110 : 0;
        songView.Columns.Add("Composer", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_GENRE)) != 0 ? 110 : 0;
        songView.Columns.Add("Genre", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_PUBLISHER)) != 0 ? 110 : 0;
        songView.Columns.Add("Publisher", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_CONDUCTOR)) != 0 ? 110 : 0;
        songView.Columns.Add("Conductor", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_YEAR)) != 0 ? 50 : 0;
        songView.Columns.Add("Year", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_TRACK)) != 0 ? 50 : 0;
        songView.Columns.Add("Track", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_DURATION)) != 0 ? 50 : 0;
        songView.Columns.Add("Time", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_COMMENTS)) != 0 ? 140 : 0;
        songView.Columns.Add("Comments", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_LYRICS)) != 0 ? 140 : 0;
        songView.Columns.Add("Lyrics", iWidth, System.Windows.Forms.HorizontalAlignment.Left);
        iWidth = (g_fieldVisible & (1 << LV_FIELD_PATH)) != 0 ? 3000 : 0;
        songView.Columns.Add("Path", iWidth, System.Windows.Forms.HorizontalAlignment.Left);

        buttonSetChecks.Enabled = false;
        buttonProcess.Enabled = false;

        songView.UseWaitCursor = false;
        this.progressBar.Value = 0;
        this.g_keyPressed = -1;

        // Clear text-find...
        g_findNextIndex = -1;
        g_findNextText = "";
      }
      catch
      {
        MessageBox.Show("Error in SongViewInit()", TUNESFIX);
      }
    }
    //---------------------------------------------------------------------------
    protected void SongViewRefresh()
    {
      // Check the uint sFieldVisible to see which fields to show Title Artist and Album are always visible
      // the integer assignments below also represent the actual flag-bit in g_fieldVisible
      // LV_FIELD_TITLE = 0;
      // LV_FIELD_ARTIST = 1;
      // LV_FIELD_ALBUM = 2;
      // LV_FIELD_PERFORMER = 3;
      // LV_FIELD_COMPOSER = 4;
      // LV_FIELD_GENRE = 5;
      // LV_FIELD_PUBLISHER = 6;
      // LV_FIELD_CONDUCTOR = 7;
      // LV_FIELD_YEAR = 8;
      // LV_FIELD_TRACK = 9;
      // LV_FIELD_DURATION = 10;
      // LV_FIELD_COMMENTS = 11;
      // LV_FIELD_LYRICS = 12;
      // LV_FIELD_PATH = 13;
      try
      {
        if (songView.Columns.Count != LV_FIELD_COUNT) return;

        //refresh songView control
        songView.Columns[LV_FIELD_TITLE].Width = 140;
        songView.Columns[LV_FIELD_ARTIST].Width = 110;
        songView.Columns[LV_FIELD_ALBUM].Width = 140;

        int iWidth = (g_fieldVisible & (1 << LV_FIELD_PERFORMER)) != 0 ? 110 : 0;
        songView.Columns[LV_FIELD_PERFORMER].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_COMPOSER)) != 0 ? 110 : 0;
        songView.Columns[LV_FIELD_COMPOSER].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_GENRE)) != 0 ? 110 : 0;
        songView.Columns[LV_FIELD_GENRE].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_PUBLISHER)) != 0 ? 110 : 0;
        songView.Columns[LV_FIELD_PUBLISHER].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_CONDUCTOR)) != 0 ? 110 : 0;
        songView.Columns[LV_FIELD_CONDUCTOR].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_YEAR)) != 0 ? 50 : 0;
        songView.Columns[LV_FIELD_YEAR].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_TRACK)) != 0 ? 50 : 0;
        songView.Columns[LV_FIELD_TRACK].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_DURATION)) != 0 ? 50 : 0;
        songView.Columns[LV_FIELD_DURATION].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_COMMENTS)) != 0 ? 140 : 0;
        songView.Columns[LV_FIELD_COMMENTS].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_LYRICS)) != 0 ? 140 : 0;
        songView.Columns[LV_FIELD_LYRICS].Width = iWidth;
        iWidth = (g_fieldVisible & (1 << LV_FIELD_PATH)) != 0 ? 3000 : 0;
        songView.Columns[LV_FIELD_PATH].Width = iWidth;
        songView.Update();
      }
      catch
      {
        MessageBox.Show("Error in SongViewRefresh()", TUNESFIX);
      }
    }
    //---------------------------------------------------------------------------
    private void SetFieldVisibleFromMenuChecks()
    {
      // Set fieldVisible based on menu checks
      g_fieldVisible = 0;
      g_fieldVisible |= (1 << LV_FIELD_TITLE);
      g_fieldVisible |= (1 << LV_FIELD_ARTIST);
      g_fieldVisible |= (1 << LV_FIELD_ALBUM);
      if (viewPerformerMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_PERFORMER);
      if (viewComposerMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_COMPOSER);
      if (viewGenreMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_GENRE);
      if (viewPublisherMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_PUBLISHER);
      if (viewConductorMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_CONDUCTOR);
      if (viewYearMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_YEAR);
      if (viewTrackMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_TRACK);
      if (viewDurationMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_DURATION);
      if (viewCommentsMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_COMMENTS);
      if (viewLyricsMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_LYRICS);
      if (viewPathMenuItem.Checked) g_fieldVisible |= (1 << LV_FIELD_PATH);
      //MessageBox.Show(g_fieldVisible.ToString()); // use this to set Settings initial value
    }
    //---------------------------------------------------------------------------
    private void SetMenuChecksFromFieldVisible()
    {
      // Init the View menu's checkmarks based on flags in fieldVisible
      //MessageBox.Show(g_fieldVisible.ToString()); // use this to set Settings initial value
      viewPerformerMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_PERFORMER)) != 0 ? true : false;
      viewComposerMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_COMPOSER)) != 0 ? true : false;
      viewGenreMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_GENRE)) != 0 ? true : false;
      viewPublisherMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_PUBLISHER)) != 0 ? true : false;
      viewConductorMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_CONDUCTOR)) != 0 ? true : false;
      viewYearMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_YEAR)) != 0 ? true : false;
      viewTrackMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_TRACK)) != 0 ? true : false;
      viewDurationMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_DURATION)) != 0 ? true : false;
      viewCommentsMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_COMMENTS)) != 0 ? true : false;
      viewLyricsMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_LYRICS)) != 0 ? true : false;
      viewPathMenuItem.Checked = (g_fieldVisible & (1 << LV_FIELD_PATH)) != 0 ? true : false;
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Add Files to Song List

    private int ProcessMusicFiles(string path)
    {
      int result = 0;

      try
      {
        DisableControls(); // Don't allow check-boxes to operate...

        SongViewInit();

        List<string> allfiles = new List<string>();

        using (FormStatus fs = new FormStatus(this))
        {
          fs.BodyText = MSG_B;
          fs.ProgressVisible = true;
          fs.Show(this);
          fs.Update();

          allfiles = GetAllFilesRecurse(path);

          using (MediaTags.MediaTags tagReader = new MediaTags.MediaTags(g_rootPath))
          {
            //MessageBox.Show(tagReader.FileFilters);

            for (int ii = 0; ii < allfiles.Count; ii++)
            {
              //if ((ii & 0xf) == 0)
              //{
              if (g_watcherDeleted || g_watcherRenamed)
                break;

              fs.ProgressValue = progressBar.Value = (100 * (ii + 1) / allfiles.Count);
                
              Application.DoEvents();

              if (fs.KeyPressed >= 0 || this.g_keyPressed >= 0)
              {
                result = 1; // Cancel
                break;
              }
              //}

              if (AddFileToSongView(tagReader, allfiles[ii]) == false)
              {
                result = -1; // Error
                break;
              }
            }
          }

          fs.Close();
        }
      }
      catch
      {
        result = -2; // Error
      }

      if (result == 0)
      {
        TFsort();

        progressBar.Value = 0;

        string msg = MSGBOX_A;
        MsgBox dlg = new MsgBox();
        DialogResult dr = dlg.Show(MSGBOXREGKEY, "DontShow2", DialogResult.OK, "Don't show this again",
          msg, TUNESFIX, MessageBoxButtons.OK, MessageBoxIcon.Information);

        richTextBox.Text = MSG_C;
      }

      NotifyIfFileChanged();

      EnableControls();

      return result;
    }
    //---------------------------------------------------------------------------
    private List<string> GetAllFilesRecurse(string path)
    {
      string[] allfiles = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);

      List<string> list = new List<string>();

      foreach (string file in allfiles)
      {
        if (g_watcherDeleted || g_watcherRenamed)
          break;

        if (System.IO.Path.GetExtension(file).ToLower() == ".lnk")
        {
          // Get shortcut's real path and add it if valid
          WshShell shell = new WshShell();

          //Link the interface to our shortcut
          WshShortcut link = (WshShortcut)shell.CreateShortcut(file);

          //string s = file.Name + ", " + file.Directory + ", " + file.DirectoryName + ", " +
          //file.FullName + ", " + file.Extension + ", " + file.Exists;
          //MessageBox.Show(s);
          //string s = link.FullName + ", " + link.TargetPath + ", " + link.WorkingDirectory;
          //MessageBox.Show(s);

          if (Directory.Exists(link.TargetPath) == true)
            list.AddRange(GetAllFilesRecurse(link.TargetPath));
          else if (System.IO.File.Exists(link.TargetPath) == true)
            list.Add(link.TargetPath);
        }
        else
          list.Add(file);
      }

      return list;
    }
    //---------------------------------------------------------------------------
    private bool AddFileToSongView(MediaTags.MediaTags tagReader, string rPath)
    {
      if (tagReader == null || String.IsNullOrEmpty(rPath)) return false;

      try
      {
        // Check the file's extension against the file-filter list
        if (g_fileFilterList.Count > 0)
        {
          if (FilterInList(Path.GetExtension(rPath).ToLower()))
            return AddSongViewData(tagReader, rPath);
        }
        else
          return AddSongViewData(tagReader, rPath);
      }
      catch { return false; }

      return true;
    }
    //---------------------------------------------------------------------------
    private bool AddSongViewData(MediaTags.MediaTags tagReader, string rPath, int idx = -1)
    // If we pass idx >= 0 we replace an existing item in songView...
    {
      if (tagReader == null || !System.IO.File.Exists(rPath)) return false;

      SongInfo si = tagReader.Read(rPath);
      if (si == null) return false;

      // Fill in info from the file-path if it's missing
      g_pathTitle = false;
      g_pathArtist = false;
      g_pathAlbum = false;

      try
      {
        if (!si.bTitleTag || (!si.bArtistTag && !si.bPerformerTag) || !si.bAlbumTag)
        {
          SongInfo2 pathsio = tagReader.ParsePath(rPath);

          if (!si.bTitleTag)
          {
            si.Title = pathsio.Title;
            if (!string.IsNullOrEmpty(si.Title)) g_pathTitle = true;
          }

          if (!si.bArtistTag && !si.bPerformerTag)
          {
            si.Artist = pathsio.Artist;
            if (!string.IsNullOrEmpty(si.Artist)) g_pathArtist = true;
          }

          if (!si.bAlbumTag)
          {
            si.Album = pathsio.Album;
            if (!string.IsNullOrEmpty(si.Album)) g_pathAlbum = true;
          }
        }
      }
      catch { si.bException = true; } // Threw an exception

      string[] lvData = new string[LV_FIELD_COUNT];

      try
      {
        // Check the uint sFieldVisible to see which fields to show Title Artist and Album are always visible
        // the integer assignments below also represent the actual flag-bit in sFieldVisible
        // LV_FIELD_TITLE = 0;
        // LV_FIELD_ARTIST = 1;
        // LV_FIELD_ALBUM = 2;
        // LV_FIELD_PERFORMER = 3;
        // LV_FIELD_COMPOSER = 4;
        // LV_FIELD_GENRE = 5;
        // LV_FIELD_PUBLISHER = 6;
        // LV_FIELD_CONDUCTOR = 7;
        // LV_FIELD_YEAR = 8;
        // LV_FIELD_TRACK = 9;
        // LV_FIELD_DURATION = 10;
        // LV_FIELD_COMMENTS = 11;
        // LV_FIELD_LYRICS = 12;
        // LV_FIELD_PATH = 13;

        //create listview data
        lvData[LV_FIELD_TITLE] = si.Title;
        lvData[LV_FIELD_ARTIST] = si.Artist;
        lvData[LV_FIELD_ALBUM] = si.Album;
        lvData[LV_FIELD_PERFORMER] = si.Performer;
        lvData[LV_FIELD_COMPOSER] = si.Composer;
        lvData[LV_FIELD_GENRE] = si.Genre;
        lvData[LV_FIELD_PUBLISHER] = si.Publisher;
        lvData[LV_FIELD_CONDUCTOR] = si.Conductor;
        lvData[LV_FIELD_YEAR] = si.Year;
        lvData[LV_FIELD_TRACK] = si.Track;

        // this field is read-only! (remove leading 00: and trailing fraction)
        if (si.Duration.TotalSeconds == 0)
          lvData[LV_FIELD_DURATION] = "*";
        else
        {
          string s = si.Duration.ToString("g"); // short-format, culture-sensitive
          while (s.Length > 1 && (s.StartsWith("0") || s.StartsWith(":")))
            s = s.Remove(0, 1);
          int pos = s.LastIndexOf(".");
          if (pos >= 0)
            s = s.Substring(0, pos);
          lvData[LV_FIELD_DURATION] = s;
        }

        lvData[LV_FIELD_COMMENTS] = si.Comments;
        lvData[LV_FIELD_LYRICS] = si.Lyrics;
        lvData[LV_FIELD_PATH] = rPath;

        ListViewItem lvi = new ListViewItem(lvData, 0);

        // Set the Tag property for each field to 1 if the actual tag exists in the song-file we read...
        // Also preserves the file-type and "exception thrown" condition in songView Tag properties...
        // (available for later use by the tag-editor or other algorithms). Also sets color black if
        // the actual tag for the item was read or gray if not.
        SetSubitemTags(lvi, si);

        if (idx >= 0)
        {
          if (songView.Items.Count == 0 || idx >= songView.Items.Count) return false;
          lvi.Selected = true; // Set it selected
          songView.Items[idx] = lvi; // Replace existing item
        }
        else
          songView.Items.Add(lvi); // Add new item

        return true;
      }
      catch
      {
        return false;
      }
    }
    //---------------------------------------------------------------------------
    // Set the Tag property for each field to 1 if the actual tag exists in the song-file we read...
    private bool SetSubitemTags(ListViewItem lvi, SongInfo si)
    {
      try
      {
        lvi.SubItems[LV_FIELD_TITLE].Tag = si.bTitleTag;
        lvi.SubItems[LV_FIELD_ARTIST].Tag = si.bArtistTag;
        lvi.SubItems[LV_FIELD_ALBUM].Tag = si.bAlbumTag;
        lvi.SubItems[LV_FIELD_PERFORMER].Tag = si.bPerformerTag;
        lvi.SubItems[LV_FIELD_COMPOSER].Tag = si.bComposerTag;
        lvi.SubItems[LV_FIELD_GENRE].Tag = si.bGenreTag;
        lvi.SubItems[LV_FIELD_PUBLISHER].Tag = si.bPublisherTag;
        lvi.SubItems[LV_FIELD_CONDUCTOR].Tag = si.bConductorTag;
        lvi.SubItems[LV_FIELD_YEAR].Tag = si.bYearTag;
        lvi.SubItems[LV_FIELD_TRACK].Tag = si.bTrackTag;
        lvi.SubItems[LV_FIELD_DURATION].Tag = si.bDurationTag;
        lvi.SubItems[LV_FIELD_COMMENTS].Tag = si.bCommentsTag;
        lvi.SubItems[LV_FIELD_LYRICS].Tag = si.bLyricsTag;

        // Put the file-type in the Path tag...
        lvi.SubItems[LV_FIELD_PATH].Tag = si.FileType;

        // use main item's Tag to save the duration TimeSpan
        lvi.Tag = si.Duration;

        // Set color red if exception during read or else black or gray
        if (si.bException)
          lvi.ForeColor = Color.Red;
        else
        {
          lvi.UseItemStyleForSubItems = false; // Allow subitem colors
          if (g_pathTitle) lvi.SubItems[LV_FIELD_TITLE].ForeColor = Color.Blue;
          else lvi.SubItems[LV_FIELD_TITLE].ForeColor = (si.bTitleTag ? Color.Black : Color.Gray);
          if (g_pathArtist) lvi.SubItems[LV_FIELD_ARTIST].ForeColor = Color.Blue;
          else lvi.SubItems[LV_FIELD_ARTIST].ForeColor = (si.bArtistTag ? Color.Black : Color.Gray);
          if (g_pathAlbum) lvi.SubItems[LV_FIELD_ALBUM].ForeColor = Color.Blue;
          else lvi.SubItems[LV_FIELD_ALBUM].ForeColor = (si.bAlbumTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_PERFORMER].ForeColor = (si.bPerformerTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_COMPOSER].ForeColor = (si.bComposerTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_GENRE].ForeColor = (si.bGenreTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_PUBLISHER].ForeColor = (si.bPublisherTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_CONDUCTOR].ForeColor = (si.bConductorTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_YEAR].ForeColor = (si.bYearTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_TRACK].ForeColor = (si.bTrackTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_DURATION].ForeColor = (si.bDurationTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_COMMENTS].ForeColor = (si.bCommentsTag ? Color.Black : Color.Gray);
          lvi.SubItems[LV_FIELD_LYRICS].ForeColor = (si.bLyricsTag ? Color.Black : Color.Gray);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }
    //---------------------------------------------------------------------------
    // Set the Tag property for each field to 1 if the actual tag exists in the song-file we read...
    private bool SetSubitemTags(ListViewItem lvi, SongInfo2 si)
    {
      try
      {
        lvi.SubItems[LV_FIELD_TITLE].Tag = si.bTitleTag;
        lvi.SubItems[LV_FIELD_ARTIST].Tag = si.bArtistTag;
        lvi.SubItems[LV_FIELD_ALBUM].Tag = si.bAlbumTag;
        lvi.SubItems[LV_FIELD_PERFORMER].Tag = si.bPerformerTag;
    
        // Put the file-type in the Path tag...
        lvi.SubItems[LV_FIELD_PATH].Tag = si.FileType;

        // use main item's Tag to save the duration TimeSpan
        lvi.Tag = si.Duration;

        // Set color red if exception during read or else black or gray
        if (si.bException)
          lvi.ForeColor = Color.Red;
        else
        {
          lvi.UseItemStyleForSubItems = false; // Allow subitem colors

          if (g_pathTitle) lvi.SubItems[LV_FIELD_TITLE].ForeColor = Color.Blue;
          else lvi.SubItems[LV_FIELD_TITLE].ForeColor = (si.bTitleTag ? Color.Black : Color.Gray);

          if (g_pathArtist) lvi.SubItems[LV_FIELD_ARTIST].ForeColor = Color.Blue;
          else lvi.SubItems[LV_FIELD_ARTIST].ForeColor = (si.bArtistTag ? Color.Black : Color.Gray);

          if (g_pathAlbum) lvi.SubItems[LV_FIELD_ALBUM].ForeColor = Color.Blue;
          else lvi.SubItems[LV_FIELD_ALBUM].ForeColor = (si.bAlbumTag ? Color.Black : Color.Gray);

          lvi.SubItems[LV_FIELD_PERFORMER].ForeColor = (si.bPerformerTag ? Color.Black : Color.Gray);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Set Checks

    private void buttonSetChecks_Click(object sender, EventArgs e)
    {
      SetCheckingMode();
    }
    //---------------------------------------------------------------------------
    private void SetCheckingMode()
    {
      DisableControls();

      using (FormSetChecks fsc = new FormSetChecks())
      {
        fsc.Mode = this.g_checkingMode;
        fsc.ExcludeCompillations = this.g_excludeCompilations;
        fsc.IgnorePrefix = this.g_ignorePrefix;
        fsc.Prefix = this.g_prefix;
        fsc.Ratio = this.g_ratio;
        fsc.MinSongs = this.g_minSongs;

        DialogResult dr = fsc.ShowDialog();

        if (dr == DialogResult.Cancel)
        {
          EnableControls();
          return;
        }

        this.g_checkingMode = fsc.Mode;
        this.g_excludeCompilations = fsc.ExcludeCompillations;
        this.g_ignorePrefix = fsc.IgnorePrefix;
        this.g_prefix = fsc.Prefix;
        this.g_ratio = fsc.Ratio;
        this.g_minSongs = fsc.MinSongs;
      }

      SetChecks();

      EnableControls();
    }
    //---------------------------------------------------------------------------
    private void SetChecks()
    {
      ClearAllChecks();

      if (this.g_checkingMode == FormSetChecks.SETCHECK_COMPILLATIONS)
        CheckCompillations();
      else
      {
        songView.SelectedItems.Clear();

        CheckDBTAP(this.g_excludeCompilations);

        if (songView.CheckedItems.Count == 0)
          MessageBox.Show("All of the songs in the list with tag-information appear to be\r\n" +
            "correctly ordered in the file-system...");
        else
        {
          songView.BeginUpdate();

          // Scan all checked songs and select any that have missing Title, Album or both Artist and Performer tag info
          // then open FormProcessing with Mode set to PROCESSING_PATHTOTAG. In the case of Artist, we don't want to
          // overwrite the field with path info if it has an alternate source from FirstPerformer/Author...
          foreach (ListViewItem lvi in songView.CheckedItems) if ((bool)lvi.SubItems[LV_FIELD_TITLE].Tag == false ||
             ((bool)lvi.SubItems[LV_FIELD_ARTIST].Tag == false && (bool)lvi.SubItems[LV_FIELD_PERFORMER].Tag == false) ||
               (bool)lvi.SubItems[LV_FIELD_ALBUM].Tag == false)
              lvi.Selected = true;

          songView.EndUpdate();

          if (songView.SelectedItems.Count > 0)
          {
            g_initPathToTag = true;
            MessageBox.Show("Songs with missing Album or Artist tags have been auto-selected.\r\n" +
              "Click OK then press the Process button to continue... or you can press Ctrl+E\r\n" +
              "to edit the selected tags and add the Album or Artist name.");
          }
          else
          {
            g_initPathToTag = false;

            string msg = MSGBOX_C;

            MsgBox dlg = new MsgBox();

            DialogResult dr = dlg.Show(MSGBOXREGKEY, "DontShow1", DialogResult.OK, "Don't show this again",
              msg, TUNESFIX, MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
    }
    //---------------------------------------------------------------------------
    private void CheckCompillations()
    {
      if (songView.Items.Count > 0)
      {
        if (!SetChecksFromList(GetCompilationList()))
        {
          MessageBox.Show("Error in SetChecksFromList()");
          return;
        }

        // Scroll to selected item
        if (songView.SelectedItems.Count > 0)
        {
          songView.TopItem = songView.SelectedItems[0];
          songView.TopItem.Focused = true;
        }

        richTextBox.Text = MSGCOMP;
      }
    }
    //---------------------------------------------------------------------------
    private void CheckDBTAP(bool bExcludeCompilations)
    {
      if (songView.Items.Count > 0)
      {
        if (bExcludeCompilations)
        {
          List<int> lNF = GetDBTAPList(); // List of items with mismatched tag and path
          List<int> lComp = GetCompilationList(); // items we want to delete from lNF

          // Go through list of songs that are in compillations and remove them from the list
          // of songs with mismatched tag/path...
          lComp.ForEach(item => lNF.Remove(item));

          // Remove items from lNF that have "prefix" in the Artist
          if (g_ignorePrefix && !String.IsNullOrEmpty(g_prefix))
          {
            string[] prefixes = g_prefix.Split(';'); // Get prefixes to ignore

            for (int ii = 0; ii < prefixes.Length; ii++)
              prefixes[ii] = StripToLower(prefixes[ii]); // Trim them up and compare lowercase only

            string artist, artistPath;
            string albumPath, titlePath; // not used

            // ignorePrefix prefix (this is where we have a user-prefix set to say "The"
            // and artist is "thepolice" (after eliminating non alphanumeric chars and converting to lower-case)
            // and artistPath is "police"... we don't want this song to be checked!)
            for (int ii = 0; ii < lNF.Count && ii < songView.Items.Count; ii++)
            {
              artist = GetArtist(songView.Items[lNF[ii]]);

              if (artist == string.Empty)
                continue;

              ParsePath(songView.Items[lNF[ii]].SubItems[LV_FIELD_PATH].Text, g_rootPath, out artistPath, out albumPath, out titlePath);

              if (artistPath == string.Empty)
                continue;

              foreach (string pre in prefixes)
              {
                if (pre == string.Empty)
                  continue;

                try
                {
                  // if either the artist in the tag starts with pre or the artist in the file-path starts
                  // with pre but not both...
                  if (artist.StartsWith(pre) ^ artistPath.StartsWith(pre))
                  {
                    // Remove this song from the checked-items if the artist in the tag matches the artist in the file-path
                    // after the prefix is removed from one or the other of the strings
                    if (artist.StartsWith(pre))
                      artist = artist.Substring(pre.Length, artist.Length - pre.Length).Trim();
                    else if (artistPath.StartsWith(pre))
                      artistPath = artistPath.Substring(pre.Length, artistPath.Length - pre.Length).Trim();

                    if (artist != string.Empty && artist == artistPath)
                    {
                      lNF.RemoveAt(ii);
                      //MessageBox.Show("removed: " + songView.Items[ii].SubItems[LV_FIELD_ARTIST].Text);
                      ii--; // correct index for removed item, it incriments in outer-loop and we don't want a goto!
                      break; // exit foreach string pre... continue with lNF.ForEach...
                    }
                  }
                }
                catch
                {
                  MessageBox.Show("Exception in CheckDBTAP() for prefix: \"" + pre + "\" and item: \"" + ii.ToString() + "\"");
                  return;
                }
              }
            }
          }

          if (!SetChecksFromList(lNF))
          {
            MessageBox.Show("Error in SetChecksFromList()");
            return;
          }

        }
        else
          SetChecksFromList(GetDBTAPList());

        // Scroll to selected item
        if (songView.SelectedItems.Count > 0)
        {
          songView.TopItem = songView.SelectedItems[0];
          songView.TopItem.Focused = true;
          richTextBox.Text = MSG_E;
        }
        else
          richTextBox.Text = MSG_D;

      }
    }
    //---------------------------------------------------------------------------
    // Return a list of songs that need to be checked because they are in a compillation
    // For this to work, the list MUST be pre-sorted by Album!
    private List<int> GetCompilationList()
    {
      if (songView.Items.Count <= 0) return null;

      songView.UseWaitCursor = true;

      try
      {
        string sPrevArtist = GetArtist(songView.Items[0]);
        string sPrevAlbum = GetAlbum(songView.Items[0]);
        string sPresArtist, sPresAlbum;

        int fileCounter = 1;
        int saveIndex = 0;
        double ratio = 0.0;

        bool bFirst = true;

        // Collection of artists on this album
        List<string> artists = new List<string>();

        // Checked list of songs to return
        List<int> checkedItemsList = new List<int>();

        int count = songView.Items.Count;

        for (int ii = 1; ii <= count; ii++)
        {
          // 0 means we put a check on every song...
          // re-order by album, then artist... for example, the
          // folder Steely Dan with two albums would now be deleted
          // and the two albums moved to the destination directory.
          if (g_minSongs == 0)
          {
            songView.Items[ii - 1].Checked = true;
            continue;
          }

          if (bFirst)
          {
            artists.Clear();

            fileCounter = 1;
            saveIndex = ii - 1; // Start of an album
            bFirst = false;
          }

          if (ii < count)
          {
            sPresArtist = GetArtist(songView.Items[ii]);
            sPresAlbum = GetAlbum(songView.Items[ii]);
          }
          else
            sPresAlbum = sPresArtist = string.Empty;

          if (ii < count && sPrevAlbum == sPresAlbum)
          {
            fileCounter++; // # songs per album (used to compute ratio below)

            if (!string.IsNullOrEmpty(sPresArtist) && !artists.Contains(sPresArtist))
              artists.Add(sPresArtist); // Add new artist with a count of 1
          }
          else // album name changed...
          {
            ratio = (double)artists.Count / (double)fileCounter;

            // Go backward and check items in a music-collection
            if (ratio >= g_ratio && fileCounter >= g_minSongs)
              // Actually set the check-boxes if count > updownMinSongs
              for (int jj = ii - 1; jj >= saveIndex; jj--)
                checkedItemsList.Add(jj);

            bFirst = true;
          }

          // Update previous to this...
          if (ii < count)
          {
            sPrevAlbum = sPresAlbum;
            sPrevArtist = sPresArtist;
          }
        }

        songView.UseWaitCursor = false;

        return checkedItemsList;
      }
      catch
      {
        MessageBox.Show("Problem occurred in SetCompilationChecks()!");
        songView.UseWaitCursor = false;
        return null;
      }
    }
    //---------------------------------------------------------------------------
    // Return a list of songs that need to be checked because the tag Artist/Album does not match the path Artist/Album
    // or the artist tag is not from FirstArtist. Don't check title
    private List<int> GetDBTAPList()
    {
      int count = songView.Items.Count;

      if (count <= 0)
        return null;

      songView.UseWaitCursor = true;

      try
      {
        string sPathAlbum, sPathArtist;

        // Checked list of songs to return
        List<int> checkedItemsList = new List<int>();

        ListViewItem lvi = new ListViewItem();

        // NOTE: Can't use foreach on BufferedListView!!!!!! (big pain, I know...)
        for (int ii = 0; ii < count; ii++)
        {
          lvi = songView.Items[ii];

          string sArtist = GetArtist(lvi);
          string sAlbum = GetAlbum(lvi);

          // If missing artist or album tag add the song to the list
          if (sAlbum == string.Empty || sArtist == string.Empty)
          {
            checkedItemsList.Add(ii);
            continue;
          }

          string sPath = lvi.SubItems[LV_FIELD_PATH].Text;

          string sPathTitle = ""; // not used here
          ParsePath(sPath, g_rootPath, out sPathArtist, out sPathAlbum, out sPathTitle);

          sPathAlbum = StripToLower(sPathAlbum);
          sPathArtist = StripToLower(sPathArtist);

          // Put a check on this song if path does not match tag
          if (sPathAlbum == string.Empty || sPathArtist == string.Empty || sPathAlbum != sAlbum || sPathArtist != sArtist)
            checkedItemsList.Add(ii);
        }

        songView.UseWaitCursor = false;
        return checkedItemsList;
      }
      catch
      {
        MessageBox.Show("Problem occurred in SetDBTAPChecks()!");
        songView.UseWaitCursor = false;
        return null;
      }
    }
    //---------------------------------------------------------------------------
    private bool SetChecksFromList(List<int> checkedList)
    {
      try
      {
        ClearAllChecks();

        if (checkedList == null)
          return false;

        int ensureVisibleIndex = -1; // Used to scroll to something checked

        checkedList.ForEach(item =>
        {
          if (item < songView.Items.Count)
          {
            songView.Items[item].Checked = true;

            if (ensureVisibleIndex < 0)
              ensureVisibleIndex = item; // Use to scroll to 1st checked songs...
          }
        });

        // Scroll to something checked...
        if (ensureVisibleIndex >= 0)
          songView.EnsureVisible(ensureVisibleIndex);

        return true;
      }
      catch { return false; }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region PROCESS Button Handler (move files)

    private void buttonProcess_Click(object sender, EventArgs e)
    {
      bool saveEnabled = fileSystemWatcher1.EnableRaisingEvents;
      fileSystemWatcher1.EnableRaisingEvents = false;

      if (this.g_checkingMode == FormSetChecks.SETCHECK_COMPILLATIONS)
        ProcessCompilations();
      else
        ProcessDBTAP();

      fileSystemWatcher1.EnableRaisingEvents = saveEnabled;
    }
    //---------------------------------------------------------------------------
    private void ProcessDBTAP()
    {
      bool bTitle, bAlbum, bArtist, bTransferArt, bOverwriteTags;
      int mode;

      if (songView.SelectedItems.Count == 0)
      {
        MessageBox.Show(MSGDBTAP);
        return;
      }

      using (FormProcessing fp = new FormProcessing())
      {
        // init dialog
        fp.ArtistChecked = true;
        fp.AlbumChecked = true;
        fp.TransferArt = true;
        fp.TitleChecked = true;

        if (g_initPathToTag)
        {
          fp.Mode = FormProcessing.PROCESSING_PATHTOTAG;
          fp.OverwriteTags = false;
        }
        else
        {
          fp.Mode = FormProcessing.PROCESSING_TAGTOPATH;
          fp.OverwriteTags = true;
        }

        if (fp.ShowDialog() == DialogResult.Cancel) return;

        // set globals
        bTitle = fp.TitleChecked;
        bArtist = fp.ArtistChecked;
        bAlbum = fp.AlbumChecked;
        bTransferArt = fp.TransferArt;
        bOverwriteTags = fp.OverwriteTags;
        mode = fp.Mode;
      }

      string msg;

      if (mode == FormProcessing.PROCESSING_TAGTOPATH)
        msg = MSGBOX_B1;
      else
        msg = MSGBOX_B2;

      if (MessageBox.Show(msg, TUNESFIX, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
        return;

      string destPath = "";

      if (mode == FormProcessing.PROCESSING_TAGTOPATH)
      {
        folderBrowserDialog1.SelectedPath = g_rootPath;

        folderBrowserDialog1.Description = MSGBROWSER;

        if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
          return;

        destPath = folderBrowserDialog1.SelectedPath;
        g_rootPath = destPath;
      }

      DisableControls();

      try
      {
        int countFoldersCreated = 0;
        int countFoldersDeleted = 0;
        int countImagesCopied = 0;
        int countImagesDeleted = 0;
        int countMusicFilesMoved = 0;
        int countOldMusicFilesDeleted = 0;
        int countFailedMove = 0;

        bool bYesToAll = false;

        // process files
        if (mode == FormProcessing.PROCESSING_TAGTOPATH)
        {
          List<string> savePaths = new List<string>();

          // Go into a loop that moves each selected song into a directory made up of the Artist/Album/Title.ext from
          // the meta-tag info and updates the path in the songView list.
          for (int ii = 0; ii < songView.SelectedItems.Count; ii++)
          {
            //if ((ii & 0xf) == 0)
            //{
            if (g_watcherDeleted || g_watcherRenamed)
              break;

            progressBar.Value = 100 * ii / songView.Items.Count;
            Application.DoEvents();
            if (this.g_keyPressed >= 0) break;
            //}

            string listFullPath = songView.SelectedItems[ii].SubItems[LV_FIELD_PATH].Text;

            string listPath = Path.GetDirectoryName(listFullPath);

            if (!System.IO.File.Exists(listFullPath))
              continue; // keep going if this file isn't there...

            string sArtist, sAlbum, sTitle;

            if (bArtist)
            {
              sArtist = ReplaceIllegalPathChars(songView.SelectedItems[ii].SubItems[LV_FIELD_ARTIST].Text); // replace illegal path chars...

              if (sArtist == string.Empty)
                sArtist = ReplaceIllegalPathChars(songView.SelectedItems[ii].SubItems[LV_FIELD_PERFORMER].Text);
            }
            else
              sArtist = string.Empty;

            if (bAlbum)
              sAlbum = ReplaceIllegalPathChars(songView.SelectedItems[ii].SubItems[LV_FIELD_ALBUM].Text);
            else
              sAlbum = string.Empty;

            if (bTitle)
              sTitle = ReplaceIllegalFileChars(songView.SelectedItems[ii].SubItems[LV_FIELD_TITLE].Text); // replace illegal file chars...
            else
              sTitle = string.Empty;

            string sPathArtist, sPathAlbum, sPathTitle;
            ParsePath(listFullPath, g_rootPath, out sPathArtist, out sPathAlbum, out sPathTitle);

            if (sArtist == string.Empty) sArtist = sPathArtist; // this does not work if there is no artist in the path - we get the root
            if (sAlbum == string.Empty) sAlbum = sPathAlbum;
            if (sTitle == string.Empty) sTitle = sPathTitle;
            if (sTitle == string.Empty) continue; // have to have a file-name at this point

            // build the destination path
            string newPath = destPath;

            if (sArtist != string.Empty)
              newPath = Path.Combine(newPath, sArtist);

            if (sAlbum != string.Empty)
              newPath = Path.Combine(newPath, sAlbum);

            // add the file-name
            string destFullPath = Path.Combine(newPath, sTitle + Path.GetExtension(listFullPath));

            // Don't do anything if source and dest full path files are one and the same...
            if (listFullPath == destFullPath)
              continue;

            // create the destination directory
            if (!Directory.Exists(newPath))
            {
              try
              {
                Directory.CreateDirectory(newPath);
                countFoldersCreated++;
              }
              catch
              {
                MessageBox.Show("Unable to create directory: \r\n  \"" + newPath + "\"\r\nquitting...");
                return;
              }
            }

            // Delete the destination file if it exists
            if (System.IO.File.Exists(destFullPath))
            {
              if (!bYesToAll)
              {
                MemoryBox mb = new MemoryBox();

                MemoryBoxResult result = mb.ShowMemoryDialog("File already exists..." + Environment.NewLine +
                  "\"" + destFullPath + "\"" + Environment.NewLine + "Overwrite?", "TunesFiX");

                if (result == MemoryBoxResult.No)
                  continue;

                if (result == MemoryBoxResult.Cancel || result == MemoryBoxResult.NoToAll)
                  return;

                if (result == MemoryBoxResult.YesToAll)
                  bYesToAll = true;
              }

              // delete the old file
              try { System.IO.File.Delete(destFullPath); }
              catch (IOException ex) { Console.WriteLine(ex.Message); }
              countOldMusicFilesDeleted++;
            }

            // Move and rename the file and update the list
            try
            {
              System.IO.File.Move(listFullPath, destFullPath);

              songView.BeginUpdate();
              songView.Items[songView.SelectedItems[ii].Index].SubItems[LV_FIELD_PATH].Text = destFullPath; // Update the path-field
              songView.Items[songView.SelectedItems[ii].Index].Checked = false; // Uncheck
              songView.EndUpdate();

              countMusicFilesMoved++;

              // Only copy album art if it's to a different directory
              if (bTransferArt && listPath != newPath)
              {
                countImagesCopied += CopyAlbumArt(listPath, newPath);
                savePaths.Add(listPath); // save original path (used later to delete album art)
              }
            }
            catch
            {
              countFailedMove++;
              continue; // try next song
            }

            if (countFailedMove > 0)
            {
              MessageBox.Show("Failed to move " + countFailedMove.ToString() + " files!");
              return;
            }
          }

          countImagesDeleted = DeleteAlbumArtSysFilesAndFolders(savePaths, bTransferArt, out countFoldersDeleted);

          // Do a final deletion of empty folders
          countFoldersDeleted += RemoveEmptyDirectories(destPath);

          progressBar.Value = 0;

          if (bTransferArt)
          {
            // Report
            MessageBox.Show("Music files moved: " + countMusicFilesMoved.ToString() + Environment.NewLine +
              "Old music files deleted: " + countOldMusicFilesDeleted.ToString() + Environment.NewLine +
              "Folders created: " + countFoldersCreated.ToString() + Environment.NewLine +
              "Old folders deleted: " + countFoldersDeleted.ToString() + Environment.NewLine +
              "Album images copied: " + countImagesCopied.ToString() + Environment.NewLine +
              "Old album images deleted: " + countImagesDeleted.ToString() + Environment.NewLine +
              "Failed to move: " + countFailedMove.ToString(), "Report:");
          }
          else
          {
            // Report
            MessageBox.Show("Music files moved: " + countMusicFilesMoved.ToString() + Environment.NewLine +
              "Old music files deleted: " + countOldMusicFilesDeleted.ToString() + Environment.NewLine +
              "Folders created: " + countFoldersCreated.ToString() + Environment.NewLine +
              "Old folders deleted: " + countFoldersDeleted.ToString() + Environment.NewLine +
              "Failed to move: " + countFailedMove.ToString(), "Report:");
          }
        }
        else // Set song tags based on path
        {
          bool bAlbumChanged = false;

          int countAlbumTags = 0;
          int countArtistTags = 0;
          int countPerformerTags = 0;
          int countTitleTags = 0;
          int countFailed = 0;
          int countListFailed = 0;

          SongInfo2 si = new SongInfo2();

          MediaTags.MediaTags tagReader = new MediaTags.MediaTags(g_rootPath);

          for (int ii = 0; ii < songView.SelectedItems.Count; ii++)
          {
            //if ((ii & 0xf) == 0)
            //{
            if (g_watcherDeleted || g_watcherRenamed)
              break;

            progressBar.Value = 100 * ii / songView.Items.Count;
            Application.DoEvents();

            if (this.g_keyPressed >= 0)
              break;
            //}

            string sPath = songView.SelectedItems[ii].SubItems[LV_FIELD_PATH].Text;

            if (!System.IO.File.Exists(sPath))
              continue; // keep going if this file isn't there...

            // Read song-tags
            si = tagReader.Read2(sPath);

            // Fill in info from the file-path if it's missing
            try
            {
              if (si.bException || !si.bTitleTag || !si.bArtistTag || !si.bAlbumTag)
              {
                SongInfo2 pathsio = tagReader.ParsePath(sPath);
                if (!si.bTitleTag) si.Title = pathsio.Title;
                if (!si.bArtistTag) si.Artist = pathsio.Artist;
                if (!si.bPerformerTag) si.Performer = pathsio.Artist;
                if (!si.bAlbumTag) si.Album = pathsio.Album;
              }
            }
            catch { si.bException = true; } // Threw an exception

            // Write the tag if the user checked the box allowing it and either they also checked "Overwrite old tags"
            // or if there was no old tag and the new tag string has something in it.
            bool bWriteAlbum = bAlbum && (bOverwriteTags || (!si.bAlbumTag && !string.IsNullOrEmpty(si.Album)));
            bool bWriteArtist = bArtist && (bOverwriteTags || (!si.bArtistTag && !string.IsNullOrEmpty(si.Artist)));
            bool bWritePerformer = bArtist && (bOverwriteTags || (!si.bPerformerTag && !string.IsNullOrEmpty(si.Performer)));
            bool bWriteTitle = bTitle && (bOverwriteTags || (!si.bTitleTag && !string.IsNullOrEmpty(si.Title)));

            // Only write what we changed
            if (bWriteAlbum || bWriteArtist || bWritePerformer || bWriteTitle)
            {
              SongInfo wsi = new SongInfo();

              if (bWriteAlbum)
              {
                wsi.Album = si.Album;
                wsi.bAlbumTag = true; // tell tagReader to update this item on write (below)
                countAlbumTags++;
              }

              if (bWriteArtist)
              {
                wsi.Artist = si.Artist;
                wsi.bArtistTag = true; // tell tagReader to update this item on write (below)
                countArtistTags++;
              }

              if (bWritePerformer)
              {
                wsi.Performer = si.Performer;
                wsi.bPerformerTag = true; // tell tagReader to update this item on write (below)
                countPerformerTags++;
              }

              if (bWriteTitle)
              {
                wsi.Title = si.Title;
                wsi.bTitleTag = true;
                countTitleTags++;
              }

              try { tagReader.Write(wsi, sPath); }
              catch { countFailed++; continue; }

              songView.BeginUpdate();

              try
              {
                int idx = songView.SelectedItems[ii].Index; // index into main list

                if (idx >= 0 && idx < songView.Items.Count)
                {
                  // update the list enties
                  if (bWriteTitle)
                  {
                    songView.Items[idx].SubItems[LV_FIELD_TITLE].Text = si.Title;
                    songView.Items[idx].SubItems[LV_FIELD_TITLE].Tag = true;
                    si.bTitleTag = true;
                  }

                  if (bWriteArtist)
                  {
                    songView.Items[idx].SubItems[LV_FIELD_ARTIST].Text = si.Artist;
                    songView.Items[idx].SubItems[LV_FIELD_ARTIST].Tag = true;
                    si.bArtistTag = true;
                  }

                  if (bWritePerformer)
                  {
                    songView.Items[idx].SubItems[LV_FIELD_PERFORMER].Text = si.Performer;
                    songView.Items[idx].SubItems[LV_FIELD_PERFORMER].Tag = true;
                    si.bPerformerTag = true;
                  }

                  if (bWriteAlbum)
                  {
                    songView.Items[idx].SubItems[LV_FIELD_ALBUM].Text = si.Album;
                    songView.Items[idx].SubItems[LV_FIELD_ALBUM].Tag = true;
                    si.bAlbumTag = true;
                  }

                  SetSubitemTags(songView.Items[idx], si); // update field colors
                  songView.Items[idx].Checked = false; // uncheck

                  if (bWriteAlbum && !bAlbumChanged) bAlbumChanged = true; // used to force sort if any album-tag is changed
                }
                else countListFailed++;
              }
              catch { countListFailed++; }

              songView.EndUpdate();
            }
          }

          if (bAlbumChanged) TFsort();

          progressBar.Value = 0;

          // Report
          if (countArtistTags == 0 && countAlbumTags == 0 && countTitleTags == 0 && countListFailed == 0 && countFailed == 0)
            MessageBox.Show("Song tags were ok. No changes needed to be made.");
          else
            MessageBox.Show("Artist tags updated: " + countArtistTags.ToString() + Environment.NewLine +
              "Performer tags updated: " + countPerformerTags.ToString() + Environment.NewLine +
              "Album tags updated: " + countAlbumTags.ToString() + Environment.NewLine +
              "Title tags updated: " + countTitleTags.ToString() + Environment.NewLine +
              "List update failures: " + countListFailed.ToString() + Environment.NewLine +
              "Tag update failures: " + countFailed.ToString(), "Report:");
        }
      }
      finally
      {
        NotifyIfFileChanged();
        EnableControls();
      }
    }
    //---------------------------------------------------------------------------
    private void ProcessCompilations()
    {
      if (songView.Items.Count == 0)
      {
        MessageBox.Show("Click \"File->Open\" to select a music directory and load songs...", TUNESFIX);
        return;
      }

      if (songView.CheckedItems.Count == 0)
      {
        MessageBox.Show("Nothing is checked! Set the checkboxes for songs you want to re-group \"by album\"." +
        " Press the \"Set Checks\" button to automatically check songs.", TUNESFIX);
        return;
      }

      MessageBox.Show("IF YOU DO NOT HAVE A BACKUP OF YOUR SONGS, PLEASE REPLY " + Environment.NewLine + "\"NO\" TO THE NEXT QUESTION AND GO MAKE ONE!", TUNESFIX,
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      DialogResult result =
      MessageBox.Show("Now we will create new directories for your" + Environment.NewLine +
            "compilations and move files. OK to continue?", TUNESFIX,
                         MessageBoxButtons.YesNo,
                                MessageBoxIcon.None,
                                        MessageBoxDefaultButton.Button2);

      if (result == DialogResult.No) return;

      folderBrowserDialog1.SelectedPath = g_rootPath;

      folderBrowserDialog1.Description = "Select a destination folder for your " +
                      "music. New folders will be created in and songs will be moved into the " +
                      "EXACT folder you select. Empty folders will be deleted at: " +
                      "\"" + g_rootPath + "\"";

      DialogResult dr = folderBrowserDialog1.ShowDialog();

      if (dr == DialogResult.Cancel) return;

      string destPath = folderBrowserDialog1.SelectedPath;

      DisableControls();

      // Get each checked item and move it then delete its directory
      // if empty...
      int localFilesMoved = 0;
      int localImagesCopied = 0;
      int localImagesDeleted = 0;
      int localFoldersDeleted = 0;
      int localFoldersCreated = 0;

      List<string> savePaths = new List<string>();

      for (int ii = 0; ii < songView.Items.Count; ii++)
      {
        //if ((ii & 0xf) == 0)
        //{
        if (g_watcherDeleted || g_watcherRenamed)
          break;

        progressBar.Value = 100 * ii / songView.Items.Count;
        Application.DoEvents();

        if (this.g_keyPressed >= 0)
          break;
        //}

        if (songView.Items[ii].Checked)
        {
          string listFullPath = songView.Items[ii].SubItems[LV_FIELD_PATH].Text;
          string album = songView.Items[ii].SubItems[LV_FIELD_ALBUM].Text;

          try
          {
            if (System.IO.File.Exists(listFullPath)) // Source file exists?
            {
              album = ReplaceIllegalPathChars(album);

              string destPathAlbum = Path.Combine(destPath, album);

              if (!Directory.Exists(destPathAlbum))
              {
                try
                {
                  Directory.CreateDirectory(destPathAlbum); // make destination directory
                }
                catch
                {
                  // path is read only or is not empty or we don't have permission
                  MessageBox.Show("Can't create directory: \"" + destPathAlbum + "\"", TUNESFIX);
                  EnableControls();
                  return;
                }

                localFoldersCreated++;
              }

              string diagnostic = "(empty)";

              try
              {
                string fileName = Path.GetFileName(listFullPath);
                string destPathFull = Path.Combine(destPathAlbum, fileName);
                string listPath = Path.GetDirectoryName(listFullPath);

                if (listFullPath != destPathFull) // Skip if source and dest the same...
                {
                  if (System.IO.File.Exists(destPathFull)) System.IO.File.Replace(listFullPath, destPathFull, null);
                  else System.IO.File.Move(listFullPath, destPathFull);

                  // Update path in the listView control
                  songView.Items[ii].SubItems[LV_FIELD_PATH].Text = destPathFull;

                  localFilesMoved++;

                  // Only copy album art if it's to a different directory
                  if (listPath != destPathAlbum)
                  {
                    localImagesCopied += CopyAlbumArt(listPath, destPathAlbum);
                    savePaths.Add(listPath); // save a list of old paths used to delete art
                  }
                }
              }
              catch
              {
                MessageBox.Show("Unable to move file! (1)" + Environment.NewLine + diagnostic, TUNESFIX);
                EnableControls();
                return;
              }
            }
          }
          catch
          {
            MessageBox.Show("Unable to move file! (2)", TUNESFIX);
            EnableControls();
            return;
          }
        }
      }

      // Get the unique paths of all the checked items and transfer any album art then delete the folder
      // if it's empty
      localImagesDeleted = DeleteAlbumArtSysFilesAndFolders(savePaths, true, out localFoldersDeleted);

      // Do a final deletion of empty folders
      localFoldersDeleted += RemoveEmptyDirectories(destPath);

      this.progressBar.Value = 0;

      // Info for for MessageBox
      string S1, S2, S3; // make it plural?
      if (localFilesMoved != 1) S1 = " files. ";
      else S1 = " file. ";
      if (localFoldersDeleted != 1) S2 = " empty folders. ";
      else S2 = " empty directory. ";
      if (localFoldersCreated != 1) S3 = " new folders. "; else S3 = " new folder. ";

      string mbInfo, tbInfo;

      if (localFilesMoved == 0 && localFoldersDeleted == 0 && localFoldersCreated == 0)
        mbInfo = tbInfo = "Music in: \"" + destPath + "\"" +
                           Environment.NewLine + "was already organized!";
      else
      {
        mbInfo = "Organized " + localFilesMoved.ToString() + S1 +
                                Environment.NewLine +
        "Removed " + localFoldersDeleted.ToString() + S2 +
                                Environment.NewLine +
        "Created " + localFoldersCreated.ToString() + S3;

        // Info for textBox
        tbInfo = "Organized " + localFilesMoved.ToString() + S1 +
        "Removed " + localFoldersDeleted.ToString() + S2 +
        "Created " + localFoldersCreated.ToString() + S3 + Environment.NewLine +
        "Destination:" + "\"" + destPath + "\"";
      }

      richTextBox.Text = tbInfo;
      MessageBox.Show(mbInfo, TUNESFIX);

      NotifyIfFileChanged();
      EnableControls();
    }
    //---------------------------------------------------------------------------
    private int DeleteAlbumArtSysFilesAndFolders(List<string> paths, bool bTransferArt, out int foldersDeleted)
    {
      var imageExt = new List<string> { ".jpg", ".gif", ".png" }; // possible expensions for album-art

      int count = 0;

      foldersDeleted = 0;

      // remove album art from each source path if no more songs
      using (FormStatus fs = new FormStatus(this))
      {
        HashSet<string> hs = new HashSet<string>(paths); // Weed out duplicates

        progressBar.Value = 0;
        int progressCounter = 0;

        fs.BodyText = MSGSTATUS_A;
        if (hs.Count > 50) fs.Show(this);
        fs.Update();

        foreach (string path in hs)
        {
          if (fs.KeyPressed >= 0) break;
          progressBar.Value = 100 * ++progressCounter / hs.Count;
          Application.DoEvents();
          if (this.g_keyPressed >= 0) break;

          // If the directory contains more than just album art and the desktop.ini and Thumbs.db files (7 or more files)
          // then don't bother deleting the art because we may have additional files/subdirectories in this folder
          // besides music!
          if (GetNumFileSystemEntries(path, 7) == 7) continue;

          if (bTransferArt)
          {
            List<string> imageFiles;

            try
            {
              imageFiles = Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly)
              .Where(file => imageExt.Any(e => file.EndsWith(e, StringComparison.OrdinalIgnoreCase)))
              .ToList();
            }
            catch
            {
              MessageBox.Show("Error enumerating imageFiles!");
              return -1;
            }

            if (imageFiles.Count > 0)
            {
              // if no more songs in source directory, delete its album art (if any)
              List<string> musicFiles;

              try
              {
                musicFiles = Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly)
                .Where(file => g_fileFilterList.Any(e => file.EndsWith(e, StringComparison.OrdinalIgnoreCase)))
                .ToList();
              }
              catch
              {
                MessageBox.Show("Error enumerating musicFiles!");
                return -1;
              }

              // delete images
              if (musicFiles.Count == 0)
              {
                foreach (string file in imageFiles)
                {
                  try
                  {
                    System.IO.File.Delete(file);
                    count++;
                  }
                  catch { };
                }
              }
            }
          }

          // If all that's left are either Thumbs.db and/or desktop.ini, delete them and remove the folder
          if (DeleteSysFilesAndFolder(path))
            foldersDeleted++;
        }

        fs.Close();
      }

      return count;
    }
    //---------------------------------------------------------------------------
    // Returns true if the folder was deleted
    // if non-system files remain in the folder it won't be removed
    private bool DeleteSysFilesAndFolder(string path)
    {
      int numFileSystemEntries = GetNumFileSystemEntries(path, 3); // returns 0, 1, 2 or 3

      if (numFileSystemEntries == 3) return false; // don't check further if over 2 items still in the folder

      // Handle myriad permutations of system-file deletion and then remove the
      // empty directory
      try
      {
        string sThumbs = Path.Combine(path, "Thumbs.db");
        string sDesk = Path.Combine(path, "desktop.ini");
        bool bThumbsExists = System.IO.File.Exists(sThumbs);
        bool bDeskExists = System.IO.File.Exists(sDesk);

        if (numFileSystemEntries == 1)
        {
          if (bThumbsExists || bDeskExists)
          {
            if (bThumbsExists)
              System.IO.File.Delete(sThumbs);
            else if (bDeskExists)
              System.IO.File.Delete(sDesk);

            Directory.Delete(path);

            return true;
          }
        }

        if (bThumbsExists && bDeskExists && numFileSystemEntries == 2)
        {
          System.IO.File.Delete(sThumbs);
          System.IO.File.Delete(sDesk);
          Directory.Delete(path);
          return true;
        }

        if (numFileSystemEntries == 0)
        {
          Directory.Delete(path);
          return true;
        }
      }
      catch { }

      return false;
    }
    //---------------------------------------------------------------------------
    private int CopyAlbumArt(string sourcePath, string destPath)
    {
      // copy album art from source path to dest if it's not there already...
      List<string> imageFiles;
      var imageExt = new List<string> { ".jpg", ".gif", ".png" }; // possible expensions for album-art
      int count = 0;

      try
      {
        imageFiles = Directory.EnumerateFiles(sourcePath, "*", SearchOption.TopDirectoryOnly)
        .Where(file => imageExt.Any(e => file.EndsWith(e, StringComparison.OrdinalIgnoreCase)))
        .ToList();
      }
      catch
      {
        MessageBox.Show("Failed to enumerate image files!");
        return 0;
      }

      try
      {
        foreach (var imageSource in imageFiles)
        {
          string imageDest = Path.Combine(destPath, Path.GetFileName(imageSource));

          // Copy the album art
          if (!System.IO.File.Exists(imageDest))
          {
            try
            {
              System.IO.File.Copy(imageSource, imageDest);
              count++;
            }
            catch { }
          }
        }
      }
      catch { }

      return count;
    }
    //---------------------------------------------------------------------------
    // Efficient way to see if a directory has more than "comp" entries
    // including subdirectory names... if comp is > 0 we break out of
    // iteration when count == comp. Otherwise we return the number
    // of file-sistem files AND directories in path. Returns -1 if
    // error.
    private int GetNumFileSystemEntries(string path, int comp = 0)
    {
      try
      {
        int count = 0;
        foreach (string file in Directory.EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly))
        {
          count++;

          if (comp > 0 && count >= comp)
            break;
        }

        return count;
      }
      catch { return -1; } // error
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Directory Copy, Count, Move and Delete

    private bool CopyAll(string sourceDirectory, string targetDirectory, bool bMove = false)
    {
      DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
      DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

      if (CopyAll(diSource, diTarget, bMove))
      {
        this.g_keyPressed = -1;
        progressBar.Value = 0;
        return true;
      }

      this.g_keyPressed = -1;
      progressBar.Value = 0;
      return false;
    }
    //---------------------------------------------------------------------------
    private bool CopyAll(DirectoryInfo source, DirectoryInfo target, bool bMove = false)
    {
      try
      {
        // Check if the target directory exists, if not, create it.
        if (Directory.Exists(target.FullName) == false)
          Directory.CreateDirectory(target.FullName);

        // Copy each file into it's new directory.
        FileInfo[] fileInfoArray = source.GetFiles();

        for (int ii = 0; ii < fileInfoArray.Length; ii++)
        {
          if (bMove)
            fileInfoArray[ii].MoveTo(Path.Combine(target.ToString(), fileInfoArray[ii].Name));
          else
            fileInfoArray[ii].CopyTo(Path.Combine(target.ToString(), fileInfoArray[ii].Name), true); // Copy and overwrite

          if ((++g_copyCount % 10) == 0)
          {
            Application.DoEvents();
            progressBar.Value = 100 * g_copyCount / g_fileCount;

            // Don't allow user to cancel on a move!!!!
            if (!bMove && this.g_keyPressed >= 0)
              return true; // quit
          }
        }

        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
          DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);

          if (CopyAll(diSourceSubDir, nextTargetSubDir))
            return true; // quit

          if (!bMove && this.g_keyPressed >= 0)
            return true; // quit
        }
      }
      catch { return true; } // error

      return false; // keep going
    }
    //---------------------------------------------------------------------------
    // 
    // Deletes a directory and all its files and subdirectories. 
    // 
    private void DeleteFiles(string directory)
    {
      try
      {
        DirectoryInfo dInfo = new DirectoryInfo(directory);

        if (dInfo.Exists)
          dInfo.Delete(true);

        dInfo = null;
      }
      catch
      {
      }
    }
    //---------------------------------------------------------------------------
    private int RemoveEmptyDirectories(string startLocation)
    // Delete empties in startLocation then delete ourself
    {
      bool saveEnabled = fileSystemWatcher1.EnableRaisingEvents;
      fileSystemWatcher1.EnableRaisingEvents = false;

      g_RemoveCounter = 0; // Global counter...
      g_FailCounter = 0; // Global counter...
      TaskRemoveEmptyDirectories(startLocation);

      if (Directory.GetFiles(startLocation).Length == 0 &&
                      Directory.GetDirectories(startLocation).Length == 0)
      {
        try
        {
          Directory.Delete(startLocation, false);
          g_RemoveCounter++;
        }
        catch
        {
          g_FailCounter++;
        }
      }

      fileSystemWatcher1.EnableRaisingEvents = saveEnabled;

      return g_RemoveCounter; // return global counter
    }
    //---------------------------------------------------------------------------
    private void TaskRemoveEmptyDirectories(string startLocation)
    // Delete empties in startLocation
    {
      foreach (var directory in Directory.GetDirectories(startLocation))
      {
        TaskRemoveEmptyDirectories(directory);

        if (Directory.GetFiles(directory).Length == 0 &&
                        Directory.GetDirectories(directory).Length == 0)
        {
          try
          {
            Directory.Delete(directory, false);
            g_RemoveCounter++;
          }
          catch
          {
            g_FailCounter++;
          }
        }
      }
    }
    //---------------------------------------------------------------------------
    // Copies dir and all subdirectories and files...
    private void CopyDirectory(string SourcePath, string DestinationPath)
    {
      //Create all of the directories
      foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
      {
        try
        {
          Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
          g_dirCount++;
        }
        catch { }
      }

      //Now copy all the files
      foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
          SearchOption.AllDirectories))
      {
        try
        {
          System.IO.File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
          g_copyCount++;
        }
        catch
        {
        }
      }
    }
    //---------------------------------------------------------------------------
    private void FileCountDirectory(string startLocation)
    {
      foreach (var directory in Directory.GetDirectories(startLocation))
      {
        FileCountDirectory(directory);

        try { g_fileCount += Directory.GetFiles(directory).Length; }
        catch { }
      }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Drag-Drop Events (Mouse Move, Etc.)

    private void songView_DragOver(object sender, DragEventArgs e)
    {
      // Determine whether string data exists in the drop data. If not, then
      // the drop effect reflects that the drop cannot occur.
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else if (e.Data.GetDataPresent(DataFormats.Text))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }
    //---------------------------------------------------------------------------
    private void songView_DragDrop(object sender, DragEventArgs e)
    {
      using (MediaTags.MediaTags tagReader = new MediaTags.MediaTags(g_rootPath))
      {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
          string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));

          foreach (string fileLoc in filePaths)
            // Code to read the contents of the text file
            if (System.IO.File.Exists(fileLoc))
              AddFileToSongView(tagReader, fileLoc);
        }
        else if (e.Data.GetDataPresent(DataFormats.Text))
        {
          string filePath = (string)(e.Data.GetData(DataFormats.Text));

          if (System.IO.File.Exists(filePath))
            AddFileToSongView(tagReader, filePath);
        }
      }
    }
    //---------------------------------------------------------------------------
    private void songView_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        try
        {
          ListView lv = sender as ListView;

          ListViewItem dragSourceItem = lv.GetItemAt(e.X, e.Y);

          if (dragSourceItem == null)
          {
            g_dragBox = Rectangle.Empty;
            return;
          }

          g_dragSourcePath = dragSourceItem.SubItems[LV_FIELD_PATH].Text;

          // Remember the point where the mouse down occurred. The DragSize indicates
          // the size that the mouse can move before a drag event should be started.                
          Size dragSize = SystemInformation.DragSize;

          // Create a rectangle using the DragSize, with the mouse position being
          // at the center of the rectangle.
          g_dragBox = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                    e.Y - (dragSize.Height / 2)), dragSize);
        }
        catch // Click over empty area
        {
          g_dragBox = Rectangle.Empty;
        }
      }
      else
        // Reset the rectangle if the mouse is not over an item in the ListBox.
        g_dragBox = Rectangle.Empty;
    }
    //---------------------------------------------------------------------------

    private void songView_MouseUp(object sender, MouseEventArgs e)
    {
      // NOTE: this event hook won't fire for normal drag/drop... event
      // is purged i suppose...

      // Reset the drag rectangle when the mouse button is raised.
      g_dragBox = Rectangle.Empty;
    }
    //---------------------------------------------------------------------------
    private void songView_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        // If the mouse moves outside the rectangle, start the drag.
        if (e.Button == MouseButtons.Left && g_dragBox != Rectangle.Empty &&
          !g_dragBox.Contains(e.X, e.Y) && System.IO.File.Exists(g_dragSourcePath))
        {
          string[] array = { g_dragSourcePath };
          var data = new DataObject(DataFormats.FileDrop, array);
          songView.DoDragDrop(data, DragDropEffects.Copy);
        }
        else
          // Reset the rectangle if the mouse is not over an item in the ListBox.
          g_dragBox = Rectangle.Empty;
      }
      catch
      {
        g_dragBox = Rectangle.Empty;
      }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Tag Editing

    public void DoTagEdit()
    {
      if (songView.SelectedItems.Count <= 0)
      {
        MessageBox.Show("Nothing selected to edit...", "TunesFiX");
        return;
      }

      DialogResult dr;
      SongInfo dlg = new SongInfo(); // Will hold user's input from the FormEdit dialog
      string saveOrigPath;

      try
      {
        using (FormEdit fe = new FormEdit())
        {
          fe.SI = InitDialogFields();

          fe.SelectedItemCount = songView.SelectedItems.Count;

          // Set path box to longest common initial path...
          List<string> paths = new List<string>();

          try
          {
            foreach (ListViewItem lvi in songView.SelectedItems)
              paths.Add(lvi.SubItems[LV_FIELD_PATH].Text);
          }
          catch
          {
            MessageBox.Show("Error Adding Path Names!");
            return;
          }

          saveOrigPath = FindCommonPath(Path.DirectorySeparatorChar.ToString(), paths);

          // Add \ to path so we can tell it from a file... we will never have
          // a blank path - minimum will be "\"
          if (string.IsNullOrEmpty(saveOrigPath) || (Directory.Exists(saveOrigPath) && saveOrigPath[saveOrigPath.Length - 1] != Path.DirectorySeparatorChar))
            saveOrigPath += Path.DirectorySeparatorChar;

          fe.SI.FilePath = saveOrigPath;

          //        fe.PathReadOnly = true;

          dr = fe.ShowDialog(this);

          // Xfer properties and trim the strings
          dlg = fe.SI;
          dlg.TrimAll();
        } // dispose of the dialog
      }
      catch
      {
        MessageBox.Show("Unable to prepare edit dialog (1)...");
        return;
      }

      if (dr != DialogResult.Yes) return;

      bool saveEnabled = fileSystemWatcher1.EnableRaisingEvents;
      fileSystemWatcher1.EnableRaisingEvents = false;

      try
      {
        bool bMove = false;
        bool bCopy = false;

        string dlgFileNameOnly = string.Empty;
        string dlgExtOnly = string.Empty;

        if (dlg.bFilepathTag)
        {
          try
          {
            // This will throw an exception if any invalid path chars like <>
            dlgFileNameOnly = Path.GetFileNameWithoutExtension(dlg.FilePath);
            dlgExtOnly = Path.GetExtension(dlg.FilePath);
          }
          catch
          {
            try
            {
              if (dlg.FilePath.Length > 0 && dlg.FilePath[dlg.FilePath.Length - 1] != Path.DirectorySeparatorChar)
              {
                string[] array = dlg.FilePath.Split(Path.DirectorySeparatorChar);
                dlgFileNameOnly = array[array.Length - 1];
                array = dlgFileNameOnly.Split('.');
                dlgFileNameOnly = array[0];
              }
            }
            catch { }
          }

          // Check for move or copy command...
          if (dlg.FilePath.Length >= 5)
          {
            string command = dlg.FilePath.Substring(0, 5);
            if (command.ToLower() == "move " || command.ToLower() == "copy ")
            {
              dlg.FilePath = dlg.FilePath.Substring(5);

              if (command.ToLower() == "move ") bMove = true;
              else bCopy = true;
            }
            else
            {
              command = dlg.FilePath.Substring(0, 4);
              if (command.ToLower() == "move" || command.ToLower() == "copy")
              {
                dlg.FilePath = dlg.FilePath.Substring(4);

                if (command.ToLower() == "move") bMove = true;
                else bCopy = true;
              }
            }
          }

          if (!string.IsNullOrEmpty(dlgFileNameOnly))
          {
            // Error if more than one item selected and no wildcards...
            if (songView.SelectedItems.Count > 1)
            {
              if ((!(dlgFileNameOnly.Contains("<") && dlgFileNameOnly.Contains(">")) && !dlgFileNameOnly.Contains("*") && !dlgFileNameOnly.Contains("?")) ||
                  (dlgFileNameOnly.Contains("?") && string.IsNullOrEmpty(dlg.Title)))
              {
                MessageBox.Show("You need the * or ? wildcard or <#> in the filename\r\n" +
                  "if more than one song is selected!");
                return;
              }
            }
          }
        }

        DisableControls();

        bool bAlbumChanged = false;

        int l_fileFail = 0;
        int l_fileCount = 0;
        int l_tagFail = 0;
        int l_tagCount = 0;

        FormStatus fs = null;

        if (bCopy == true && songView.SelectedItems.Count > 100)
        {
          fs = new FormStatus(this);
          fs.BodyText = MSGSTATUS_B;
          fs.Show(this);
          fs.Update();
        }

        int songCounter = 0;
        int songCount = 1;
        string prev_album = songView.SelectedItems[0].SubItems[LV_FIELD_ALBUM].Text;

        using (var mt = new MediaTags.MediaTags(g_rootPath))
        {
          int selCount = songView.SelectedItems.Count;

          for (int ii = 0; ii < selCount; ii++)
          {
            Application.DoEvents();

            if (g_keyPressed >= 0) break;

            ListViewItem lvi = songView.SelectedItems[ii]; // get a reference to our item...

            string filePath = lvi.SubItems[LV_FIELD_PATH].Text;

            // Provide an overall progress indicator...
            this.progressBar.Value = 100 * ii / selCount;

            if (fs != null)
            {
              if (fs.KeyPressed >= 0) break;

              fs.LabelName = Path.GetFileName(filePath);

              // Provide a rough album-by-album progess indicator...
              fs.ProgressValue = 100 * songCounter++ / songCount;

              if (songCounter > songCount)
              {
                songCounter = 0;
                songCount = 1;

                for (int jj = ii; jj < selCount; jj++)
                {
                  string album = songView.SelectedItems[jj].SubItems[LV_FIELD_ALBUM].Text;
                  songCount++;

                  if (prev_album != album)
                  {
                    prev_album = album;

                    // Don't reset unless several songs on album...
                    if (songCount < 2) continue;
                    break;
                  }
                }
              }
            } // end if (fs != null)

            //If user typed something...
            if (dlg.bFilepathTag)
            {
              string newPath = string.Empty;

              try
              {
                try
                {
                  // This throws exception if path has <>!!!
                  newPath = RemoveIllegalPathChars(Path.GetDirectoryName(dlg.FilePath));
                }
                catch
                {
                  try
                  {
                    newPath = dlg.FilePath;

                    if (newPath.Length > 0)
                    {
                      for (int jj = newPath.Length - 1; jj >= 0; jj--)
                      {
                        if (newPath[jj] == Path.DirectorySeparatorChar) break;
                        newPath = newPath.Remove(jj);
                      }
                    }
                  }
                  catch { }
                }

                // If user-path has a drive letter use it to replace
                // the old common root (the unseen remainder of the original
                // path is preserved)... otherwise, the path becomes
                // relative to the old common root (not replacing it but appended
                // to it) and the old unseen part of the path is not used...
                //
                // So if i select 5 files from different Steely Dan albums,
                // the common root the user sees in the editor may be:
                // G:\Test Music\Steely Dan\
                //
                // Typing: Copy G:\Music\Steely Dan\ would COPY the songs to the same
                // album folders in G:\Music\Steely Dan. (if the original root is
                // not changed, a MOVE is used so that filenames can be changed...)
                //
                // Typing: Copy \Selected Songs\ will COPY the songs to
                // G:\Test Music\Steely Dan\Selected Songs\ but NOT preserve their
                // old album path info
                if (newPath.Length > 0 && newPath[0] == Path.DirectorySeparatorChar)
                  newPath = Path.GetDirectoryName(saveOrigPath) + newPath;
                else
                {
                  try
                  {
                    if (filePath != saveOrigPath)
                    {
                      string temp = Path.GetDirectoryName(filePath.Replace(saveOrigPath, string.Empty));
                      newPath = Path.Combine(newPath, temp);
                    }
                  }
                  catch { }
                }
              }
              catch { newPath = string.Empty; }

              try
              {
                // Can't get a destination path out of what the user typed,
                // then use original path
                if (string.IsNullOrEmpty(newPath))
                  newPath = Path.GetDirectoryName(filePath);

                string newFullPath;

                //
                // Process filename...
                //
                if (!string.IsNullOrEmpty(dlgFileNameOnly))
                {
                  string oldFile = Path.GetFileNameWithoutExtension(filePath);
                  string oldExt = Path.GetExtension(filePath);

                  string newExt = dlgExtOnly;
                  string newFile = dlgFileNameOnly;

                  if (newFile == "*<>*")
                    newFile = ReplaceIndexSequence(ii, oldFile, newFile); // remove all digits command?
                  else if (newFile.Contains("*") || newFile.Contains("?"))
                  {
                    if (newFile.Contains("*"))
                      newFile = newFile.Replace("*", oldFile);

                    if (newFile.Contains("?"))
                      newFile = newFile.Replace("?", lvi.SubItems[LV_FIELD_TITLE].Text);

                    // Replace <005> etc.
                    newFile = ReplaceIndexSequence(ii, newFile);
                  }
                  else if (selCount > 1)
                    newFile = ReplaceIndexSequence(ii, oldFile, newFile);

                  if (string.IsNullOrEmpty(newExt) || newExt == ".*")
                    newFile += oldExt;
                  else
                    newFile += newExt;

                  newFile = RemoveIllegalFileChars(newFile);

                  newFullPath = Path.Combine(newPath, newFile);
                }
                else
                  newFullPath = Path.Combine(newPath, Path.GetFileName(filePath));

                if (filePath != newFullPath)
                {

                  if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);

                  // We use Move if user specificly mandated it with the
                  // keyword MOVE, or if the source and destination paths are
                  // identical (possibly renaming the file)
                  if (bMove || Path.GetDirectoryName(filePath) == Path.GetDirectoryName(newFullPath))
                  {
                    try
                    {
                      MessageBox.Show("move: \"" + filePath + "\" to \"" + newFullPath + "\"");

                      // Ensure that the target does not exist.
                      if (System.IO.File.Exists(newFullPath))
                        System.IO.File.Delete(newFullPath);

                      System.IO.File.Move(filePath, newFullPath); // Move or rename
                      filePath = newFullPath;
                      lvi.SubItems[LV_FIELD_PATH].Text = newFullPath;
                      lvi.Checked = true;
                      l_fileCount++;
                    }
                    catch (Exception e)
                    {
                      l_fileFail++;

                      if (selCount > 1)
                      {
                        if (MessageBox.Show("Move failed:\n\n\"" + e.Message + "\"" + "\n\n" +
                              "Abort?", TUNESFIX,
                                           MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Exclamation,
                                                          MessageBoxDefaultButton.Button1) == DialogResult.Yes) break;

                      }
                      else
                        MessageBox.Show("Move failed:\n\n\"" + e.Message + "\"", TUNESFIX,
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  }
                  else if (bCopy)
                  {
                    try
                    {
                      MessageBox.Show("copy: \"" + filePath + "\" to \"" + newFullPath + "\"");

                      // Ensure that the target does not exist.
                      if (System.IO.File.Exists(newFullPath))
                        System.IO.File.Delete(newFullPath);

                      System.IO.File.Copy(filePath, newFullPath); // Copy is default
                      filePath = newFullPath;
                      lvi.SubItems[LV_FIELD_PATH].Text = newFullPath;
                      lvi.Checked = true;
                      l_fileCount++;
                    }
                    catch (Exception e)
                    {
                      l_fileFail++;

                      if (selCount > 1)
                      {
                        if (MessageBox.Show("Copy failed:\n\n\"" + e.Message + "\"" + "\n\n" +
                              "Abort?", TUNESFIX,
                                           MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Exclamation,
                                                          MessageBoxDefaultButton.Button1) == DialogResult.Yes) break;

                      }
                      else
                        MessageBox.Show("Copy failed:\n\n\"" + e.Message + "\"", TUNESFIX,
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  }
                }
              }
              catch { l_fileFail++; }
            } // end if (dlgPathChanged)

            try
            {
              var si = new SongInfo();
              si = mt.Read(filePath); // Read this song's info

              // Update if user changed the field in the dialog OR if there was no field to read...
              if (dlg.bAlbumTag || !si.bAlbumTag)
              {
                si.Album = ReplaceWildcards(lvi, ii, LV_FIELD_ALBUM, dlg.Album);
                si.bAlbumTag = true; // Tell dll library to update this item...
              }

              // Update if user changed the field in the dialog OR if there was no field to read...
              if (dlg.bTitleTag || !si.bTitleTag)
              {
                string oldTitle = lvi.SubItems[LV_FIELD_TITLE].Text;
                string newTitle = dlg.Title;

                if (newTitle == "*<>*") newTitle = ReplaceIndexSequence(ii, oldTitle, newTitle); // remove all digits command?
                else if (newTitle.Contains("*") || newTitle.Contains("?"))
                {
                  if (newTitle.Contains("*")) newTitle = newTitle.Replace("*", oldTitle);

                  if (newTitle.Contains("?"))
                  {
                    try { newTitle = newTitle.Replace("?", Path.GetFileNameWithoutExtension(lvi.SubItems[LV_FIELD_PATH].Text)); }
                    catch { }
                  }
                }

                // Replace <005> etc.
                newTitle = ReplaceIndexSequence(ii, newTitle);

                lvi.SubItems[LV_FIELD_TITLE].Text = newTitle; // Update item in the list

                si.Title = newTitle;
                si.bTitleTag = true;
              }

              // Update if user changed the field in the dialog OR if there was no field to read...
              if (dlg.bArtistTag || !si.bArtistTag)
              {
                si.Artist = ReplaceWildcards(lvi, ii, LV_FIELD_ARTIST, dlg.Artist);
                si.bArtistTag = true;
              }

              // NOTE: The rest of the tags are only written if the user changed it. If there was
              // no tag to read, we won't presume to write one.
              if (dlg.bPerformerTag)
              {
                si.Performer = ReplaceWildcards(lvi, ii, LV_FIELD_PERFORMER, dlg.Performer);
                si.bPerformerTag = true;
              }

              if (dlg.bComposerTag)
              {
                si.Composer = ReplaceWildcards(lvi, ii, LV_FIELD_COMPOSER, dlg.Composer);
                si.bComposerTag = true;
              }

              if (dlg.bGenreTag)
              {
                si.Genre = ReplaceWildcards(lvi, ii, LV_FIELD_GENRE, dlg.Genre);
                si.bGenreTag = true;
              }

              if (dlg.bPublisherTag)
              {
                si.Publisher = ReplaceWildcards(lvi, ii, LV_FIELD_PUBLISHER, dlg.Publisher);
                si.bPublisherTag = true;
              }

              if (dlg.bConductorTag)
              {
                si.Conductor = ReplaceWildcards(lvi, ii, LV_FIELD_CONDUCTOR, dlg.Conductor);
                si.bConductorTag = true;
              }

              if (dlg.bYearTag)
              {
                si.Year = ReplaceWildcards(lvi, ii, LV_FIELD_YEAR, dlg.Year);
                si.bYearTag = true;
              }

              if (dlg.bTrackTag)
              {
                si.Track = ReplaceWildcards(lvi, ii, LV_FIELD_TRACK, dlg.Track);
                si.bTrackTag = true;
              }

              if (dlg.bDurationTag)
              {
                si.Duration = dlg.Duration;
                si.bDurationTag = true;
              }

              if (dlg.bCommentsTag)
              {
                si.Comments = ReplaceWildcards(lvi, ii, LV_FIELD_COMMENTS, dlg.Comments);
                si.bCommentsTag = true;
              }

              if (dlg.bLyricsTag)
              {
                si.Lyrics = ReplaceWildcards(lvi, ii, LV_FIELD_LYRICS, dlg.Lyrics);
                si.bLyricsTag = true;
              }

              // Set the tags in lvi to the "bChanged" flags and set the colors of the subitems
              SetSubitemTags(lvi, si);

              // Call MediaTagSharp's Write method and update counters
              if (mt.Write(si, filePath)) l_tagCount++;
              else l_tagFail++;
            }
            catch { l_tagFail++; }
          } // end for

          this.progressBar.Value = 0;

        } // end using

        if (fs != null)
        {
          fs.Close();
          fs = null;
        }

        // Delete directory and subdirectories if empty
        if (bMove && l_fileCount > 0) RemoveEmptyDirectories(saveOrigPath);

        if (bAlbumChanged) TFsort();

        string s = string.Empty;

        if (l_fileCount > 1)
        {
          if (bMove)
            s += "Moved or renamed: " + l_fileCount.ToString() + " files\r\n";
          else if (bCopy)
            s += "Copied: " + l_fileCount.ToString() + " files\r\n";
          else
            s += "Renamed: " + l_fileCount.ToString() + " files\r\n";
        }

        if (l_tagCount > 1)
          s += "Modified: " + l_tagCount.ToString() + " tags\r\n";

        if (l_fileFail > 1)
          s += "Failed to move/copy/rename: " + l_fileFail.ToString() + " files\r\n";

        if (l_tagFail > 0)
        {
          s += "Failed to modify: " + l_tagFail.ToString() + " tag(s)\r\n";
          s += "(Make sure the song file is not locked or playing!)";
        }

        if (!string.IsNullOrEmpty(s))
        {
          s = "Report:\r\n" + s;
          MessageBox.Show(s, "TunesFiX");
        }
      }
      catch
      {
        MessageBox.Show("Problem processing selected files.\r\nTry closing the program and restart...");
      }
      finally
      {
        EnableControls();
        fileSystemWatcher1.EnableRaisingEvents = saveEnabled;
      }      
    }
    //---------------------------------------------------------------------------
    // Check the uint sFieldVisible to see which fields to show Title Artist and Album are always visible
    // the integer assignments below also represent the actual flag-bit in sFieldVisible
    // LV_FIELD_TITLE = 0;
    // LV_FIELD_ARTIST = 1;
    // LV_FIELD_ALBUM = 2;
    // LV_FIELD_PERFORMER = 3;
    // LV_FIELD_COMPOSER = 4;
    // LV_FIELD_GENRE = 5;
    // LV_FIELD_PUBLISHER = 6;
    // LV_FIELD_CONDUCTOR = 7;
    // LV_FIELD_YEAR = 8;
    // LV_FIELD_TRACK = 9;
    // LV_FIELD_DURATION = 10;
    // LV_FIELD_COMMENTS = 11;
    // LV_FIELD_LYRICS = 12;
    // LV_FIELD_PATH = 13;
    private string ReplaceWildcards(ListViewItem lvi, int iteration, int idx, string sNew)
    {
      string sOld = lvi.SubItems[idx].Text;

      try
      {
        if (sNew == "*<>*") // remove all digits command?
          sNew = ReplaceIndexSequence(iteration, sOld, sNew);
        else
        {
          if (sNew.Contains("*")) sNew = sNew.Replace("*", sOld);
          if (sNew.Contains("?")) sNew = sNew.Replace("?", lvi.SubItems[LV_FIELD_TITLE].Text);
          sNew = ReplaceIndexSequence(iteration, sNew); // Replace <005> etc.
        }

        lvi.SubItems[idx].Text = sNew; // update the item
      }
      catch { sNew = sOld; }

      return sNew;
    }
    //---------------------------------------------------------------------------
    // Overloaded!!
    //
    // Replaces the sequence <###> in a string with
    // ### plus nIn... padded with leading 0's
    // so <Song:0001> would print Song:0001 Song:0002, etc.
    //
    // Typing <> removes the outermost numbers from the beginning
    // or end of the string.
    //
    private string ReplaceIndexSequence(int nIn, string sIn)
    {
      return ReplaceIndexSequence(nIn, sIn, sIn);
    }

    private string ReplaceIndexSequence(int nIn, string sIn, string sDlg)
    // sDlg will have the users input string possibly having <##> format tags in it.
    // sIn will either be the same as sDlg or it will have the original filename, song title,
    // or album name prior to adding tags in the dialog. This is needed in the
    // case of a <> tag because you need the original string to strip numbers out of...
    // We will build sOut and return it.
    {
      int nextIdx = sIn.Length;
      string sOut = string.Empty;

      try
      {
        if (sDlg.Contains("<") && sDlg.Contains(">"))
        {
          while (sDlg.Contains("<") && sDlg.Contains(">"))
          {
            int fIdx = sDlg.IndexOf("<");
            int eIdx = sDlg.IndexOf(">");

            if (eIdx >= fIdx + 2)
            {
              int len = eIdx - fIdx - 1;
              string subString = sDlg.Substring(fIdx + 1, len);
              subString = subString.Replace("#", "0"); // user can put in #...
              int val = Convert.ToInt32(subString) + nIn;

              string prefix = sDlg.Substring(0, fIdx); // Get text in front of the '<'

              // See if there is another tag to the right and get its start index as nIdx
              int nIdx = -1;
              if (eIdx + 1 < sDlg.Length)
                nIdx = sDlg.IndexOf("<", eIdx + 1); // Index of next tag (if any)

              // Get text after the '>' but before the next '<'
              string suffix = string.Empty;

              if (nIdx >= eIdx + 1)
              {
                suffix = sIn.Substring(eIdx + 1, nIdx - (eIdx + 1));
                nextIdx = nIdx;
              }
              else if (sIn.Length > eIdx + 1)
                suffix = sIn.Substring(eIdx + 1, sIn.Length - (eIdx + 1));

              sOut += prefix + val.ToString("D" + len) + suffix;
            }
            else if (eIdx == fIdx + 1) // <> Remove digits command
            {
              if (eIdx == sDlg.Length - 1) // Parse last group of digits or spaces from end...
              {
                if (sIn == sDlg && sIn.Length >= 2)
                  sIn = sIn.Substring(0, sIn.Length - 2); // Remove tag so we can process sIn

                int ii = sIn.Length - 1;

                while (Char.IsWhiteSpace(sIn, ii))
                {
                  sIn = sIn.Remove(ii--, 1);
                  if (ii == 0) break;
                }
                while (Char.IsDigit(sIn, ii))
                {
                  sIn = sIn.Remove(ii--, 1);
                  if (ii == 0) break;
                }
                while (Char.IsWhiteSpace(sIn, ii))
                {
                  sIn = sIn.Remove(ii--, 1);
                  if (ii == 0) break;
                }
                MessageBox.Show(sIn);
              }
              else if (fIdx == 0) // Parse first group of digits or spaces from beginning...
              {
                if (sIn == sDlg && sIn.Length >= 2)
                  sIn = sIn.Substring(2, sIn.Length - 2); // Remove tag so we can process sIn

                int ii = 0;
                while (Char.IsWhiteSpace(sIn, ii))
                  sIn = sIn.Remove(ii, 1);
                while (Char.IsDigit(sIn, ii))
                  sIn = sIn.Remove(ii, 1);
                while (Char.IsWhiteSpace(sIn, ii))
                  sIn = sIn.Remove(ii, 1);
              }
              else // parse all digits out
              {
                if (sIn == sDlg)
                  sIn = sIn.Replace("<>", ""); // Remove all <> tags so we can process sIn

                for (int ii = 0; ii < sIn.Length; )
                {
                  if (Char.IsDigit(sIn, ii))
                    sIn = sIn.Remove(ii, 1);
                  else
                    ii++;
                }
              }

              // Trim spaces
              if (!string.IsNullOrEmpty(sIn))
                sIn.Trim();

              sOut = sIn;
            }

            string sTemp;

            // Remove this tag and any prefix...
            if (nextIdx >= 0 && nextIdx < sDlg.Length)
              sTemp = sDlg.Substring(nextIdx, sDlg.Length - nextIdx);
            else
              sTemp = "";

            // If sIn == sDlg need to remove the <> tag!
            if (sIn == sDlg)
              sIn = sTemp;

            // Remove <> tag...
            sDlg = sTemp;
          }
        }
        else
          sOut = sIn; // Return input string if no <> tags...
      }
      catch
      {
      }

      return sOut;
    }
    //---------------------------------------------------------------------------
    // Pass Tags to this function such as Title, Album, Artist - returns the tag
    // cleaned up don't pass it a "real" path with slashes and a drive letter
    // you need to keep!
    private string ReplaceIllegalPathChars(string sIn)
    {
      if (string.IsNullOrEmpty(sIn)) return string.Empty;
      sIn = sIn.Replace('/', ' ');
      sIn = sIn.Replace('\\', ' ');
      sIn = sIn.Replace(':', ' ');

      string invalid = new string(Path.GetInvalidPathChars());

      foreach (char c in invalid)
        sIn = sIn.Replace(c.ToString(), "");

      return sIn;
    }
    //---------------------------------------------------------------------------
    // Pass Tags to this function such as Title, Album, Artist - returns the tag
    // cleaned up don't pass it a "real" path with slashes and a drive letter
    // you need to keep!
    private string ReplaceIllegalFileChars(string sIn)
    {
      if (string.IsNullOrEmpty(sIn)) return string.Empty;
      sIn = sIn.Replace('/', ' ');
      sIn = sIn.Replace('\\', ' ');
      sIn = sIn.Replace(':', ' ');
      string invalid = new string(Path.GetInvalidFileNameChars());
      foreach (char c in invalid) sIn = sIn.Replace(c.ToString(), "");

      return sIn;
    }
    //---------------------------------------------------------------------------
    private string RemoveIllegalPathChars(string sIn)
    {
      if (string.IsNullOrEmpty(sIn)) return string.Empty;
      string invalid = new string(Path.GetInvalidPathChars());
      foreach (char c in invalid) sIn = sIn.Replace(c.ToString(), "");
      return sIn;
    }
    //---------------------------------------------------------------------------
    private string RemoveIllegalFileChars(string sIn)
    {
      if (string.IsNullOrEmpty(sIn)) return string.Empty;
      string invalid = new string(Path.GetInvalidFileNameChars());
      foreach (char c in invalid) sIn = sIn.Replace(c.ToString(), "");
      return sIn;
    }
    //---------------------------------------------------------------------------
    //
    // Return longest common initial path given a list of paths...
    // http://rosettacode.org/wiki/Find_common_directory_path
    //
    public string FindCommonPath(string Separator, List<string> Paths)
    {
      string CommonPath = String.Empty;

      try
      {
        List<string> SeparatedPath = Paths.First(
          str => str.Length == Paths.Max(st2 => st2.Length)).Split(new string[] { Separator },
                     StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (string PathSegment in SeparatedPath.AsEnumerable())
        {
          if (CommonPath.Length == 0 && Paths.All(str => str.StartsWith(PathSegment))) CommonPath = PathSegment;
          else if (Paths.All(str => str.StartsWith(CommonPath + Separator + PathSegment))) CommonPath += Separator + PathSegment;
          else break;
        }
      }
      catch { MessageBox.Show("Error in FindCommonPath()"); }

      return CommonPath;
    }
    //---------------------------------------------------------------------------
    public SongInfo InitDialogFields()
    {
      // LV_FIELD_TITLE = 0;
      // LV_FIELD_ARTIST = 1;
      // LV_FIELD_ALBUM = 2;
      // LV_FIELD_PERFORMER = 3;
      // LV_FIELD_COMPOSER = 4;
      // LV_FIELD_GENRE = 5;
      // LV_FIELD_PUBLISHER = 6;
      // LV_FIELD_CONDUCTOR = 7;
      // LV_FIELD_YEAR = 8;
      // LV_FIELD_TRACK = 9;
      // LV_FIELD_DURATION = 10;
      // LV_FIELD_COMMENTS = 11;
      // LV_FIELD_LYRICS = 12;
      // LV_FIELD_PATH = 13;
      SongInfo si = new SongInfo();
      si.Title = songView.SelectedItems[0].SubItems[LV_FIELD_TITLE].Text;
      si.Artist = songView.SelectedItems[0].SubItems[LV_FIELD_ARTIST].Text;
      si.Album = songView.SelectedItems[0].SubItems[LV_FIELD_ALBUM].Text;
      si.Performer = songView.SelectedItems[0].SubItems[LV_FIELD_PERFORMER].Text;
      si.Composer = songView.SelectedItems[0].SubItems[LV_FIELD_COMPOSER].Text;
      si.Genre = songView.SelectedItems[0].SubItems[LV_FIELD_GENRE].Text;
      si.Publisher = songView.SelectedItems[0].SubItems[LV_FIELD_PUBLISHER].Text;
      si.Conductor = songView.SelectedItems[0].SubItems[LV_FIELD_CONDUCTOR].Text;
      si.Year = songView.SelectedItems[0].SubItems[LV_FIELD_YEAR].Text;
      si.Track = songView.SelectedItems[0].SubItems[LV_FIELD_TRACK].Text;

      // Set Duration 0 if more than one item selected
      if (songView.SelectedItems.Count > 1)
        si.Duration = TimeSpan.FromSeconds(0);
      else
      {
        // Set the duration field via this item's main Tag property
        try { si.Duration = (TimeSpan)songView.SelectedItems[0].Tag; }
        catch { si.Duration = TimeSpan.FromSeconds(0); }
      }

      si.Comments = songView.SelectedItems[0].SubItems[LV_FIELD_COMMENTS].Text;
      si.Lyrics = songView.SelectedItems[0].SubItems[LV_FIELD_LYRICS].Text;

      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_TITLE].Text != si.Title) { si.Title = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_ARTIST].Text != si.Artist) { si.Artist = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_ALBUM].Text != si.Album) { si.Album = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_PERFORMER].Text != si.Performer) { si.Performer = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_COMPOSER].Text != si.Composer) { si.Composer = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_GENRE].Text != si.Genre) { si.Genre = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_PUBLISHER].Text != si.Publisher) { si.Publisher = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_CONDUCTOR].Text != si.Conductor) { si.Conductor = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_YEAR].Text != si.Year) { si.Year = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_TRACK].Text != si.Track) { si.Track = "*"; break; }

      // NOTE: Search of comments and lyrics for a huge number of selected songs where the fields are long
      // and all the same might take a LONG time!!!!!!
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_COMMENTS].Text != si.Comments) { si.Comments = "*"; break; }
      foreach (ListViewItem lvi in songView.SelectedItems)
        if (lvi.SubItems[LV_FIELD_LYRICS].Text != si.Lyrics) { si.Lyrics = "*"; break; }
      // Fast method...
      //if (songView.SelectedItems.Count > 1) si.Comments = si.Lyrics = "*";
      
      return si;
    }
    //---------------------------------------------------------------------------
    // Useful future snippet...
    //private int getSelectedSubItemIndex(ListView listView)
    //{
    //  if (listView.SelectedItems.Count == 1)
    //  {
    //    int x = 0;
    //    ListViewItem item = listView.SelectedItems[0];
    //    Point pt = listView.PointToClient(Control.MousePosition);
    //    for (int idx = 0; idx < item.SubItems.Count; ++idx)
    //    {
    //      x += listView.Columns[idx].Width;
    //      if (pt.X < x)
    //        return idx;
    //    }
    //  }
    //  return -1;
    //}
    //---------------------------------------------------------------------------
    #endregion

    #region Misc.
    //---------------------------------------------------------------------------
    // Try this instead of new class for listView to get double-buffering!
    // using System.Reflection;
    //public static void SetDoubleBuffered(Control control)
    //{
    //  //Set instance non-public property with name "DoubleBuffered"
    //  //to true.
    //  typeof(Control).InvokeMember("DoubleBuffered",BindingFlags.SetProperty |
    //    BindingFlags.Instance | BindingFlags.NonPublic,null, control, new object[] { true });
    //}
    //---------------------------------------------------------------------------
    private void DisableControls()
    {
      this.songView.ListViewItemSorter = null;

      songView.UseWaitCursor = true;

      menuTools.Enabled = false;
      menuEdit.Enabled = false;
      menuView.Enabled = false;
      menuFile.Enabled = false;
      checkBoxExcel.Enabled = false;
      buttonSetChecks.Enabled = false;
      buttonProcess.Enabled = false;

      progressBar.Value = 0;
      this.g_keyPressed = -1;
    }
    //---------------------------------------------------------------------------
    private void EnableControls()
    {
      songView.UseWaitCursor = false;

      menuTools.Enabled = true;
      menuEdit.Enabled = true;
      menuView.Enabled = true;
      menuFile.Enabled = true;
      checkBoxExcel.Enabled = true;
      buttonSetChecks.Enabled = true;
      buttonProcess.Enabled = true;
      this.progressBar.Value = 0;
      this.g_keyPressed = -1;
      this.songView.ListViewItemSorter = g_lvwColumnSorter;
      songView.Focus();
    }
    //---------------------------------------------------------------------------
    private void TFsort()
    {
      if (songView.Items.Count <= 0) return;

      try
      {
        // Sort by album-title
        g_lvwColumnSorter.SortColumn = LV_FIELD_ALBUM;
        g_lvwColumnSorter.Order = SortOrder.Ascending;

        // Perform the sort with these new sort options.
        this.songView.Sort();
      }
      catch { MessageBox.Show("Problem sorting songs!"); }
    }
    //---------------------------------------------------------------------------
    private string StripToLower(string sIn)
    {
      // We want to set checks if the songs are very
      // close to the same album-name except for case
      // of special chars...

      // using System.Text.RegularExpressions
      // Example: remove all non alphanumeric except space and dash
      // - (dash) must be at end or escaped with \\ to avoid being taken for a range...
      //Regex rgx = new Regex("[^a-zA-Z0-9 \\-]"); // Replace all 

      // We want to simply replace all non alphanumeric chars unless the result
      // is an empty string...
      //Regex rgx = new Regex("[^a-zA-Z0-9]"); // Keep a-z, A-Z and 0-9
      //string sOut = string.Empty;
      //sOut = rgx.Replace(sOut, string.Empty);
      string sOut = new string(sIn.Where(c => char.IsLetterOrDigit(c)).ToArray());
      return (sOut.ToLower());
    }
    //---------------------------------------------------------------------------
    private string GetArtist(ListViewItem lvi)
    {
      string sArtist;

      if ((bool)lvi.SubItems[LV_FIELD_ARTIST].Tag == true)
        sArtist = StripToLower(lvi.SubItems[LV_FIELD_ARTIST].Text);
      else
        sArtist = string.Empty;

      if (VariousUnknownOrEmpty(sArtist) && (bool)lvi.SubItems[LV_FIELD_PERFORMER].Tag)
      {
        string performer = StripToLower(lvi.SubItems[LV_FIELD_PERFORMER].Text);

        if (!string.IsNullOrEmpty(performer))
          sArtist = performer;
      }

      return sArtist;
    }
    //---------------------------------------------------------------------------
    private string GetAlbum(ListViewItem lvi)
    {
      string sAlbum;

      if ((bool)lvi.SubItems[LV_FIELD_ALBUM].Tag == true)
        sAlbum = StripToLower(lvi.SubItems[LV_FIELD_ALBUM].Text);
      else
        sAlbum = string.Empty;

      return sAlbum;
    }
    //---------------------------------------------------------------------------
    bool VariousUnknownOrEmpty(string s)
    {
      if (string.IsNullOrEmpty(s)) return true;
      s = StripToLower(s);
      return s == "various" || s == "various artists" || s == "unknown" || s == "unknown artist";
    }
    //---------------------------------------------------------------------------
    public bool ParsePath(string path, string root, out string artist, out string album, out string title)
    {
      title = artist = album = string.Empty;

      try
      {
        title = Path.GetFileNameWithoutExtension(path); // Title

        int comparelen = 3; // expected tokins: artist, album, song

        // If MediaTags g_root property was set, parse it out of the song-path
        if (!string.IsNullOrEmpty(root) && path.StartsWith(root))
          path = path.Substring(root.Length, path.Length - root.Length);

        if (Path.IsPathRooted(path))
          comparelen++; // Adjust # expected tokins up if drive-letter present...

        // Split into 0=drive, 1=artist, 2=album, 3=song
        // Split into 0=artist, 1=album, 2=song (if not rooted)
        string[] paths = path.Split(Path.DirectorySeparatorChar);

        int len = paths.Length;

        if (len >= comparelen)
        {
          artist = paths[len - 3]; // Artist
          album = paths[len - 2]; // Album
        }
        else if (len >= comparelen - 1)
          album = paths[len - 2]; // Album

        return true;
      }
      catch { return false; } // Threw an exception
    }
    #endregion

    #region Menu Handlers
    //---------------------------------------------------------------------------    
    // FYI: good for debugging?
    //Trace.WriteLine("");
    //Debug.WriteLine("");
    //---------------------------------------------------------------------------
    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DoTagEdit();
    }
    //---------------------------------------------------------------------------
    private void findToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (songView.Items.Count == 0)
      {
        g_findNextIndex = -1;
        g_findNextText = "";
        MessageBox.Show("No Items in list!");
        return;
      }

      try
      {
        using (FormFind ff = new FormFind(g_findNextText, "Find:"))
        {
          if (ff.ShowDialog() == DialogResult.OK)
          {
            ListViewItem lvi = songView.FindItemWithText(ff.FindText, true, 0, true);

            if (lvi != null)
            {
              if (lvi.Index >= 0 && lvi.Index < songView.Items.Count)
              {
                songView.SelectedItems.Clear();
                songView.Focus();
                songView.Items[lvi.Index].Selected = true;
                songView.EnsureVisible(lvi.Index);
                g_findNextIndex = lvi.Index + 1;
                g_findNextText = ff.FindText;
              }
              else
                MessageBox.Show("Index out of bounds!");
            }
            else
              findNextToolStripMenuItem_Click(null, null);
          }
        }
      }
      catch { }
    }
    //---------------------------------------------------------------------------
    private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // Go display dialog if no find-string...
      if (String.IsNullOrEmpty(this.g_findNextText) || g_findNextIndex < 0)
      {
        findToolStripMenuItem_Click(null, null);
        return;
      }

      if (songView.Items.Count == 0)
      {
        g_findNextIndex = -1;
        g_findNextText = "";
        MessageBox.Show("No Items in list!");
        return;
      }

      try
      {
        // Limit check
        if (g_findNextIndex < 0 || g_findNextIndex >= songView.Items.Count) g_findNextIndex = 0;

        ListViewItem lvi = songView.FindItemWithText(g_findNextText, true, g_findNextIndex, true);

        if (lvi != null)
        {
          if (lvi.Index >= 0 && lvi.Index < songView.Items.Count)
          {
            songView.SelectedItems.Clear();
            songView.Focus();
            songView.Items[lvi.Index].Selected = true;
            songView.EnsureVisible(lvi.Index);
            g_findNextIndex = lvi.Index + 1;
          }
          else
            MessageBox.Show("Index out of bounds!");
        }
        else
        {
          MessageBox.Show("Search for \"" + g_findNextText + "\" reached end of list...\r\n" +
                                 "Press F3 to re-start search.");
          g_findNextIndex = -1;
        }
      }
      catch { }
    }
    //---------------------------------------------------------------------------
    private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      //TunesFiX reassembles music compilations that have become disorganized.
      //If you import and convert WMA music files using iTunes, they are
      //automatically organized by Artist rather than by album.
      //A compilation cd will become scattered over dozens of folders.
      //TunesFiX uses an algorithm to collect songs belonging to compilations
      //and puts them into their original folders.
      AboutBox aboutBox = new AboutBox();
      aboutBox.Show();
    }
    //---------------------------------------------------------------------------
    private void helpTagEditorTitleAlbumBoxesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(HELPSITE);
    }
    //---------------------------------------------------------------------------
    private void playSongToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Command Line Parameters for Wmplayer
      //Windows Media Player supports a set of command line parameters that
      //specify how the Player behaves when it starts. The following table details
      //the parameters and their behaviors.
      //
      //Syntax  Behavior  
      //
      //"path\filename"
      //(For example: wmplayer "c:\filename.wma")
      //Start the Player and play the file. 
      //
      //"path\filename" /fullscreen
      //(For example: wmplayer "c:\filename.wmv" /fullscreen)
      //Play the specified file in full-screen mode.
      //
      //You must specify the path and file name of the content to play. 
      //Device:{DVD|AudioCD}
      //(For example: wmplayer /device:audio CD)
      // Play a DVD or audio CD. 
      //"path\filename?WMPSkin=skin name"
      //For example: wmplayer "c:\filename.wma?wmpskin=headspace"
      // Open the Player, applying the specified skin. 
      //Service:keyname Open the Player showing the online store specified by keyname.
      //Requires Windows Media Player 10 or later.
      //Task NowPlaying  Open the Player in the Now Playing feature. 
      //Task MediaGuide  Open the Player in the Media Guide feature (current 
      // active online store in Windows Media Player 10 or later). 
      //Task CDAudio  Open the Player in the Copy from CD feature (Rip feature
      // in Windows Media Player 10 or Windows Media Player 11). This parameter 
      // is not supported in Windows Media Player 12. 
      //Task CDWrite  Open the Player in the Burn feature.
      // Requires Windows Media Player 10. 
      //Task MediaLibrary  Open the Player in the Library feature. 
      //Task RadioTuner  Open the Player in the Radio Tuner feature (current 
      // active online store in Windows Media Player 10 or later). 
      //Task PortableDevice  Open the Player in the Copy to CD or Device feature
      // (Sync feature in Windows Media Player 10 or later). 
      //Task Services /Service servicename Open the Player in the Premium Services
      // feature, showing the service specified by the servicename parameter. This
      // value is the unique name for the service. If the specified service has not
      // been previously viewed, the servicename parameter is ignored. (Opens the specified
      // online store in Windows Media Player 10 or later.) 
      //Task ServiceTaskX Open the Player in the online store service task pane
      // specified by X. For example, /Task ServiceTask1 opens the Player in the       
      // first online store service task pane. 
      //Task SkinViewer  Open the Player in the Skin Chooser feature. 
      //Playlist PlaylistName Open the Player and play the specified playlist. 
      //Schema:{Music|Pictures|Video|TV|Other}
      //For example: wmplayer /Schema:Pictures /Task:PortableDevice
      // Open the Player, showing the specified media category. Requires Windows Media Player 11. 

      if (songView != null)
      {
        try
        {
          // /play /close /fullscreen /Playlist <List> /device:AudioCD
          // /device:DVD /prefetch:3
          //            Process.Start("wmplayer.exe", "\"" +
          //                    lv.SelectedItems[0].SubItems[LV_FIELD_PATH].Text +
          //                                                "?wmpskin=headspace\"");
          if (songView.SelectedItems.Count == 1)
          {
            string f = songView.SelectedItems[0].SubItems[LV_FIELD_PATH].Text;
            if (System.IO.File.Exists(f))
              try { Process.Start(f); }
              catch { } // play song
          }
          else if (songView.SelectedItems.Count > 1)
          {
            // More than one selected item we go write our own playlist and send that as the file to WMP
            List<string> sl = new List<string>();
            foreach (ListViewItem lvi in songView.SelectedItems)
              sl.Add(lvi.SubItems[LV_FIELD_PATH].Text);
            ExportWPL wpl = new ExportWPL(this);

            string fPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + PLAYLIST_PATH; // @"\Discrete-Time Systems\TunesFiX\"

            if (!Directory.Exists(fPath)) Directory.CreateDirectory(fPath);

            string fName = fPath + PLAYLIST_NAME; // "TunesFiX.wpl";

            wpl.Export(sl, fName);

            if (System.IO.File.Exists(fName))
              try { Process.Start(fName); }
              catch { } // play song
          }
        }
        catch { }
      }
    }
    //---------------------------------------------------------------------------
    private void deleteSongTagsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (songView.SelectedItems.Count <= 0)
      {
        MessageBox.Show("Nothing selected to edit...", "TunesFiX");
        return;
      }

      // delete all
      int count = songView.SelectedItems.Count;

      DialogResult dr;

      if (count > 1)
        dr = MessageBox.Show("Strip ALL MEDIA TAGS (!!!) from " + count.ToString() + " selected files?",
          "TunesFiX Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
      else
        dr = MessageBox.Show("Strip ALL MEDIA TAGS (!!!) from\r\n\"" +
          songView.SelectedItems[0].SubItems[LV_FIELD_PATH].Text + "\"?", "TunesFiX Editor",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

      if (dr == DialogResult.Yes)
      {
        foreach (ListViewItem lvi in songView.SelectedItems)
        {
          string fn = lvi.SubItems[LV_FIELD_PATH].Text;

          try
          {
            if (!System.IO.File.Exists(fn))
            {
              if (MessageBox.Show("File does not exist:\r\n\"" + fn + "\"\r\nQuit?", "TunesFiX Editor",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                break;
            }
            else
            {
              using (var mt = new MediaTags.MediaTags(g_rootPath))
              {
                int retVal = mt.DeleteAll(fn);

                if (retVal < 0)
                {
                  if (MessageBox.Show("Unable to delete tags from:\r\n\"" + fn + "\"\r\nQuit?", "TunesFiX Editor",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                                                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                  {
                    mt.Dispose();
                    break;
                  }
                }
              }
            }
          }
          catch { }
        }

        // Refresh modified tag's listView items (color)
        try
        {
          using (var mt = new MediaTags.MediaTags(g_rootPath))
            for (int ii = 0; ii < songView.SelectedItems.Count; ii++)
              AddSongViewData(mt, songView.SelectedItems[ii].SubItems[LV_FIELD_PATH].Text,
                                       songView.SelectedItems[ii].Index); // replace-mode...
        }
        catch { }
      }
    }
    //---------------------------------------------------------------------------
    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SongViewInit();
    }
    //---------------------------------------------------------------------------
    private void restoreMenuItem_Click(object sender, EventArgs e)
    {
      RegistryRead(true);

      // Clear the "DoNotShow" checkbox registry entries
      RegistryKey regKey = Registry.CurrentUser.CreateSubKey(MSGBOXREGKEY);
      regKey.SetValue("DontShow1", false);
      regKey.SetValue("DontShow2", false);
      //regKey.SetValue("DontShow3", false);
      regKey.Close();
    }
    //---------------------------------------------------------------------------
    private void menuOpenMusicFolder_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.Description = MSGFBD_OPENMUSICFOLDER;

      folderBrowserDialog1.SelectedPath = g_rootPath;

      DialogResult dr = folderBrowserDialog1.ShowDialog();

      if (dr == DialogResult.Cancel) return;

      g_rootPath = folderBrowserDialog1.SelectedPath;

      if (!Directory.Exists(g_rootPath))
      {
        g_rootPath = Environment.SpecialFolder.MyMusic.ToString();
        if (!Directory.Exists(g_rootPath)) return;
      }

      this.Text = "TunesFiX: \"" + g_rootPath + "\"";

      // Get the filenames and add to the songView
      int result = ProcessMusicFiles(g_rootPath);

      if (result == 1)
      {
        MessageBox.Show("Add files to list cancelled!", TUNESFIX);
        SongViewInit();
      }
      else if (result < 0)
      {
        MessageBox.Show("Error occured: " + result.ToString(), TUNESFIX);
        SongViewInit();
      }
      else
      {
        // These let us detect remote song-renaming or deleting
        g_watcherRenamed = false;
        g_watcherDeleted = false;
        fileSystemWatcher1.Path = g_rootPath;
        fileSystemWatcher1.EnableRaisingEvents = true;

        buttonSetChecks.Enabled = true;
        buttonProcess.Enabled = true;
      }
    }
    //---------------------------------------------------------------------------
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    //---------------------------------------------------------------------------
    private void removeUncheckedItemsFromListToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DisableControls();

      int count = 0;

      songView.BeginUpdate();

      using (FormStatus fs = new FormStatus(this))
      {
        fs.BodyText = MSGSTATUS_C;
        fs.Show(this);
        fs.Update();

        for (int ii = 0; ii < songView.Items.Count; ii++)
        {
          //if ((ii & 0xf) == 0)
          //{
          if (g_watcherDeleted || g_watcherRenamed)
            break;

          progressBar.Value = (100 * (ii + 1) / songView.Items.Count);
          Application.DoEvents();
          if (this.g_keyPressed >= 0 || fs.KeyPressed >= 0)
            break;
          //}

          if (!songView.Items[ii].Checked)
          {
            songView.Items.RemoveAt(ii);
            count++;
            ii--;
          }
        }

        fs.Close();
      }

      songView.EndUpdate();

      progressBar.Value = 0;

      MessageBox.Show("Removed " + count.ToString() + " songs from list.\r\n" +
        songView.Items.Count.ToString() + " songs remain in the list.");

      NotifyIfFileChanged();
      EnableControls();
    }
    //---------------------------------------------------------------------------
    private void menuSelectAll_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem lvi in songView.Items)
        lvi.Selected = true;
    }
    //---------------------------------------------------------------------------
    private void menuCheckAll_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem lvi in songView.Items)
        lvi.Checked = true;
    }
    //---------------------------------------------------------------------------
    private void menuUncheckAll_Click(object sender, EventArgs e)
    {
      ClearAllChecks();
    }
    //---------------------------------------------------------------------------
    private void menuRemoveEmptyDirectories_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.Description = MSGFBD_REMOVEEMPTYDIR;

      DialogResult dr = folderBrowserDialog1.ShowDialog();
      string path = folderBrowserDialog1.SelectedPath;

      if (dr == DialogResult.Cancel)
        return;

      if (Directory.Exists(path))
      {
        DialogResult result =
        MessageBox.Show("Remove all empty directories below: " + Environment.NewLine +
                Environment.NewLine + "\"" + path + "\"?", TUNESFIX,
                           MessageBoxButtons.YesNo,
                                  MessageBoxIcon.None,
                                          MessageBoxDefaultButton.Button2);

        if (result == DialogResult.No)
          return;

        // Note: This will remove "path" also if it's ultimately empty
        int count = RemoveEmptyDirectories(path);
        string s = "Empty folders removed: " + count.ToString() + Environment.NewLine +
          "Unable to remove: " + g_FailCounter.ToString() + " folders.";
        MessageBox.Show(s, TUNESFIX);
      }
      else
        MessageBox.Show("Directory: " + path + "does not exist!", TUNESFIX);
    }
    //---------------------------------------------------------------------------
    private void menuAddFileTypes_Click(object sender, EventArgs e)
    {
      // Add new file-types
      FormFileTypes fft = new FormFileTypes(this);
      fft.Show(this);
    }
    #endregion

    #region Clipboard

    private void copyToClipboardAllMenuItem_Click(object sender, EventArgs e)
    {
      if (this.songView.Items.Count == 0 || this.songView.Columns.Count == 0)
      {
        MessageBox.Show("There are no items to copy!");
        return;
      }

      try
      {
        Clipboard.Clear();

        if (checkBoxExcel.Checked)
        {
          List<string> sl = new List<string>();
          int colCount = this.songView.Columns.Count;
          string buf = String.Empty;

          // Setup the columns
          for (int i = 0; i < colCount; i++)
          {
            if (songView.Columns[i].Width != 0)
              buf += this.songView.Columns[i].Text + '\t';
          }

          if (buf.Length > 0) // strip the last tab
            buf = buf.Remove(buf.Length - 1, 1);

          sl.Add(buf);

          // Build the data row by row
          for (int i = 0; i < this.songView.Items.Count; i++)
          {
            buf = String.Empty;

            for (int j = 0; j < colCount; j++)
            {
              if (songView.Columns[j].Width != 0)
                buf += this.songView.Items[i].SubItems[j].Text + '\t';
            }

            if (buf.Length > 0) // strip the last tab
              buf = buf.Remove(buf.Length - 1, 1);

            sl.Add(buf);
          }

          Clipboard.SetText(string.Join(Environment.NewLine, sl.ToArray()));
        }
        else // Copy paths only
        {
          System.Collections.Specialized.StringCollection sc =
            new System.Collections.Specialized.StringCollection();

          // Build the data row by row
          for (int i = 0; i < this.songView.Items.Count; i++)
            // Add path
            sc.Add(this.songView.Items[i].SubItems[LV_FIELD_PATH].Text);

          Clipboard.SetFileDropList(sc);
        }
      }
      catch { MessageBox.Show("Error in copy to clipboard!"); }
    }
    //---------------------------------------------------------------------------    
    private void copyToClipboardSelectedMenuItem_Click(object sender, EventArgs e)
    {
      if (this.songView.SelectedItems.Count == 0 || this.songView.Columns.Count == 0)
      {
        MessageBox.Show("There are no items to copy!");
        return;
      }

      try
      {
        Clipboard.Clear();

        if (checkBoxExcel.Checked)
        {
          List<string> sl = new List<string>();
          int colCount = this.songView.Columns.Count;
          string buf = String.Empty;

          // Setup the columns
          for (int i = 0; i < colCount; i++)
          {
            if (songView.Columns[i].Width != 0)
              buf += this.songView.Columns[i].Text + '\t';
          }

          if (buf.Length > 0) // strip the last tab
            buf = buf.Remove(buf.Length - 1, 1);

          sl.Add(buf);

          // Build the data row by row
          for (int i = 0; i < this.songView.SelectedItems.Count; i++)
          {
            buf = String.Empty;

            for (int j = 0; j < colCount; j++)
            {
              if (songView.Columns[j].Width != 0)
                buf += this.songView.SelectedItems[i].SubItems[j].Text + '\t';
            }

            if (buf.Length > 0) // strip the last tab
              buf = buf.Remove(buf.Length - 1, 1);

            sl.Add(buf);
          }

          Clipboard.SetText(string.Join(Environment.NewLine, sl.ToArray()));
        }
        else // Copy selected paths only
        {
          System.Collections.Specialized.StringCollection sc =
            new System.Collections.Specialized.StringCollection();

          // Build the data row by row
          for (int i = 0; i < this.songView.Items.Count; i++)
          {
            // Skip if not selected
            if (!this.songView.Items[i].Selected)
              continue;

            // Add path
            sc.Add(this.songView.Items[i].SubItems[LV_FIELD_PATH].Text);
          }

          Clipboard.SetFileDropList(sc);
        }
      }
      catch { MessageBox.Show("Error in copy to clipboard!"); }
    }
    //---------------------------------------------------------------------------
    private void copyToClipboardCheckedMenuItem_Click(object sender, EventArgs e)
    {
      if (this.songView.CheckedItems.Count == 0 || this.songView.Columns.Count == 0)
      {
        MessageBox.Show("There are no items to copy!");
        return;
      }

      try
      {
        Clipboard.Clear();

        if (checkBoxExcel.Checked)
        {
          List<string> sl = new List<string>();
          int colCount = this.songView.Columns.Count;
          string buf = String.Empty;

          // Setup the columns
          for (int i = 0; i < colCount; i++)
          {
            if (songView.Columns[i].Width != 0)
              buf += this.songView.Columns[i].Text + '\t';
          }

          if (buf.Length > 0) // strip the last tab
            buf = buf.Remove(buf.Length - 1, 1);

          sl.Add(buf);

          // Build the data row by row
          for (int i = 0; i < this.songView.CheckedItems.Count; i++)
          {
            buf = String.Empty;

            for (int j = 0; j < colCount; j++)
            {
              if (songView.Columns[j].Width != 0)
                buf += this.songView.CheckedItems[i].SubItems[j].Text + '\t';
            }

            if (buf.Length > 0) // strip the last tab
              buf = buf.Remove(buf.Length - 1, 1);

            sl.Add(buf);
          }

          Clipboard.SetText(string.Join(Environment.NewLine, sl.ToArray()));
        }
        else // Copy checked paths only
        {
          System.Collections.Specialized.StringCollection sc =
            new System.Collections.Specialized.StringCollection();

          // Build the data row by row
          for (int i = 0; i < this.songView.CheckedItems.Count; i++)
            // Add path
            sc.Add(this.songView.CheckedItems[i].SubItems[LV_FIELD_PATH].Text);

          Clipboard.SetFileDropList(sc);
        }
      }
      catch { MessageBox.Show("Error in copy to clipboard!"); }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Encode/Decode Filters

    private List<string> EncodeFilters(string textFilterList)
    {
      List<string> fileFilterList = new List<string>();

      try
      {
        string[] split = textFilterList.Split(' ');
        fileFilterList.AddRange(split);
      }
      catch { fileFilterList.AddRange(new string[] { ".mp3", ".wma", ".wav" }); }

      return fileFilterList;
    }
    //---------------------------------------------------------------------------
    private string DecodeFilters(List<string> fileFilterList)
    {
      string s = string.Empty;

      try
      {
        foreach (string filter in fileFilterList)
          s += filter + ' ';

        if (s.Length > 0)
          s = s.Substring(0, s.Length - 1);
      }
      catch
      {
        s = ".mp3 .wma .wav";
      }

      return s;
    }
    //---------------------------------------------------------------------------
    private bool FilterInList(string ext)
    {
      try
      {
        // Check the file's extension against the file-filter list
        if (g_fileFilterList.Count > 0)
        {
          foreach (string filter in g_fileFilterList)
            if (ext == filter.ToLower())
              return true;
          return false;
        }
        else
          return false;
      }
      catch { return false; }
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Misc Events

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape) this.g_keyPressed = (int)Keys.Escape;  // Tell ProcessMusicFiles to Cancel...

      // Find Next?
      // neds to fire an event...
      //      if (e.KeyCode == Keys.F3) findNextToolStripMenuItem_Click(null, null);
    }
    //---------------------------------------------------------------------------
    private void songView_ItemChecked(object sender, ItemCheckedEventArgs e)
    // Bug fix for multiple items being checked when holding Shift to select multiple items
    {
      try
      {
        if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift)
        {
          if (g_bFirstChange)
          {
            g_bFirstChange = false;
            e.Item.Checked = !e.Item.Checked;
          }
          else
            g_bFirstChange = true;
        }
      }
      catch { }
    }
    //---------------------------------------------------------------------------
    private void songView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      try
      {
        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == g_lvwColumnSorter.SortColumn)
        {
          // Reverse the current sort direction for this column.
          g_lvwColumnSorter.Order = (g_lvwColumnSorter.Order == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
        }
        else
        {
          // Set the column number that is to be sorted; default to ascending.
          g_lvwColumnSorter.SortColumn = e.Column;
          g_lvwColumnSorter.Order = SortOrder.Ascending;
        }

        // Perform the sort with these new sort options.
        this.songView.Sort();
      }
      catch { MessageBox.Show("Problem sorting songs!"); }
    }
    //---------------------------------------------------------------------------
    private void ClearAllChecks()
    {
      foreach (ListViewItem item in songView.Items) item.Checked = false;
    }
    //---------------------------------------------------------------------------
    #endregion

    #region View Menu Click
    //---------------------------------------------------------------------------
    private void menuViewItem_Click(object sender, EventArgs e)
    {
      // User clicked a view-menu item...
      SetFieldVisibleFromMenuChecks();
      SongViewRefresh();
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Uninstall Menu Click
    //---------------------------------------------------------------------------
    //private void uninstallMenuItem_Click(object sender, EventArgs e)
    //// CSIDL_COMMON_STARTMENU
    //// CSIDL_COMMON_PROGRAMS
    //// CSIDL_COMMON_DESKTOPDIRECTORY
    //// string shortcut = Path.Combine(startMenuDir, @"The Company\MyShortcut.lnk");
    //{
    //  DialogResult result1 = MessageBox.Show("Uninstall TunesFiX?",
    //                             "Are you sure?",
    //                              MessageBoxButtons.YesNo,
    //                              MessageBoxIcon.Warning,
    //                              MessageBoxDefaultButton.Button2);

    //  if (result1 == DialogResult.No)
    //    return;

    //  try
    //  {
    //    string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
    //    string shortcut = Path.Combine(startMenuDir, SHORTCUT_FILE);
    //    if (System.IO.File.Exists(shortcut))
    //      System.IO.File.Delete(shortcut);

    //    shortcut = Path.Combine(startMenuDir, @"Programs\" + SHORTCUT_FILE);
    //    if (System.IO.File.Exists(shortcut))
    //      System.IO.File.Delete(shortcut);

    //    // Remove the C:\Program Data\Microsoft\Windows\Start Menu\Programs\TunesFiX folder (if any)
    //    shortcut = Path.Combine(startMenuDir, @"Programs\TunesFiX");
    //    if (Directory.Exists(shortcut)) Directory.Delete(shortcut, true);
    //  }
    //  catch
    //  {
    //  }

    //  try
    //  {
    //    string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
    //    string shortcut = Path.Combine(startMenuDir, SHORTCUT_FILE);
    //    if (System.IO.File.Exists(shortcut))
    //      System.IO.File.Delete(shortcut);
    //  }
    //  catch
    //  {
    //  }

    //  // This works ok but I want to stay with .NET!
    //  //
    //  //StringBuilder path = new StringBuilder(MAX_PATH);
    //  //SHGetSpecialFolderPath(IntPtr.Zero, path, CSIDL_COMMON_PROGRAMS, false);
    //  //shortcut = path.ToString() + Path.DirectorySeparatorChar + SHORTCUT_FILE;
    //  //if (File.Exists(shortcut))
    //  //  File.Delete(shortcut);

    //  // Remove ourself and all files!
    //  string StartupDir = System.Windows.Forms.Application.StartupPath;
    //  string[] directories = StartupDir.Split(Path.DirectorySeparatorChar);

    //  //MessageBox.Show(directories[directories.Length - 1]);

    //  // if not the TunesFiX subdirectory - its dangerous to delete files...
    //  if (directories.Length == 0 || directories[directories.Length - 1] != TUNESFIX)
    //  {
    //    // Abort program...
    //    MessageBox.Show(TUNESFIX + " is not in the normal install directory." + Environment.NewLine +
    //                        "So as a precaution we won't delete any files..." + Environment.NewLine +
    //                        "You can manually delete " + TUNESFIX + " at: " + Environment.NewLine +
    //                                "\"" + StartupDir + "\"", TUNESFIX);
    //    Application.Exit();
    //    return;
    //  }

    //  // Remove Add/Remove Programs entry
    //  RemoveUninstallKey();

    //  string ModuleName = System.Windows.Forms.Application.ExecutablePath;

    //  // Change to Discrete-Time Systems Directory first, then use "rd"
    //  // do completely remove TunesFiX and all subdirectories and files...
    //  //
    //  // string sCommand = "/c echo \"Removing " + TUNESFIX +
    //  //            " Please Wait...\" & ping 1.1.1.1 -n 1 -w 3000 > nul & " +
    //  //                     "cd ..\\ & rd /s /q \"" + StartupDir + "\"";
    //  //
    //  //
    //  string sCommand = "/c echo \"Removing " + TUNESFIX +
    //   " Please Wait...\" & ping 1.1.1.1 -n 1 -w 3000 > nul & " +
    //                       "cd ..\\ & rd /s /q \"" + StartupDir + "\"";

    //  Process process = new Process();
    //  process.StartInfo.FileName = "cmd.exe";
    //  process.StartInfo.Arguments = sCommand;
    //  process.StartInfo.CreateNoWindow = true;
    //  process.Start();

    //  // Abort program...
    //  Application.Exit();
    //}
    //---------------------------------------------------------------------------
    //private bool IsNewRevision()
    //{
    //  bool bNewVersion = false;

    //  using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(UNINSTALL_KEY, true))
    //  {
    //    if (parent == null)
    //      return false;

    //    try
    //    {
    //      RegistryKey key = null;

    //      try
    //      {
    //        if ((key = parent.OpenSubKey(TUNESFIX, true)) == null) return true; // No uninstall key return true!

    //        string newVersion = GetType().Assembly.GetName().Version.ToString();
    //        string oldVersion = key.GetValue("DisplayVersion").ToString();

    //        //MessageBox.Show(newVersion + ", " + oldVersion);

    //        if (oldVersion != newVersion) bNewVersion = true;
    //      }
    //      finally {if (key != null) key.Close();}
    //    }
    //    catch {return true;} // Can't read uninstall info...
    //  }
    //  return bNewVersion;
    //}
    //---------------------------------------------------------------------------
    //private void CreateUninstaller()
    //{
    //  using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(UNINSTALL_KEY, true))
    //  {
    //    if (parent == null) return;

    //    try
    //    {
    //      RegistryKey key = null;

    //      try
    //      {
    //        key = parent.OpenSubKey(TUNESFIX, true) ?? parent.CreateSubKey(TUNESFIX);
    //        if (key == null) return;

    //        Assembly asm = GetType().Assembly;
    //        Version v = asm.GetName().Version;
    //        string exe = "\"" + asm.CodeBase.Substring(8).Replace("/", "\\\\") + "\"";

    //        key.SetValue("DisplayName", "TunesFiX");
    //        key.SetValue("ApplicationVersion", v.ToString());
    //        key.SetValue("Publisher", "Discrete-Time Systems");
    //        key.SetValue("DisplayIcon", exe);
    //        key.SetValue("DisplayVersion", v.ToString());
    //        key.SetValue("URLInfoAbout", "http://www.yahcolorize.com");
    //        key.SetValue("Contact", "dxzl@live.com");
    //        key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
    //        key.SetValue("UninstallString", exe + " /uninstall");
    //      }
    //      finally {if (key != null) key.Close();}
    //    }
    //    catch {}
    //  }
    //}
    //---------------------------------------------------------------------------
    //private void RemoveUninstallKey()
    //{
    //  using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(UNINSTALL_KEY, true))
    //  {
    //    if (parent == null) return;
    //    try {parent.DeleteSubKey(TUNESFIX, false);}
    //    catch {}
    //  }
    //}
    //---------------------------------------------------------------------------
    #endregion

    #region FileSystemWatcher_Events

    private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
    {
      fileSystemWatcher1.EnableRaisingEvents = false;
      g_watcherOldPath = e.OldFullPath;
      g_watcherNewPath = e.FullPath;
      g_watcherRenamed = true;

      MessageBox.Show("Renamed:\n\"" + g_watcherOldPath + "\"\nto:\n\"" + g_watcherNewPath +
        "\"\n\nYou should click File->Open to re-load or an error may occur!");
    }
    //---------------------------------------------------------------------------
    private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
    {
      fileSystemWatcher1.EnableRaisingEvents = false;
      g_watcherOldPath = "";
      g_watcherNewPath = e.FullPath;
      g_watcherDeleted = true;

      MessageBox.Show("Deleted:\n\"" + g_watcherNewPath +
        "\"\n\nYou should click File->Open to re-load or an error may occur!");
    }
    //---------------------------------------------------------------------------
    private void NotifyIfFileChanged()
    {
      if (g_watcherRenamed)
        MessageBox.Show("Renamed:\n\"" + g_watcherOldPath + "\"\nto:\n\"" + g_watcherNewPath +
        "\"\n\nYou should click File->Open to re-load or an error may occur!");
      else if (g_watcherDeleted)
        MessageBox.Show("Deleted:\n\"" + g_watcherNewPath +
        "\"\n\nYou should click File->Open to re-load or an error may occur!");
    }
    //---------------------------------------------------------------------------
    #endregion

    #region Global Notifier Events

    // Called when user has double-clicked an item in BufferedListView
    // (We want to edit the song's tag-info...)
    void GlobalNotifier_ItemDoubleClicked(int value)
    {
      DoTagEdit();
    }

    //---------------------------------------------------------------------------
    #endregion
  }

  #region Global Notifiers
  // lets us know when user double-clicked an item in BufferedListView or
  // when file's fingerprint calculation is finished

  public delegate void DoubleClickedEventHandler(int value);

  public static class GlobalNotifier
  {
    public static event DoubleClickedEventHandler ItemDoubleClicked;

    public static void OnItemDoubleClicked(int value)
    {
      if (ItemDoubleClicked != null) ItemDoubleClicked(value);
    }
  }
  //---------------------------------------------------------------------------
  #endregion
}
