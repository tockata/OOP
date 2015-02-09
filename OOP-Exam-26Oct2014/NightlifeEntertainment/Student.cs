namespace NightlifeEntertainment
{
    public class Student : Ticket
    {
        public Student(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            return base.CalculatePrice() * 0.80m;
        }
    }
}
