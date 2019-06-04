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
        Factory factory = new Factory("127.0.0.1", "5432", "postgres", "1", "Viktor_db"); //Viktor_db
        ErrorProtector errorProtector = new ErrorProtector();
        

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AdministratorRequest.Show_Titles(factory, dgvTitles);
            if (dgvTitles.CurrentRow != null)
                dgvTitles.Rows[dgvTitles.CurrentRow.Index].Selected = false;
        }

        #region Staff
        private void btnSelectAllStaff_Click(object sender, EventArgs e)
        {
            fillDgvForAllStaff();
            AdministratorRequest.Show_All_Staff(factory, dgvSelectedStaff);
        }
        private void fillDgvForAllStaff()
        {
            dgvSelectedStaff.Columns.Add("ID", "Номер");
            dgvSelectedStaff.Columns.Add("Name", "Имя");
            dgvSelectedStaff.Columns.Add("LastName", "Фамилия");
            dgvSelectedStaff.Columns.Add("Patronymic", "Отчество");
            dgvSelectedStaff.Columns.Add("Education", "Образование");
            dgvSelectedStaff.Columns.Add("Phone", "Телефон");
            dgvSelectedStaff.Columns.Add("Registration", "Прописка");
            dgvSelectedStaff.Columns.Add("Pass", "Паспортный данные");
            dgvSelectedStaff.Columns.Add("Type", "Тип сотрудника");
        }
        private void BtnAddStaff_Click(object sender, EventArgs e)
        {
           errorProtector.Protected_Staff_Insert(factory, tbStaffInsertName.Text, tbStaffInsertLastname.Text,
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
        private void BtnSelectStaffById_Click(object sender, EventArgs e)
        {
            fillDgvForAllStaff();
            if (rbtnSelectStaffByID.Checked)
                AdministratorRequest.Select_Concrete_Staff_By_ID(factory, dgvSelectedStaff, Convert.ToInt32(tbStaffSelectByID.Text));
        }
        private void BtnStaffDegreeAdd_Click(object sender, EventArgs e)
        {

        }
        private void BtnRefreshStaffTitle_Click(object sender, EventArgs e)
        {
            //AdministratorRequest
        }
        #endregion

        private void BtnStaffShowEmployeeSheet_Click(object sender, EventArgs e)
        {
            fillDgvForEmployeeSheet();
            AdministratorRequest.Show_Staff_Time_Sheet(factory, dgvStaffEmployeeSheet);
        }
        private void fillDgvForEmployeeSheet()
        {
            dgvStaffEmployeeSheet.Columns.Add("ID_Employee_Sheet", "Номер табеля сотрудника");
            dgvStaffEmployeeSheet.Columns.Add("ID_Time_Sheet", "Номер табеля кафедры");
            dgvStaffEmployeeSheet.Columns.Add("ID_Staff", "Номер табеля сотрудника");
            dgvStaffEmployeeSheet.Columns.Add("Number_of_work_days", "Кол-во рабочих дней");
            dgvStaffEmployeeSheet.Columns.Add("Number_of_day_offs", "Кол-во дней отсуствия");
            dgvStaffEmployeeSheet.Columns.Add("Number_of_vacation_days", "Кол-во дней отпуска");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            factory.RepositoryChair.UpdatePhone(tbChairUpdatePhone.Text, tbChairUpdateID.Text);
        }
    }
}
