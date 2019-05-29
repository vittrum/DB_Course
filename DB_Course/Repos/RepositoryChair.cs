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
    class RepositoryChair
    {
        private SqlConnection sqlConnection;
        public RepositoryChair(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Chair> GetTable()
        {
            Chair chair;
            List<Chair> chairs = new List<Chair>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"chair\"" +
                    "order by \"ID_Chair\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    chair = new Chair(
                        dbDataRecord["ID_Chair"].ToString(),
                        dbDataRecord["c_name"].ToString(),
                        dbDataRecord["Phone"].ToString());
                    chairs.Add(chair);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return chairs;
        }
        public void Delete(string ID_Chair)
        {
            try
            {
                string QueryString =
                    "delete from \"chair\"" +
                    " where \"ID_Chair\" = @ID_Chair;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Chair", Convert.ToInt32(ID_Chair));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
    }
}
