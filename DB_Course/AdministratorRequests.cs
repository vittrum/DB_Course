using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
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
            Contract.ContractFailed += (sender, e) =>
            {
                MessageBox.Show(e.Message);
                e.SetHandled();
            };
            Contract.Requires(name.GetType() != typeof(string));
            Contract.Requires(lastname.GetType() != typeof(string));
            
            factory.RepositoryStaff.Insert(name, lastname, patronymic, education, phone, registration, pass, type);
        }
        public void Select_All_Staff(Factory factory, DataGridView dgv, string selectString)
        {
            // to do
        }
        public void Delete_Staff(Factory factory)
        {
            // to do
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
