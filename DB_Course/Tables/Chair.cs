using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Chair
    {
        public string ID_Chair { private set; get; }
        public string Name { private set; get; }
        public string Phone { private set; get; }

        public Chair() { }
        public Chair(
            string ID_Chair,
            string Name,
            string Phone)
        {
            this.ID_Chair = ID_Chair;
            this.Name = Name;
            this.Phone = Phone;
        }

    }
}
