using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Employee_Management_Project
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to logout?","Confirmation Message",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes) {
                Application.Exit();
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            // your code here
        }
        private void label7_Click(object sender, EventArgs e)
        {
            // your code here
        }

        private void regbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(regname.Text)) {
                MessageBox.Show("Name cannot be blank");
                regname.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(regemail.Text)) {
                MessageBox.Show("Email should not be blank");
                regemail.Focus();
                return;            
            }
            if (string.IsNullOrWhiteSpace(regpassword.Text))
            {
                MessageBox.Show("Enter Password");
                regpassword.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(regmobile.Text))
            {
                MessageBox.Show("Enter Mobile");
                regmobile.Focus();
                return;
            }
            if (regpassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");
                regpassword.Focus();
                return;
            }
            if (regmobile.Text.Length < 10)
            {
                MessageBox.Show("Mobile number must be at least 10 digits");
                regmobile.Focus();
                return;
            }

            try {

                SqlConnection Con = new SqlConnection(
                    @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"

                );
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_register", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = regname.Text;

                SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = regpassword.Text;

                SqlParameter p3 = new SqlParameter("@email", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = regemail.Text;

                SqlParameter p4 = new SqlParameter("@mblnum", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = regmobile.Text;

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Success");
                }
                else {
                    MessageBox.Show("Failled");
                    Con.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }






        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else 
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
