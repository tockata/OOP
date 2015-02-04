using System.Collections.Generic;
using Lab_Multimedia_Shop.Interfaces;

namespace Lab_Multimedia_Shop.Engine
{
    public class RentManager
    {
        private static ISet<IRent> rents = new HashSet<IRent>();

        public static ISet<IRent> Rents
        {
            get
            {
                return new HashSet<IRent>(rents);
            }
        }

        public static void AddRent(IRent rent)
        {
            rents.Add(rent);
        }
    }
}
