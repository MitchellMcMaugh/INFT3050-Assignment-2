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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if logged in
            if (Session["Username"] != null)
            {
                Label3.Text = "Logged in as " + Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("01WelcomePage.aspx");
            }

            string userFinder = Session["Username"].ToString();
            Label2.Text = userFinder.ToString();
            SqlConnection conn4 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn4.Open();
            string uID = Label2.Text;
            SqlCommand user = new SqlCommand("SELECT userID FROM Users WHERE userLogin=@uID", conn4);
            user.Parameters.Add("uID", @uID);
            Label2.Text = user.ExecuteScalar().ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Choose a monster to fight against
            string selectedValue = RadioButtonList1.SelectedValue;
            Application["Fighter"] = selectedValue;
            if (selectedValue != "")
            {
                Response.Redirect("17fighting.aspx");
            }
        }
    }
}