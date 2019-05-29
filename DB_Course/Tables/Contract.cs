namespace DB_Course.Tables
{
    class Contract
    {
        public string ID_Employment_Contract { private set; get; }
        public string ID_Staff { private set; get; }
        public string ID_Chair { private set; get; }
        public string ID_Position { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string Additional_Information { private set; get; }

        public Contract() { }
        public Contract(
            string ID_Employment_Contract,
            string ID_Staff,
            string ID_Chair,
            string ID_Position,
            string Beginn_Date,
            string End_Date,
            string Additional_Information)
        {
            this.ID_Chair = ID_Chair;
            this.ID_Staff = ID_Staff;
            this.ID_Employment_Contract = ID_Employment_Contract;
            this.ID_Position = ID_Position;
            this.Beginn_Date = Beginn_Date;
            this.End_Date = End_Date;
            this.Additional_Information = Additional_Information;
        }
    }
}
