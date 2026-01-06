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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(
                        @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"
                );
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_emp_details", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox6.Text;

                SqlParameter p2 = new SqlParameter("@emp_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox1.Text;

                SqlParameter p3 = new SqlParameter("@emp_salary", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text;

                SqlParameter p4 = new SqlParameter("@emp_dep", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = comboBox1.SelectedItem.ToString();

                SqlParameter p5 = new SqlParameter("@emp_role", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = comboBox2.SelectedItem.ToString();

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Failled");
                    Con.Close();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(
                        @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"
                );
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_fetch", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SD = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                SD.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                //MessageBox.Show("Data Loaded Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult check = MessageBox.Show("Are you want to delete?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {

                    SqlConnection Con = new SqlConnection(
                        @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"
                    );
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete", Con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pl = new SqlParameter("@emp_id",SqlDbType.VarChar);
                    cmd.Parameters.Add(pl).Value = textBox5.Text;


                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        MessageBox.Show("Data Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failled");
                 
                    }
                        Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(
                        @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"
                );
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_search", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pl = new SqlParameter("@searchdata", SqlDbType.VarChar);
                cmd.Parameters.Add(pl).Value = textBox5.Text;

                SqlDataAdapter SD = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                SD.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                //MessageBox.Show("Data Loaded Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(
                        @"Data Source=DESKTOP-LS5MPR0; Initial Catalog=employeemanagement; Integrated Security=True"
                );
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_update", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox6.Text;

                SqlParameter p2 = new SqlParameter("@emp_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox1.Text;

                SqlParameter p3 = new SqlParameter("@emp_salary", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text;

                SqlParameter p4 = new SqlParameter("@emp_dep", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = comboBox1.SelectedItem.ToString();

                SqlParameter p5 = new SqlParameter("@emp_role", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = comboBox2.SelectedItem.ToString();

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Failled");
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap B = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(B, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(B, 403,177);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
