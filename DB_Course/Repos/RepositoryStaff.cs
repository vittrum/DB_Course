using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;
using DB_Course.Tables;
using System.Diagnostics.Contracts;
namespace DB_Course.Repos
{
    class RepositoryStaff
    {
        private SqlConnection sqlConnection;
        public RepositoryStaff(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Staff> GetTable()
        {
            Staff staff;
            List<Staff> staffs = new List<Staff>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"staff\"" +
                    "order by \"ID_Staff\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    staff = new Staff(
                        dbDataRecord["ID_Staff"].ToString(),
                        dbDataRecord["Type"].ToString(),
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Education"].ToString(),
                        dbDataRecord["Phone"].ToString(),
                        dbDataRecord["Registration"].ToString(),
                        dbDataRecord["Pass"].ToString());
                    staffs.Add(staff);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return staffs;
        }
        public void Delete(string ID_Staff)
        {
            try
            {
                string QueryString =
                    "delete from \"staff\"" +
                    " where \"ID_Staff\" = @ID_Staff;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Staff", Convert.ToInt32(ID_Staff));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
        public void Insert(
            string Name,
            string Lastname,
            string Patronymic,
            string Education,
            string Phone,
            string Registration,
            string Pass,
            string Type)
        {
            try
            {
                string QueryString = 
                    "insert into staff" +
                    "(s_name, \"LastName\", \"Patronymic\",\"Education\",\"Phone\"," +
                    "\"Registration\",\"Pass\",\"Type\")" +
                    "values (@Name, @Lastname, @Patronymic, @Education, @Phone," +
                    "@Registration, @Pass, @Type);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@Name", Name); // Возможно нужно прописать Add Wit Value!
                Command.Parameters.AddWithValue("@LastName", Lastname);
                Command.Parameters.AddWithValue("@Patronymic", Patronymic);
                Command.Parameters.AddWithValue("@Education", Education);
                Command.Parameters.AddWithValue("@Phone", Phone);
                Command.Parameters.AddWithValue("@Registration", Registration);
                Command.Parameters.AddWithValue("@Pass", Pass);
                Command.Parameters.AddWithValue("@Type", Type);

                try { Command.ExecuteNonQuery(); }
                catch { MessageBox.Show("Лажа с эезекьютом"); }
            }
            catch { MessageBox.Show("Лажа с методом"); }

        }

        public Staff GetStaffByID(int id)
        {
            Staff staff = new Staff();
            NpgsqlCommand Command =
                    new NpgsqlCommand("select * from staff where \"ID_Staff\" = " + Convert.ToString(id)+';', sqlConnection.CreateConnection.Connection);
            NpgsqlDataReader dataReader = Command.ExecuteReader();
            foreach (DbDataRecord dbDataRecord in dataReader)
            {
                staff = new Staff(
                    dbDataRecord["ID_Staff"].ToString(),
                    dbDataRecord["Type"].ToString(),
                    dbDataRecord["s_name"].ToString(),
                    dbDataRecord["LastName"].ToString(),
                    dbDataRecord["Patronymic"].ToString(),
                    dbDataRecord["Education"].ToString(),
                    dbDataRecord["Phone"].ToString(),
                    dbDataRecord["Registration"].ToString(),
                    dbDataRecord["Pass"].ToString());
            }
            dataReader.Close();
            return staff;
        }
        
    }
}
