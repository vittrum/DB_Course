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
    class RepositoryChair
    {
        private SqlConnection sqlConnection;
        public RepositoryChair(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Chair> GetTable()
        {
            Chair chair;
            List<Chair> chairs = new List<Chair>();
            try
            {
                string QueryString =
                    "select *" +
                    "from \"chair\"" +
                    "order by \"ID_Chair\";";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    chair = new Chair(
                        dbDataRecord["ID_Chair"].ToString(),
                        dbDataRecord["c_name"].ToString(),
                        dbDataRecord["Phone"].ToString());
                    chairs.Add(chair);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return chairs;
        }
        public void Delete(string ID_Chair)
        {
            try
            {
                string QueryString =
                    "delete from \"chair\"" +
                    " where \"ID_Chair\" = @ID_Chair;";
                NpgsqlCommand Command = new NpgsqlCommand
                    (QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Chair", Convert.ToInt32(ID_Chair));
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка на уровне БД " + Convert.ToString(ex));
            }
        }
        public Chair GetChair(string ID_Chair)
          {
              Chair chair = new Chair();
              try
              {
                  string QueryString =
                      "select *" +
                      "from \"chair\"" +
                      "where \"ID_Chair\" = " + Convert.ToString(ID_Chair)+";";
                  NpgsqlCommand Command =
                      new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                  NpgsqlDataReader dataReader = Command.ExecuteReader();
                  foreach (DbDataRecord dbDataRecord in dataReader)
                  {
                      chair = new Chair(
                          dbDataRecord["ID_Chair"].ToString(),
                          dbDataRecord["c_name"].ToString(),
                          dbDataRecord["Phone"].ToString());
                  }
                  dataReader.Close();
              }
              catch (PostgresException ex)
              {
                  MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
              }
              return chair;
          }
        public void Insert(string Name, string Phone)
        {
            try
            {
                string QueryString =
                    "insert into \"chair\"" +
                    "(\"c_name\", \"Phone\")" +
                    " values (@Name, @Phone);";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@Name", Name); 
                Command.Parameters.AddWithValue("@Phone", Convert.ToInt32(Phone));

                try
                {
                    Command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка выполнения операции. \nПроверьте корректность введенных данных");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка выполнения операции." + e.Message);
            }
        }
        public void UpdatePhone(string Phone, string c_name)
        {
            try
            {
                //MessageBox.Show(c_name);
                string QueryString =
                    "update \"chair\"" +
                    "set \"Phone\" = @Phone " +
                    "where \"c_name\" = @c_name;";
                NpgsqlCommand Command = 
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@Phone", Convert.ToInt64(Phone));
                Command.Parameters.AddWithValue("@c_name", c_name);
                Command.ExecuteNonQuery();
                
            }
            catch (PostgresException e)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + e.Message);
            }

        }
        
    }
}
