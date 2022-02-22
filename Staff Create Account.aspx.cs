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
    public partial class Staff_Create_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {


            if (acctype.SelectedValue == "Keels")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into KeelsStaffDetails values (@id, @name, @gender, @uname, @pwd)", con);
                cmd.Parameters.AddWithValue("@id", id_no.Text);
                cmd.Parameters.AddWithValue("@name", Name.Text);
                cmd.Parameters.AddWithValue("@gender", Gender.SelectedValue);
                cmd.Parameters.AddWithValue("@uname", Username.Text);
                cmd.Parameters.AddWithValue("@pwd", Password.Text);
                cmd.ExecuteNonQuery();
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Account Creation Succesful');", true);
                Response.Write("<script>alert('Keels Account Creation Succesful')</script>");
                id_no.Text = "";
                Name.Text = "";
                Gender.SelectedValue = "";
                Username.Text = "";
                Password.Text = "";
                //Page.RegisterStartupScript("myscript", script: "<script language='javascript'>alert('Select Account Type')</script>");
            }
            else if (acctype.SelectedValue == "DoA")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into DoAStaffDetails values (@id, @name, @gender, @uname, @pwd)", con);
                cmd.Parameters.AddWithValue("@id", id_no.Text);
                cmd.Parameters.AddWithValue("@name", Name.Text);
                cmd.Parameters.AddWithValue("@gender", Gender.SelectedValue);
                cmd.Parameters.AddWithValue("@uname", Username.Text);
                cmd.Parameters.AddWithValue("@pwd", Password.Text);
                cmd.ExecuteNonQuery();
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Account Creation Succesful');", true);
                Response.Write("<script>alert('DoA Account Creation Succesful')</script>");
                id_no.Text = "";
                Name.Text = "";
                Gender.SelectedValue = "";
                Username.Text = "";
                Password.Text = "";
                //Page.RegisterStartupScript("myscript", script: "<script language='javascript'>alert('Select Account Type')</script>");
            }
            else
            {
                Response.Write("<script>alert('Select Account Type !!')</script>");
            }

        }
    }
}