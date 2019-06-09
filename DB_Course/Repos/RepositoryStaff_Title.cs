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
    class RepositoryStaff_Title
    {
        private SqlConnection sqlConnection;
        public RepositoryStaff_Title(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Staff_Title> GetTable()
        {
            Staff_Title staff_title;
            List<Staff_Title> staff_titles = new List<Staff_Title>();
            try
            {
                string QueryString =
                    "select staff.s_name, staff.\"LastName\", staff.\"Patronymic\", \"Titles\".\"Name\", \"Staff_Title\".\"Date_of_assignment\" " +
                        "from staff, \"Titles\", \"Staff_Title\" " +
                        "where staff.\"ID_Staff\" = \"Staff_Title\".\"ID_Staff\" " +
                        "and \"Titles\".\"ID_Title\" = \"Staff_Title\".\"ID_Title\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    staff_title = new Staff_Title(
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["Lastname"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Name"].ToString(),
                        dbDataRecord["Date_of_assignment"].ToString());
                    staff_titles.Add(staff_title);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return staff_titles;
        }

        public void Add(string s_name, string LastName, string Patronymic, string name, string date)
        {
            try
            {
                string QueryString =
                    "select add_staff_title(@s_name, @LastName, @Patronymic, @name, @date);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@s_name", s_name);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@Patronymic", Patronymic);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@date", date);

                try { Command.ExecuteNonQuery(); }
                catch (PostgresException ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void Delete(string s_name, string LastName, string Patronymic, string name, string date)
        {
            try
            {
                string QueryString =
                    "select delete_staff_title(@s_name, @LastName, @Patronymic, @name, @date);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@s_name", s_name);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@Patronymic", Patronymic);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@date", date);

                try { Command.ExecuteNonQuery(); }
                catch (PostgresException ex) { MessageBox.Show(ex.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
