using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Staff_Title
    {
        public string ID_Staff { private set; get; }
        public string ID_Title { private set; get; }
        public string Date_of_assignment { private set; get; }

        public Staff_Title() { }
        public Staff_Title(
            string ID_Staff,
            string ID_Title,
            string Date_of_assignment)
        {
            this.Date_of_assignment = Date_of_assignment;
            this.ID_Staff = ID_Staff;
            this.ID_Title = ID_Title;
        }
    }
}
