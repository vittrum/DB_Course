using System.Windows.Forms;

namespace DB_Course
{
    class AdministratorRequests
    {
        
        #region Staff requests
        
        public void Select_By_ID(Factory factory, DataGridView dgv, int id)
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
        public void Insert_Staff(Factory factory, string name, string lastname, 
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
        public void Select_All_Staff(Factory factory, DataGridView dgv)
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
        #endregion
      
        #region Titles
        public void Title_Output(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryTitle.GetTable())
            {
                dgv.Rows.Add(i.ID_Title, i.Name);
            }
        }
        #endregion
    }
}
