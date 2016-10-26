namespace TunesFiX
{
  partial class FormStatus
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatus));
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.labelName = new System.Windows.Forms.Label();
      this.textBox = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(3, 79);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(405, 14);
      this.progressBar.Step = 1;
      this.progressBar.TabIndex = 0;
      this.progressBar.UseWaitCursor = true;
      this.progressBar.Visible = false;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 96);
      this.tableLayoutPanel1.TabIndex = 3;
      this.tableLayoutPanel1.UseWaitCursor = true;
      // 
      // labelName
      // 
      this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelName.Location = new System.Drawing.Point(3, 58);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(405, 18);
      this.labelName.TabIndex = 1;
      this.labelName.Text = "labelName";
      this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelName.UseWaitCursor = true;
      this.labelName.Visible = false;
      // 
      // textBox
      // 
      this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(245)))));
      this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox.Location = new System.Drawing.Point(3, 3);
      this.textBox.Multiline = true;
      this.textBox.Name = "textBox";
      this.textBox.ReadOnly = true;
      this.textBox.Size = new System.Drawing.Size(405, 52);
      this.textBox.TabIndex = 2;
      this.textBox.TabStop = false;
      this.textBox.Text = "Test Text";
      this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.textBox.UseWaitCursor = true;
      this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
      // 
      // FormStatus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(207)))), ((int)(((byte)(245)))));
      this.ClientSize = new System.Drawing.Size(411, 96);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormStatus";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Status";
      this.UseWaitCursor = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStatus_FormClosing);
      this.Load += new System.EventHandler(this.FormStatus_Load);
      this.Shown += new System.EventHandler(this.FormStatus_Shown);
      this.VisibleChanged += new System.EventHandler(this.FormStatus_VisibleChanged);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormStatus_KeyDown);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox textBox;

  }
}