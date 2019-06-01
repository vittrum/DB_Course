using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data;
using DB_Course.Repos;
using System.Diagnostics.Contracts; 

namespace DB_Course
{
    class AdministratorRequests
    {
        
        #region Staff requests
        
        public void Insert_Staff(Factory factory, string name, string lastname, string patronymic, string education,
                                string phone, string registration, string pass, string type)
        {
            /*Contract.ContractFailed += (sender, e) =>
            {
                MessageBox.Show(e.Message);
                e.SetHandled();
            };
            Contract.Requires(name.GetType() != typeof(string));
            Contract.Requires(lastname.GetType() != typeof(string));*/
            
            factory.RepositoryStaff.Insert(name, lastname, patronymic, education, phone, registration, pass, type);
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
        public void SelectSomeStaff(Factory factory, DataGridView dgv, 
            bool needPass, bool needEducation, bool needPhone, bool needType, bool needRegistration)
        {
            /*dgv.Columns.Add("ID", "Номер");
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
                DataGridViewRow current_row = new DataGridViewRow();
                //dgv.Rows.Add(current_row);
                dgv.Rows.Add(i.ID_Staff, i.Name, i.Lastname, i.Patronymic);//, i.Education, i.Phone, i.Registration, i.Pass, i.Type);
                if (needEducation)
                    dgv. .Add(i.Education);
                if (needPhone)
                    dgv.Rows.Add(i.Phone);
                if (needRegistration)
                    dgv.Rows.Add(i.Registration);
                if (needPass)
                    dgv.Rows.Add(i.Pass);
                if (needType)
                    dgv.Rows.Add(i.Type);*/
                //Еще нужно доделать
            //}
        }
        public void Delete_Staff(Factory factory, string id_staff)
        {
            factory.RepositoryStaff.Delete(id_staff);
        }
        #endregion
        public void Title_Output(Factory factory, DataGridView dgv)
        {
            foreach (var i in factory.RepositoryTitle.GetTable())
            {
                dgv.Rows.Add(i.ID_Title, i.Name);
            }
        }
    }
}
