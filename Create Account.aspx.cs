using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WEB_Project
{
    public partial class Create_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into FarmerDetails values (@nic, @name, @gender, @location, @pwd)", con);
            cmd.Parameters.AddWithValue("@nic", nic.Text);
            cmd.Parameters.AddWithValue("@name", Name.Text);
            cmd.Parameters.AddWithValue("@gender", Gender.SelectedValue);
            if(Location.SelectedValue == "select")
            {
                Response.Write("<script>alert('Select a Location')</script>");
            }
            else
            {
                cmd.Parameters.AddWithValue("@location", Location.SelectedValue);
                cmd.Parameters.AddWithValue("@pwd", Password.Text);
                cmd.ExecuteNonQuery();
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Account Creation Succesful');", true);
                Response.Write("<script>alert('Account Creation Succesful')</script>");
                Response.Redirect("Login Page.aspx");
                //Page.RegisterStartupScript("myscript", script: "<script language='javascript'>alert('Select Account Type')</script>");
            }




        }
    }
}