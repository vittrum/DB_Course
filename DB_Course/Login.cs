using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;

namespace DB_Course
{
    class Login
    {
        private SqlConnection sqlConnection;
        public Login(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public string Check_Role()
        {
            string _role = "kaboom";
            try
            {
                string QueryString =
                        "select session_user;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    _role = dbDataRecord["session_user"].ToString();
                }
                dataReader.Close();
                MessageBox.Show(_role + "is now");
            }
            
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return _role;
        }
    }
}
