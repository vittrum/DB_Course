using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Course.Repos;
namespace DB_Course
{
    class Factory : IDisposable
    {
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



    }
}
