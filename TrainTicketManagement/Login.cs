using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTicketManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            PasswordTb.Text = "";
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text=="" || PasswordTb.Text=="")
            {
                MessageBox.Show("Enter UserName And Password");
            }
            else if(UNameTb.Text=="Admin" && PasswordTb.Text=="Admin")
            {
                Train Obj = new Train();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Credentials!!!");
                UNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }


    }
}
