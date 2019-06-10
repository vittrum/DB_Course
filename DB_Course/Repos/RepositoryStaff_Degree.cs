using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;
using DB_Course.Tables;

namespace DB_Course.Repos
{
    class RepositoryStaff_Degree
    {
        private SqlConnection sqlConnection;
        public RepositoryStaff_Degree(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Staff_Degree> GetTable()
        {
            Staff_Degree staff_degree;
            List<Staff_Degree> staff_degrees = new List<Staff_Degree>();
            try
            {
                string QueryString =
                    "select staff.s_name, staff.\"LastName\", staff.\"Patronymic\", \"Degree\".\"Name\", \"Staff_Degree\".\"Date_of_assignment\" " +
                        "from staff, \"Degree\", \"Staff_Degree\" " +
                        "where staff.\"ID_Staff\" = \"Staff_Degree\".\"ID_Staff\" " +
                        "and \"Degree\".\"ID_Degree\" = \"Staff_Degree\".\"ID_Degree\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    staff_degree = new Staff_Degree(
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["Lastname"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Name"].ToString(),
                        dbDataRecord["Date_of_assignment"].ToString());
                    staff_degrees.Add(staff_degree);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return staff_degrees;
        }

        public void Add(string s_name, string LastName, string Patronymic, string name, string date)
        {
            try
            {
                string QueryString =
                    "select add_staff_degree(@s_name, @LastName, @Patronymic, @name, @date);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@s_name", s_name); 
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@Patronymic", Patronymic);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@date", date);

                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show("Ошибка на уровне базы данных. \n Проверьте корректность введенных данных");
                }
            }
            catch { MessageBox.Show("Ошибка выполнения операции"); }
        }
        public void Delete(string s_name, string LastName, string Patronymic, string name, string date)
        {
            try
            {
                string QueryString =
                    "select delete_staff_degree(@s_name, @LastName, @Patronymic, @name, @date);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@s_name", s_name);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@Patronymic", Patronymic);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@date", date);

                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (PostgresException e)
                {
                    MessageBox.Show("Ошибка выполнения операции");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка выполнения операции");
            }
        }
    }
}
