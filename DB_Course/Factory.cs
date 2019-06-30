using System;
using DB_Course.Repos;
using Npgsql;
namespace DB_Course
{
    class Factory : IDisposable
    {
        public NpgsqlConnection NpgsqlConnection;
        public SqlConnection SqlConnection;

        public Login log { private get; set; }
        public Login login => log;
        public Registration reg { private get; set; }
        public Registration registration => reg;
        public RepositoryBusiness_Trip RepositoryBusiness_Trip { private get; set; }
        public RepositoryBusiness_Trip Business_Trip => RepositoryBusiness_Trip;
        public RepositoryChair RepositoryChair { private get; set; }
        public RepositoryChair Chair => RepositoryChair;
        public RepositoryContract RepositoryContract { private get; set; }
        public RepositoryContract Contract => RepositoryContract;
        public RepositoryDegree RepositoryDegree { private get; set; }
        public RepositoryDegree Degree => RepositoryDegree;
        public RepositoryEmployee_Sheet RepositoryEmployee_Sheet { private get; set; }
        public RepositoryEmployee_Sheet Employee_Sheet => RepositoryEmployee_Sheet;
        public RepositoryOrder RepositoryOrder { private get; set; }
        public RepositoryOrder Order => RepositoryOrder;
        public RepositoryPositions RepositoryPositions { private get; set; }
        public RepositoryPositions Positions => RepositoryPositions;
        public RepositorySick_List RepositorySick_List { private get; set; }
        public RepositorySick_List Sick_List => RepositorySick_List;
        public RepositoryStaff RepositoryStaff { private get; set; }
        public RepositoryStaff Staff => RepositoryStaff;
        public RepositoryStaff_Degree RepositoryStaff_Degree { private get; set; }
        public RepositoryStaff_Degree Staff_Degree => RepositoryStaff_Degree;
        public RepositoryStaff_Title RepositoryStaff_Title { private get; set; }
        public RepositoryStaff_Title Staff_Title => RepositoryStaff_Title;
        public RepositoryTime_Sheet RepositoryTime_Sheet { private get; set; }
        public RepositoryTime_Sheet Time_Sheet => RepositoryTime_Sheet;
        public RepositoryTitle RepositoryTitle { private get; set; }
        public RepositoryTitle Title => RepositoryTitle;        
        //public RepositoryTransfer_Training RepositoryTransfer_Training { private get; set; }
        //public RepositoryTransfer_Training Transfer_Training => RepositoryTransfer_Training;
        public RepositoryVacations RepositoryVacations { private get; set; }
        public RepositoryVacations Vacations => RepositoryVacations;
    
        private bool Disposed = false;

        public Factory(string server, string port, string user, string pass, string dbname)
        {
            string ConnectionString = "Server=" + server + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + dbname + ";";
            NpgsqlConnection = new NpgsqlConnection(ConnectionString);
            SqlConnection = new SqlConnection(NpgsqlConnection);
            OpenConnection();
            RepositoryBusiness_Trip = new RepositoryBusiness_Trip(SqlConnection);
            RepositoryChair = new RepositoryChair(SqlConnection);
            RepositoryContract = new RepositoryContract(SqlConnection);
            RepositoryDegree = new RepositoryDegree(SqlConnection);
            RepositoryEmployee_Sheet = new RepositoryEmployee_Sheet(SqlConnection);
            RepositoryOrder = new RepositoryOrder(SqlConnection);
            RepositoryPositions = new RepositoryPositions(SqlConnection);
            RepositorySick_List = new RepositorySick_List(SqlConnection);
            RepositoryStaff = new RepositoryStaff(SqlConnection);
            RepositoryStaff_Degree = new RepositoryStaff_Degree(SqlConnection);
            RepositoryStaff_Title = new RepositoryStaff_Title(SqlConnection);
            RepositoryTime_Sheet = new RepositoryTime_Sheet(SqlConnection);
            RepositoryTitle = new RepositoryTitle(SqlConnection);
            //RepositoryTransfer_Training = new RepositoryTransfer_Training(SqlConnection);
            RepositoryVacations = new RepositoryVacations(SqlConnection);
            reg = new Registration(SqlConnection);
            log = new Login(SqlConnection);
        }

        public void OpenConnection()
        {
            SqlConnection.Connection.Open();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    SqlConnection.Connection.Close();
                }
                Disposed = true;
            }
        }
        ~Factory()
        {
            Dispose(false);
        }

    }
}
