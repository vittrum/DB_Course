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
        public List<Contract> GetTable()
        {
            Contract contract;
            List<Contract> business_Trips = new List<Contract>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"contract\"" +
                    "order by \"ID_Contract\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    contract = new Contract(
                        dbDataRecord["ID_Contract"].ToString(),
                        dbDataRecord["ID_Staff"].ToString(),
                        dbDataRecord["ID_Chair"].ToString(),
                        dbDataRecord["ID_Position"].ToString(),
                        dbDataRecord["Beginn_Date"].ToString(),
                        dbDataRecord["End_Date"].ToString(),
                        dbDataRecord["Additional_information"].ToString());
                    business_Trips.Add(contract);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return business_Trips;
        }
        public void Delete(string ID_Employment_Contract)
        {
            try
            {
                string QueryString =
                    "delete from \"contract\"" +
                    " where \"ID_Employment_Contract\" = @ID_Employment_Contract;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Employment_Contract", Convert.ToInt32(ID_Employment_Contract));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
        public void Insert(
            string ID_Staff,
            string ID_Chair,
            string ID_Position,
            string Beginn_Date,
            string End_Date)
        {
            try
            {
                string QueryString =
                    "insert into \"Employment_Contract\"" +
                    "(\"ID_Staff\",\"ID_Chair\",\"ID_Position\",\"Beginn_Date\",\"End_Date\")" +
                    "values (@ID_Staff, @ID_Chair, @ID_Position, @Beginn_Date, @End_Date);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Staff", ID_Staff);
                Command.Parameters.AddWithValue("@ID_Chair", ID_Chair);
                Command.Parameters.AddWithValue("@ID_Position", ID_Position);
                Command.Parameters.AddWithValue("@Beginn_Date", Beginn_Date);
                Command.Parameters.AddWithValue("@End_Date", End_Date);

                try { Command.ExecuteNonQuery(); }
                catch { MessageBox.Show("Лажа с эезекьютом"); }
            }
            catch { MessageBox.Show("Лажа с методом"); }
        }

    }
}
