using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Course.Repos;

namespace DB_Course
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        AdministratorRequests AdministratorRequest = new AdministratorRequests();
        Factory factory = new Factory("127.0.0.1", "5432", "postgres", "1", "University personnel department"); //Viktor_db
        DataTable dt = new DataTable();
        

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AdministratorRequest.Title_Output(factory, dgvTitles);
            if (dgvTitles.CurrentRow != null)
                dgvTitles.Rows[dgvTitles.CurrentRow.Index].Selected = false;
        }
        #region Staff
        private void btnSelectAllStaff_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Select_All_Staff(factory, dgvSelectedStaff);
        }

        private void BtnAddStaff_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Insert_Staff(factory, tbStaffInsertName.Text, tbStaffInsertLastname.Text,
                                              tbStaffInsertPatronymic.Text, tbStaffInsertEducation.Text,
                                              tbStaffInsertPhone.Text, tbStaffInsertRegistration.Text,
                                              tbStaffInsertPass.Text, tbStaffInsertType.Text);                
        }
        
        private void BtnDeleteStaff_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Delete_Staff(factory, tbStaffDeleteID.Text);
        }
        
        private void BtnStaffSelectSome_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Select_Some_Staff(factory, dgvSelectedStaff, chboxStaffPass.Checked, chboxStaffEducation.Checked,
                chboxStaffPhone.Checked, chboxStaffType.Checked, chboxStaffRegistration.Checked);

        }
        #endregion

        private void BtnSelectStaffById_Click(object sender, EventArgs e)
        {
            if (rbtnSelectStaffByID.Checked)
                AdministratorRequest.Select_By_ID(factory, dgvSelectedStaff, Convert.ToInt32(tbStaffSelectByID.Text));
        }
    }
}
