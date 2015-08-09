using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityMedicineWebApp.UI
{
    public partial class LoginUI : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["CMconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string checkUser = "SELECT COUNT(*) FROM center_table WHERE code='"+usernameTextBox.Text+"' ";
            SqlCommand command = new SqlCommand(checkUser,connection);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            if (temp==1)
            {
                connection.Open();
                string checkPass = "SELECT password FROM center_table WHERE code='" + usernameTextBox.Text + "'";
                SqlCommand passCommand = new SqlCommand(checkPass,connection);
                string password = passCommand.ExecuteScalar().ToString();

                if (password==passTextBox.Text)
                {
                    Session["loginSession"] = usernameTextBox.Text;
                    msgLabel.Text="Login Successfull";
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    msgLabel.Text = "Incorrect password !";
                }
            }
            else
            {
                msgLabel.Text="UserName Is not Correct";
            }
          
        }
    }
}