using System.Text;
using MusicShopManager.Interfaces;
using System;

namespace MusicShopManager.Models
{
    public class Drum : Instrument, IDrums
    {
        private int width;
        private int height;

        public Drum(string make, string model, decimal price, string color, int width, int height) 
            : base(make, model, price, color)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width must be positive.");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height must be positive.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder drum = new StringBuilder(base.ToString());
            drum.AppendFormat("\nSize: {0}cm x {1}cm", this.Width, this.Height);

            return drum.ToString();
        }
    }
}
