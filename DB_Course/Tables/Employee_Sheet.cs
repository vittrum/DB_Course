namespace DB_Course.Tables
{
    class Employee_Sheet
    {
        public string ID_Employee_Sheet { private set; get; }
        public string ID_Time_Sheet { private set; get; }
        public string ID_Staff { private set; get; }
        public string Number_of_work_days { private set; get; }
        public string Number_of_day_offs { private set; get; }
        public string Number_of_vacation_days { private set; get; }

        public Employee_Sheet () { }

        public Employee_Sheet(
            string ID_Employee_Sheet,
            string ID_Time_Sheet,
            string ID_Staff,
            string Number_of_work_days,
            string Number_of_day_offs,
            string Number_of_vacation_days)
        {
            this.ID_Employee_Sheet = ID_Employee_Sheet;
            this.ID_Staff = ID_Staff;
            this.ID_Time_Sheet = ID_Time_Sheet;
            this.Number_of_day_offs = Number_of_day_offs;
            this.Number_of_vacation_days = Number_of_vacation_days;
            this.Number_of_work_days = Number_of_work_days;
        }
    }
}
