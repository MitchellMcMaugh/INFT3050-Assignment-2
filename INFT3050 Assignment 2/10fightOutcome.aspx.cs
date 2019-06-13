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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string winnerString = "";
            if (Session["Username"] != null)
            {
                //Check if logged in
                Label3.Text = "Logged in as " + Session["Username"].ToString();
                if (Application["Winner"] != null)
                {
                    SqlConnection conn5 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                    conn5.Open();
                    string uID = Application["Winner"].ToString();
                    SqlCommand winner = new SqlCommand("SELECT userCharacterName FROM userCharacters WHERE userCharacterID=@uID", conn5);
                    winner.Parameters.Add("uID", @uID);
                    winnerString = winner.ExecuteScalar().ToString();
                    lbl_fightWinner.Text = winnerString + " won the fight!";
                }
                else
                {
                    Response.Redirect("04home.aspx");
                }

            }
            else
            {
                Response.Redirect("01WelcomePage.aspx");
            }
            
        }
    }
}