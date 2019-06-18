using System;
using System.Windows.Forms;

namespace DB_Course
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region login
            tabControlMain.Visible = false;
            //panelLogin.Visible = true;
            
            #endregion

            //Заполнить кафедры            

            FillDgvForChair();
            AdministratorRequest.Show_Chairs(factory, dgvChair);
            //Вывод степеней и званий
            FillDgvForDegrees();
            AdministratorRequest.Show_Degrees(factory,dgvDegrees);
            FillDgvForTitles();
            AdministratorRequest.Show_Titles(factory, dgvTitles);
            //Вывод должностей
            FillDgvForPositions();
            AdministratorRequest.Show_Positions(factory, dgvPositions);
            // Заполнение комбобоксов
            AdministratorRequest.Get_Positions(factory, comboContractPositions);
            AdministratorRequest.Get_Chairs(factory, comboContractChair);
            AdministratorRequest.Get_Titles(factory, comboTitles);
            AdministratorRequest.Get_Degrees(factory, comboDegrees);
            AdministratorRequest.Get_Chairs(factory, comboStaffByChair);
            AdministratorRequest.Get_Chairs(factory, comboChairSheet);
            AdministratorRequest.Get_Chairs(factory, comboChairUpd);
        }
        
        AdministratorRequests AdministratorRequest = new AdministratorRequests();
        Factory factory = new Factory("127.0.0.1", "5432", "observer", "3333", "University personnel department"); //Viktor_db
        ErrorProtector errorProtector = new ErrorProtector();

       

        #region Staff

        private void BtnStaffSelectWithChoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnSelectStaffByName.Checked)
                {
                    FillDgvForSingleStaff();
                    AdministratorRequest.Select_Staff_By_Name(factory, dgvSelectedStaff, tbStaffSelectByName.Text,
                                        tbStaffSelectByLastname.Text, tbStaffSelectByPatronymic.Text);
                }
                if (rbtnSelectStaffByChair.Checked)
                {
                    FillDgvForAllStaff();
                    AdministratorRequest.Select_Staff_By_Chair(factory, dgvSelectedStaff, comboStaffByChair.SelectedItem.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Clear_Staff_By_Name_tb();
        }

        //есть
        private void BtnSelectAllStaff_Click(object sender, EventArgs e)
        {
            FillDgvForAllStaff();
            AdministratorRequest.Show_All_Staff(factory, dgvSelectedStaff);
            FillDgvForStaffWithParameters();
        }

        //есть
        private void BtnAddStaff_Click(object sender, EventArgs e)
        {
            
            try
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
                         comboStaffType.SelectedItem.ToString());
            }
            catch { }
            Clear_Staff_Insert_tb();
            FillDgvForAllStaff();
            AdministratorRequest.Show_All_Staff(factory, dgvSelectedStaff);
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
       
     //   private void BtnStaffDegreeAdd_Click(object sender, EventArgs e)       
                
        private void BtnAddStaffDegree_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Add_Staff_Degrees(factory, tbStaffDegreeAddName.Text,
                                                    tbStaffDegreeAddLastname.Text, 
                                                    tbStaffDegreeAddPatronymic.Text, 
                                                    comboDegrees.SelectedItem.ToString(), 
                                                    dateStaffDegreeAdd.Value.ToShortDateString());
            FillDgvForStaffDegree();
            AdministratorRequest.Show_Staff_Degrees(factory, dgvStaffDegree);
        }

        private void BtnAddStaffTitle_Click(object sender, EventArgs e)
        {
            if (true)
                AdministratorRequest.Add_Staff_Title(factory, tbStaffTitleAddName.Text, tbStaffTitleAddLastname.Text,
                    tbStaffTitleAddPatronymic.Text, comboTitles.SelectedItem.ToString(), dateStaffTitleAdd.Value.ToShortDateString());
            FillDgvForStaffTitle();
            AdministratorRequest.Show_Staff_Titles(factory, dgvStaffTitle);
        }

        private void BtnStaffShowEmployeeSheet_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeSheet();
            AdministratorRequest.Show_Staff_Time_Sheet(factory, dgvStaffEmployeeSheet);
        }

        private void BtnAddStaffOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboOrderTypeAdd.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тип приказа!");
                }
                if (comboOrderTypeAdd.SelectedItem.ToString() == "Командировка")
                {
                    panelSickListOrder.Visible = false;
                    panelBusinessTripOrder.Visible = true;
                    AdministratorRequest.Add_Staff_Business_Trip(factory,
                        tbOrderName.Text, tbOrderLastname.Text, tbOrderPatronymic.Text, comboOrderTypeAdd.SelectedItem.ToString(),
                        dtpAddOrderBeginn.Value.ToShortDateString(), dtpAddOrderEnd.Value.ToShortDateString(),
                        tbBusinessTripPlace.Text, tbBusinessTripPurpose.Text, tbBusinessTripToBePaid.Text);
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
            }
            catch { }
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

        private void BtnShowStaffDegree_Click(object sender, EventArgs e)
        {
            FillDgvForStaffDegree();
            AdministratorRequest.Show_Staff_Degrees(factory, dgvStaffDegree);
        }

        private void BtnShowStaffTitle_Click(object sender, EventArgs e)
        {
            FillDgvForStaffTitle();
            AdministratorRequest.Show_Staff_Titles(factory, dgvStaffTitle);
        }

        private void BtnSelectAllContracts_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeContract();
            AdministratorRequest.Show_Staff_Contract(factory, dgvStaffContract);
        }

        private void BtnContractAdd_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeContract();
            AdministratorRequest.Add_Staff_Contract(factory, tbContractAddStaffName.Text,
                                                    tbContractAddStaffLastname.Text,
                                                    tbContractAddStaffPatronymic.Text,
                                                    comboContractChair.SelectedItem.ToString(),
                                                    comboContractPositions.SelectedItem.ToString(),
                                                    dateContractBeginn.Value.ToShortDateString(),
                                                    dateContractEnd.Value.ToShortDateString(),
                                                    "No info");
            AdministratorRequest.Show_Staff_Contract(factory, dgvStaffContract);
        }

        private void BtnDeleteStaffDegree_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStaffDegree.SelectedRows)
            {
                AdministratorRequest.Delete_Staff_Degree(factory, row.Cells["Name"].Value.ToString(),
                                                                  row.Cells["LastName"].Value.ToString(),
                                                                  row.Cells["Patronymic"].Value.ToString(),
                                                                  row.Cells["Degree_Name"].Value.ToString(),
                                                                  row.Cells["Date_of_assignment"].Value.ToString());
                dgvStaffDegree.Rows.Remove(row);
            }
        }

        private void BtnDeleteStaffTitle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStaffTitle.SelectedRows)
            {
                AdministratorRequest.Delete_Staff_Title(factory, row.Cells["Name"].Value.ToString(),
                                                                  row.Cells["LastName"].Value.ToString(),
                                                                  row.Cells["Patronymic"].Value.ToString(),
                                                                  row.Cells["Title_Name"].Value.ToString(),
                                                                  row.Cells["Date_of_assignment"].Value.ToString());
                dgvStaffTitle.Rows.Remove(row);
            }
        }
        #endregion
        //Все работает, нужен апдейт телефона
        #region Chair
        private void BtnAddChair_Click_1(object sender, EventArgs e)
        {
            FillDgvForChair();
            AdministratorRequest.Add_Chair(factory, tbAddChair.Text, tbAddChairPhone.Text);
            AdministratorRequest.Show_Chairs(factory, dgvChair);
        }
        /*private void BtnShowChairs_Click(object sender, EventArgs e)
        {
            FillDgvForChair();
            AdministratorRequest.Show_Chairs(factory, dgvChair);
        }*/

        private void BtnDeleteChair_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChair.SelectedRows)
            {
                AdministratorRequest.Delete_Chair(factory, row.Cells["ID_Chair"].Value.ToString());
                dgvChair.Rows.Remove(row);
            }
        }
        private void BtnUpdChairPhone_Click(object sender, EventArgs e)
        {
            try
            {
                FillDgvForChair();
                //AdministratorRequest.Show_Chairs(factory, dgvChair);
                AdministratorRequest.Update_Chair_Phone(factory, tbChairPhoneUpd.Text, comboChairUpd.SelectedItem.ToString());
                AdministratorRequest.Show_Chairs(factory, dgvChair);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка. Проверьте корректность данных");
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
            FillDgvForDegrees();
            AdministratorRequest.Show_Degrees(factory, dgvDegrees);
        }

        private void BtnAddTitle_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Add_Title(factory, tbAddTitle.Text);
            FillDgvForTitles();
            AdministratorRequest.Show_Titles(factory, dgvTitles);
        }

        /* private void BtnShowAllDegrees_Click(object sender, EventArgs e)
        {
            FillDgvForDegrees();
            AdministratorRequest.Show_Degrees(factory, dgvDegrees);
        }

        private void BtnShowAllTitles_Click(object sender, EventArgs e)
        {
            FillDgvForTitles();
            AdministratorRequest.Show_Titles(factory, dgvTitles);
        }*/

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
                comboStaffType.SelectedItem.ToString() != string.Empty
            )
                return true;
            else
                return false;
        }
        #endregion

        #region DataGridView control
        //Сотрудник
        private void FillDgvForSingleStaff()
        {
            dgvSelectedStaff.Columns.Clear();
            dgvSelectedStaff.Columns.Add("Education", "Образование");
            dgvSelectedStaff.Columns.Add("Phone", "Телефон");
            dgvSelectedStaff.Columns.Add("Registration", "Прописка");
            dgvSelectedStaff.Columns.Add("Pass", "Паспортный данные");
            dgvSelectedStaff.Columns.Add("Type", "Тип сотрудника");
        }
        private void FillDgvForAllStaff()
        {
            dgvSelectedStaff.Columns.Clear();
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
        private void FillDgvForStaffWithParameters()
        {
            /*dgvSelectedStaff.Columns.Clear();
            dgvSelectedStaff.Columns.Add("Name", "Имя");
            dgvSelectedStaff.Columns.Add("LastName", "Фамилия");
            dgvSelectedStaff.Columns.Add("Patronymic", "Отчество");*/
            if (!chboxStaffEducation.Checked)
                dgvSelectedStaff.Columns.Remove("Education");
            if (!chboxStaffPhone.Checked)
                dgvSelectedStaff.Columns.Remove("Phone");
            if (!chboxStaffRegistration.Checked)
                dgvSelectedStaff.Columns.Remove("Registration");
            if (!chboxStaffPass.Checked)
                dgvSelectedStaff.Columns.Remove("Pass");
            if (!chboxStaffType.Checked)
                dgvSelectedStaff.Columns.Remove("Type");
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
            dgvStaffContract.Columns.Add("s_name", "Имя");
            dgvStaffContract.Columns.Add("LastName", "Фамилия");
            dgvStaffContract.Columns.Add("Patronymic", "Отчество");
            dgvStaffContract.Columns.Add("c_name", "Кафедра");
            dgvStaffContract.Columns.Add("Name", "Должность");
            dgvStaffContract.Columns.Add("Beginn_Date", "Начало");
            dgvStaffContract.Columns.Add("End_Date", "Окончание");
            dgvStaffContract.Columns.Add("Additional_information", "Доп. информация");
        }
        private void FillDgvForStaffTitle()
        {
            dgvStaffTitle.Columns.Clear();
            //dgvStaffTitle.Columns.Add("ID_Title", "Номер");
            dgvStaffTitle.Columns.Add("Name", "Имя");
            dgvStaffTitle.Columns.Add("LastName", "Фамилия");
            dgvStaffTitle.Columns.Add("Patronymic", "Отчество");
            dgvStaffTitle.Columns.Add("Title_Name", "Звание");
            dgvStaffTitle.Columns.Add("Date_of_assignment", "Дата присвоения");

        }
        private void FillDgvForStaffDegree()
        {
            dgvStaffDegree.Columns.Clear();
            //dgvStaffDegree.Columns.Add("ID_Degree", "Номер");
            dgvStaffDegree.Columns.Add("Name", "Имя");
            dgvStaffDegree.Columns.Add("LastName", "Фамилия");
            dgvStaffDegree.Columns.Add("Patronymic", "Отчество");
            dgvStaffDegree.Columns.Add("Degree_Name", "Степень");
            dgvStaffDegree.Columns.Add("Date_of_assignment", "Дата присвоения");
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
            dgvOrders.Columns.Add("Info", "Текст приказа");
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
        private void FillDgvForTimeSheet()
        {
            dgvTimeSheet.Columns.Clear();
            dgvTimeSheet.Columns.Add("id_time_sheet", "Номер табеля");
            dgvTimeSheet.Columns.Add("id_chair", "Номер кафедры");
            dgvTimeSheet.Columns.Add("begd", "Начало");
            dgvTimeSheet.Columns.Add("endd", "Конец");

        }
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

        #region TextBox control
        private void Clear_Staff_Insert_tb()
        {
            tbStaffInsertEducation.Clear();
            tbStaffInsertLastname.Clear();
            tbStaffInsertName.Clear();
            tbStaffInsertPass.Clear();
            tbStaffInsertPatronymic.Clear();
            tbStaffInsertPhone.Clear();
            tbStaffInsertRegistration.Clear();
        }

        public void Clear_Staff_By_Name_tb()
        {
            tbStaffSelectByLastname.Clear();
            tbStaffSelectByName.Clear();
            tbStaffSelectByPatronymic.Clear();
        }

        #endregion

        
               

        private void BtnLogin_Click_2(object sender, EventArgs e)
        {
            try
            {
                string login = comboLogin.SelectedItem.ToString();
                string pass = tbLogin.Text;
                factory = new Factory("127.0.0.1", "5432", login, pass, "University personnel department");
                tabControlMain.Visible = true;
                gbLogin.Dispose();
                if (login == "user_")
                {
                    btnDeleteChair.Visible = false;
                    btnDeleteContract.Visible = false;
                    btnDeleteStaff.Visible = false;
                    btnDeletePosition.Visible = false;
                    BtnDeleteStaffDegree.Visible = false;
                    BtnDeleteStaffTitle.Visible = false;
                    BtnDeleteStaffTimeSheet.Visible = false;
                    BtnDeleteTitle.Visible = false;
                    BtnDeleteDegree.Visible = false;
                    gbUpdPhone.Visible = false;
                }
                if (login == "observer")
                {
                    tabControlStaff.Visible = false;
                    gbAddChair.Visible = false;
                    gbUpdPhone.Visible = false;
                    panelAddSheet.Visible = false;
                    btnDeleteChair.Visible = false;
                    btnDeleteContract.Visible = false;
                    btnDeleteStaff.Visible = false;
                    btnDeletePosition.Visible = false;
                    BtnDeleteStaffDegree.Visible = false;
                    BtnDeleteStaffTitle.Visible = false;
                    BtnDeleteStaffTimeSheet.Visible = false;
                    BtnDeleteTitle.Visible = false;
                    BtnDeleteDegree.Visible = false;
                    gbUpdPhone.Visible = false;
                    BtnAddPosition.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте соединение и корректность введенных данных");
            }
            

        }

        private void BtnContractShow_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Show_Concrete_Staff_Contract(factory, dgvStaffContract, tbContractSelectName.Text,
                tbContractSelectLastname.Text, tbContractSelectPatronymic.Text);
        }

        private void BtnAddStaffSheet_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeSheet();
            AdministratorRequest.Add_Staff_Sheet(factory,
                                                 tbAddStaffSheetId.Text,
                                                 tbAddStaffSheetTimeSheet.Text,
                                                 tbAddStaffSheetWorkdays.Text,
                                                 tbAddStaffSheetDayOffs.Text,
                                                 tbAddStaffSheetVacations.Text);
            AdministratorRequest.Show_Staff_Time_Sheet(factory, dgvStaffEmployeeSheet);
        }

        private void BtnShowChairTimeSheet_Click(object sender, EventArgs e)
        {

            FillDgvForTimeSheet();
            AdministratorRequest.Show_Chair_Time_Sheet(factory, dgvTimeSheet);
        }

        private void BtnAddTimeSheet_Click(object sender, EventArgs e)
        {
            AdministratorRequest.Add_Chair_Time_Sheet(factory,
                comboChairSheet.SelectedItem.ToString(),
                dateTimeSheetBegin.Value.ToShortDateString(),
                dateTimeSheetEnd.Value.ToShortDateString());
        }

        private void BtnDeleteContract_Click(object sender, EventArgs e)
        {
            //AdministratorRequest.Delete_Staff_Contract(factory, )
        }

        private void BtnShowAllEmployeeSheet_Click(object sender, EventArgs e)
        {
            FillDgvForEmployeeSheet();
            AdministratorRequest.Show_Staff_Time_Sheet(factory, dgvStaffEmployeeSheet);
        }
    }
}
