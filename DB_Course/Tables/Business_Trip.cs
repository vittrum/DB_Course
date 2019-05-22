using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Business_Trip
    {
        public string ID_Business_Trip { private set; get; }
        public string ID_Staff { private set; get; }
        public string ID_Order { private set; get; }
        public string Purpose_of_the_trip { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string To_be_paid { private set; get; }

        public Business_Trip() { }

        public Business_Trip(
            string ID_Business_Trip,
            string ID_Staff,
            string ID_Order,
            string Purpose_of_the_trip,
            string Beginn_Date,
            string End_Date,
            string To_be_paid)
        {
            this.ID_Business_Trip = ID_Business_Trip;
            this.ID_Order = ID_Order;
            this.ID_Staff = ID_Staff;
            this.Purpose_of_the_trip = Purpose_of_the_trip;
            this.End_Date = End_Date;
            this.Beginn_Date = Beginn_Date;
            this.To_be_paid = To_be_paid;
        }
    }
}
