namespace DB_Course.Tables
{
    class Orders
    {
        public string ID_Order { private set; get; }
        public string Type { private set; get; }
        public string Text { private set; get; }

        public Orders () { }

        public Orders(
            string ID_Order,
            string Type,
            string Text)
        {
            this.ID_Order = ID_Order;
            this.Type = Type;
            this.Text = Text;
        }
    }
}
