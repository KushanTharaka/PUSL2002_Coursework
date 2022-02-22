using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;

namespace WEB_Project
{
    public partial class Farmer_Acc_Revoke_Reinstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FarmerData();
            FarmerRevData();
        }


        public void FarmerData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FarmerDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FarmerAcc.DataSource = dt;
            FarmerAcc.DataBind();
            con.Close();
        }

        public void FarmerRevData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from FarmerRev", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FarmerRevAcc.DataSource = dt;
            FarmerRevAcc.DataBind();
            con.Close();
        }

        protected void btnFRevoke_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            if (txtF1ID.Text != "")
            {
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select National_Id from FarmerOrders where National_Id=@nic", con);
                cmd2.Parameters.AddWithValue("@nic", txtF1ID.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("select * from FarmerOrders where National_Id=@nic", con);
                    cmd3.Parameters.AddWithValue("@nic", txtF1ID.Text);
                    SqlDataReader dr = cmd3.ExecuteReader();
                    dr.Read();
                    String National_Id = dr.GetValue(0).ToString();
                    String Name = dr.GetValue(1).ToString();
                    String Latitude = dr.GetValue(2).ToString();
                    String Longitude = dr.GetValue(3).ToString();
                    String Selling = dr.GetValue(4).ToString();
                    String Description = dr.GetValue(5).ToString();
                    String Image = dr.GetValue(6).ToString();
                    String Status = dr.GetValue(7).ToString();
                    con.Close();

                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("insert into FarmerRevOrders (National_ID, Name, Latitude, Longitude, Selling, Description, Image, Status) values (@nic, @name, @lat, @lng, @type, @description, @img, @status)", con);
                    cmd4.Parameters.AddWithValue("@nic", National_Id);
                    cmd4.Parameters.AddWithValue("@name", Name);
                    cmd4.Parameters.AddWithValue("@lat", Latitude);
                    cmd4.Parameters.AddWithValue("@lng", Longitude);
                    cmd4.Parameters.AddWithValue("@type", Selling);
                    cmd4.Parameters.AddWithValue("@description", Description);
                    cmd4.Parameters.AddWithValue("@img", Image);
                    cmd4.Parameters.AddWithValue("@status", Status);
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("DELETE FROM FarmerOrders WHERE National_Id=@nationalid;", con);
                    cmd5.Parameters.AddWithValue("@nationalid", txtF1ID.Text);
                    cmd5.ExecuteNonQuery();


                }


                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into FarmerRev(National_Id, Name, Gender, Location, Password) values(@nationalid, @name, @gender, @location, @password)", con);
                int rowid = int.Parse(hfindex1.Value);
                cmd1.Parameters.AddWithValue("@nationalid", FarmerAcc.Rows[rowid].Cells[1].Text);
                cmd1.Parameters.AddWithValue("@name", FarmerAcc.Rows[rowid].Cells[2].Text);
                cmd1.Parameters.AddWithValue("@gender", FarmerAcc.Rows[rowid].Cells[3].Text);
                cmd1.Parameters.AddWithValue("@location", FarmerAcc.Rows[rowid].Cells[4].Text);
                cmd1.Parameters.AddWithValue("@password", FarmerAcc.Rows[rowid].Cells[5].Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM FarmerDetails WHERE National_Id=@nationalid;", con);
                cmd.Parameters.AddWithValue("@nationalid", FarmerAcc.Rows[rowid].Cells[1].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtF1ID.Text = "";
                FarmerData();
                FarmerRevData();
            }
            else
            {
                Response.Write("<script>alert('Select An Account to Revoke')</script>");
            }
            
        }

        protected void btnFReinstate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            if(txtF2ID.Text != "")
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select National_Id from FarmerRevOrders where National_Id=@nic", con);
                cmd2.Parameters.AddWithValue("@nic", txtF2ID.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("select * from FarmerRevOrders where National_Id=@nic", con);
                    cmd3.Parameters.AddWithValue("@nic", txtF2ID.Text);
                    SqlDataReader dr = cmd3.ExecuteReader();
                    dr.Read();
                    String National_Id = dr.GetValue(0).ToString();
                    String Name = dr.GetValue(1).ToString();
                    String Latitude = dr.GetValue(2).ToString();
                    String Longitude = dr.GetValue(3).ToString();
                    String Selling = dr.GetValue(4).ToString();
                    String Description = dr.GetValue(5).ToString();
                    String Image = dr.GetValue(6).ToString();
                    String Status = dr.GetValue(7).ToString();
                    con.Close();

                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("insert into FarmerOrders (National_ID, Name, Latitude, Longitude, Selling, Description, Image, Status) values (@nic, @name, @lat, @lng, @type, @description, @img, @status)", con);
                    cmd4.Parameters.AddWithValue("@nic", National_Id);
                    cmd4.Parameters.AddWithValue("@name", Name);
                    cmd4.Parameters.AddWithValue("@lat", Latitude);
                    cmd4.Parameters.AddWithValue("@lng", Longitude);
                    cmd4.Parameters.AddWithValue("@type", Selling);
                    cmd4.Parameters.AddWithValue("@description", Description);
                    cmd4.Parameters.AddWithValue("@img", Image);
                    cmd4.Parameters.AddWithValue("@status", Status);
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("DELETE FROM FarmerRevOrders WHERE National_Id=@nationalid;", con);
                    cmd5.Parameters.AddWithValue("@nationalid", txtF2ID.Text);
                    cmd5.ExecuteNonQuery();
                    con.Close();

                }

                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into FarmerDetails(National_Id, Name, Gender, Location, Password) values(@nationalid, @name, @gender, @location, @password)", con);
                int rowid = int.Parse(hfindex.Value);
                cmd1.Parameters.AddWithValue("@nationalid", FarmerRevAcc.Rows[rowid].Cells[1].Text);
                cmd1.Parameters.AddWithValue("@name", FarmerRevAcc.Rows[rowid].Cells[2].Text);
                cmd1.Parameters.AddWithValue("@gender", FarmerRevAcc.Rows[rowid].Cells[3].Text);
                cmd1.Parameters.AddWithValue("@location", FarmerRevAcc.Rows[rowid].Cells[4].Text);
                cmd1.Parameters.AddWithValue("@password", FarmerRevAcc.Rows[rowid].Cells[5].Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM FarmerRev WHERE National_Id=@nationalid;", con);
                cmd.Parameters.AddWithValue("@nationalid", FarmerRevAcc.Rows[rowid].Cells[1].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtF2ID.Text = "";
                FarmerData();
                FarmerRevData();
            }
            else
            {
                Response.Write("<script>alert('Select An Account to Reinstate')</script>");
            }
            
        }

        protected void FarmerAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idno = FarmerAcc.SelectedIndex;
            txtF1ID.Text = Convert.ToString(FarmerAcc.Rows[idno].Cells[1].Text);
            hfindex1.Value = Convert.ToString(FarmerAcc.SelectedIndex);
        }

        protected void FarmerRevAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idno = FarmerRevAcc.SelectedIndex;
            txtF2ID.Text = Convert.ToString(FarmerRevAcc.Rows[idno].Cells[1].Text);
            hfindex.Value = Convert.ToString(FarmerRevAcc.SelectedIndex);
        }

        protected void typeacc_Click(object sender, EventArgs e)
        {
            if (acctype.SelectedValue == "Farmer")
            {
                Response.Redirect("Farmer Acc Revoke Reinstate");
            }
            else if (acctype.SelectedValue == "Keels")
            {
                Response.Redirect("Keels Acc Revoke Reinstate");
            }
            else
            {
                Response.Redirect("DoA Acc Revoke Reinstate");
            }
        }
    }
}