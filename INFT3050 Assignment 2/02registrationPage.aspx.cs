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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click1(object sender, EventArgs e)
        {
            //Initialise Variables
            string login = "";
            string firstName = "";
            string surname = "";
            string dob = "";
            string email = "";
            string password = "";
            if (txtRegister_password.Text == txtRegister_passwordConfirm.Text)
            {
                //Set variables
                login = txtRegister_login.Text;
                firstName = txtRegister_firstName.Text;
                surname = txtRegister_surname.Text;
                dob = txtRegister_dob.Text;
                email = txtRegister_email.Text;
                password = txtRegister_password.Text;

                //SQL INSERT Registered User
                SqlConnection conn6 = new SqlConnection("Data Source=DESKTOP-79985J6;Initial Catalog=INFT3050MitchellMcMaugh3185423;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn6;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("login", @login);
                cmd.Parameters.Add("firstName", @firstName);
                cmd.Parameters.Add("surname", @surname);
                cmd.Parameters.Add("dob", @dob);
                cmd.Parameters.Add("email", @email);
                cmd.Parameters.Add("password", @password);
                cmd.CommandText = "INSERT Users (email, userLogin, userPassword, firstName, lastName, dateOfBirth) VALUES (@email, @login, @password, @firstName, @surname, @dob)";
                conn6.Open();
                cmd.ExecuteNonQuery();
                conn6.Close();
                Response.Redirect("03loginPage.aspx");
            }
        }
    }
}