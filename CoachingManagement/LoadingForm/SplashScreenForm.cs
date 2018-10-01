using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachingManagement
{
    public partial class SplashScreenForm : Form
    {

        Boolean flag = false;
        public SplashScreenForm()
        {
            InitializeComponent();
            
            
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            String str = Convert.ToChar(169) + " 2017 All Rights Reserved";
            label2.Text = str;
        }

        private void CheckPassword()
        {
            string password = "admin";
            if (password == passbox.Text)
            {
                flag = true;
            }
            else
            {
                status.Text = "Worng! Try again.";
                
            }


        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                if (flag)
                {
                    status.Text = "";
                    Program.OpenMainFormOnClose = true;
                    rectangleShape2.Visible = true;
                    rectangleShape2.Width = 2 + rectangleShape2.Width;
                   
                    if (rectangleShape2.Width >= 436)
                    {
                        timer1.Stop();
                        this.Close();
                        
                    }
                }
                
                
            }catch(Exception)
            {
                return;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void passbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                start.PerformClick();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void checkshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkshowpass.Checked)
            {
                passbox.UseSystemPasswordChar = false;
            }
            else
            {
                passbox.UseSystemPasswordChar = true;
            }
        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {

        }

     
    }
}
