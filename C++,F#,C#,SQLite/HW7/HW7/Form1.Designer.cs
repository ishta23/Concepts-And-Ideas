namespace HW7
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.button1 = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.button4 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.yearTextBox = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.button7 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.nineText = new System.Windows.Forms.TextBox();
      this.nineButton = new System.Windows.Forms.Button();
      this.button8 = new System.Windows.Forms.Button();
      this.tenButton = new System.Windows.Forms.TextBox();
      this.topNum = new System.Windows.Forms.TextBox();
      this.iucrInput = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.elevenButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.topNum12 = new System.Windows.Forms.TextBox();
      this.fromYear = new System.Windows.Forms.TextBox();
      this.toYear = new System.Windows.Forms.TextBox();
      this.button9 = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.areaN = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(13, 13);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(132, 52);
      this.button1.TabIndex = 0;
      this.button1.Text = "#2: Each Year";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.yearlyStat);
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 20;
      this.listBox1.Location = new System.Drawing.Point(151, 12);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(616, 284);
      this.listBox1.TabIndex = 1;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(13, 71);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(132, 49);
      this.button2.TabIndex = 2;
      this.button2.Text = "#3:Crime Codes";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.taskThree);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(13, 180);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(132, 42);
      this.button3.TabIndex = 3;
      this.button3.Text = "#5: Total Graph";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.taskFive);
      // 
      // chart1
      // 
      chartArea2.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea2);
      legend2.Name = "Legend1";
      this.chart1.Legends.Add(legend2);
      this.chart1.Location = new System.Drawing.Point(316, 319);
      this.chart1.Name = "chart1";
      series2.ChartArea = "ChartArea1";
      series2.Legend = "Legend1";
      series2.Name = "Series1";
      this.chart1.Series.Add(series2);
      this.chart1.Size = new System.Drawing.Size(448, 233);
      this.chart1.TabIndex = 4;
      this.chart1.Text = "chart1";
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(13, 126);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(132, 48);
      this.button4.TabIndex = 5;
      this.button4.Text = "#4: Area Names";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.taskFour);
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(13, 229);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(132, 45);
      this.button5.TabIndex = 6;
      this.button5.Text = "#6: Area Graph";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.taskSix);
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(12, 277);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(132, 38);
      this.button6.TabIndex = 7;
      this.button6.Text = "#7: Month Graph";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.taskSeven);
      // 
      // yearTextBox
      // 
      this.yearTextBox.Location = new System.Drawing.Point(79, 321);
      this.yearTextBox.Name = "yearTextBox";
      this.yearTextBox.Size = new System.Drawing.Size(61, 26);
      this.yearTextBox.TabIndex = 8;
      this.yearTextBox.TextChanged += new System.EventHandler(this.textBox1);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(79, 353);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(61, 26);
      this.textBox2.TabIndex = 9;
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(81, 385);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(59, 26);
      this.textBox3.TabIndex = 10;
      this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
      // 
      // button7
      // 
      this.button7.Location = new System.Drawing.Point(12, 420);
      this.button7.Name = "button7";
      this.button7.Size = new System.Drawing.Size(133, 32);
      this.button7.TabIndex = 11;
      this.button7.Text = "#8: Combo List";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new System.EventHandler(this.taskEight);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 321);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 20);
      this.label1.TabIndex = 12;
      this.label1.Text = "Year";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(14, 358);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 20);
      this.label2.TabIndex = 13;
      this.label2.Text = "IUCR";
      this.label2.Click += new System.EventHandler(this.label2_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(18, 390);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 20);
      this.label3.TabIndex = 14;
      this.label3.Text = "Area #";
      this.label3.Click += new System.EventHandler(this.label3_Click);
      // 
      // nineText
      // 
      this.nineText.Location = new System.Drawing.Point(13, 459);
      this.nineText.Name = "nineText";
      this.nineText.Size = new System.Drawing.Size(61, 26);
      this.nineText.TabIndex = 15;
      // 
      // nineButton
      // 
      this.nineButton.Location = new System.Drawing.Point(81, 459);
      this.nineButton.Name = "nineButton";
      this.nineButton.Size = new System.Drawing.Size(63, 32);
      this.nineButton.TabIndex = 16;
      this.nineButton.Text = "#9";
      this.nineButton.UseVisualStyleBackColor = true;
      this.nineButton.Click += new System.EventHandler(this.taskNine);
      // 
      // button8
      // 
      this.button8.Location = new System.Drawing.Point(81, 498);
      this.button8.Name = "button8";
      this.button8.Size = new System.Drawing.Size(63, 34);
      this.button8.TabIndex = 17;
      this.button8.Text = "#10";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new System.EventHandler(this.taskTen);
      // 
      // tenButton
      // 
      this.tenButton.Location = new System.Drawing.Point(12, 494);
      this.tenButton.Name = "tenButton";
      this.tenButton.Size = new System.Drawing.Size(63, 26);
      this.tenButton.TabIndex = 18;
      // 
      // topNum
      // 
      this.topNum.Location = new System.Drawing.Point(223, 298);
      this.topNum.Name = "topNum";
      this.topNum.Size = new System.Drawing.Size(87, 26);
      this.topNum.TabIndex = 19;
      // 
      // iucrInput
      // 
      this.iucrInput.Location = new System.Drawing.Point(223, 331);
      this.iucrInput.Name = "iucrInput";
      this.iucrInput.Size = new System.Drawing.Size(87, 26);
      this.iucrInput.TabIndex = 20;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(157, 300);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 20);
      this.label4.TabIndex = 21;
      this.label4.Text = "Top N: ";
      this.label4.Click += new System.EventHandler(this.label4_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(167, 334);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(49, 20);
      this.label5.TabIndex = 22;
      this.label5.Text = "IUCR";
      // 
      // elevenButton
      // 
      this.elevenButton.Location = new System.Drawing.Point(169, 362);
      this.elevenButton.Name = "elevenButton";
      this.elevenButton.Size = new System.Drawing.Size(141, 35);
      this.elevenButton.TabIndex = 23;
      this.elevenButton.Text = "#11 ";
      this.elevenButton.UseVisualStyleBackColor = true;
      this.elevenButton.Click += new System.EventHandler(this.taskEleven);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(168, 403);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(59, 20);
      this.label6.TabIndex = 24;
      this.label6.Text = "Top N: ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(168, 436);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(50, 20);
      this.label7.TabIndex = 25;
      this.label7.Text = "From:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(172, 460);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(35, 20);
      this.label8.TabIndex = 26;
      this.label8.Text = "To: ";
      // 
      // topNum12
      // 
      this.topNum12.Location = new System.Drawing.Point(223, 403);
      this.topNum12.Name = "topNum12";
      this.topNum12.Size = new System.Drawing.Size(87, 26);
      this.topNum12.TabIndex = 27;
      // 
      // fromYear
      // 
      this.fromYear.Location = new System.Drawing.Point(225, 436);
      this.fromYear.Name = "fromYear";
      this.fromYear.Size = new System.Drawing.Size(85, 26);
      this.fromYear.TabIndex = 28;
      // 
      // toYear
      // 
      this.toYear.Location = new System.Drawing.Point(225, 466);
      this.toYear.Name = "toYear";
      this.toYear.Size = new System.Drawing.Size(85, 26);
      this.toYear.TabIndex = 29;
      // 
      // button9
      // 
      this.button9.Location = new System.Drawing.Point(169, 519);
      this.button9.Name = "button9";
      this.button9.Size = new System.Drawing.Size(141, 38);
      this.button9.TabIndex = 30;
      this.button9.Text = "#12";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new System.EventHandler(this.taskTwelve);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(150, 494);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(89, 20);
      this.label9.TabIndex = 31;
      this.label9.Text = "Area Name";
      this.label9.Click += new System.EventHandler(this.label9_Click);
      // 
      // areaN
      // 
      this.areaN.Location = new System.Drawing.Point(246, 493);
      this.areaN.Name = "areaN";
      this.areaN.Size = new System.Drawing.Size(64, 26);
      this.areaN.TabIndex = 32;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(776, 564);
      this.Controls.Add(this.areaN);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.button9);
      this.Controls.Add(this.toYear);
      this.Controls.Add(this.fromYear);
      this.Controls.Add(this.topNum12);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.elevenButton);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.iucrInput);
      this.Controls.Add(this.topNum);
      this.Controls.Add(this.tenButton);
      this.Controls.Add(this.button8);
      this.Controls.Add(this.nineButton);
      this.Controls.Add(this.nineText);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button7);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.yearTextBox);
      this.Controls.Add(this.button6);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.chart1);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.TextBox yearTextBox;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox nineText;
    private System.Windows.Forms.Button nineButton;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.TextBox tenButton;
    private System.Windows.Forms.TextBox topNum;
    private System.Windows.Forms.TextBox iucrInput;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button elevenButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox topNum12;
    private System.Windows.Forms.TextBox fromYear;
    private System.Windows.Forms.TextBox toYear;
    private System.Windows.Forms.Button button9;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox areaN;
  }
}

