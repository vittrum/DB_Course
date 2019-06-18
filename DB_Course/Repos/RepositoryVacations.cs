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
    class RepositoryVacations
    {
        private SqlConnection sqlConnection;
        public RepositoryVacations(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Vacation> GetTable()
        {
            Vacation vac;
            List<Vacation> vacs = new List<Vacation>();
            try
            {
                string QueryString =
                    "select * from staff_vacation";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    vac = new Vacation(
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Beginn_Date"].ToString(),
                        dbDataRecord["End_Date"].ToString(),
                        dbDataRecord["Is_paid"].ToString());
                    vacs.Add(vac);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return vacs;
        }
    }
}
