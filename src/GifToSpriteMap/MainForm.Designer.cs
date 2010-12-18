namespace GifToSpriteMap
{
  partial class MainForm
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
		this.listBoxPaths = new System.Windows.Forms.ListBox();
		this.buttonMoveUp = new System.Windows.Forms.Button();
		this.buttonMoveDown = new System.Windows.Forms.Button();
		this.buttonAdd = new System.Windows.Forms.Button();
		this.buttonRemove = new System.Windows.Forms.Button();
		this.comboBoxShape = new System.Windows.Forms.ComboBox();
		this.buttonGo = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.uiComboOutputAs = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		// 
		// listBoxPaths
		// 
		this.listBoxPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
		this.listBoxPaths.FormattingEnabled = true;
		this.listBoxPaths.IntegralHeight = false;
		this.listBoxPaths.Location = new System.Drawing.Point(10, 30);
		this.listBoxPaths.Name = "listBoxPaths";
		this.listBoxPaths.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
		this.listBoxPaths.Size = new System.Drawing.Size(720, 189);
		this.listBoxPaths.TabIndex = 1;
		this.listBoxPaths.SelectedIndexChanged += new System.EventHandler(this.listBoxPathsSelectedIndexChanged);
		// 
		// buttonMoveUp
		// 
		this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		this.buttonMoveUp.Location = new System.Drawing.Point(735, 30);
		this.buttonMoveUp.Name = "buttonMoveUp";
		this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
		this.buttonMoveUp.TabIndex = 4;
		this.buttonMoveUp.Text = "Move &Up";
		this.buttonMoveUp.UseVisualStyleBackColor = true;
		this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUpClick);
		// 
		// buttonMoveDown
		// 
		this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
		this.buttonMoveDown.Location = new System.Drawing.Point(735, 59);
		this.buttonMoveDown.Name = "buttonMoveDown";
		this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
		this.buttonMoveDown.TabIndex = 5;
		this.buttonMoveDown.Text = "Move &Down";
		this.buttonMoveDown.UseVisualStyleBackColor = true;
		this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDownClick);
		// 
		// buttonAdd
		// 
		this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.buttonAdd.Location = new System.Drawing.Point(12, 236);
		this.buttonAdd.Name = "buttonAdd";
		this.buttonAdd.Size = new System.Drawing.Size(75, 23);
		this.buttonAdd.TabIndex = 2;
		this.buttonAdd.Text = "&Add ";
		this.buttonAdd.UseVisualStyleBackColor = true;
		this.buttonAdd.Click += new System.EventHandler(this.buttonAddClick);
		// 
		// buttonRemove
		// 
		this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		this.buttonRemove.Location = new System.Drawing.Point(93, 236);
		this.buttonRemove.Name = "buttonRemove";
		this.buttonRemove.Size = new System.Drawing.Size(75, 23);
		this.buttonRemove.TabIndex = 3;
		this.buttonRemove.Text = "&Remove";
		this.buttonRemove.UseVisualStyleBackColor = true;
		this.buttonRemove.Click += new System.EventHandler(this.buttonRemoveClick);
		// 
		// comboBoxShape
		// 
		this.comboBoxShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.comboBoxShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxShape.FormattingEnabled = true;
		this.comboBoxShape.Items.AddRange(new object[] {
            "Wide",
            "Square",
            "Tall"});
		this.comboBoxShape.Location = new System.Drawing.Point(641, 236);
		this.comboBoxShape.Name = "comboBoxShape";
		this.comboBoxShape.Size = new System.Drawing.Size(89, 21);
		this.comboBoxShape.TabIndex = 7;
		// 
		// buttonGo
		// 
		this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.buttonGo.Location = new System.Drawing.Point(737, 236);
		this.buttonGo.Name = "buttonGo";
		this.buttonGo.Size = new System.Drawing.Size(75, 23);
		this.buttonGo.TabIndex = 9;
		this.buttonGo.Text = "Go";
		this.buttonGo.UseVisualStyleBackColor = true;
		this.buttonGo.Click += new System.EventHandler(this.buttonGoClick);
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(7, 13);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(114, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "&Paths to animated gifs:";
		// 
		// label2
		// 
		this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(638, 220);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(92, 13);
		this.label2.TabIndex = 6;
		this.label2.Text = "&Destination shape";
		// 
		// uiComboOutputAs
		// 
		this.uiComboOutputAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.uiComboOutputAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.uiComboOutputAs.FormattingEnabled = true;
		this.uiComboOutputAs.Location = new System.Drawing.Point(558, 236);
		this.uiComboOutputAs.Name = "uiComboOutputAs";
		this.uiComboOutputAs.Size = new System.Drawing.Size(74, 21);
		this.uiComboOutputAs.TabIndex = 7;
		this.uiComboOutputAs.SelectedIndexChanged += new System.EventHandler(this.uiComboOutputAsSelectedIndexChanged);
		// 
		// label3
		// 
		this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(555, 220);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(53, 13);
		this.label3.TabIndex = 6;
		this.label3.Text = "&Output as";
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(823, 271);
		this.Controls.Add(this.label3);
		this.Controls.Add(this.label2);
		this.Controls.Add(this.label1);
		this.Controls.Add(this.buttonGo);
		this.Controls.Add(this.uiComboOutputAs);
		this.Controls.Add(this.comboBoxShape);
		this.Controls.Add(this.buttonMoveDown);
		this.Controls.Add(this.buttonRemove);
		this.Controls.Add(this.buttonAdd);
		this.Controls.Add(this.buttonMoveUp);
		this.Controls.Add(this.listBoxPaths);
		this.Name = "MainForm";
		this.Text = "Transform GIF To Spritemap";
		this.Load += new System.EventHandler(this.form1Load);
		this.ResumeLayout(false);
		this.PerformLayout();

    }

    #endregion

	private System.Windows.Forms.ListBox listBoxPaths;
    private System.Windows.Forms.Button buttonMoveUp;
    private System.Windows.Forms.Button buttonMoveDown;
    private System.Windows.Forms.Button buttonAdd;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.ComboBox comboBoxShape;
    private System.Windows.Forms.Button buttonGo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
	private System.Windows.Forms.ComboBox uiComboOutputAs;
	private System.Windows.Forms.Label label3;

  }
}

