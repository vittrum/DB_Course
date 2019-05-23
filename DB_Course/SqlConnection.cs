using System;
using System.Windows.Forms;
using Npgsql;

namespace DB_Course
{
    public class SqlConnect
    {
        private static SqlConnect NewConnection = null;

        public SqlConnect(NpgsqlConnection Connection)
        {
            this.Connection = Connection;
        }

        public SqlConnect GetNewSqlConnection()
        {
            return NewConnection = new SqlConnect(Connection);
        }

        public NpgsqlConnection Connection { get; }

        public void OpenConnection()
        {
            try
            {
                Connection.Open();
                //MessageBox.Show(@"Соединение открыто!");
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }
        public void CloseConnection()
        {
            try
            {
                Connection.Close();
                //MessageBox.Show(@"Соединение закрыто!");
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }
    }
}
