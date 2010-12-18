namespace GifToSpriteMap
{
  partial class ProcessingWindow
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
      this.pictureBoxSource = new System.Windows.Forms.PictureBox();
      this.pictureBoxDestination = new System.Windows.Forms.PictureBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
      this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestination)).BeginInit();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBoxSource
      // 
      this.pictureBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxSource.Location = new System.Drawing.Point(12, 12);
      this.pictureBoxSource.Name = "pictureBoxSource";
      this.pictureBoxSource.Size = new System.Drawing.Size(100, 50);
      this.pictureBoxSource.TabIndex = 1;
      this.pictureBoxSource.TabStop = false;
      // 
      // pictureBoxDestination
      // 
      this.pictureBoxDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxDestination.Location = new System.Drawing.Point(12, 195);
      this.pictureBoxDestination.Name = "pictureBoxDestination";
      this.pictureBoxDestination.Size = new System.Drawing.Size(100, 50);
      this.pictureBoxDestination.TabIndex = 2;
      this.pictureBoxDestination.TabStop = false;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 470);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(558, 22);
      this.statusStrip1.TabIndex = 5;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripSplitButton1
      // 
      this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem});
      this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripSplitButton1.Name = "toolStripSplitButton1";
      this.toolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
      this.toolStripSplitButton1.Text = "toolStripSplitButton1";
      // 
      // cancelToolStripMenuItem
      // 
      this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
      this.cancelToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
      this.cancelToolStripMenuItem.Text = "Cancel";
      this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
      // 
      // toolStripProgressBar1
      // 
      this.toolStripProgressBar1.Name = "toolStripProgressBar1";
      this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
      this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
      // 
      // ProcessingWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(558, 492);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.pictureBoxDestination);
      this.Controls.Add(this.pictureBoxSource);
      this.Name = "ProcessingWindow";
      this.Text = "Processing Animation...";
      this.SizeChanged += new System.EventHandler(this.ProcessingWindow_SizeChanged);
      this.Load += new System.EventHandler(this.onLoad);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestination)).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxSource;
    private System.Windows.Forms.PictureBox pictureBoxDestination;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
    private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
  }
}