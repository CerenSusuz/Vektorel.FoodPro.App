using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vektorel.FoodPro.Business.NorthwindBO;
using Vektorel.FoodPro.Model.Constants;

namespace Vektorel.FoodPro.WinForm.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ApplicationUserBO ub = new ApplicationUserBO();
            if (ub.Login(txtUserName.Text,txtPassword.Text))
            {
                var type = txtUserName.Text.ToLower() == "admin" ? LoginType.Administrator : LoginType.Employee;
                frmMainMenu frm = new frmMainMenu(type);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgot frm = new frmForgot();
            frm.ShowDialog();
        }
    }
}
