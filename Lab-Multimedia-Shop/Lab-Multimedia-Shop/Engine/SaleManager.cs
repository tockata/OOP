using Lab_Multimedia_Shop.Interfaces;
using System.Collections.Generic;

namespace Lab_Multimedia_Shop.Engine
{
    public static class SaleManager
    {
        private static ISet<ISale> sales = new HashSet<ISale>();

        public static ISet<ISale> Sales
        {
            get
            {
                return new HashSet<ISale>(sales);
            }
        }

        public static void AddSale(ISale sale)
        {
            sales.Add(sale);
        }
    }
}
