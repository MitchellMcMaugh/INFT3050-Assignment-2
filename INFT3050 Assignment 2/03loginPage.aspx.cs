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
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login2_Click(object sender, EventArgs e)
        {
            //Check if fields match user
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
            string emailTxt = txtLogin_email.Text;
            string pass = txtLogin_password.Text;
            SqlCommand cmd = new SqlCommand("SELECT email,userPassword from Users where email=@emailTxt and userPassword=@pass", con);
            cmd.Parameters.Add("emailTxt", @emailTxt);
            cmd.Parameters.Add("pass", @pass);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                conn.Open();
                string emailTxt2 = txtLogin_email.Text;
                SqlCommand user = new SqlCommand("SELECT userLogin FROM Users WHERE email=@emailTxt2", conn);
                user.Parameters.Add("emailTxt2", @emailTxt2);
                //Create login session
                Session["Username"] = user.ExecuteScalar();
                Response.Redirect("04home.aspx");
            }
            else
            {
                con.Close();
            }
        }
    }
}