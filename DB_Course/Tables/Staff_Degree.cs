using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Staff_Degree
    {
        public string ID_Staff { private set; get; }
        public string ID_Degree { private set; get; }
        public string Date_of_assignment { private set; get; }

        public Staff_Degree() { }
        public Staff_Degree(
            string ID_Staff,
            string ID_Degree,
            string Date_of_assignment)
        {
            this.ID_Degree = ID_Degree;
            this.ID_Staff = ID_Staff;
            this.Date_of_assignment = Date_of_assignment;
        }
    }
}
