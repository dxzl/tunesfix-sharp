using System;
using System.Windows.Forms;

namespace TunesFiX
{
  public partial class FormStatus : Form
  {
    private int keyPressed = -1;

    public int KeyPressed // Calling Form should poll this...
    {
      get { return this.keyPressed; }
    }

    public string BodyText
    {
      get { return this.textBox.Text; }
      set { this.textBox.Text = value; }
    }

    public bool ProgressVisible // Calling Form should poll this...
    {
      get { return this.progressBar.Visible; }
      set { this.progressBar.Visible = value; }
    }

    public int ProgressValue
    {
      set
      {
        this.progressBar.Value = value;

        if (!this.progressBar.Visible)
          this.progressBar.Visible = true;
      }
    }

    public string LabelName
    {
      set 
      { 
        this.labelName.Text = value; 
        this.labelName.Visible = true;
      }
    }

    private readonly IMainForm form;

    public FormStatus(IMainForm form)
    {
      InitializeComponent();
      this.form = form;
    }

    private void FormStatus_Load(object sender, EventArgs e)
    {
    }

    private void FormStatus_Shown(object sender, EventArgs e)
    {
      textBox.DeselectAll();
    }

    private void textBox_TextChanged(object sender, EventArgs e)
    {
      textBox.DeselectAll();
    }

    private void FormStatus_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.keyPressed = -1; // Reset
    }

    private void FormStatus_VisibleChanged(object sender, EventArgs e)
    {
      this.keyPressed = -1; // Reset
    }

    private void FormStatus_KeyDown(object sender, KeyEventArgs e)
    {
      // If KeyPreview is true, this function will handle
      // key events first and then pass them to the focused
      // child control.
      if (e.KeyCode == Keys.Escape) this.keyPressed = (int)Keys.Escape;  // Tell main program to Cancel...

      // Set this to block key events from
      // being passed to the child-control with focus
      e.Handled = true;
    }
  }
}
