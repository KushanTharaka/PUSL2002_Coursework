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
using Newtonsoft.Json;

namespace WEB_Project
{
    public partial class ReportMap : System.Web.UI.Page
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
            con.Close();

            var serializedOrders = JsonConvert.SerializeObject(dt);
            hflati.Value = serializedOrders;
        }

    }
}