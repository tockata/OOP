using System.Text;
using MusicShopManager.Interfaces;
using System;

namespace MusicShopManager.Models
{
    public abstract class Instrument : Article, IInstrument
    {
        private string color;
        protected bool isElectronic = false;

        protected Instrument(string make, string model, decimal price, string color) 
            : base(make, model, price)
        {
            this.Color = color;
        }

        public string Color
        {
            get { return this.color; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The color is required.");
                }

                this.color = value;
            }
        }

        public bool IsElectronic
        {
            get { return this.isElectronic; }
        }

        public override string ToString()
        {
            StringBuilder instrument = new StringBuilder(base.ToString());
            instrument.AppendFormat("\nColor: {0}", this.Color);
            instrument.AppendFormat("\nElectronic: {0}", this.IsElectronic ? "yes" : "no");

            return instrument.ToString();
        }
    }
}
