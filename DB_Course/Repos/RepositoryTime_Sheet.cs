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
    class RepositoryTime_Sheet
    {
        private SqlConnection sqlConnection;
        public RepositoryTime_Sheet(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Time_Sheet> GetTable()
        {
            Time_Sheet time_sheet;
            List<Time_Sheet> time_sheets = new List<Time_Sheet>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"Time_Sheet\"" +
                    "order by \"ID_Time_Sheet\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    time_sheet = new Time_Sheet(
                        dbDataRecord["ID_Time_Sheet"].ToString(),
                        dbDataRecord["ID_Chair"].ToString(),
                        dbDataRecord["Beginn_Date"].ToString(),
                        dbDataRecord["End_Date"].ToString());
                    time_sheets.Add(time_sheet);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return time_sheets;
        }
        public void Insert(string ID_Chair, string Beginn_Date, string End_Date)
        {
            try { 
            string QueryString =
                "insert into \"Time_Sheet\"" +
                "(\"ID_Chair\", \"Beginn_Date\", \"End_Date\")" +
                "values (@ID_Chair, @Beginn_Date, @End_Date);";
            NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
            Command.Parameters.AddWithValue("@ID_Chair", ID_Chair); // Возможно нужно прописать Add Wit Value!
            Command.Parameters.AddWithValue("@Beginn_Date", Beginn_Date);
            Command.Parameters.AddWithValue("@End_Date", End_Date);
            

            try { Command.ExecuteNonQuery(); }
            catch { MessageBox.Show("Лажа с эезекьютом"); }
        }
            catch { MessageBox.Show("Лажа с методом"); }
}
        public void Delete(string ID_Time_Sheet)
        {
            try
            {
                string QueryString =
                    "delete from \"Time_Sheet\"" +
                    " where \"ID_Time_Sheet\" = @ID_Time_Sheet;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Time_Sheet", Convert.ToInt32(ID_Time_Sheet));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
    }
}
