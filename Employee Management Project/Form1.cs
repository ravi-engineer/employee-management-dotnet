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

namespace Employee_Management_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lg_password.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lg_btn_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrWhiteSpace(lg_uname.Text))
                {
                    MessageBox.Show("Username showuld not blank");
                    lg_uname.Focus();
                    return;
                }
                if (String.IsNullOrWhiteSpace(lg_password.Text))
                {
                    MessageBox.Show("Password showuld not blank");
                    lg_password.Focus();
                    return;
                }
                string uname = lg_uname.Text.Trim();
                string pwd = lg_password.Text.Trim();

                // 2. Hardcoded ADMIN login
                if (uname == "Admin" && pwd == "12345678")
                {
                    MessageBox.Show("Welcome Admin");
                    Dashboard d = new Dashboard();
                    d.Show();
                    this.Hide();
                    return;   // very IMPORTANT – do NOT continue to SQL login
                }


                using (SqlConnection con = new SqlConnection(
        @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_login", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@uname", uname);
                        cmd.Parameters.AddWithValue("@password", pwd);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        // Safe check: dataset must have 1 table & 1 row
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                            if (count > 0)
                            {
                                MessageBox.Show("Login Successful");
                                EmpDashboard ed = new EmpDashboard();
                                ed.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lg_uname.Clear();
            lg_password.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
