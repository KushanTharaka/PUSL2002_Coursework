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
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessagesReply();          
        }

        protected void btnautofill_Click(object sender, EventArgs e)
        {
            String uname = Request.Cookies["farmeruname"].Value;
            hfuname.Value = uname;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from FarmerDetails where National_Id=@nic", con);
            cmd.Parameters.AddWithValue("@nic", hfuname.Value);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtname.Text = dr.GetValue(0).ToString();
                txtnic.Text = uname;
            }
            con.Close();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Messages(National_Id, Name, Message) values(@nic, @name, @msg)", con);
            if (txtnic.Text == "" || txtnic.Text == "" || txtmsg.Text == "")
            {
                    Response.Write("<script>alert('Click AutoFill and Complete the Message')</script>");           
            }
            else
            {
                cmd.Parameters.AddWithValue("@nic", txtnic.Text);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@msg", txtmsg.Text);
                cmd.ExecuteNonQuery();
                txtnic.Text = "";
                txtname.Text = "";
                txtmsg.Text = "";
                MessagesReply();
                Response.Write("<script>alert('Message Sent !!')</script>");         
            }
        }

        public void MessagesReply()
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
            SqlCommand cmd = new SqlCommand("select * from Messages where National_Id=@nic", con);
            cmd.Parameters.AddWithValue("@nic", uname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Messagegv.DataSource = dt;
            Messagegv.DataBind();
            con.Close();
        }

        protected void Message_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexrow.Value = Convert.ToString(Messagegv.SelectedIndex);
            int index = int.Parse(indexrow.Value);
            tfmsg.Text = Convert.ToString(Messagegv.Rows[index].Cells[3].Text);
            tfreply.Text = Convert.ToString(Messagegv.Rows[index].Cells[4].Text);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if(indexrow.Value != "")
            {
                indexrow.Value = Convert.ToString(Messagegv.SelectedIndex);
                int index = int.Parse(indexrow.Value);
                //txtnic.Text = Convert.ToString(index);
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Messages WHERE National_Id=@nationalid and Message=@message;", con);
                cmd.Parameters.AddWithValue("@nationalid", Messagegv.Rows[index].Cells[1].Text);
                cmd.Parameters.AddWithValue("@message", Messagegv.Rows[index].Cells[3].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                indexrow.Value = "";
                tfmsg.Text = "Select a Message";
                tfreply.Text = "Select a Message";
                MessagesReply();
            }
            else
            {
                Response.Write("<script>alert('No Messages to Delete !!')</script>");
            }
            
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            tfmsg.Text = "Select a Message";
            tfreply.Text = "Select a Message";
        }

        protected void btnclr_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtnic.Text = "";
            txtmsg.Text = "";
        }
    }
}