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
                    "select * from contract_display;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    contract = new Contract(
                        dbDataRecord["ID_Contract"].ToString(),
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["c_name"].ToString(),
                        dbDataRecord["Name"].ToString(),
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
                    " where \"ID_Contract\" = @ID_Contract;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Contract", Convert.ToInt32(ID_Employment_Contract));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
        public void Insert(
            string s_name,
            string lastname,
            string patrinymic,
            string chair,
            string position,
            string begin_date,
            string End_Date,
            string a_info)
        {
            try
            {
                string QueryString =
                    "select add_contract (@s_name, @LastName, @Patronymic, @c_name, @Name, @Beginn_Date, @End_Date, @Additional_information);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@s_name", s_name);
                Command.Parameters.AddWithValue("@LastName", lastname);
                Command.Parameters.AddWithValue("@Patronymic", patrinymic);
                Command.Parameters.AddWithValue("@c_name", chair);
                Command.Parameters.AddWithValue("@Name", position);
                Command.Parameters.AddWithValue("@Beginn_Date", begin_date);
                Command.Parameters.AddWithValue("@End_Date", End_Date);
                Command.Parameters.AddWithValue("@Additional_information", a_info);

                try
                {
                    Command.ExecuteNonQuery();
                }
                catch(PostgresException ex)
                {
                    MessageBox.Show("Проверьте корректность ввода.\n Возможно, сотрудник уже совмещает две должности");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте корректность ввода.\n Возможно, сотрудник уже совмещает две должности");
            }
        }

        public List<Contract> GetContract(string s_name, string lastname, string patronymic)
        {
            Contract contract;
            List<Contract> contracts = new List<Contract>();
            MessageBox.Show(s_name +' '+ lastname + ' ' + patronymic);
            try
            {
                string QueryString =
                    "select * from contract_display" +
                    "where \"s_name\" = '" + s_name + "'"+ //"%" +
                    " and \"LastName\" = '"+ lastname + "'" +//"%" +
                    " and \"Patronymic\" = '" + patronymic + "'" + ";"; //???????????????
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    contract = new Contract(
                        dbDataRecord["ID_Contract"].ToString(),
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["c_name"].ToString(),
                        dbDataRecord["Name"].ToString(),
                        dbDataRecord["Beginn_Date"].ToString(),
                        dbDataRecord["End_Date"].ToString(),
                        dbDataRecord["Additional_information"].ToString());
                    contracts.Add(contract);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return contracts;
        }

    }
}
