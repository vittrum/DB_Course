using System;
using System.Windows.Forms;
using Npgsql;

namespace DB_Course
{
    class SqlConnection
    {
        private static SqlConnection NewConnection = null;
        public NpgsqlConnection Connection { get; }
        public SqlConnection (NpgsqlConnection Connection)
        {
            this.Connection = Connection;
        }
        public SqlConnection CreateConnection => NewConnection = new SqlConnection(Connection);
        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
