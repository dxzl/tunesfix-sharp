using System;
using System.Windows.Forms;

namespace TunesFiX
{
  public partial class FormSetChecks : Form
  {
    internal const int SETCHECK_COMPILLATIONS = 1;
    internal const int SETCHECK_DBTAP = 2;

    // automatic read-only property must be set before calling ShowDialog()!
    public int Mode { get; set; }
    public bool ExcludeCompillations { get; set; }
    public bool IgnorePrefix { get; set; }
    public string Prefix { get; set; }
    public double Ratio { get; set; }  // % of songs in album that define a "collection"
    public int MinSongs { get; set; }  // Minimum songs in a collection

    public FormSetChecks()
    {
      InitializeComponent();

      toolTip1.SetToolTip(upDownPercent, "Minimum percentage of different artists in" + Environment.NewLine +
        "an album that defines it as a \"collection\".");

      toolTip1.SetToolTip(upDownMinSongs, "Minimum number of different artists on the same album " + "to call it a \"collection\"." + Environment.NewLine +
        "(Setting this to 0 means ALL songs will be re-ordered by " + "Album, then Artist)");
    }

    private void FormSetChecks_Shown(object sender, EventArgs e)
    {
      checkBoxExcludeComp.Checked = ExcludeCompillations;
      checkBoxIgnorePrefix.Checked = IgnorePrefix;
      textBoxPrefix.Text = Prefix;

      if (Mode == SETCHECK_DBTAP)
      {
        radioButtonDBTAP.Checked = true;
        checkBoxExcludeComp.Visible = true;
        checkBoxIgnorePrefix.Visible = true;
        textBoxPrefix.Visible = checkBoxIgnorePrefix.Checked ? true : false;
        upDownPercent.Visible = false;
        upDownMinSongs.Visible = false;
        labelMinArtists.Visible = false;
        labelMinPercent.Visible = false;
      }
      else
      {
        radioButtonCompillations.Checked = true;
        checkBoxExcludeComp.Visible = false;
        checkBoxIgnorePrefix.Visible = false;
        textBoxPrefix.Visible = false;
        upDownPercent.Visible = true;
        upDownMinSongs.Visible = true;
        labelMinArtists.Visible = true;
        labelMinPercent.Visible = true;
      }
    }

    private void FormSetChecks_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (radioButtonCompillations.Checked) this.Mode = SETCHECK_COMPILLATIONS;
      else this.Mode = SETCHECK_DBTAP;

      ExcludeCompillations =checkBoxExcludeComp.Checked;
      IgnorePrefix = checkBoxIgnorePrefix.Checked;
      Prefix = textBoxPrefix.Text;
      Ratio = (double)upDownPercent.Value / 100.0;
      MinSongs = (int)upDownMinSongs.Value;
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void radioButtonCompillations_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButtonDBTAP.Checked)
      {
        checkBoxExcludeComp.Visible = true;
        checkBoxIgnorePrefix.Visible = true;
        textBoxPrefix.Visible = checkBoxIgnorePrefix.Checked ? true : false;
        upDownPercent.Visible = false;
        upDownMinSongs.Visible = false;
        labelMinArtists.Visible = false;
        labelMinPercent.Visible = false;
      }
      else
      {
        checkBoxExcludeComp.Visible = false;
        checkBoxIgnorePrefix.Visible = false;
        textBoxPrefix.Visible = false;
        upDownPercent.Visible = true;
        upDownMinSongs.Visible = true;
        labelMinArtists.Visible = true;
        labelMinPercent.Visible = true;
      }
    }

    private void checkBoxIgnorePrefix_CheckedChanged(object sender, EventArgs e)
    {
      textBoxPrefix.Visible = checkBoxIgnorePrefix.Checked ? true : false;
    }
  }
}
