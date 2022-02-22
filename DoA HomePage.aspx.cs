using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace WEB_Project
{
    public partial class DoA_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FOrders();
        }

        public void FOrders()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FarmerOrders", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Orders.DataSource = dt;
            Orders.DataBind();
            con.Close();

            var serializedOrders = JsonConvert.SerializeObject(dt);
            hflati.Value = serializedOrders;
        }

        protected void Orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Dnic");
            cookie.Value = Convert.ToString(Orders.SelectedIndex);
            Response.Cookies.Add(cookie);
            int gvin = Convert.ToInt32(Request.Cookies["Dnic"].Value);
            nic.Text = Convert.ToString(Orders.Rows[gvin].Cells[1].Text);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();

            if (nic.Text == "")
            {
                Response.Write("<script>alert('Click an Order First')</script>");
            }
            else
            {
                int gvin = Convert.ToInt32(Request.Cookies["Dnic"].Value);
                nic.Text = Convert.ToString(Orders.Rows[gvin].Cells[1].Text);
                SqlCommand cmd = new SqlCommand("update FarmerOrders set Status=@status where National_Id=@nic;", con);
                cmd.Parameters.AddWithValue("@nic", Orders.Rows[gvin].Cells[1].Text);
                cmd.Parameters.AddWithValue("@status", stat.SelectedValue);
                cmd.ExecuteNonQuery();
                nic.Text = "";
                FOrders();
                if (stat.SelectedValue == "Buying")
                {
                    Response.Write("<script>alert('Order Placed !!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Order Canceled !!')</script>");
                }
            }
        }
    }
}