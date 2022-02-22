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
    public partial class DoA_Acc_Revoke_Reinstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoAData();
            DoARevData();
        }

        public void DoAData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DoAStaffDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DoAAcc.DataSource = dt;
            DoAAcc.DataBind();
            con.Close();
        }

        public void DoARevData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DoARev", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DoARevAcc.DataSource = dt;
            DoARevAcc.DataBind();
            con.Close();
        }

        protected void DoAAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idno = DoAAcc.SelectedIndex;
            txtD1ID.Text = Convert.ToString(DoAAcc.Rows[idno].Cells[1].Text);
            hfindex1.Value = Convert.ToString(DoAAcc.SelectedIndex);
        }

        protected void DoARevAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idno = DoARevAcc.SelectedIndex;
            txtD2ID.Text = Convert.ToString(DoARevAcc.Rows[idno].Cells[1].Text);
            hfindex.Value = Convert.ToString(DoARevAcc.SelectedIndex);
        }

        protected void btnDRevoke_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();           
            if(txtD1ID.Text != "")
            {
                int rowid = int.Parse(hfindex1.Value);
                SqlCommand cmd1 = new SqlCommand("insert into DoARev(DoA_Id, Name, Gender, Username, Password) values(@doaid, @name, @gender, @username, @password)", con);
                cmd1.Parameters.AddWithValue("@doaid", DoAAcc.Rows[rowid].Cells[1].Text);
                cmd1.Parameters.AddWithValue("@name", DoAAcc.Rows[rowid].Cells[2].Text);
                cmd1.Parameters.AddWithValue("@gender", DoAAcc.Rows[rowid].Cells[3].Text);
                cmd1.Parameters.AddWithValue("@username", DoAAcc.Rows[rowid].Cells[4].Text);
                cmd1.Parameters.AddWithValue("@password", DoAAcc.Rows[rowid].Cells[5].Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM DoAStaffDetails WHERE DoA_Id=@doaid;", con);
                cmd.Parameters.AddWithValue("@doaid", DoAAcc.Rows[rowid].Cells[1].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtD1ID.Text = "";
                DoAData();
                DoARevData();
            }
            else
            {
                Response.Write("<script>alert('Select An Account to Revoke')</script>");
            }
            
        }

        protected void btnDReinstate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            if(txtD2ID.Text != "")
            {
                SqlCommand cmd1 = new SqlCommand("insert into DoAStaffDetails(DoA_Id, Name, Gender, Username, Password) values(@doaid, @name, @gender, @username, @password)", con);
                int rowid = int.Parse(hfindex.Value);
                cmd1.Parameters.AddWithValue("@doaid", DoARevAcc.Rows[rowid].Cells[1].Text);
                cmd1.Parameters.AddWithValue("@name", DoARevAcc.Rows[rowid].Cells[2].Text);
                cmd1.Parameters.AddWithValue("@gender", DoARevAcc.Rows[rowid].Cells[3].Text);
                cmd1.Parameters.AddWithValue("@username", DoARevAcc.Rows[rowid].Cells[4].Text);
                cmd1.Parameters.AddWithValue("@password", DoARevAcc.Rows[rowid].Cells[5].Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM DoARev WHERE DoA_Id=@doaid;", con);
                cmd.Parameters.AddWithValue("@doaid", DoARevAcc.Rows[rowid].Cells[1].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtD2ID.Text = "";
                DoAData();
                DoARevData();
            }
            else
            {
                Response.Write("<script>alert('Select An Account to Reinstate')</script>");
            }
            
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