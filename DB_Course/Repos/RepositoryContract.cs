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
    class RepositoryContract
    {
        private SqlConnection sqlConnection;
        public RepositoryContract(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
    }
}
