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

namespace WEB_Project
{
    public partial class Customer_Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Reply();
            NotReply();
        }
        public void Reply()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Messages where Reply IS NULL;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvreply.DataSource = dt;
            gvreply.DataBind();
            con.Close();
        }

        public void NotReply()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Messages where Reply IS NOT NULL;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvnotreply.DataSource = dt;
            gvnotreply.DataBind();
            con.Close();
        }

        protected void gvreply_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfindex.Value = Convert.ToString(gvreply.SelectedIndex);
            int index = int.Parse(hfindex.Value);
            lblmsg1.Text = Convert.ToString(gvreply.Rows[index].Cells[3].Text);
        }

        protected void gvnotreply_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfindex.Value = Convert.ToString(gvnotreply.SelectedIndex);
            int index = int.Parse(hfindex.Value);
            lblmsg.Text = Convert.ToString(gvnotreply.Rows[index].Cells[3].Text);
            txtrply.Text = Convert.ToString(gvnotreply.Rows[index].Cells[4].Text);
        }

        protected void btnreply_Click(object sender, EventArgs e)
        {
            hfindex.Value = Convert.ToString(gvreply.SelectedIndex);
            int index = int.Parse(hfindex.Value);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            
            if (lblmsg1.Text == "Select a Message" || txtrply1.Text == "")
            {
                Response.Write("<script>alert('Click a Message and Reply')</script>");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Messages set Reply=@reply where National_Id=@nic and Message=@msg;", con);
                cmd.Parameters.AddWithValue("@nic", gvreply.Rows[index].Cells[1].Text);
                cmd.Parameters.AddWithValue("@msg", gvreply.Rows[index].Cells[3].Text);
                cmd.Parameters.AddWithValue("@reply", txtrply1.Text);
                cmd.ExecuteNonQuery();
                lblmsg1.Text = "Select a Message";
                txtrply1.Text = "";
                hfindex.Value = "";
                Reply();
                NotReply();
                Response.Write("<script>alert('Reply Sent !!')</script>");
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            hfindex.Value = Convert.ToString(gvnotreply.SelectedIndex);
            int index = int.Parse(hfindex.Value);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            if (txtrply.Text != "" && lblmsg.Text != "Select a Message")
            {
                
                SqlCommand cmd = new SqlCommand("update Messages set Reply=NULL where National_Id=@nic and Message=@msg;", con);
                cmd.Parameters.AddWithValue("@nic", gvnotreply.Rows[index].Cells[1].Text);
                cmd.Parameters.AddWithValue("@msg", gvnotreply.Rows[index].Cells[3].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                hfindex.Value = "";
                lblmsg.Text = "Select a Message";
                txtrply.Text = "Select a Message";
                Reply();
                NotReply();
                Response.Write("<script>alert('Reply Deleted !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('No Reply to Delete !!')</script>");
            }
        }
    }
}