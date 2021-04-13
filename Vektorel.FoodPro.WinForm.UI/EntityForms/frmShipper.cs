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
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.WinForm.UI.EntityForms
{
    public partial class frmShipper : Form
    {
        public FormMode Mode { get; set; }
        public Shipper SelectedShipper { get; set; }

        // Add
        public frmShipper()
        {
            Mode = FormMode.Add;
            InitializeComponent();
        }

        // Update
        public frmShipper(Shipper shipper)
        {
            Mode = FormMode.Update;
            SelectedShipper = shipper;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShipperBO sb = new ShipperBO();
            switch (Mode)
            {
                case FormMode.Add:
                    Shipper s = new Shipper
                    {
                        CompanyName = txtCompanyName.Text,
                        Phone = txtPhone.Text
                    };
                    if (sb.Insert(s))
                    {
                        MessageBox.Show("Successful");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
                case FormMode.Update:
                    SelectedShipper.CompanyName = txtCompanyName.Text;
                    SelectedShipper.Phone = txtPhone.Text;
                    if (sb.Update(SelectedShipper))
                    {
                        MessageBox.Show("Successful");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
            }
            this.Close();
        }

        private void frmShipper_Load(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case FormMode.Add:
                    break;
                case FormMode.Update:
                    txtCompanyName.Text = SelectedShipper.CompanyName;
                    txtPhone.Text = SelectedShipper.Phone;
                    break;
                default:
                    break;
            }
        }
    }
}
