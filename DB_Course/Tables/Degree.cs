using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Degree
    {
        public string ID_Degree { private set; get; }
        public string Name { private set; get; }

        public Degree() { }

        public Degree(
            string ID_Degree,
            string Name)
        {
            this.Name = Name;
            this.ID_Degree = ID_Degree;
        }
    }
}
