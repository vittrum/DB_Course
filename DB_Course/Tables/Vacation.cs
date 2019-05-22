using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Vacation
    {
        public string ID_Staff { private set; get; }
        public string ID_Order { private set; get; }
        public string ID_Vacation { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string Is_Paid { private set; get; }
        public Vacation() { }
        public Vacation(
            string ID_Vacation,
            string ID_Staff,
            string ID_Order,
            string Beginn_Date,
            string End_Date,
            string Is_Paid)
        {
            this.ID_Vacation = ID_Vacation;
            this.ID_Staff = ID_Staff;
            this.ID_Order = ID_Order;
            this.Is_Paid = Is_Paid;
            this.End_Date = End_Date;
            this.Beginn_Date = Beginn_Date;
        }
    }
}
