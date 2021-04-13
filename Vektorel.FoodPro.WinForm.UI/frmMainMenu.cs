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
using Vektorel.FoodPro.WinForm.UI.EntityForms;

namespace Vektorel.FoodPro.WinForm.UI
{
    public partial class frmMainMenu : Form
    {
        public CurrentPoco CurrentPoco { get; set; }

        public frmMainMenu(LoginType _type)
        {
            InitializeComponent();
            if (_type==LoginType.Employee)
            {
                usersToolStripMenuItem.Visible = false;
            }
        }

        
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msi = sender as ToolStripMenuItem;
            foreach (var item in menuToolStripMenuItem.DropDownItems)
            {
                var myItem = item as ToolStripMenuItem;
                myItem.Checked = false;
            }
            msi.Checked = true;

            if (msi.Text == "Shippers")
            {
                ShipperBO sb = new ShipperBO();
                dgvMain.DataSource = null;
                dgvMain.DataSource = sb.GetList();
                CurrentPoco = CurrentPoco.Shipper;
                

            }
            else if (msi.Text == "Categories")
            {
                CategoryBO cb = new CategoryBO();
                dgvMain.DataSource = null;
                dgvMain.DataSource = cb.GetList();
                CurrentPoco = CurrentPoco.Category;
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (CurrentPoco)
            {
                case CurrentPoco.Shipper:
                    frmShipper fs = new frmShipper();
                    fs.ShowDialog();
                    break;
                case CurrentPoco.Category:
                    frmCategory fc = new frmCategory();
                    fc.ShowDialog();
                    break;
                
                default:
                    break;
            }
        }

        private void frmMainMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvMain, new Point(e.Location.X, e.Location.Y - contextMenuStrip1.Height));
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (CurrentPoco)
            {
                case CurrentPoco.Shipper:
                    ShipperBO sb = new ShipperBO();
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = sb.GetList();
                    break;
                case CurrentPoco.Category:
                    CategoryBO cb = new CategoryBO();
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = cb.GetList();
                    break;
               
                default:
                    break;
            }
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                switch (CurrentPoco)
                {
                    case CurrentPoco.Shipper:
                        frmShipper fs = new frmShipper(dgvMain.Rows[e.RowIndex].DataBoundItem as Shipper);
                        fs.ShowDialog();
                        break;
                    case CurrentPoco.Category:
                        frmCategory fc = new frmCategory((Category)dgvMain.Rows[e.RowIndex].DataBoundItem);
                        fc.ShowDialog();
                        break;
                  
                    default:
                        break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count>=1)
            {
                DialogResult dr = MessageBox.Show("Are you serious?", "BE CAREFUL", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var rows = dgvMain.SelectedRows;
                    bool isSuccess = false;
                    switch (CurrentPoco)
                    {
                        case CurrentPoco.Shipper:
                            for (int i = 0; i < rows.Count; i++)
                            {
                                var s = rows[i].DataBoundItem as Shipper;
                                ShipperBO sb = new ShipperBO();
                                if (sb.Delete(s.ShipperID))
                                {
                                    isSuccess = true;
                                }
                            }
                            break;
                        case CurrentPoco.Category:
                            for (int i = 0; i < rows.Count; i++)
                            {
                                var c = rows[i].DataBoundItem as Category;
                                CategoryBO cb = new CategoryBO();
                                if (cb.Delete(c.CategoryID))
                                {
                                    isSuccess = true;
                                }
                            }
                            break;
                       
                        default:
                            break;
                    }
                    if (isSuccess)
                    {
                        MessageBox.Show("Successful");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                dgvMain.Rows[e.RowIndex].Selected = true;
            }
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dr = MessageBox.Show("Are you sure?","EXIT",MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);

            if (dr == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = dr == DialogResult.Cancel;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var searchText = textBox1.Text.ToLower();

            switch (CurrentPoco)
            {
                case CurrentPoco.Shipper:
                    ShipperBO sb = new ShipperBO();
                    var list = sb.GetList();
                    var newList = list.Where(x => x.CompanyName.ToLower().Contains(searchText)).ToList();
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = newList;
                    break;
                case CurrentPoco.Category:
                    CategoryBO cb = new CategoryBO();
                    var list2 = cb.GetList();
                    var newList2 = list2.Where(x => x.CategoryName.ToLower().Contains(searchText)).ToList();
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = newList2;
                    break;
                case CurrentPoco.ApplicationUser:
                    ApplicationUserBO ub = new ApplicationUserBO();
                    var list3 = ub.GetList();
                    var newList3 = list3.Where(x => x.UserName.ToLower().Contains(searchText)).ToList();
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = newList3;
                    break;
                default:
                    break;
            }
        }

        private void frmMainMenu_Resize(object sender, EventArgs e)
        {
            dgvMain.Width = this.Width;
        }
        
    }
}
