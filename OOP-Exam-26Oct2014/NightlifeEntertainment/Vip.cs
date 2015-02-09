namespace NightlifeEntertainment
{
    public class Vip : Ticket
    {
        public Vip(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            return base.CalculatePrice() * 1.5m;
        }
    }
}
