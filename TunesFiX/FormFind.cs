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
