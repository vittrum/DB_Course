using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;
using DB_Course.Tables;

namespace DB_Course.Repos
{
    class RepositorySick_List
    {
        private SqlConnection sqlConnection;
        public RepositorySick_List(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
    }
}
