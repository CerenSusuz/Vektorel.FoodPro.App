using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vektorel.FoodPro.Business.NorthwindBO;
using Vektorel.FoodPro.Model.Constants;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.WinForm.UI.EntityForms
{
    public partial class frmCategory : Form
    {
        public FormMode Mode { get; set; }
        public Category SelectedCategory { get; set; }
        public string ImagePath { get; set; }
        public frmCategory()
        {
            Mode = FormMode.Add;
            InitializeComponent();
        }

        public frmCategory(Category cat)
        {
            Mode = FormMode.Update;
            SelectedCategory = cat;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CategoryBO bo = new CategoryBO();
            if (Mode == FormMode.Add)
            {
                Category cat = new Category();
                cat.CategoryName = txtCatName.Text;
                cat.Description = txtDescription.Text;
                cat.Picture = openFileDialog1.FileName;
                if (bo.Insert(cat))
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                SelectedCategory.CategoryName = txtCatName.Text;
                SelectedCategory.Description = txtDescription.Text;
                SelectedCategory.Picture = openFileDialog1.FileName;
                if (bo.Update(SelectedCategory))
                {
                    MessageBox.Show("Successfully updated");
                }
                else
                {
                    MessageBox.Show("There is an error during update operation");
                }
            }
        }

        private void pbxCategory_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pbxCategory.ImageLocation = openFileDialog1.FileName;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update)
            {
                txtCatName.Text = SelectedCategory.CategoryName;
                txtDescription.Text = SelectedCategory.Description;
                pbxCategory.ImageLocation = SelectedCategory.Picture;
            }
        }
    }
}
