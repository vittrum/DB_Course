using System.Windows.Forms;
using DB_Course.Tables;

namespace DB_Course
{
    class AdministratorRequests
    {
        
        #region Staff 
        
        public void Select_Concrete_Staff_By_ID(Factory factory, DataGridView dgv, int id)
        {
            
            dgv.Columns.Add("ID", "Номер");
            dgv.Columns.Add("Name", "Имя");
            dgv.Columns.Add("LastName", "Фамилия");
            dgv.Columns.Add("Patronymic", "Отчество");
            dgv.Columns.Add("Education", "Образование");
            dgv.Columns.Add("Phone", "Телефон");
            dgv.Columns.Add("Registration", "Прописка");
            dgv.Columns.Add("Pass", "Паспортный данные");
            dgv.Columns.Add("Type", "Тип сотрудника");
            Staff staff = factory.Staff.GetStaffByID(id);
            dgv.Rows.Add(staff.ID_Staff, 
                         staff.Name, 
                         staff.Lastname,
                         staff.Patronymic,
                         staff.Education,
                         staff.Phone,
                         staff.Registration,
                         staff.Pass,
                         staff.Type);
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
            dgv.Columns.Add("ID", "Номер");
            dgv.Columns.Add("Name", "Имя");
            dgv.Columns.Add("LastName", "Фамилия");
            dgv.Columns.Add("Patronymic", "Отчество");
            dgv.Columns.Add("Education", "Образование");
            dgv.Columns.Add("Phone", "Телефон");
            dgv.Columns.Add("Registration", "Прописка");
            dgv.Columns.Add("Pass", "Паспортный данные");
            dgv.Columns.Add("Type", "Тип сотрудника");

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
        public void Show_Staff_Time_Sheet() { }
        public void Show_Concrete_Staff_Titles() { }
        public void Show_Concrete_Staff_Degrees() { }
        public void Show_Staff_Chair() { }
        public void Show_Staff_Orders() { }
        public void Show_Staff_Contract() { }
        public void Add_Staff_Contract() { }
        public void Delete_Staff_Contract() { }
        #endregion
      
        #region Titles
        public void Show_Titles(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryTitle.GetTable())
            {
                dgv.Rows.Add(i.ID_Title, i.Name);
            }
        }
        public void Add_Title() { }
        public void Delete_Title() { }
        #endregion

        #region Degrees
        public void Show_Degrees() { }
        public void Add_Degree() { }
        public void Delete_Degree() { }
        #endregion

        #region Staff_Titles
        public void Show_Staff_Titles() { }
        public void Add_Staff_Title() { }
        public void Delete_Staff_Title() { }

        #endregion

        #region Staff_Degrees
        public void Show_Staff_Degrees() { }
        public void Add_Staff_Degrees() { }
        public void Delete_Staff_Degrees() { }
        #endregion

        #region Orders
        public void Show_Orders() { }
        public void Select_Concrete_Order() { }
        public void Add_Order() { }
        public void Delete_Order() { }
        #endregion

        #region Chairs
        public void Show_Chairs() { }
        public void Select_Concrete_Chair() { }
        public void Add_Chair() { }
        public void Delete_Chair() { }
        public void Update_Chair_Phone() { }
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

    }
}
