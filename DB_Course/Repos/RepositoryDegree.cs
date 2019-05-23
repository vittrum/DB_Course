using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Course.Tables;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;

namespace DB_Course
{
    class RepositoryDegree
    {
        private SqlConnection sqlConnect;
        public RepositoryDegree(SqlConnection sqlConnect)
        {
            this.sqlConnect = sqlConnect;
        }
        public List<Degree> GetTable()
        {
            Degree degree;
            List<Degree> degrees = new List<Degree>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"Degree\"" +
                    "order by \"ID_Degree\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnect.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    degree = new Degree(
                        dbDataRecord["ID_Degree"].ToString(),
                        dbDataRecord["Name"].ToString());
                    degrees.Add(degree);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return degrees;
        }
        public void Delete(string ID_Degree)
        {
            try
            {
                string QueryString =
                    "delete from \"Degrees\"" +
                    " where \"ID_Degree\" = @ID_Degree;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnect.CreateConnection.Connection);

            }
        }
    }
}
