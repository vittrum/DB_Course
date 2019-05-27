using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Course.Repos;
using Npgsql;
namespace DB_Course
{
    class Factory : IDisposable
    {
        public NpgsqlConnection NpgsqlConnection;
        public SqlConnection SqlConnection;
        public RepositoryBusiness_Trip RepositoryBusiness_Trip
        {
            get => RepositoryBusiness_Trip;
            private set => RepositoryBusiness_Trip = value;
        }
        public RepositoryChair RepositoryChair
        {
            get => RepositoryChair;
            private set => RepositoryChair = value;
        }
        public RepositoryContract RepositoryContract
        {
            get => RepositoryContract;
            private set => RepositoryContract = value;
        }
        public RepositoryDegree RepositoryDegree
        {
            get => RepositoryDegree;
            private set => RepositoryDegree = value;
        }
        public RepositoryEmployee_Sheet RepositoryEmployee_Sheet
        {
            get => RepositoryEmployee_Sheet;
            private set => RepositoryEmployee_Sheet = value;
        }
        public RepositoryOrder RepositoryOrder
        {
            get => RepositoryOrder;
            private set => RepositoryOrder = value;
        }
        public RepositoryPositions RepositoryPositions
        {
            get => RepositoryPositions;
            private set => RepositoryPositions = value;
        }
        public RepositorySick_List RepositorySick_List
        {
            get => RepositorySick_List;
            private set => RepositorySick_List = value;
        }
        public RepositoryStaff RepositoryStaff
        {
            get => RepositoryStaff;
            private set => RepositoryStaff = value;
        }
        public RepositoryStaff_Degree RepositoryStaff_Degree
        {
            get => RepositoryStaff_Degree;
            private set => RepositoryStaff_Degree = value;
        }
        public RepositoryStaff_Title RepositoryStaff_Title
        {
            get => RepositoryStaff_Title;
            set => RepositoryStaff_Title = value;
        }
        public RepositoryTime_Sheet RepositoryTime_Sheet
        {
            get => RepositoryTime_Sheet;
            set => RepositoryTime_Sheet = value;
        }
        public RepositoryTitle RepositoryTitle
        {
            get => RepositoryTitle;
            set => RepositoryTitle = value;
        }
        public RepositoryTransfer_Training RepositoryTransfer_Training
        {
            get => RepositoryTransfer_Training;
            set => RepositoryTransfer_Training = value;
        }
        public RepositoryVacations RepositoryVacations
        {
            get => RepositoryVacations;
            set => RepositoryVacations = value;
        }
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
