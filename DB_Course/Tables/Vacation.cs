namespace DB_Course.Tables
{
    class Vacation
    {
        public string s_name { private set; get; }
        public string LastName { private set; get; }
        public string Patronymic { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string Is_Paid { private set; get; }
        public Vacation() { }
        public Vacation(
            string s_name,
            string LastName,
            string Patronymic,
            string Beginn_Date,
            string End_Date,
            string Is_Paid)
        {
            this.s_name = s_name;
            this.LastName = LastName;
            this.Patronymic = Patronymic;
            this.Is_Paid = Is_Paid;
            this.End_Date = End_Date;
            this.Beginn_Date = Beginn_Date;
        }
    }
}
