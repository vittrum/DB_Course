namespace DB_Course.Tables
{
    class Business_Trip
    {
        public string ID_Order { private set; get; }

        public string s_name { private set; get; }
        public string LastName { private set; get; }
        public string Patronymic { private set; get; }
        public string Purpose_of_the_trip { private set; get; }
        public string Place_of_the_trip { private set; get; }
        public string Beginn_Date { private set; get; }
        public string End_Date { private set; get; }
        public string To_be_paid { private set; get; }

        public Business_Trip() { }

        public Business_Trip(
            string ID_Order,
            string s_name,
            string LastName,
            string Patronymic,
            string Purpose_of_the_trip,
            string Place_of_the_trip,
            string Beginn_Date,
            string End_Date,
            string To_be_paid)
        {
            this.ID_Order = ID_Order;
            this.s_name = s_name;
            this.Patronymic = Patronymic;
            this.LastName = LastName;
            this.Purpose_of_the_trip = Purpose_of_the_trip;
            this.Place_of_the_trip = Place_of_the_trip;
            this.End_Date = End_Date;
            this.Beginn_Date = Beginn_Date;
            this.To_be_paid = To_be_paid;
        }
    }
}
