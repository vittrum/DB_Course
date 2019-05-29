namespace DB_Course.Tables
{
    class Transfer_Training
    {
        public string ID_Transfer_Training { private set; get; }
        public string ID_Staff { private set; get; }
        public string ID_Order { private set; get; }
        public string Type { private set; get; }
        public string Last_place_of_work { private set; get; }
        public string Current_place_of_work { private set; get; }
        public string Cause { private set; get; }

        public Transfer_Training() { }
        public Transfer_Training(
            string ID_Transfer_Training,
            string ID_Staff,
            string ID_Order,
            string Type,
            string Last_place_of_work,
            string Current_place_of_work,
            string Cause)
        {
            this.ID_Transfer_Training = ID_Transfer_Training;
            this.ID_Staff = ID_Staff;
            this.ID_Order = ID_Order;
            this.Last_place_of_work = Last_place_of_work;
            this.Current_place_of_work = Current_place_of_work;
            this.Type = Type;
            this.Cause = Cause;
        }
    }
}
