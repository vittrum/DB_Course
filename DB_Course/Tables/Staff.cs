using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Course.Tables
{
    class Staff
    {
        public string ID_Staff { private set; get; }
        public string Type { private set; get; }
        public string Name { private set; get; }
        public string Lastname { private set; get; }
        public string Patronymic { private set; get; }
        public string Education { private set; get; }
        public string Phone { private set; get; }
        public string Registration { private set; get; }
        public string Pass { private set; get; }

        public Staff() { }

        public Staff(
            string ID_Staff,
            string Type,
            string Name,
            string Lastname,
            string Patronymic,
            string Education,
            string Phone,
            string Registration,
            string Pass)
        {
            this.Education = Education;
            this.ID_Staff = ID_Staff;
            this.Name = Name;
            this.Lastname = Lastname;
            this.Patronymic = Patronymic;
            this.Phone = Phone;
            this.Registration = Registration;
            this.Pass = Pass;
            this.Type = Type;
        }
    }
}
