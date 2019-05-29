using System;
using DB_Course.Repos;
using Npgsql;
namespace DB_Course
{
    class Factory : IDisposable
    {
        public NpgsqlConnection NpgsqlConnection;
        public SqlConnection SqlConnection;
        public RepositoryBusiness_Trip RepositoryBusiness_Trip { get; set; }
        public RepositoryBusiness_Trip Business_Trip => RepositoryBusiness_Trip;
        public RepositoryChair RepositoryChair { get; set; }
        public RepositoryChair Chair => RepositoryChair;
        public RepositoryContract RepositoryContract { get; set; }
        public RepositoryContract Contract => RepositoryContract;
        public RepositoryDegree RepositoryDegree { get; set; }
        public RepositoryDegree Degree => RepositoryDegree;
        public RepositoryEmployee_Sheet RepositoryEmployee_Sheet { get; set; }
        public RepositoryEmployee_Sheet Employee_Sheet => RepositoryEmployee_Sheet;
        public RepositoryOrder RepositoryOrder { get; set; }
        public RepositoryOrder Order => RepositoryOrder;
        public RepositoryPositions RepositoryPositions { get; set; }
        public RepositoryPositions Positions => RepositoryPositions;
        public RepositorySick_List RepositorySick_List { get; set; }
        public RepositorySick_List Sick_List => RepositorySick_List;
        public RepositoryStaff RepositoryStaff { get; set; }
        public RepositoryStaff Staff => RepositoryStaff;
        public RepositoryStaff_Degree RepositoryStaff_Degree { get; set; }
        public RepositoryStaff_Degree Staff_Degree => RepositoryStaff_Degree;
        public RepositoryStaff_Title RepositoryStaff_Title { get; set; }
        public RepositoryStaff_Title Staff_Title => RepositoryStaff_Title;
        public RepositoryTime_Sheet RepositoryTime_Sheet { get; set; }
        public RepositoryTime_Sheet Time_Sheet => RepositoryTime_Sheet;
        public RepositoryTitle RepositoryTitle { get; set; }
        public RepositoryTitle Tiltle => RepositoryTitle;        
        public RepositoryTransfer_Training RepositoryTransfer_Training { get; set; }
        public RepositoryTransfer_Training Transfer_Training => RepositoryTransfer_Training;
        public RepositoryVacations RepositoryVacations { get; set; }
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
            RepositoryTransfer_Training = new RepositoryTransfer_Training(SqlConnection);
            RepositoryVacations = new RepositoryVacations(SqlConnection);
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
