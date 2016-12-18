namespace ChicagoCrime
{
  partial class Form1
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
      this.cmdByYear = new System.Windows.Forms.Button();
      this.graphPanel = new System.Windows.Forms.Panel();
      this.txtFilename = new System.Windows.Forms.TextBox();
      this.arrest = new System.Windows.Forms.Button();
      this.byCrimeButton = new System.Windows.Forms.Button();
      this.inputCrime = new System.Windows.Forms.TextBox();
      this.byAreaButton = new System.Windows.Forms.Button();
      this.areaTxt = new System.Windows.Forms.TextBox();
      this.Chicago = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cmdByYear
      // 
      this.cmdByYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmdByYear.Location = new System.Drawing.Point(12, 12);
      this.cmdByYear.Name = "cmdByYear";
      this.cmdByYear.Size = new System.Drawing.Size(105, 74);
      this.cmdByYear.TabIndex = 0;
      this.cmdByYear.Text = "By Year";
      this.cmdByYear.UseVisualStyleBackColor = true;
      this.cmdByYear.Click += new System.EventHandler(this.cmdByYear_Click);
      // 
      // graphPanel
      // 
      this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.graphPanel.BackColor = System.Drawing.Color.White;
      this.graphPanel.Location = new System.Drawing.Point(123, 12);
      this.graphPanel.Name = "graphPanel";
      this.graphPanel.Size = new System.Drawing.Size(769, 454);
      this.graphPanel.TabIndex = 1;
      // 
      // txtFilename
      // 
      this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFilename.BackColor = System.Drawing.SystemColors.Control;
      this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtFilename.Location = new System.Drawing.Point(123, 474);
      this.txtFilename.Name = "txtFilename";
      this.txtFilename.Size = new System.Drawing.Size(769, 35);
      this.txtFilename.TabIndex = 2;
      this.txtFilename.Text = "Crimes-2013-2015.csv";
      // 
      // arrest
      // 
      this.arrest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.arrest.Location = new System.Drawing.Point(13, 87);
      this.arrest.Name = "arrest";
      this.arrest.Size = new System.Drawing.Size(105, 63);
      this.arrest.TabIndex = 3;
      this.arrest.Text = "Arrest %";
      this.arrest.UseVisualStyleBackColor = true;
      this.arrest.Click += new System.EventHandler(this.arrestButtonClick);
      // 
      // byCrimeButton
      // 
      this.byCrimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.byCrimeButton.Location = new System.Drawing.Point(12, 156);
      this.byCrimeButton.Name = "byCrimeButton";
      this.byCrimeButton.Size = new System.Drawing.Size(102, 72);
      this.byCrimeButton.TabIndex = 4;
      this.byCrimeButton.Text = "By Crime";
      this.byCrimeButton.UseVisualStyleBackColor = true;
      this.byCrimeButton.Click += new System.EventHandler(this.byCrimeClick);
      // 
      // inputCrime
      // 
      this.inputCrime.Location = new System.Drawing.Point(14, 233);
      this.inputCrime.Name = "inputCrime";
      this.inputCrime.Size = new System.Drawing.Size(99, 40);
      this.inputCrime.TabIndex = 5;
      // 
      // byAreaButton
      // 
      this.byAreaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.byAreaButton.Location = new System.Drawing.Point(14, 279);
      this.byAreaButton.Name = "byAreaButton";
      this.byAreaButton.Size = new System.Drawing.Size(96, 75);
      this.byAreaButton.TabIndex = 6;
      this.byAreaButton.Text = "By Area ";
      this.byAreaButton.UseVisualStyleBackColor = true;
      this.byAreaButton.Click += new System.EventHandler(this.byAreaClick);
      // 
      // areaTxt
      // 
      this.areaTxt.Location = new System.Drawing.Point(17, 360);
      this.areaTxt.Name = "areaTxt";
      this.areaTxt.Size = new System.Drawing.Size(95, 40);
      this.areaTxt.TabIndex = 7;
      // 
      // Chicago
      // 
      this.Chicago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Chicago.Location = new System.Drawing.Point(16, 414);
      this.Chicago.Name = "Chicago";
      this.Chicago.Size = new System.Drawing.Size(93, 75);
      this.Chicago.TabIndex = 8;
      this.Chicago.Text = "Chicago";
      this.Chicago.UseVisualStyleBackColor = true;
      this.Chicago.Click += new System.EventHandler(this.cityButtonClick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(904, 508);
      this.Controls.Add(this.Chicago);
      this.Controls.Add(this.areaTxt);
      this.Controls.Add(this.byAreaButton);
      this.Controls.Add(this.arrest);
      this.Controls.Add(this.inputCrime);
      this.Controls.Add(this.byCrimeButton);
      this.Controls.Add(this.txtFilename);
      this.Controls.Add(this.graphPanel);
      this.Controls.Add(this.cmdByYear);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(6);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Chicago Crime Analysis";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdByYear;
    private System.Windows.Forms.Panel graphPanel;
    private System.Windows.Forms.TextBox txtFilename;
    private System.Windows.Forms.Button arrest;
    private System.Windows.Forms.Button byCrimeButton;
    private System.Windows.Forms.TextBox inputCrime;
    private System.Windows.Forms.Button byAreaButton;
    private System.Windows.Forms.TextBox areaTxt;
    private System.Windows.Forms.Button Chicago;
  }
}

