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
    public partial class Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            if(acctype.SelectedValue == "WebMaster")
            {
                SqlCommand cmd = new SqlCommand("select Username, Password from WebmasterLogin where Username=@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPWD.Text);            
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    HttpCookie cookie = new HttpCookie("webmasteruname");
                    cookie.Value = txtUserName.Text;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("WebMaster HomePage.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password or Wrong Account type')</script>");
                }
            }
            else if (acctype.SelectedValue == "Farmer")
            {
                SqlCommand cmd = new SqlCommand("select National_Id, Password from FarmerDetails where National_Id=@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPWD.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    HttpCookie cookie = new HttpCookie("farmeruname");
                    cookie.Value = txtUserName.Text;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Farmer HomePage.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password or Wrong Account type')</script>");
                }
            }
            else if (acctype.SelectedValue == "Keels")
            {
                SqlCommand cmd = new SqlCommand("select Username, Password from KeelsStaffdetails where Username=@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPWD.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    HttpCookie cookie = new HttpCookie("keelsuname");
                    cookie.Value = txtUserName.Text;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Keels HomePage.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password or Wrong Account type')</script>");
                }
            }
            else if (acctype.SelectedValue == "DoA")
            {
                SqlCommand cmd = new SqlCommand("select Username, Password from DoAStaffDetails where Username=@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPWD.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    HttpCookie cookie = new HttpCookie("doauname");
                    cookie.Value = txtUserName.Text;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("DoA HomePage.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password or Wrong Account type')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select an Account Type');", true);
                //Page.RegisterStartupScript("myscript", script: "<script language='javascript'>alert('Select Account Type')</script>");
            }
        }
    }
}