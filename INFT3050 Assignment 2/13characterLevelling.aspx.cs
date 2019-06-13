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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lbl_userLogin.Text = "Logged in as " + Session["Username"].ToString();

                string userLogin = Session["Username"].ToString();
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT userId FROM Users WHERE userLogin = @userLogin", conn);
                cmd.Parameters.Add("userLogin", @userLogin);
                int uID = Convert.ToInt32(cmd.ExecuteScalar());
                lbl_uIDHidden.Text = uID.ToString();
                SqlCommand cmd2 = new SqlCommand("SELECT exercisePoints FROM Users WHERE userLogin = @userLogin", conn);
                cmd2.Parameters.Add("userLogin", @userLogin);
                int eP = Convert.ToInt32(cmd2.ExecuteScalar());
                Application["eP"] = eP;
                lbl_points.Text = eP.ToString();
                
            }
            else
            {
                Response.Redirect("01WelcomePage.aspx");
            }

        
            
        }

        protected void btn_lvelUp_Click(object sender, EventArgs e)
        {
            string userLogin = Session["Username"].ToString();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT userId FROM Users WHERE userLogin = @userLogin", conn);
            cmd.Parameters.Add("userLogin", @userLogin);
            int curUserId1 = Convert.ToInt32(cmd.ExecuteScalar());
            int spent = Convert.ToInt32(txt_pointsToLevel.Text);
            if (spent <= Convert.ToInt32(Application["eP"]))
                {
                SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = conn2;
                conn2.Open();
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("curUserId1", @curUserId1);
                cmd3.Parameters.Add("spent", @spent);
                cmd3.CommandText = "UPDATE Users SET exercisePoints = exercisePoints - @spent WHERE userId = @curUserId1";
                cmd3.ExecuteNonQuery();
                cmd3.CommandText = "UPDATE UserCharacters SET userCharacterExperience = userCharacterExperience + @spent WHERE userId = @curUserId1";
                cmd3.ExecuteNonQuery();
                conn2.Close();
                Response.Redirect("13characterLevelling.aspx");

                //Updates Level and Steps if Necessary
                string userLoginCheck = Session["Username"].ToString();
                SqlConnection levelStepCheckConnection = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                levelStepCheckConnection.Open();
                SqlCommand currentUserIdFinder = new SqlCommand("SELECT userId FROM Users WHERE userLogin = @userLoginCheck", levelStepCheckConnection);
                currentUserIdFinder.Parameters.Add("userLoginCheck", @userLoginCheck);
                int curUserId = Convert.ToInt32(cmd.ExecuteScalar());
                SqlCommand levelStepCheckCmd = new SqlCommand("SELECT userCharacterExperience FROM UserCharacters WHERE userId = @curUserId", levelStepCheckConnection);
                levelStepCheckCmd.Parameters.Add("curUserId", @curUserId);
                int experienceValue = Convert.ToInt32(levelStepCheckCmd.ExecuteScalar());

                if (experienceValue >= 0 && experienceValue <= 200)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 1 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 201 && experienceValue <= 425)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 2 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 426 && experienceValue <= 675)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 3 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 676 && experienceValue <= 1000)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 4 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 1001 && experienceValue <= 1400)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 1 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 1401 && experienceValue <= 1900)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 2 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 1901 && experienceValue <= 2400)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 3 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 2401 && experienceValue <= 3000)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 4 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 3001 && experienceValue <= 3700)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 1 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 3701 && experienceValue <= 4500)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 2 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 4501 && experienceValue <= 5400)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 3 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 5401 && experienceValue <= 6400)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 4 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 6401 && experienceValue <= 7500)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 1 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 7501 && experienceValue <= 8700)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 2 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 8701 && experienceValue <= 10000)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 3 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 10001 && experienceValue <= 11500)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 4 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
                if (experienceValue >= 11501)
                {
                    SqlCommand levelChange = new SqlCommand();
                    levelChange.Connection = levelStepCheckConnection;
                    levelChange.CommandType = CommandType.Text;
                    levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 0, userCharacterStep = 0 WHERE userId = @curUserId";
                    levelChange.Parameters.Add("curUserId", @curUserId);
                    levelChange.ExecuteNonQuery();
                }
            }
        }
    }
}