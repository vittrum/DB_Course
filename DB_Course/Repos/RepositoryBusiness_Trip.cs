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
    class RepositoryBusiness_Trip
    {
        private SqlConnection sqlConnection;
        public RepositoryBusiness_Trip(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Business_Trip> GetTable()
        {
            Business_Trip business_trip;
            List<Business_Trip> business_Trips = new List<Business_Trip>();
            try
            {
                string QueryString =
                    "select * from staff_business_trip;";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    business_trip = new Business_Trip(
                        dbDataRecord["ID_Order"].ToString(),
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Purpose_of_the_trip"].ToString(),
                        dbDataRecord["Place_of_the_trip"].ToString(),
                        dbDataRecord["Beginn_Date"].ToString(),
                        dbDataRecord["End_Date"].ToString(),
                        dbDataRecord["To_be_paid"].ToString());
                    business_Trips.Add(business_trip);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return business_Trips;
        }
        public void Delete(string ID_Business_Trip)
        {
            try
            {
                string QueryString =
                    "delete from \"Business_Trip\"" +
                    " where \"ID_Business_Trip\" = @ID_Business_Trip;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Business_Trip", Convert.ToInt32(ID_Business_Trip));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }

        public void Add(
            string ID_Staff,
            string begin_date,
            string End_Date,
            string type,
            string place,
            string purpose,
            string to_be_paid)
        {
            try
            {
               // MessageBox.Show('1' + End_Date + ' ' + begin_date);
                string QueryString =
                    "select add_business_trip (@ID_Staff, @Beginn_Date, @End_Date, @Type, @Place, @purpose, @to_be_paid);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@s_name", ID_Staff);
                Command.Parameters.AddWithValue("@Beginn_Date", begin_date);
                Command.Parameters.AddWithValue("@End_Date", End_Date);
                Command.Parameters.AddWithValue("@Type", type);
                Command.Parameters.AddWithValue("@Place", place);
                Command.Parameters.AddWithValue("@purpose", purpose);
                Command.Parameters.AddWithValue("@to_be_paid", Convert.ToInt32(to_be_paid));
               // MessageBox.Show('2' + End_Date +' '+ begin_date);
                try
                {
                    Command.ExecuteNonQuery();
                }
                catch (PostgresException ex)
                {
                    MessageBox.Show("Проверьте корректность ввода pg.\n" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте корректность ввода.\n " + ex.Message);
            }
        }

    }
}
