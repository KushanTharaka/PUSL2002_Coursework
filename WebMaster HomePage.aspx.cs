using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_Project
{
    public partial class WebMaster_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncreateacc_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff Create Account.aspx");
        }

        protected void btnrevacc_Click(object sender, EventArgs e)
        {
            Response.Redirect("Farmer Acc Revoke Reinstate.aspx");
        }

        protected void btnrep_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebMaster Charts.aspx");
        }
    }
}