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
           /* FillDgvForStaffAll();
            AdministratorRequest.Show_All_Staff(factory, dgvSelectedStaff);
            FillDgvForChair();
            AdministratorRequest.Show_Chairs(factory, dgvChair);*/
            FillDgvForDegrees();
            AdministratorRequest.Show_Degrees(factory,dgvDegrees);
          
            
            

        }
        AdministratorRequests AdministratorRequest = new AdministratorRequests();
        Factory factory = new Factory("127.0.0.1", "5432", "postgres", "1", "University personnel department"); //Viktor_db
        ErrorProtector errorProtector = new ErrorProtector();
        
        //
        #region Staff
        //есть
        private void BtnSelectAllStaff_Click(object sender, EventArgs e)
        {
            FillDgvForStaffAll();
            AdministratorRequest.Show_All_Staff(factory, dgvSelectedStaff);
        }       
        //есть
        private void BtnAddStaff_Click(object sender, EventArgs e)
        {
           if (!Check_Staff_Insert_Textboxes())
                errorProtector.EmptyBox();
           else 
               AdministratorRequest.Add_Staff
                    (factory, 
                    tbStaffInsertName.Text, 
                    tbStaffInsertLastname.Text,
                    tbStaffInsertPatronymic.Text, 
                    tbStaffInsertEducation.Text,                                              
                    tbStaffInsertPhone.Text, 
                    tbStaffInsertRegistration.Text,                                              
                    tbStaffInsertPass.Text, 
                    tbStaffInsertType.Text);                
        }        
        //есть
        private void BtnDeleteStaff_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSelectedStaff.SelectedRows)
            {                
                AdministratorRequest.Delete_Staff(factory, row.Cells["ID"].Value.ToString());                
                dgvSelectedStaff.Rows.Remove(row);
            }            
        }        

        private void BtnStaffSelectSome_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Select_Some_Staff(factory, dgvSelectedStaff, chboxStaffPass.Checked, chboxStaffEducation.Checked,
                chboxStaffPhone.Checked, chboxStaffType.Checked, chboxStaffRegistration.Checked);
        }
       
        private void BtnStaffDegreeAdd_Click(object sender, EventArgs e)
        {

        }
                
        private void BtnAddStaffDegree_Click(object sender, EventArgs e)
        {
            if (true)
                AdministratorRequest.Add_Staff_Degrees();
        }

        private void BtnAddStaffTitle_Click(object sender, EventArgs e)
        {
            if (true)
                AdministratorRequest.Add_Staff_Title();
        }

        private void BtnStaffShowEmployeeSheet_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeSheet();
            AdministratorRequest.Show_Staff_Time_Sheet(factory, dgvStaffEmployeeSheet);
        }

        private void BtnAddStaffOrder_Click(object sender, EventArgs e)
        {
            if (comboOrderTypeAdd.SelectedItem.ToString() == "Командировка")
            {
                panelSickListOrder.Visible = false;
                panelBusinessTripOrder.Visible = true;

            }
            if (comboOrderTypeAdd.SelectedItem.ToString() == "Отпуск")
            {
                panelSickListOrder.Visible = false;
                panelBusinessTripOrder.Visible = false;
            }
            if (comboOrderTypeAdd.SelectedItem.ToString() == "Больничный")
            {
                panelSickListOrder.Visible = true;
                panelBusinessTripOrder.Visible = false;
            }
            else MessageBox.Show("Выберите тип приказа!");
        }

        private void BtnShowAllOrders_Click(object sender, EventArgs e)
        {
            FillDgvForOrders();
            AdministratorRequest.Show_Orders(factory, dgvOrders);
        }

        private void BtnShowStaffOrders_Click(object sender, EventArgs e)
        {
            if (comboOrderTypes.SelectedItem.ToString() == "Командировка")
            {
                FillDgvForOrderBusinessTrip();
                //AdministratorRequest.Show_Staff_Business_Trips(factory, dgvOrders);                
            }
            if (comboOrderTypes.SelectedItem.ToString() == "Больничный")
            {
                FillDgvForOrderSick_List();
                //AdministratorRequest.Show_Staff_Sick_List(factory, dgvOrders);
            }
            if (comboOrderTypes.SelectedItem.ToString() == "Отпуск")
            {
                FillDgvForOrderVacation();
                //AdministratorRequest.Show_Staff_Vacations(factory, dgvOrders);
            }
        }
        #endregion
        //Все работает, нужен апдейт телефона
        #region Chair
        private void BtnAddChair_Click(object sender, EventArgs e)
        {
            FillDgvForChair();
            AdministratorRequest.Add_Chair(factory, tbAddChair.Text, tbAddChairPhone.Text);
            AdministratorRequest.Show_Chairs(factory, dgvChair);
        }
        private void BtnShowChairs_Click(object sender, EventArgs e)
        {
            FillDgvForChair();
            AdministratorRequest.Show_Chairs(factory, dgvChair);
        }

        private void BtnDeleteChair_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChair.SelectedRows)
            {
                AdministratorRequest.Delete_Chair(factory, row.Cells["ID_Chair"].Value.ToString());
                dgvChair.Rows.Remove(row);
            }
        }


        #endregion
        //Все работает
        #region Positions
        private void BtnAddPosition_Click(object sender, EventArgs e)
        {
            FillDgvForPositions();
            AdministratorRequest.Add_Position(factory, tbAddPosition.Text);
            AdministratorRequest.Show_Positions(factory, dgvPositions);
        }
        private void BtnShowAllPositions_Click(object sender, EventArgs e)
        {
            FillDgvForPositions();
            AdministratorRequest.Show_Positions(factory, dgvPositions);
        }

        private void BtnDeletePosition_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPositions.SelectedRows)
            {
                AdministratorRequest.Delete_Position(factory, row.Cells["ID_Position"].Value.ToString());
                dgvPositions.Rows.Remove(row);
            }
        }
        #endregion
        //Все работает
        #region Degrees And Titles
        private void BtnAddDegree_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Add_Degree(factory, tbAddDegree.Text);
        }

        private void BtnAddTitle_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Add_Title(factory, tbAddTitle.Text);
        }

        private void BtnShowAllDegrees_Click(object sender, EventArgs e)
        {
            FillDgvForDegrees();
            AdministratorRequest.Show_Degrees(factory, dgvDegrees);
        }

        private void BtnShowAllTitles_Click(object sender, EventArgs e)
        {
            FillDgvForTitles();
            AdministratorRequest.Show_Titles(factory, dgvTitles);
        }

        private void BtnDeleteDegree_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDegrees.SelectedRows)
            {
                AdministratorRequest.Delete_Degree(factory, row.Cells["ID_Degree"].Value.ToString());
                dgvDegrees.Rows.Remove(row);
            }
        }

        private void BtnDeleteTitle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTitles.SelectedRows)
            {
                AdministratorRequest.Delete_Title(factory, row.Cells["ID_Title"].Value.ToString());
                dgvTitles.Rows.Remove(row);
            }
        }
        #endregion

        #region Insert validation

        private bool Check_Staff_Insert_Textboxes()
        {
            if
            (
                tbStaffInsertName.Text != string.Empty
                &&
                tbStaffInsertLastname.Text != string.Empty
                &&
                tbStaffInsertPatronymic.Text != string.Empty
                &&
                tbStaffInsertEducation.Text != string.Empty
                &&
                tbStaffInsertPhone.Text != string.Empty
                &&
                tbStaffInsertRegistration.Text != string.Empty
                &&
                tbStaffInsertPass.Text != string.Empty
                &&
                tbStaffInsertType.Text != string.Empty
            )
                return true;
            else
                return false;
        }
        #endregion

        #region DataGridView control
        //Сотрудник
        private void FillDgvForStaffAll()
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
        private void FillDgvForStaffWithParameters(bool needPass, bool needEducation, 
            bool needPhone, bool needType, bool needRegistration)
        {
            dgvSelectedStaff.Columns.Add("Name", "Имя");
            dgvSelectedStaff.Columns.Add("LastName", "Фамилия");
            dgvSelectedStaff.Columns.Add("Patronymic", "Отчество");
            if (needEducation)
                dgvSelectedStaff.Columns.Add("Education", "Образование");
            if (needPhone)
                dgvSelectedStaff.Columns.Add("Phone", "Телефон");
            if (needRegistration)
                dgvSelectedStaff.Columns.Add("Registration", "Прописка");
            if (needPass)
                dgvSelectedStaff.Columns.Add("Pass", "Паспортный данные");
            if (needType)
                dgvSelectedStaff.Columns.Add("Type", "Тип сотрудника");
        }
        private void FillDgvForEmployeeSheet()
        {
            dgvStaffEmployeeSheet.Columns.Clear();
            dgvStaffEmployeeSheet.Columns.Add("ID_Employee_Sheet", "Номер табеля сотрудника");
            dgvStaffEmployeeSheet.Columns.Add("ID_Time_Sheet", "Номер табеля кафедры");
            dgvStaffEmployeeSheet.Columns.Add("ID_Staff", "Номер табеля сотрудника");
            dgvStaffEmployeeSheet.Columns.Add("Number_of_work_days", "Кол-во рабочих дней");
            dgvStaffEmployeeSheet.Columns.Add("Number_of_day_offs", "Кол-во дней отсуствия");
            dgvStaffEmployeeSheet.Columns.Add("Number_of_vacation_days", "Кол-во дней отпуска");
        }
        private void FillDgvForEmployeeContract()
        {
            dgvStaffContract.Columns.Clear();
            dgvStaffContract.Columns.Add("ID_Contract", "Номер");
            dgvStaffContract.Columns.Add("Chair", "Кафедра");
            dgvStaffContract.Columns.Add("Position", "Должность");
            dgvStaffContract.Columns.Add("Beginn_Date", "Начало");
            dgvStaffContract.Columns.Add("End_Date", "Окончание");
        }
        private void FillDgvForStaffTitle()
        {
            dgvStaffTitle.Columns.Clear();
            dgvStaffTitle.Columns.Add("ID_Title", "Номер");
            dgvStaffTitle.Columns.Add("Name", "Имя");
            dgvStaffTitle.Columns.Add("LastName", "Фамилия");
            dgvStaffTitle.Columns.Add("Patronymic", "Отчество");
            dgvStaffTitle.Columns.Add("Title_Name", "Звание");
        }
        private void FillDgvForStaffDegree()
        {
            dgvStaffDegree.Columns.Clear();
            dgvStaffDegree.Columns.Add("ID_Degree", "Номер");
            dgvStaffDegree.Columns.Add("Name", "Имя");
            dgvStaffDegree.Columns.Add("LastName", "Фамилия");
            dgvStaffDegree.Columns.Add("Patronymic", "Отчество");
            dgvStaffDegree.Columns.Add("Degree_Name", "Степень");
        }
        //Приказы
        private void FillDgvForOrders()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("Name", "Имя");
            dgvOrders.Columns.Add("Lastname", "Фамилия");
            dgvOrders.Columns.Add("Patronymic", "Отчество");
            dgvOrders.Columns.Add("Type", "Тип");
            dgvOrders.Columns.Add("Beginn_Date", "Начало");
            dgvOrders.Columns.Add("End_Date", "Окончание");
        }
        private void FillDgvForOrderBusinessTrip()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("Beginn_Date", "Начало");
            dgvOrders.Columns.Add("End_Date", "Окончание");
            dgvOrders.Columns.Add("Is_paid", "Оплачиваемый?");
        }
        private void FillDgvForOrderVacation()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("Purpose", "Цель");
            dgvOrders.Columns.Add("Place", "Место");
            dgvOrders.Columns.Add("Beginn_Date", "Начало");
            dgvOrders.Columns.Add("End_Date", "Окончание");
            dgvOrders.Columns.Add("Cause", "Причина");
            dgvOrders.Columns.Add("Payment", "К оплате");
        }
        private void FillDgvForOrderSick_List()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add("Beginn_Date", "Начало");
            dgvOrders.Columns.Add("End_Date", "Окончание");
            dgvOrders.Columns.Add("Cause", "Причина");
            dgvOrders.Columns.Add("Is_paid", "Оплачиваемый?");
        }
        //Кафедра
        private void FillDgvForChair()
        {
            dgvChair.Columns.Clear();
            dgvChair.Columns.Add("ID_Chair", "Номер");
            dgvChair.Columns.Add("Chair_Name", "Название");
            dgvChair.Columns.Add("Chair_Phone", "Телефон");
        }
        //Звания и степени
        private void FillDgvForDegrees()
        {
            dgvDegrees.Columns.Clear();
            dgvDegrees.Columns.Add("ID_Degree", "Номер");
            dgvDegrees.Columns.Add("Degree_Name", "Степень");
        }
        private void FillDgvForTitles()
        {
            dgvTitles.Columns.Clear();
            dgvTitles.Columns.Add("ID_Title", "Номер");
            dgvTitles.Columns.Add("Title_Name", "Звание");
        }
        //Должности 
        private void FillDgvForPositions()
        {
            dgvPositions.Columns.Clear();
            dgvPositions.Columns.Add("ID_Position", "Номер");
            dgvPositions.Columns.Add("Name", "Должность");
        }
       #endregion
               
        
        //Непонятная дичь
        private void Button1_Click_1(object sender, EventArgs e)
        {
            AdministratorRequest.Show_Titles(factory, dgvTitles);
            if (dgvTitles.CurrentRow != null)
                dgvTitles.Rows[dgvTitles.CurrentRow.Index].Selected = false;
        }

        //Переделать
        private void BtnSelectAllContracts_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeContract();
            AdministratorRequest.Show_Staff_Contract(factory, dgvStaffContract);
        }



    }
}
