using System.Text;
using Estates.Interfaces;
using System;

namespace Estates.Data.Estates
{
    public class House : Estate, IHouse
    {
        private int floors;

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if (value < 0 || 10 < value)
                {
                    throw new ArgumentOutOfRangeException("Floors must be in range [0 ... 500]");
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder house = new StringBuilder(base.ToString());
            house.Append(", Floors: " + this.Floors);
            return house.ToString();
        }
    }
}
