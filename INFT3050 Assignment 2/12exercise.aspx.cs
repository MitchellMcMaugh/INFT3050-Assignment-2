using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;

namespace INFT3050_Assignment_2
{
    public partial class WebForm6 : System.Web.UI.Page
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

        protected void btn_sendCode_Click(object sender, EventArgs e)
        {
            //Code generating
            Random rnd = new Random();
            Application["CodeKey"] = rnd.Next(1, 9999);
            Application["CodeFull"] = Convert.ToInt32(txtSteps.Text) + Convert.ToInt32(Application["CodeKey"]);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            conn.Open();
            string userEmail = "";
            int uID = Convert.ToInt32(Application["CurrentUserID"]);
            SqlCommand emailGet = new SqlCommand("SELECT email FROM Users WHERE userID=@uID", conn);
            emailGet.Parameters.Add("uID", @uID);
            userEmail = emailGet.ExecuteScalar().ToString();

            //Email Settings
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("INFT3050AssignmentMM@gmail.com", "gummyworms");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("INFT3050AssignmentMM@gmail.com", "MyWeb Site");
            mail.To.Add(new MailAddress(userEmail));
            mail.Subject = "Your Exercise Validation Code";
            
            mail.Body = Application["CodeFull"].ToString();

            smtpClient.Send(mail);
        }

        protected void btnSubmitSteps_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Application["CodeFull"]) - Convert.ToInt32(txtSteps.Text) == Convert.ToInt32(Application["CodeKey"]))
                {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string userLogin = Session["Username"].ToString();
                int steps = Convert.ToInt32(txtSteps.Text);
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT userId FROM Users WHERE userLogin = @userLogin",conn);
                cmd.Parameters.Add("userLogin", @userLogin);
                int curUserId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                //If code matches then do
                if (txtStepsCode.Text == Application["CodeFull"].ToString())
                {
                    SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;
                    conn2.Open();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("curUserId", @curUserId);
                    cmd2.Parameters.Add("date", @date);
                    cmd2.Parameters.Add("steps", @steps);
                    cmd2.CommandText = "INSERT UserExercise (userId, dateOfExercise, steps) VALUES (@curUserId, @date, @steps)";
                    cmd2.ExecuteNonQuery();
                    cmd2.CommandText = "UPDATE Users SET exercisePoints = exercisePoints + @steps/20 WHERE userId = @curUserId";
                    cmd2.ExecuteNonQuery();
                    conn2.Close();
                    Response.Redirect("04home.aspx");
                }
            }
        }
    }
}