using System.Windows.Forms;
using DB_Course.Tables;

namespace DB_Course
{
    class AdministratorRequests
    {
        //Все однотабличные запросы есть (еще 3)
        #region Staff 
        
        public void Select_Concrete_Staff_By_ID(Factory factory, DataGridView dgv, int id)
        {
            dgv.Rows.Add(factory.Staff.GetStaffByID(id).ID_Staff,
                         factory.Staff.GetStaffByID(id).Name,
                         factory.Staff.GetStaffByID(id).Lastname,
                         factory.Staff.GetStaffByID(id).Patronymic,
                         factory.Staff.GetStaffByID(id).Education,
                         factory.Staff.GetStaffByID(id).Phone,
                         factory.Staff.GetStaffByID(id).Registration,
                         factory.Staff.GetStaffByID(id).Pass,
                         factory.Staff.GetStaffByID(id).Type);
        }
        public void Add_Staff(Factory factory, string name, string lastname, 
                                string patronymic, string education,
                                string phone, string registration, 
                                string pass, string type)
        {
            /*Contract.ContractFailed += (sender, e) =>
            {
                MessageBox.Show(e.Message);
                e.SetHandled();
            };
            Contract.Requires(name.GetType() != typeof(string));
            Contract.Requires(lastname.GetType() != typeof(string));*/
            
            factory.RepositoryStaff.Insert(name, lastname, patronymic, education, 
                                            phone, registration, pass, type);
        }
        public void Show_All_Staff(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryStaff.GetTable())
            {
                dgv.Rows.Add(i.ID_Staff,i.Name, i.Lastname, i.Patronymic, i.Education, i.Phone, i.Registration, i.Pass, i.Type);
            }
        }
        public void Select_Some_Staff(Factory factory, DataGridView dgv, 
                                    bool needPass, bool needEducation, 
                                    bool needPhone, bool needType, bool needRegistration)
        {
            dgv.Columns.Add("ID", "Номер");
            dgv.Columns.Add("Name", "Имя");
            dgv.Columns.Add("LastName", "Фамилия");
            dgv.Columns.Add("Patronymic", "Отчество");
            if (needEducation)
                dgv.Columns.Add("Education", "Образование");
            if (needPhone)
                dgv.Columns.Add("Phone", "Телефон");
            if (needRegistration)
                dgv.Columns.Add("Registration", "Прописка");
            if (needPass)
                dgv.Columns.Add("Pass", "Паспортный данные");
            if (needType)
                dgv.Columns.Add("Type", "Тип сотрудника");

            foreach (var i in factory.RepositoryStaff.GetTable())
            {
                int rowindex = dgv.Rows.Add();
                var row = dgv.Rows[rowindex];
                row.Cells["ID"].Value = i.ID_Staff;
                row.Cells["Name"].Value = i.Name;
                row.Cells["Lastname"].Value = i.Lastname;
                row.Cells["Patronymic"].Value = i.Patronymic;
                if (needEducation)
                    row.Cells["Education"].Value = i.Education;                                
                if (needPhone)
                    row.Cells["Phone"].Value = i.Phone;
                if (needRegistration)
                    row.Cells["Registration"].Value = i.Registration;
                if (needPass)
                    row.Cells["Pass"].Value = i.Pass;
                if (needType)
                    row.Cells["Type"].Value = i.Type;
            }
        }
        public void Delete_Staff(Factory factory, string id_staff)
        {
            factory.RepositoryStaff.Delete(id_staff);
        }
        public void Show_Staff_Time_Sheet(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryEmployee_Sheet.GetTable())
            {
                dgv.Rows.Add(i.ID_Employee_Sheet, i.ID_Time_Sheet, i.ID_Staff, i.Number_of_work_days,
                    i.Number_of_day_offs, i.Number_of_vacation_days);
            }
        }
        public void Show_Concrete_Staff_Titles(Factory factory, DataGridView dgv)
        {
            
        }
        public void Show_Concrete_Staff_Degrees() { }
        public void Show_Staff_Chair() { }
        public void Show_Staff_Orders() { }
        public void Show_Staff_Contract(Factory factory, DataGridView dgv)
        {
            //Cтолбцы
            foreach (var i in factory.Contract.GetTable())
            {
                dgv.Rows.Add(i.ID_Employment_Contract, i.ID_Staff, i.ID_Chair,
                    i.ID_Position, i.Beginn_Date, i.End_Date, i.Additional_Information);
            }
        }
        public void Add_Staff_Contract(Factory factory, string ID_Staff, string ID_Chair,
                                       string ID_Position, string Beginn_Date, string End_Date)
        {
            factory.RepositoryContract.Insert(ID_Staff, ID_Chair, ID_Position, Beginn_Date, End_Date);
        }
        public void Delete_Staff_Contract(Factory factory, string ID_Contract)
        {
            factory.RepositoryContract.Delete(ID_Contract);
        }
        #endregion
        //Все запросы есть
        #region Titles
        public void Show_Titles(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryTitle.GetTable())
            {
                dgv.Rows.Add(i.ID_Title, i.Name);
            }
        }
        public void Add_Title(Factory factory, string Name)
        {
            factory.RepositoryTitle.Insert(Name);
        }
        public void Delete_Title(Factory factory, string ID_Title)
        {
            factory.RepositoryTitle.Delete(ID_Title);
        }
        #endregion
        //Все запросы есть 
        #region Degrees
        public void Show_Degrees(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryDegree.GetTable())
            {
                dgv.Rows.Add(i.ID_Degree, i.Name);
            }
        }
        public void Add_Degree(Factory factory, string Name)
        {
            factory.RepositoryDegree.Insert(Name);
        }
        public void Delete_Degree(Factory factory, string ID_Degree)
        {
            factory.RepositoryDegree.Delete(ID_Degree);
        }
        #endregion
        //Запросов нет (еще 3)
        #region Staff_Titles
        public void Show_Staff_Titles() { }
        public void Add_Staff_Title() { }
        public void Delete_Staff_Title() { }

        #endregion
        //Запросов нет (еще 3)
        #region Staff_Degrees
        public void Show_Staff_Degrees() { }
        public void Add_Staff_Degrees() { }
        public void Delete_Staff_Degrees() { }
        #endregion
        //Запросов нет (еще 3)
        #region Orders
        public void Show_Orders() { }
        public void Select_Concrete_Order() { }
        public void Add_Order() { }
        public void Delete_Order() { }
        #endregion

        #region Chairs
        public void Show_Chairs(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryChair.GetTable())
                dgv.Rows.Add(i.ID_Chair, i.Name, i.Phone);
        }
        public void Select_Concrete_Chair(Factory factory, DataGridView dgv, string ID_Chair)
        {
            dgv.Rows.Add(factory.RepositoryChair.GetChair(ID_Chair).ID_Chair,
            factory.RepositoryChair.GetChair(ID_Chair).Name,
            factory.RepositoryChair.GetChair(ID_Chair).Phone);
        }
        public void Add_Chair(Factory factory, string Name, string Phone)
        {
            factory.RepositoryChair.Insert(Name, Phone);
        }
        public void Delete_Chair(Factory factory, string ID_Chair)
        {
            factory.RepositoryChair.Delete(ID_Chair);
        }        
        public void Update_Chair_Phone(Factory factory, string Phone, string ID_Chair)
        {
            factory.RepositoryChair.UpdatePhone(Phone, ID_Chair);
        }
        public void Show_Chair_Time_Sheet() { }
        public void Add_Chair_Time_Sheet() { }
        public void Delete_Chair_Time_Sheet() { }
        #endregion

        #region Positions
        public void Show_Positions() { }
        public void Add_Position() { }
        public void Delete_Position() { }
        #endregion

        #region 
        #endregion
    }
}
