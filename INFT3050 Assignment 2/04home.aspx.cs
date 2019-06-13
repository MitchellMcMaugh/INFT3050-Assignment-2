using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace INFT3050_Assignment_2
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if logged in
            if (Session["Username"] != null)
            {
                Label1.Text = "Logged in as " + Session["Username"].ToString();
                
            }
            else
            {
                Response.Redirect("01WelcomePage.aspx");
            }

            string userLogin = Session["Username"].ToString();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT userId FROM Users WHERE userLogin = @userLogin", conn);
            cmd.Parameters.Add("userLogin", @userLogin);
            int curUserId = Convert.ToInt32(cmd.ExecuteScalar());
            Application["currentUserID"] = curUserId;
            conn.Close();
            lbl_hiddenLabel.Text = Application["currentUserID"].ToString();
        }
    }
}