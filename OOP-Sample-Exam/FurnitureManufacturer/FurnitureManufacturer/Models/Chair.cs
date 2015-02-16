using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        private readonly int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
        }

        public override string ToString()
        {
            StringBuilder chair = new StringBuilder(base.ToString());
            chair.AppendFormat(", Legs: {0}", this.NumberOfLegs);

            return chair.ToString();
        }
    }
}
