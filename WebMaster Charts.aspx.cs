using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace WEB_Project
{
    public partial class WebMaster_Charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            farmerchart();
            Keelschart();
            DoAchart();
        }

        void farmerchart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(National_Id) from FarmerDetails", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int active = Convert.ToInt32(dr.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(National_Id) from FarmerRev", con);
            SqlDataReader dr1 = cmd2.ExecuteReader();
            dr1.Read();
            int nonactive = Convert.ToInt32(dr1.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("update ReportFarmerAcc set Howmany=@amount where Type='Active Accounts';", con);
            cmd3.Parameters.AddWithValue("@amount", active);
            cmd3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd4 = new SqlCommand("update ReportFarmerAcc set Howmany=@amount where Type='Revoked Accounts';", con);
            cmd4.Parameters.AddWithValue("@amount", nonactive);
            cmd4.ExecuteNonQuery();
            con.Close();

            con.Open();
            int total = active + nonactive;
            SqlCommand cmd5 = new SqlCommand("update ReportFarmerAcc set Howmany=@amount where Type='Total Accounts';", con);
            cmd5.Parameters.AddWithValue("@amount", total);
            cmd5.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type, SUM(Howmany) AS Farmers FROM ReportFarmerAcc GROUP BY Type;", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
        }

        void Keelschart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(Keels_Id) from KeelsStaffDetails", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int active = Convert.ToInt32(dr.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(Keels_Id) from KeelsRev", con);
            SqlDataReader dr1 = cmd2.ExecuteReader();
            dr1.Read();
            int nonactive = Convert.ToInt32(dr1.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("update ReportKeelsAcc set Howmany=@amount where Type='Active Accounts';", con);
            cmd3.Parameters.AddWithValue("@amount", active);
            cmd3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd4 = new SqlCommand("update ReportKeelsAcc set Howmany=@amount where Type='Revoked Accounts';", con);
            cmd4.Parameters.AddWithValue("@amount", nonactive);
            cmd4.ExecuteNonQuery();
            con.Close();

            con.Open();
            int total = active + nonactive;
            SqlCommand cmd5 = new SqlCommand("update ReportKeelsAcc set Howmany=@amount where Type='Total Accounts';", con);
            cmd5.Parameters.AddWithValue("@amount", total);
            cmd5.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type, SUM(Howmany) AS Keels_Staff FROM ReportKeelsAcc GROUP BY Type;", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart2.Series[0].Points.DataBindXY(x, y);
            Chart2.Series[0].ChartType = SeriesChartType.StackedColumn;
        }

        void DoAchart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(DoA_Id) from DoAStaffDetails", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int active = Convert.ToInt32(dr.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(DoA_Id) from DoARev", con);
            SqlDataReader dr1 = cmd2.ExecuteReader();
            dr1.Read();
            int nonactive = Convert.ToInt32(dr1.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("update ReportDoAAcc set Howmany=@amount where Type='Active Accounts';", con);
            cmd3.Parameters.AddWithValue("@amount", active);
            cmd3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd4 = new SqlCommand("update ReportDoAAcc set Howmany=@amount where Type='Revoked Accounts';", con);
            cmd4.Parameters.AddWithValue("@amount", nonactive);
            cmd4.ExecuteNonQuery();
            con.Close();

            con.Open();
            int total = active + nonactive;
            SqlCommand cmd5 = new SqlCommand("update ReportDoAAcc set Howmany=@amount where Type='Total Accounts';", con);
            cmd5.Parameters.AddWithValue("@amount", total);
            cmd5.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type, SUM(Howmany) AS DoA_Staff FROM ReportDoAAcc GROUP BY Type;", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart3.Series[0].Points.DataBindXY(x, y);
            Chart3.Series[0].ChartType = SeriesChartType.StackedColumn;
        }
    }
}