using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using DB_Course.Tables;

namespace DB_Course.Repos
{
    class RepositoryTitle
    {
        private SqlConnection sqlConnection;
        public RepositoryTitle(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Title> GetTable()
        {
            Title title;
            List<Title> titles = new List<Title>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"Titles\"" +
                    "order by \"ID_Title\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    title = new Title(
                        dbDataRecord["ID_Title"].ToString(),
                        dbDataRecord["Name"].ToString());
                    titles.Add(title);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return titles;
        }
        public void Delete(string ID_Title)
        {
            try
            {
                string QueryString =
                    "delete from \"Title\"" +
                    " where \"ID_Title\" = @ID_Title;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Title", Convert.ToInt32(ID_Title));
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
                    "insert into \"Titles\"" +
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
