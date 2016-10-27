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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TunesFiX
{
  public partial class FormProcessing : Form
  {
    internal const int PROCESSING_TAGTOPATH = 1;
    internal const int PROCESSING_PATHTOTAG = 2;

    // automatic read-only property must be set before calling ShowDialog()!
    public int Mode { get; set; }
    public bool TitleChecked { get; set; }
    public bool AlbumChecked { get; set; }
    public bool ArtistChecked { get; set; }
    public bool TransferArt { get; set; }
    public bool OverwriteTags { get; set; }

    public FormProcessing()
    {
      InitializeComponent();
    }

    private void FormProcessing_Shown(object sender, EventArgs e)
    {
      if (this.Mode == PROCESSING_TAGTOPATH)
        radioButtonTagToPath.Checked = true;
      else
        radioButtonPathToTag.Checked = true;

      checkBoxTitle.Checked = TitleChecked;
      checkBoxAlbum.Checked = AlbumChecked;
      checkBoxArtist.Checked = ArtistChecked;
      checkBoxTransferArt.Checked = TransferArt;
      checkBoxOverwriteTags.Checked = OverwriteTags;
    }

    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
      checkBoxTransferArt.Visible = radioButtonPathToTag.Checked ? false : true;
      checkBoxOverwriteTags.Visible = radioButtonPathToTag.Checked ? true : false;
    }

    private void FormProcessing_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (radioButtonTagToPath.Checked) this.Mode = PROCESSING_TAGTOPATH;
      else this.Mode = PROCESSING_PATHTOTAG;

      TitleChecked = checkBoxTitle.Checked;
      AlbumChecked = checkBoxAlbum.Checked;
      ArtistChecked = checkBoxArtist.Checked;
      TransferArt = checkBoxTransferArt.Checked;
      OverwriteTags = checkBoxOverwriteTags.Checked;
    }
  }
}
