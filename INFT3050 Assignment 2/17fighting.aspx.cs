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
    public partial class WebForm17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Label3.Text = "Logged in as " + Session["Username"].ToString();
                if (Application["Fighter"] == null)
                {
                    Response.Redirect("08challenges.aspx");
                }
            }
            else
            {
                Response.Redirect("01WelcomePage.aspx");
            }

            string Fighter = Application["Fighter"].ToString();
            Label1.Text = Fighter;

            string userFinder = Session["Username"].ToString();
            Label2.Text = userFinder.ToString();

            SqlConnection conn3 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn3.Open();
            string uID = Label2.Text;
            SqlCommand user = new SqlCommand("SELECT userID FROM Users WHERE userLogin=@uID", conn3);
            user.Parameters.Add("uID", @uID);
            Label2.Text = user.ExecuteScalar().ToString();

            //Images Obtained from website (http://img14.deviantart.net/94d9/i/2013/093/9/8/four_elements_by_khanicus-d609nwk.png)
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn4 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn4.Open();
            //string uID = Label2.Text;

            string yourMonster = DropDownList1.SelectedItem.ToString();
            //string theirMonster = Label1.Text;
            SqlCommand yM = new SqlCommand("SELECT userCharacterId FROM UserCharacters WHERE UserCharacterName = @yourMonster", conn4);
            yM.Parameters.Add("yourMonster", @yourMonster);
            //SqlCommand tM = new SqlCommand("SELECT userCharacterId FROM UserCharacters WHERE UserCharacterName = @theirMonster", conn4);
            //tM.Parameters.Add("theirMonster", @theirMonster);
            string yMiD = yM.ExecuteScalar().ToString();
            string tMiD = Label1.Text;

            SqlCommand stats1 = new SqlCommand("SELECT UserCharacters.userId, UserCharacters.userCharacterId, Characters.characterType, UserCharacters.userCharacterLevel, UserCharacters.userCharacterName, UserCharacters.userCharacterStep, UserCharacters.userCharacterExperience FROM UserCharacters INNER JOIN Characters ON UserCharacters.characterId = Characters.characterId WHERE UserCharacters.userCharacterId=@yMiD", conn4);
            stats1.Parameters.Add("yMiD", @yMiD);
            
            SqlDataReader rdr1 = stats1.ExecuteReader();

            //List<string> myList = new List<string> { };
            string yourUserID = "";
            string yourCharacterID = "";
            string yourCharacterType = "";
            string yourCharacterLevel = "";
            string yourCharacterName = "";
            string yourCharacterStep = "";
            double yourCharacterExperience = 0;
            if (rdr1.Read());
            { 
                yourUserID = rdr1[0].ToString();
                yourCharacterID = rdr1[1].ToString();
                yourCharacterType = rdr1[2].ToString();
                yourCharacterLevel = rdr1[3].ToString();
                yourCharacterName = rdr1[4].ToString();
                yourCharacterStep = rdr1[5].ToString();
                yourCharacterExperience = Convert.ToDouble(rdr1[6]);
               
                //myList.Add(myString);
            }
            rdr1.Close();
            SqlCommand stats2 = new SqlCommand("SELECT UserCharacters.userId, UserCharacters.userCharacterId, Characters.characterType, UserCharacters.userCharacterLevel, UserCharacters.userCharacterName, UserCharacters.userCharacterStep, UserCharacters.userCharacterExperience FROM UserCharacters INNER JOIN Characters ON UserCharacters.characterId = Characters.characterId WHERE UserCharacters.userCharacterId=@tMiD", conn4);
            stats2.Parameters.Add("tMiD", @tMiD);
            SqlDataReader rdr2 = stats2.ExecuteReader();
            string enemyUserID = "";
            string enemyCharacterID = "";
            string enemyCharacterType = "";
            string enemyCharacterLevel = "";
            string enemyCharacterName = "";
            string enemyCharacterStep = "";
            double enemyCharacterExperience = 0;
            if (rdr2.Read());
            {
                enemyUserID = rdr2[0].ToString();
                enemyCharacterID = rdr2[1].ToString();
                enemyCharacterType = rdr2[2].ToString();
                enemyCharacterLevel = rdr2[3].ToString();
                enemyCharacterName = rdr2[4].ToString();
                enemyCharacterStep = rdr2[5].ToString();
                enemyCharacterExperience = Convert.ToDouble(rdr2[6]);

                //myList.Add(myString);
            }
            rdr2.Close();

            if (yourCharacterType == "Water")
            {
                if (enemyCharacterType == "Fire")
                {
                    yourCharacterExperience = yourCharacterExperience + (yourCharacterExperience * 0.15);
                }
                if (enemyCharacterType == "Earth")
                {
                    enemyCharacterExperience = enemyCharacterExperience + (enemyCharacterExperience * 0.15);
                }
            }

            if (yourCharacterType == "Fire")
            {
                if (enemyCharacterType == "Air")
                {
                    yourCharacterExperience = yourCharacterExperience + (yourCharacterExperience * 0.15);
                }
                if (enemyCharacterType == "Water")
                {
                    enemyCharacterExperience = enemyCharacterExperience + (enemyCharacterExperience * 0.15);
                }
            }

            if (yourCharacterType == "Air")
            {
                if (enemyCharacterType == "Earth")
                {
                    yourCharacterExperience = yourCharacterExperience + (yourCharacterExperience * 0.15);
                }
                if (enemyCharacterType == "Fire")
                {
                    enemyCharacterExperience = enemyCharacterExperience + (enemyCharacterExperience * 0.15);
                }
            }

            if (yourCharacterType == "Earth")
            {
                if (enemyCharacterType == "Water")
                {
                    yourCharacterExperience = yourCharacterExperience + (yourCharacterExperience * 0.15);
                }
                if (enemyCharacterType == "Air")
                {
                    enemyCharacterExperience = enemyCharacterExperience + (enemyCharacterExperience * 0.15);
                }
            }

            Random rnd = new Random();
            int rndBonus = rnd.Next(1, 3);
            if (rndBonus == 1)
            {
                yourCharacterExperience = yourCharacterExperience + (yourCharacterExperience * 0.25);
            }
            else
            {
                enemyCharacterExperience = enemyCharacterExperience + (enemyCharacterExperience * 0.25);
            }

            if (yourCharacterExperience > enemyCharacterExperience)
            {
                Application["Winner"] = yourCharacterID;
            }

            if (enemyCharacterExperience > yourCharacterExperience)
            {
                Application["Winner"] = enemyCharacterID;
            }

            int winnerID = Convert.ToInt32(Application["Winner"]);

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn.Open();
            SqlCommand winnerXp = new SqlCommand("SELECT userCharacterExperience FROM UserCharacters WHERE userCharacterId=@winnerID",conn);
            winnerXp.Parameters.Add("winnerID", @winnerID);
            int winnerXpNo = Convert.ToInt32(winnerXp.ExecuteScalar());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("winnerID", @winnerID);
            cmd.CommandText = "UPDATE UserCharacters SET UserCharacterExperience = UserCharacterExperience + (UserCharacterExperience * 0.25) WHERE userCharacterId = @winnerID";
            cmd.ExecuteNonQuery();
            conn.Close();
            
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("dateNow", @dateNow);
            cmd.Parameters.Add("yourCharacterID", @yourCharacterID);
            cmd.Parameters.Add("enemyCharacterID", @enemyCharacterID);

            cmd.CommandText = "INSERT Battles (dateOfBattle, userOneCharacterId, userTwoCharacterId, winnerOfBattle) VALUES (@dateNow,@yourCharacterID,@enemyCharacterID,@winnerID)";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //Updates Level and Steps if Necessary
            int winnerID1 = Convert.ToInt32(Application["Winner"]);
            SqlConnection levelStepCheckConnection = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            levelStepCheckConnection.Open();
            SqlCommand levelStepCheckCmd = new SqlCommand("SELECT userCharacterExperience FROM UserCharacters WHERE userId = @winnerID1", levelStepCheckConnection);
            levelStepCheckCmd.Parameters.Add("winnerID1", @winnerID1);
            int experienceValue = Convert.ToInt32(levelStepCheckCmd.ExecuteScalar());

            if (experienceValue >= 0 && experienceValue <= 200)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 1 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 201 && experienceValue <= 425)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 2 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 426 && experienceValue <= 675)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 3 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 676 && experienceValue <= 1000)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 1, userCharacterStep = 4 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 1001 && experienceValue <= 1400)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 1 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 1401 && experienceValue <= 1900)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 2 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 1901 && experienceValue <= 2400)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 3 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 2401 && experienceValue <= 3000)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 2, userCharacterStep = 4 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 3001 && experienceValue <= 3700)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 1 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 3701 && experienceValue <= 4500)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 2 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 4501 && experienceValue <= 5400)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 3 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 5401 && experienceValue <= 6400)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 3, userCharacterStep = 4 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 6401 && experienceValue <= 7500)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 1 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 7501 && experienceValue <= 8700)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 2 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 8701 && experienceValue <= 10000)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 3 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 10001 && experienceValue <= 11500)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 4, userCharacterStep = 4 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }
            if (experienceValue >= 11501)
            {
                SqlCommand levelChange = new SqlCommand();
                levelChange.Connection = levelStepCheckConnection;
                levelChange.CommandType = CommandType.Text;
                levelChange.CommandText = "UPDATE UserCharacters SET userCharacterLevel = 0, userCharacterStep = 0 WHERE userId = @winnerID1";
                levelChange.Parameters.Add("winnerID1", @winnerID1);
                levelChange.ExecuteNonQuery();
            }

            Response.Redirect("10fightOutcome.aspx");
        }
    }
}