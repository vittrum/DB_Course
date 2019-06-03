using System;
using System.Collections.Generic;
using DB_Course.Tables;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;

namespace DB_Course
{
    class RepositoryDegree
    {
        private SqlConnection sqlConnection;
        public RepositoryDegree(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
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
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
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
                    "delete from \"Degree\"" +
                    " where \"ID_Degree\" = @ID_Degree;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Degree", Convert.ToInt32(ID_Degree));
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
                    "insert into \"Degree\"" +
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
