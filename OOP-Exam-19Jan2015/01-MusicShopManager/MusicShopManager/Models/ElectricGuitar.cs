using System.Text;
using MusicShopManager.Interfaces;
using System;

namespace MusicShopManager.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;
        private int numberOfFrets;
        private const bool ElectricGuitarIsElectronic = true;

        public ElectricGuitar(string make, string model, decimal price, string color, string bodyWood,
            string fingerboardWood, int numberOfAdapters, int numberOfFrets) 
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
            this.isElectronic = ElectricGuitarIsElectronic;
        }

        public int NumberOfAdapters
        {
            get { return this.numberOfAdapters; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of adapters must be non-negative.");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.numberOfFrets; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The Number of frets must be positive.");
                }

                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            StringBuilder electricGuitar = new StringBuilder(base.ToString());
            electricGuitar.AppendFormat("\nAdapters: {0}", this.NumberOfAdapters);
            electricGuitar.AppendFormat("\nFrets: {0}", this.NumberOfFrets);

            return electricGuitar.ToString();
        }
    }
}
