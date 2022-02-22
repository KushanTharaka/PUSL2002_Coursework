using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WEB_Project
{
    public partial class Farmer_s_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FOrders();
        }

        protected void click_Click(object sender, EventArgs e)
        {
            if (0 == Order.Rows.Count)
            {
                String latit = Convert.ToString(hflati.Value);
                tflati.Text = Convert.ToString(latit);
                String longit = Convert.ToString(hflongi.Value);
                tflongi.Text = Convert.ToString(longit);

                String uname = Request.Cookies["farmeruname"].Value;
                hfuname.Value = uname;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name from FarmerDetails where National_Id=@nic", con);
                cmd.Parameters.AddWithValue("@nic", hfuname.Value);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tfname.Text = dr.GetValue(0).ToString();
                    tfnic.Text = uname;
                }
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Remove current Order !!')</script>");
            }
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if(tfname.Text == "")
            {
                Response.Write("<script>alert('Click Get Location and Farmer Details !')</script>");
            }
            else if(Type.SelectedValue == "")
            {
                Response.Write("<script>alert('Select what you are selling !')</script>");
            }
            else if(tfdescription.Text == "")
            {
                Response.Write("<script>alert('Enter Description !')</script>");
            }
            else if(imgup.FileName == "")
            {
                Response.Write("<script>alert('Insert an Image !')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                imgup.SaveAs(Server.MapPath("~/Images/") + Path.GetFileName(imgup.FileName));
                String link = "Images/" + Path.GetFileName(imgup.FileName);
                SqlCommand cmd = new SqlCommand("insert into FarmerOrders (National_ID, Name, Latitude, Longitude, Selling, Description, Image) values (@nic, @name, @lat, @lng, @type, @description, @img)", con);
                cmd.Parameters.AddWithValue("@nic", tfnic.Text);
                cmd.Parameters.AddWithValue("@name", tfname.Text);
                cmd.Parameters.AddWithValue("@lat", tflati.Text);
                cmd.Parameters.AddWithValue("@lng", tflongi.Text);
                cmd.Parameters.AddWithValue("@type", Type.SelectedValue);
                cmd.Parameters.AddWithValue("@description", tfdescription.Text);
                cmd.Parameters.AddWithValue("@img", link);
                cmd.ExecuteNonQuery();
                tfnic.Text = "";
                tfname.Text = "";
                tflati.Text = "";
                tflongi.Text = "";
                Type.SelectedValue = "";
                tfdescription.Text = "";
                string imageFilePath = Server.MapPath(@"~/Images/imagefilename.extension");
                System.IO.File.Delete("imageFilePath");
                FOrders();
                Response.Write("<script>alert('Order Placed !!')</script>");
            }                     
        }

        public void FOrders()
        {
            String uname = Request.Cookies["farmeruname"].Value;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select Name from FarmerDetails where National_Id=@nic", con);
            cmd1.Parameters.AddWithValue("@nic", uname);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            String name = dr.GetValue(0).ToString();
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FarmerOrders where National_ID=@nid ", con);
            cmd.Parameters.AddWithValue("@nid", uname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Order.DataSource = dt;
            Order.DataBind();
            con.Close();
        }

        protected void Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gvin = Convert.ToInt32(Order.SelectedIndex);
            tfid.Text = Convert.ToString(Order.Rows[gvin].Cells[1].Text);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if(0 == Order.Rows.Count)
            {
                Response.Write("<script>alert('No Order is Placed to Delete !!')</script>");
            }
            else if(tfid.Text == "")
            {
                Response.Write("<script>alert('Select the Order !!')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM FarmerOrders WHERE National_Id=@nationalid;", con);
                cmd.Parameters.AddWithValue("@nationalid", tfid.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                tfid.Text = "";
                FOrders();
            }
            
        }
    }
}