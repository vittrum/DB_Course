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
    class RepositoryPositions
    {
        private SqlConnection sqlConnection;
        public RepositoryPositions(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Positions> GetTable()
        {
            Positions position;
            List<Positions> positions = new List<Positions>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"Positions\"" +
                    "order by \"ID_Position\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    position = new Positions(
                        dbDataRecord["ID_Position"].ToString(),
                        dbDataRecord["Name"].ToString());
                    positions.Add(position);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return positions;
        }
        public void Delete(string ID_Position)
        {

            try
            {
                string QueryString =
                    "delete from \"Positions\"" +
                    " where \"ID_Position\" = @ID_Position;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Position", Convert.ToInt32(ID_Position));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
        public void Insert(string Name)
        {
            try
            {
                string QueryString =
                    "insert into \"Positions\"" +
                    "(\"Name\")" +
                    "values (@Name);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@Name", Name); 
                try { Command.ExecuteNonQuery(); }
                catch { MessageBox.Show("Лажа с эезекьютом"); }
            }
            catch { MessageBox.Show("Лажа с методом"); }
        }
    }
}
