using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050_Assignment_2
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if logged in
            if (Session["Username"] != null)
            {
                lbl_login.Text = "Logged in as " + Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("01WelcomePage.aspx");
            }
        }
    }
}