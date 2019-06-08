namespace DB_Course.Tables
{
    class Staff_Degree
    {
        public string s_name { private set; get; }
        public string Lastname { private set; get; }
        public string Patronymic { private set; get; }
        public string Name { private set; get; }
        public string Date_of_assignment { private set; get; }

        public Staff_Degree() { }
        public Staff_Degree(
            string s_name,
            string Lastname,
            string Patronymic,
            string Name,
            string Date_of_assignment)
        {
            this.s_name = s_name;
            this.Lastname = Lastname;
            this.Patronymic = Patronymic;
            this.Name = Name;
            this.Date_of_assignment = Date_of_assignment;
            /*select s.s_name, s."LastName", s."Patronymic", d."Name", sd."Date_of_assignment"
from staff as s, "Degree" as d, "Staff_Degree" as sd
where s."ID_Staff" = sd."ID_Staff"
and d."ID_Degree" = sd."ID_Degree"
and s.s_name = 'Наталья'
and s."Last_Name" = ''
and s."Patronymic = ''";*/
        }
    }
}
