using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Medicare_Management
{
    public partial class Login : Form
    {
       public static string userRole;
        public Login()
        {
            InitializeComponent();
        }
        MySqlConnection Con = new MySqlConnection("server=localhost;database=medicare;username=root;password=Azone123");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select Count(*) from Staff where UserId = '" + txtUserID.Text + "' and Password = '" + txtPassword.Text + "' and Role = '"+cmbRole.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (cmbRole.SelectedItem.ToString() == "Admin" || cmbRole.SelectedItem.ToString()== "Assistant"||cmbRole.SelectedItem.ToString()== "Accountant"||cmbRole.SelectedItem.ToString()== "Pharmacist")
                {
                    
                    E_MEd home = new E_MEd(cmbRole.SelectedItem.ToString());
                    home.Show();
                    this.Hide();

                    
                }
                else
                {
                    MessageBox.Show("can't log");
                }
                
            }
            else
            {
                MessageBox.Show("Wrong UserName, Password or User Role");
            }
            Con.Close();
        }

        private void checkBoxshow_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxshow.Checked == false)
            //    txtPassword.UseSystemPasswordChar = true;
            //else
            //    txtPassword.UseSystemPasswordChar = false;

            //if (checkBoxshow.Checked == false)
            //    txtPassword.UseSystemPasswordChar = true;
            //else
            //    txtPassword.UseSystemPasswordChar = false;


            if (checkBoxshow.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
                checkBoxshow.Text = "Show";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
                checkBoxshow.Text = "Hide";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
