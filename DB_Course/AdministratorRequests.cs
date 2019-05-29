using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using DB_Course.Repos;

namespace DB_Course
{
    class AdministratorRequests
    {
        public void Title_Output(Factory f, DataGridView dgv)
        {
            foreach (var i in f.RepositoryTitle.GetTable())
            {
                dgv.Rows.Add(i.ID_Title,i.Name);
            }
        }
    }
}
