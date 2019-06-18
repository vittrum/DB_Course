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
    class RepositoryOrder
    {
        private SqlConnection sqlConnection;
        public RepositoryOrder(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Orders> GetTable()
        {
            Orders or;
            List<Orders> ors = new List<Orders>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"Orders\"" +
                    "order by \"ID_Order\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    or = new Orders(
                        dbDataRecord["ID_Order"].ToString(),
                        dbDataRecord["Text"].ToString(),
                        dbDataRecord["Type"].ToString());
                    ors.Add(or);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return ors;
        }
    }
}
