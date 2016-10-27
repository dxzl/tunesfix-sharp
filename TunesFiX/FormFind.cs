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
  public partial class FormFind : Form
  {
    private string findText;
    public string FindText { get {return findText;} set { findText = value; } }

    public FormFind(string findText, string title)
    {
      InitializeComponent();
      this.findText = findText;
      this.textBox.Text = this.findText;
      this.Text = title;
    }

    private void FormFind_FormClosing(object sender, FormClosingEventArgs e)
    {
      findText = textBox.Text;
    }
  }
}
