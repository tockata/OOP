using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private readonly decimal initialHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.isConverted = false;
            this.initialHeight = height;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.height = 0.10m;

            }
            else
            {
                this.height = this.initialHeight;
            }

            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            StringBuilder convertibleChair = new StringBuilder(base.ToString());
            convertibleChair.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");

            return convertibleChair.ToString();
        }
    }
}
