using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Airline_Reservation_System
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        MySqlCommand command;
        MySqlConnection connection;
        MySqlDataReader reader;

        string myconnection = "Server=localhost; Database=dbluxspaceairways; Uid=root; pwd=";

        private void frmSignup_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(myconnection);
            connection.Open();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string nationality = cmbNationality.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            DateTime birthday = dateBirthday.Value;
            DateTime birthdayWithoutTime = new DateTime(birthday.Year, birthday.Month, birthday.Day, 0, 0, 0);
            string birthdayString = birthdayWithoutTime.ToString("MM/dd/yyyy");


            if (!String.IsNullOrEmpty(firstname) && !String.IsNullOrEmpty(lastname) && !String.IsNullOrEmpty(nationality)
                && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {

               
                /*using (var connection = new MySqlConnection(myconnection))
                {
                    connection.Open();
                    var command = new MySqlCommand("SELECT COUNT(*) FROM tbl_customer WHERE email = @email", connection);

                    command.Parameters.AddWithValue("@email", email);

                    var count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("The email address is already in use.");
                        return;
                    }
                }*/

                string sql = "INSERT INTO tbl_customer(firstname, lastname, nationality, birthday, email, password) VALUES"
                    + "('"+ firstname+ "','" + lastname+ "','" +nationality+ "','" +birthdayString+ "','" + email + "','" + password +"')";
                
                connection = new MySqlConnection(myconnection);
                connection.Open();
                
                command=new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();  
                connection.Close();
                connection.Dispose();

                MessageBox.Show("Successsfully Sign-up");

                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                cmbNationality.SelectedIndex = -1;

                txtFirstName.Focus();


            }else 
            {
                MessageBox.Show("Please fill up all the required fields.");
            }
        }

        
    }
}
