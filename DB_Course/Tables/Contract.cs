namespace DB_Course.Tables
{
    class Contract
    {
        public string ID_Employment_Contract { private set; get; }
        public string s_name { private set; get; }
        public string c_name { private set; get; }
        public string Lastname { private set; get; }
        public string Patronymic { private set; get; }
        public string Name { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string Additional_Information { private set; get; }

        public Contract() { }
        public Contract(
            string ID_Employment_Contract,
            string s_name,
            string Lastname,
            string Patronymic,
            string c_name,
            string Name,
            string Beginn_Date,
            string End_Date,
            string Additional_Information)
        {
            this.c_name = c_name;
            this.s_name = s_name;
            this.Lastname = Lastname;
            this.Patronymic = Patronymic;
            this.ID_Employment_Contract = ID_Employment_Contract;
            this.Name = Name;
            this.Beginn_Date = Beginn_Date;
            this.End_Date = End_Date;
            this.Additional_Information = Additional_Information;
        }
    }
}
