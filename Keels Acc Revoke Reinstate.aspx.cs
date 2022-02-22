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
    public partial class Keels_Acc_Revoke_Reinstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KeelsData();
            KeelsRevData();
        }

        public void KeelsData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from KeelsStaffDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KeelsAcc.DataSource = dt;
            KeelsAcc.DataBind();
            con.Close();
        }

        public void KeelsRevData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from KeelsRev", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KeelsRevAcc.DataSource = dt;
            KeelsRevAcc.DataBind();
            con.Close();
        }

        protected void KeelsAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idno = KeelsAcc.SelectedIndex;
            txtK1ID.Text = Convert.ToString(KeelsAcc.Rows[idno].Cells[1].Text);
            hfindex1.Value = Convert.ToString(KeelsAcc.SelectedIndex);
        }

        protected void KeelsRevAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idno = KeelsRevAcc.SelectedIndex;
            txtK2ID.Text = Convert.ToString(KeelsRevAcc.Rows[idno].Cells[1].Text);
            hfindex.Value = Convert.ToString(KeelsRevAcc.SelectedIndex);
        }

        protected void btnKRevoke_Click(object sender, EventArgs e)
        {
            if(txtK1ID.Text != "")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into KeelsRev(Keels_Id, Name, Gender, Username, Password) values(@keelsid, @name, @gender, @username, @password)", con);
                int rowid = int.Parse(hfindex1.Value);
                cmd1.Parameters.AddWithValue("@keelsid", KeelsAcc.Rows[rowid].Cells[1].Text);
                cmd1.Parameters.AddWithValue("@name", KeelsAcc.Rows[rowid].Cells[2].Text);
                cmd1.Parameters.AddWithValue("@gender", KeelsAcc.Rows[rowid].Cells[3].Text);
                cmd1.Parameters.AddWithValue("@username", KeelsAcc.Rows[rowid].Cells[4].Text);
                cmd1.Parameters.AddWithValue("@password", KeelsAcc.Rows[rowid].Cells[5].Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM KeelsStaffDetails WHERE Keels_Id=@keelsid;", con);
                cmd.Parameters.AddWithValue("@keelsid", KeelsAcc.Rows[rowid].Cells[1].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtK1ID.Text = "";
                KeelsData();
                KeelsRevData();
            }
            else
            {
                Response.Write("<script>alert('Select An Account to Revoke')</script>");
            }
        }

        protected void btnKReinstate_Click(object sender, EventArgs e)
        {
            if(txtK2ID.Text != "")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webdbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into KeelsStaffDetails(Keels_Id, Name, Gender, Username, Password) values(@keelsid, @name, @gender, @username, @password)", con);
                int rowid = int.Parse(hfindex.Value);
                cmd1.Parameters.AddWithValue("@keelsid", KeelsRevAcc.Rows[rowid].Cells[1].Text);
                cmd1.Parameters.AddWithValue("@name", KeelsRevAcc.Rows[rowid].Cells[2].Text);
                cmd1.Parameters.AddWithValue("@gender", KeelsRevAcc.Rows[rowid].Cells[3].Text);
                cmd1.Parameters.AddWithValue("@username", KeelsRevAcc.Rows[rowid].Cells[4].Text);
                cmd1.Parameters.AddWithValue("@password", KeelsRevAcc.Rows[rowid].Cells[5].Text);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM KeelsRev WHERE Keels_Id=@keelsid;", con);
                cmd.Parameters.AddWithValue("@keelsid", KeelsRevAcc.Rows[rowid].Cells[1].Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtK2ID.Text = "";
                KeelsData();
                KeelsRevData();
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