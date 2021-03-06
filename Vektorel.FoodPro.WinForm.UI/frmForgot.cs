using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vektorel.FoodPro.Business.NorthwindBO;

namespace Vektorel.FoodPro.WinForm.UI
{
    public partial class frmForgot : Form
    {
        public frmForgot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplicationUserBO ub = new ApplicationUserBO();
            if (ub.ForgotPassword(txtEmail.Text))
            {
                MessageBox.Show("Mail sent! Please check your email");
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no account like that");
            }
        }
    }
}
