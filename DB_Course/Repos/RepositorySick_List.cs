﻿using System;
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
    class RepositorySick_List
    {
        private SqlConnection sqlConnection;
        public RepositorySick_List(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public List<Sick_List> GetTable()
        {
            Sick_List sl;
            List<Sick_List> sls = new List<Sick_List>();
            try
            {
                string QueryString =
                    "select * from staff_sick_list";
                NpgsqlCommand Command =
                    new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                NpgsqlDataReader dataReader = Command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in dataReader)
                {
                    sl = new Sick_List(
                        dbDataRecord["s_name"].ToString(),
                        dbDataRecord["LastName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Beginn_Date"].ToString(),
                        dbDataRecord["End_Date"].ToString(),
                        dbDataRecord["Cause"].ToString(),
                        dbDataRecord["Is_paid"].ToString());
                    sls.Add(sl);
                }
                dataReader.Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Ошибка базы данных \n" + Convert.ToString(ex));
            }
            return sls;
        }
        public void Add(string id, string bdate, string edate, string cause, string is_paid )
        {
            try
            {
                string QueryString =
                    "select add_sick_list(@ID_Staff, @Beginn_Date, @End_Date, @Cause, @is_paid);";
                NpgsqlCommand Command =
                        new NpgsqlCommand(QueryString, sqlConnection.CreateConnection.Connection);
                Command.Parameters.AddWithValue("@ID_Staff", Convert.ToInt32(id));
                Command.Parameters.AddWithValue("@Beginn_Date", bdate);
                Command.Parameters.AddWithValue("@End_Date", edate);
                Command.Parameters.AddWithValue("@Cause", cause);
                Command.Parameters.AddWithValue("@is_paid", is_paid);

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
