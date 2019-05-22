using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Sick_List
    {
        public string ID_Sick_List { private set; get; }
        public string ID_Staff { private set; get; }
        public string ID_Order { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string Cause { private set; get; }
        public string Is_paid { private set; get; }

        public Sick_List() { }
        public Sick_List(
            string ID_Sick_List,
            string ID_Staff,
            string ID_Order,
            string Beginn_Date,
            string End_Date,
            string Cause,
            string Is_paid)
        {
            this.ID_Sick_List = ID_Sick_List;
            this.ID_Staff = ID_Staff;
            this.ID_Order = ID_Order;
            this.Beginn_Date = Beginn_Date;
            this.End_Date = End_Date;
            this.Cause = Cause;
            this.Is_paid = Is_paid;
        }
    }
}
