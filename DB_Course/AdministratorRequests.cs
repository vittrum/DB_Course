using System.Windows.Forms;


namespace DB_Course
{
    class AdministratorRequests
    {
        
        #region Staff 
              
        public void Add_Staff(Factory factory, string name, string lastname, string patronymic, 
            string education, string phone, string registration, string pass, string type)
        {            
            factory.Staff.Insert(name, lastname, patronymic, education, phone, registration, pass, type);
        }
        public void Show_All_Staff(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Staff.GetTable())
            {
                dgv.Rows.Add(i.ID_Staff,i.Name, i.Lastname, i.Patronymic, i.Education, i.Phone, i.Registration, i.Pass, i.Type);
            }
        }
        public void Select_Staff_By_Name(Factory factory, DataGridView dgv, string name, string lastname, string patronymic)
        {
            foreach (var i in factory.Staff.GetStaffByName(name, lastname, patronymic))
                dgv.Rows.Add(i.Education, i.Phone, i.Registration, i.Pass, i.Type);
        }
        public void Select_Staff_By_Chair(Factory factory, DataGridView dgv, string chair_name)
        {
            foreach (var i in factory.Staff.GetStaffByChair(chair_name))
                dgv.Rows.Add(i.ID_Staff, i.Name, i.Lastname, i.Patronymic, i.Education, i.Phone, i.Registration, i.Pass, i.Type);
        }
        public void Select_Some_Staff(Factory factory, DataGridView dgv, bool needPass, bool needEducation, bool needPhone, bool needType, bool needRegistration)
        {
           

            foreach (var i in factory.Staff.GetTable())
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
            factory.Staff.Delete(id_staff);
        }
        public void Show_Staff_Time_Sheet(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Employee_Sheet.GetTable())
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
            foreach (var i in factory.Contract.GetTable())
            {
                dgv.Rows.Add(i.ID_Employment_Contract, i.s_name, i.Lastname, i.Patronymic, i.c_name,
                    i.Name, i.Beginn_Date, i.End_Date, i.Additional_Information);               
            }
        }
        public void Add_Staff_Contract(Factory factory, string s_name, string lastname,
                                       string patronymic, string chair, string position, string Beginn_Date, string End_Date, string a_info)
        {
            factory.Contract.Insert(s_name, lastname, patronymic,chair, position, Beginn_Date, End_Date, a_info);
        }
        public void Delete_Staff_Contract(Factory factory, string ID_Contract)
        {
            factory.Contract.Delete(ID_Contract);
        }
        #endregion
        
        #region Titles
        public void Show_Titles(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Title.GetTable())
            {
                dgv.Rows.Add(i.ID_Title, i.Name);
            }
        }
        public void Add_Title(Factory factory, string Name)
        {
            factory.Title.Insert(Name);
        }
        public void Delete_Title(Factory factory, string ID_Title)
        {
            factory.Title.Delete(ID_Title);
        }
        #endregion
        
        #region Degrees
        public void Show_Degrees(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Degree.GetTable())
            {
                dgv.Rows.Add(i.ID_Degree, i.Name);
            }
        }
        public void Add_Degree(Factory factory, string Name)
        {
            factory.Degree.Insert(Name);
        }
        public void Delete_Degree(Factory factory, string ID_Degree)
        {
            factory.Degree.Delete(ID_Degree);
        }
        #endregion
        //еще 2
        #region Staff_Titles
        public void Show_Staff_Titles(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Staff_Title.GetTable())
                dgv.Rows.Add(i.s_name, i.Lastname, i.Patronymic, i.Name, i.Date_of_assignment);
        }
        public void Add_Staff_Title() { }
        public void Delete_Staff_Title() { }

        #endregion
        //еще 2
        #region Staff_Degrees
        public void Show_Staff_Degrees(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Staff_Degree.GetTable())
                dgv.Rows.Add(i.s_name, i.Lastname, i.Patronymic, i.Name, i.Date_of_assignment);
        }
        public void Add_Staff_Degrees() { }
        public void Delete_Staff_Degrees() { }
        #endregion
        //еще 4
        #region Orders
        public void Show_Orders(Factory factory, DataGridView dgv) { }
        public void Select_Concrete_Order() { }
        public void Add_Order() { }
        public void Delete_Order() { }
        #endregion
        //Запросы готовы (еще 1 переделать)
        #region Chairs
        public void Show_Chairs(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Chair.GetTable())
                dgv.Rows.Add(i.ID_Chair, i.Name, i.Phone);
        }
        public void Select_Concrete_Chair(Factory factory, DataGridView dgv, string ID_Chair)
        {
            dgv.Rows.Add(factory.Chair.GetChair(ID_Chair).ID_Chair,
            factory.Chair.GetChair(ID_Chair).Name,
            factory.Chair.GetChair(ID_Chair).Phone);
        }
        public void Add_Chair(Factory factory, string Name, string Phone)
        {
            factory.Chair.Insert(Name, Phone);
        }
        public void Delete_Chair(Factory factory, string ID_Chair)
        {
            factory.Chair.Delete(ID_Chair);
        }
        //Переделать
        public void Update_Chair_Phone(Factory factory, string Phone, string ID_Chair)
        {
            factory.Chair.UpdatePhone(Phone, ID_Chair);
        }
        public void Show_Chair_Time_Sheet(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Time_Sheet.GetTable())
                dgv.Rows.Add(i.ID_Time_Sheet, i.ID_Chair, i.Beginn_Date, i.End_Date);
        }
        public void Add_Chair_Time_Sheet(Factory factory, string ID_Chair, string Beginn_Date, string End_Date)
        {
            factory.Time_Sheet.Insert(ID_Chair, Beginn_Date, End_Date);
        }
        public void Delete_Chair_Time_Sheet(Factory factory, string ID_Time_Sheet)
        {
            factory.Time_Sheet.Delete(ID_Time_Sheet);
        }
        #endregion
        
        #region Positions
        public void Show_Positions(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.Positions.GetTable())
                dgv.Rows.Add(i.ID_Position, i.Name);
        }
        public void Add_Position(Factory factory, string Name)
        {
            factory.Positions.Insert(Name);
        }
        public void Delete_Position(Factory factory, string ID_Position)
        {
            factory.Positions.Delete(ID_Position);
        }
        #endregion

        #region ComboBox fill
        public void Get_Positions(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.Positions.GetTable())
                comboBox.Items.Add(i.Name);
        }
        public void Get_Chairs(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.Chair.GetTable())
                comboBox.Items.Add(i.Name);
        }
        public void Get_Titles(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.Title.GetTable())
                comboBox.Items.Add(i.Name);
        }
        public void Get_Degrees(Factory factory, ComboBox comboBox)
        {
            foreach (var i in factory.Degree.GetTable())
                comboBox.Items.Add(i.Name);
        }
        #endregion
    }
}
