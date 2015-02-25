using System.Text;
using MusicShopManager.Interfaces;
using System;

namespace MusicShopManager.Models
{
    public abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerboardWood;
        protected int numberOfStrings = 6;

        protected Guitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood) 
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The BodyWood is required.");
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The FingerBoardWood is required.");
                }

                this.fingerboardWood = value;
            }
        }

        public int NumberOfStrings
        {
            get { return this.numberOfStrings; }
        }

        public override string ToString()
        {
            StringBuilder guitar = new StringBuilder(base.ToString());
            guitar.AppendFormat("\nStrings: {0}", this.NumberOfStrings);
            guitar.AppendFormat("\nBody wood: {0}", this.BodyWood);
            guitar.AppendFormat("\nFingerboard wood: {0}", this.FingerboardWood);

            return guitar.ToString();
        }
    }
}
