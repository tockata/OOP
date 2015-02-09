using Estates.Interfaces;
using System;
using System.Text;

namespace Estates.Data.Estates
{
    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0 || 500 < value)
                {
                    throw new ArgumentOutOfRangeException("Width must be in range [0 ... 500]");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0 || 500 < value)
                {
                    throw new ArgumentOutOfRangeException("Height must be in range [0 ... 500]");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder garage = new StringBuilder(base.ToString());
            garage.Append(", Width: " + this.Width);
            garage.Append(", Height: " + this.Height);
            return garage.ToString();
        }
    }
}
