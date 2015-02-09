using System;
using System.Reflection.Emit;
using System.Text;
using Estates.Interfaces;

namespace Estates.Data.Estates
{
    public abstract class Estate : IEstate
    {
        private string name;
        private double area;
        private string location;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Estate name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public EstateType Type { get; set; }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if (value < 0 || 10000 < value)
                {
                    throw new ArgumentOutOfRangeException("Area must be in range [0 ... 10000]");
                }

                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Location cannot be null or empty!");
                }

                this.location = value;
            }
        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            StringBuilder estate = new StringBuilder();
            estate.Append(GetType().Name + ": ");
            estate.Append("Name = " + this.Name);
            estate.Append(", Area = " + this.Area);
            estate.Append(", Location = " + this.Location);
            estate.Append(", Furnitured = " + (this.IsFurnished ? "Yes" : "No"));
            return estate.ToString();
        }
    }
}
