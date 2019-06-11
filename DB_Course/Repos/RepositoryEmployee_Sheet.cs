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
    class RepositoryEmployee_Sheet
    {
        private SqlConnection sqlConnection;
        public RepositoryEmployee_Sheet(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Employee_Sheet> GetTable()
        {
            Employee_Sheet employee_sheet;
            List<Employee_Sheet> employee_sheets = new List<Employee_Sheet>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"Employee_Sheet\"" +
                    "order by \"ID_Staff\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    employee_sheet = new Employee_Sheet(
                        dbDataRecord["ID_Employee_Sheet"].ToString(),
                        dbDataRecord["ID_Time_Sheet"].ToString(),
                        dbDataRecord["ID_Staff"].ToString(),
                        dbDataRecord["Number_of_work_days"].ToString(),
                        dbDataRecord["Number_of_day_offs"].ToString(),
                        dbDataRecord["Number_of_vacation_days"].ToString());
                    employee_sheets.Add(employee_sheet);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return employee_sheets;
        }
        public void Delete(string ID_Employee_Sheet)
        {
            try
            {
                string QueryString =
                    "delete from \"Employee_Sheet\"" +
                    " where \"ID_Employee_Sheet\" = @ID_Employee_Sheet;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Staff", Convert.ToInt32(ID_Employee_Sheet));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
        public void Insert(
            string ID_Time_Sheet,
            string ID_Staff,
            string Number_of_work_days,
            string Number_of_day_offs,
            string Number_of_vacation_days)
        {
            try
            {
                string QueryString =
                    "insert into \"Employee_Sheet\"" +
                    "(\"ID_Time_Sheet\", \"ID_Staff\", \"Number_of_work_days\",\"Number_of_day_offs\",\"Number_of_vacation_days\")" +
                    "values (@ID_Time_Sheet, @ID_Staff, @Number_of_work_days, @Number_of_day_offs, @Number_of_vacation_days);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Time_Sheet", Convert.ToInt32(ID_Time_Sheet)); 
                Command.Parameters.AddWithValue("@ID_Staff", Convert.ToInt32(ID_Staff));
                Command.Parameters.AddWithValue("@Number_of_work_days", Convert.ToInt32(Number_of_work_days));
                Command.Parameters.AddWithValue("@Number_of_day_offs", Convert.ToInt32(Number_of_day_offs));
                Command.Parameters.AddWithValue("@Number_of_vacation_days", Convert.ToInt32(Number_of_vacation_days));
              
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (NpgsqlException pex)
                {
                    MessageBox.Show("Ошибка базы данных" + pex.Message);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выполнения метода");
            }

        }
    }
}
