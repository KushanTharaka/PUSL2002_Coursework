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
    public partial class Keels_Charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            barchart();
            piechart();
        }

        void barchart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(Selling) from FarmerOrders where Selling='Fruit'", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int fruits = Convert.ToInt32(dr.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(Selling) from FarmerOrders where Selling='Vegetable'", con);
            SqlDataReader dr1 = cmd2.ExecuteReader();
            dr1.Read();
            int vegetables = Convert.ToInt32(dr1.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("update OrderType set Amount=@amount where Type='Fruit';", con);
            cmd3.Parameters.AddWithValue("@amount", fruits);
            cmd3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd4 = new SqlCommand("update OrderType set Amount=@amount where Type='Vegetable';", con);
            cmd4.Parameters.AddWithValue("@amount", vegetables);
            cmd4.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type, SUM(Amount) AS TyAmount FROM OrderType GROUP BY Type;", con);
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
            BarChart.Series[0].Points.DataBindXY(x, y);
            BarChart.Series[0].ChartType = SeriesChartType.StackedColumn;
        }

        void piechart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(National_Id) from FarmerDetails", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int totfarmers = Convert.ToInt32(dr.GetValue(0));
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(Selling) from FarmerOrders", con);
            SqlDataReader dr1 = cmd2.ExecuteReader();
            dr1.Read();
            int sellfarmers = Convert.ToInt32(dr1.GetValue(0));
            con.Close();

            con.Open();
            int farmers = totfarmers - sellfarmers;
            SqlCommand cmd3 = new SqlCommand("update PieChartFarmer set Howmany=@howmany where Type='Total Farmers';", con);
            cmd3.Parameters.AddWithValue("@howmany", farmers);
            cmd3.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd4 = new SqlCommand("update PieChartFarmer set Howmany=@howmany where Type='Farmers Selling Goods';", con);
            cmd4.Parameters.AddWithValue("@howmany", sellfarmers);
            cmd4.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Type, SUM(Howmany) AS Tymany FROM PieChartFarmer GROUP BY Type;", con);
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
            PieChart.Series[0].Points.DataBindXY(x, y);
            PieChart.Series[0].ChartType = SeriesChartType.Pie;
        }
    }
}