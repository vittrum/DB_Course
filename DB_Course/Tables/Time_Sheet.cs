using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Time_Sheet
    {
        public string ID_Time_Sheet { private set; get; }
        public string ID_Chair { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }

        public Time_Sheet() { }
        public Time_Sheet(
            string ID_Time_Sheet,
            string ID_Chair,
            string Beginn_Date,
            string End_Date)
        {
            this.Beginn_Date = Beginn_Date;
            this.End_Date = End_Date;
            this.ID_Chair = ID_Chair;
            this.ID_Time_Sheet = ID_Time_Sheet;
        }
    }
}
