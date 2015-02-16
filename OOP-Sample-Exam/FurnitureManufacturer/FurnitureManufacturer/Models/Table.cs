using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, ITable
    {
        private readonly decimal length;
        private readonly decimal width;
        private decimal area;

        public Table(string model, string material, decimal price, decimal height,
            decimal length, decimal width) 
            : base(model, material, price, height)
        {
            this.length = length;
            this.width = width;
        }

        public decimal Length
        {
            get { return this.length; }
        }

        public decimal Width
        {
            get { return this.width; }
        }

        public decimal Area
        {
            get { return this.length * this.width; }
        }

        public override string ToString()
        {
            StringBuilder table = new StringBuilder(base.ToString());
            table.AppendFormat(", Length: {0}, Width: {1}, Area: {2}",
                this.Length, this.Width, this.Area);

            return table.ToString();
        }
    }
}
