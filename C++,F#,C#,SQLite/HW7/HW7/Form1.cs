//C# and SQL Program to analyze Chicago Crime Data 
//from a Microsoft SQL Server Database File
//Ishta Bhagat
//U. of Illinois, Chicago
//CS341, Spring 2016
//Homework 7

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CHART = System.Windows.Forms.DataVisualization.Charting;

namespace HW7
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    //Task #1
    private void Form1_Load(object sender, EventArgs e)
    {
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};
      AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      //grab total years 
      string sql1;
      SqlCommand cmd1;
      object total;
      sql1 = @"
      SELECT COUNT(*) AS Total 
      FROM Crimes;"
      ;
      cmd1 = new SqlCommand();
      cmd1.Connection = db;
      cmd1.CommandText = sql1;

      total = cmd1.ExecuteScalar();
      //grab min year 
      SqlCommand cmd2;
      object minYear;
      string sql2 = @"SELECT MIN(Year) from Crimes;";
      cmd2 = new SqlCommand();
      cmd2.Connection = db;
      cmd2.CommandText = sql2;
      minYear = cmd2.ExecuteScalar();
      //grab min year 
      string sql3;
      SqlCommand cmd3;
      object maxYear;
      sql3 = @"SELECT MAX(Year) from Crimes;";
      cmd3 = new SqlCommand();
      cmd3.Connection = db;
      cmd3.CommandText = sql3;
      maxYear = cmd3.ExecuteScalar();
      this.Text = ("Chicago Crime Analysis Total: " + total + " Years:  " + minYear + "-" + maxYear);
      db.Close();
    }
    //Task #2 
    private void yearlyStat(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select Year, Count(*) As 'Total', Format(Sum(Convert(float, Arrested)*100)/Count(*), 'N2') As '% Arrested' from Crimes
              Group By Year
              Order By Year;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;

      
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      foreach(DataRow row in ds.Tables["TABLE"].Rows)
      {
        string msg = string.Format(" Year: {0} : Total Crimes: {1} : Percentage Arrested: {2}", 
          row["Year"], row["Total"], row["% Arrested"]);
          this.listBox1.Items.Add(msg);

      }
    }
    //Task #3 
    private void taskThree(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select IUCR, PrimaryDesc, SecondaryDesc from Codes Order By IUCR;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        string msg = string.Format(" IUCR: {0} : Primary: {1} : Secondary: {2}",
          row["IUCR"], row["PrimaryDesc"], row["SecondaryDesc"]);
        this.listBox1.Items.Add(msg);

      }
    }
    //Task #4
    private void taskFour(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select Area, AreaName from Areas Where Area > 0 Order By AreaName;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        string msg = string.Format(" Area: {0} : AreaName: {1}",
          row["Area"], row["AreaName"]);
        this.listBox1.Items.Add(msg);

      }
    }
    //Task #5
    private void taskFive(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select Year, Count(*) As 'Total Crimes' from Crimes Group By Year Order By Year;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      this.chart1.Series.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        series1.Points.AddXY(row["Year"], row["Total Crimes"]);
      }
    }
    //Task #6
    private void taskSix(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select Area, Count(*) As 'Total Crimes' from Crimes where Area > 0 Group by Area Order by Area;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      this.chart1.Series.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        series1.Points.AddXY(row["Area"], row["Total Crimes"]);
      }
    }
    //Task #7
    private void taskSeven(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select Month(CrimeDate) As 'Month' , Count(*) As 'Total Crimes' from Crimes Group by Month(CrimeDate);";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      this.chart1.Series.Clear();
      var series1 = new CHART.Series
      {
        Name = "Series1",
        Color = System.Drawing.Color.Green,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = CHART.SeriesChartType.Line
      };
      this.chart1.Series.Add(series1);
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        series1.Points.AddXY(row["Month"], row["Total Crimes"]);
      }
    }
    //Task #8
    private void taskEight(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};
      AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      //grab total years 
      string sql1;
      SqlCommand cmd1;
      object total;
      sql1 = @"select Count(*) As 'Total Crimes' From Crimes Where ";
      string year, area, crimeCode;
      bool oneAdded = false; //for the and statement 
      bool yearB = false;
      bool areaB = false;
      bool crimeCodeB = false;
      if (!yearTextBox.Equals("") &&
        (Convert.ToInt32(yearTextBox.Text) > 2000) &&
        (Convert.ToInt32(yearTextBox.Text) < 2016))
      {
        yearB = true;
        year = yearTextBox.Text;
        if ((areaB == true || crimeCodeB == true) || (areaB == true && crimeCodeB == true))
        {
          sql1 = sql1 + "AND Year = " + year;
        }
        else
        {
          sql1 = sql1 + "Year =" + year;
        }
      }

      if (!textBox3.Text.Equals(""))
      {
        area = textBox3.Text;
        areaB = true;
        if ((yearB == true || crimeCodeB == true) || (yearB == true && crimeCodeB == true))
          sql1 = sql1 + " AND Area=" + area;
        else
          sql1 = sql1 + " Area = " + area;
      }
      if (!textBox2.Text.Equals("") )
      {
        crimeCode = textBox2.Text;
        crimeCodeB = true;
        if ((yearB == true || areaB == true) || (yearB == true && areaB == true))
          sql1 = sql1 + " AND IUCR=" + crimeCode;
        else
          sql1 = sql1 + " IUCR=" + crimeCode;
      }
      sql1 = sql1 + ";";
      
      cmd1 = new SqlCommand();
      cmd1.Connection = db;
      cmd1.CommandText = sql1;
      total = cmd1.ExecuteScalar();
      this.listBox1.Items.Add(total);
      db.Close();
    }
    //Task #9
    private void taskNine(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      string number = this.nineText.Text;
      SqlCommand cmd;
      sql = @"select TOP " + number + " Areas.AreaName As 'Area Name', COUNT(*) As 'Total Crimes' from Crimes INNER JOIN Areas on Crimes.Area = Areas.Area where Crimes.Area > 0 Group BY Areas.AreaName Order By 'Total Crimes' DESC;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        string msg = string.Format(" AreaName: {0} : Total Crimes: {1}",
          row["Area Name"], row["Total Crimes"]);
        this.listBox1.Items.Add(msg);

      }
    }
    //Task #10
    private void taskTen(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      string number = this.tenButton.Text;
      SqlCommand cmd;
      sql = @"select TOP " + number + " PrimaryDesc, SecondaryDesc, Step.Total from Codes  INNER JOIN (select count(*) as 'Total', IUCR from Crimes Group by IUCR) as Step on Step.IUCR = Codes.IUCR order by Step.Total DESC;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();

      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        string msg = string.Format(" {0} : {1} : Total: {2}",
          row["PrimaryDesc"], row["SecondaryDesc"], row["Total"]);
        this.listBox1.Items.Add(msg);

      }
    }
    //Task #11 
    private void taskEleven(object sender, EventArgs e)
    {
      string num, iucrCode;
      num = topNum.Text;
      iucrCode = iucrInput.Text;
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      SqlCommand cmd;
      sql = @"select TOP " + num + " Areas.AreaName As 'Area Name', COUNT(*) As 'Total Crimes', IUCR from Crimes INNER JOIN Areas on Crimes.Area = Areas.Area  Where IUCR = \'" + 
        iucrCode+ "\'Group BY Areas.AreaName, IUCR Order By 'Total Crimes' DESC;";
      cmd = new SqlCommand();
      cmd.Connection = db;
      //cmd.CommandText = sql;
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(ds);

      db.Close();
      foreach (DataRow row in ds.Tables["TABLE"].Rows)
      {
        string msg = string.Format(" {0} : {1} : {2}",
          row["Area Name"], row["Total Crimes"], row["IUCR"]);
        this.listBox1.Items.Add(msg);

      }

    }
    //Task #12
    private void taskTwelve(object sender, EventArgs e)
    {
      this.listBox1.Items.Clear();
      string filename, version, connectionInfo;
      SqlConnection db;
      version = "MSSQLLocalDB";
      filename = "CrimeDB.mdf";
      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);
      db = new SqlConnection(connectionInfo);
      db.Open();
      string sql;
      string number = this.topNum12.Text;
      string from = this.fromYear.Text;
      string to = this.toYear.Text;
      string aName = this.areaN.Text;
      if (number.Equals("") || from.Equals("") || to.Equals("") || aName.Equals(""))
      {
        MessageBox.Show("Oh, Enter All Values");
      }
      else
      {
        SqlCommand cmd;
        sql = @"select TOP " + number + " Codes.PrimaryDesc, Codes.SecondaryDesc, COUNT(*) As 'Total Crimes' from Crimes INNER JOIN Areas on Crimes.Area = Areas.Area RIGHT JOIN Codes on Crimes.IUCR = Codes.IUCR Where Areas.AreaName = \'" +
          aName + "\'  AND Crimes.Year BETWEEN " + from + " AND " +
          to + " Group By Codes.PrimaryDesc, Codes.SecondaryDesc Order By 'Total Crimes' DESC;";
        cmd = new SqlCommand();
        cmd.Connection = db;
        //cmd.CommandText = sql;
        DataSet ds = new DataSet();
        cmd.CommandText = sql;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds);
        db.Close();

        foreach (DataRow row in ds.Tables["TABLE"].Rows)
        {
          string msg = string.Format(" {0} : {1} : Total: {2}",
            row["PrimaryDesc"], row["SecondaryDesc"], row["Total Crimes"]);
          this.listBox1.Items.Add(msg);

        }
      }
    }

    private void textBox1(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void label9_Click(object sender, EventArgs e)
    {

    }
  }



}
