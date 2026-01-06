using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Employee_Management_Project
{
    
    public partial class ForgotPassword : Form
    {
        string randomcode;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String randomcode, from, pass, messageBody, to;
            Random random = new Random();
            randomcode = random.Next(999999).ToString();
            MailMessage message = new MailMessage();
            to = textBox1.Text.ToString();
            from = "raviprmlsm01@gmail.com";
            pass = "hklc wszt kxdr mqyr";
            messageBody = "Your OTP verification code : " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Employee Management Verification";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from,pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP Sended Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }








        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (randomcode == (textBox3.Text).ToString())
            {
                MessageBox.Show("OTP");
            }
            else
            {
                MessageBox.Show("Invalid OTP");
            }
        }
    }
}
