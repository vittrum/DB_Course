namespace DB_Course.Tables
{
    class Sick_List
    {
        public string s_name { private set; get; }
        public string LastName { private set; get; }
        public string Patronymic { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string Cause { private set; get; }
        public string Is_paid { private set; get; }

        public Sick_List() { }
        public Sick_List(
            string s_name,
            string LastName,
            string Patronymic,
            string Beginn_Date,
            string End_Date,
            string Cause,
            string Is_paid)
        {
            this.s_name = s_name;
            this.LastName = LastName;
            this.Patronymic = Patronymic;
            this.Beginn_Date = Beginn_Date;
            this.End_Date = End_Date;
            this.Cause = Cause;
            this.Is_paid = Is_paid;
        }
    }
}
