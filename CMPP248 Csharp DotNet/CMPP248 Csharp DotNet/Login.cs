/*Coded By: Anushka De Silva*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPP248_Csharp_DotNet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //Functionality of Login Button
        //This reads user's username and password
        //Username is First Name and Password is last name
        //If the username is not exist in the Databast, this will prompt a error message and take back to login page
        //If Login page processes then application will take to fromTEManager form
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginID.Text;
            string password = txtLoginPassword.Text;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            if (txtLoginID.Text == "" || txtLoginPassword.Text == " ")
            {
                MessageBox.Show("Enter User Name And Password");
                return;
            }
            string selectStatement =
                "SELECT * FROM Agents "
                + "WHERE AgtFirstName=@username and AgtLastName=@password";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@password", password);

            DataSet ds = new DataSet();

            try
            {
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(selectCommand);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i == 1)
                {
                    string message = "Welcome" + txtLoginID.Text;
                    this.Hide();
                    frmTEManager f2 = new frmTEManager();
                    f2.UserName = username;
                    f2.Show();
                    ds.Clear();
                    
                }
                else
                {
                    MessageBox.Show("Not Registered User or Invlid Name or Password.");
                    txtLoginID.Text = "";
                    txtLoginPassword.Text = "";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Functionality of Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLoginID.Text = "";
            txtLoginPassword.Text = "";
        }
        //Functionality of Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
