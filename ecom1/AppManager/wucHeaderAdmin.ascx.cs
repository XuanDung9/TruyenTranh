using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HamtruyenAdmin
{
    public partial class wucHeaderAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbkLogout_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Session["AppID"] = null;
            Response.Redirect("/Login.aspx");
        }
    }
}