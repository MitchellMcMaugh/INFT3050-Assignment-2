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
    public partial class WebForm13 : System.Web.UI.Page
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
        }

        protected void btn_createCharacter_Click(object sender, EventArgs e)
        {
            //Creating a new character
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string name = txt_characterName.Text;
            string userLogin = Session["Username"].ToString();
            int charId = Convert.ToInt32(characterTypes.SelectedValue);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn.Open();
            SqlCommand userFind = new SqlCommand("SELECT userId FROM Users WHERE userLogin = @userLogin", conn);
            userFind.Parameters.Add("userLogin", @userLogin);
            int curUserId = Convert.ToInt32(userFind.ExecuteScalar());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("curUserId", @curUserId);
            cmd.Parameters.Add("date", @date);
            cmd.Parameters.Add("charId", @charId);
            cmd.Parameters.Add("name", @name);
            cmd.CommandText = "INSERT UserCharacters (userId, dateCreated, characterId, userCharacterName) VALUES (@curUserId, @date, @charId, @name)";
            cmd.ExecuteNonQuery();
            Response.Redirect("06CharacterManagement.aspx");
        }
    }
}