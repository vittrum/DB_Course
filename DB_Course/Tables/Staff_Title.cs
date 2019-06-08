namespace DB_Course.Tables
{
    class Staff_Title
    {
        public string s_name { private set; get; }
        public string Lastname { private set; get; }
        public string Patronymic { private set; get; }
        public string Name { private set; get; }
        public string Date_of_assignment { private set; get; }

        public Staff_Title() { }
        public Staff_Title(
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
        }
    }
}
