using System.Text;
using Estates.Interfaces;
using System;

namespace Estates.Data.Offers
{
    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer(OfferType offerType) 
            : base(offerType)
        {
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Rent price per month must be positive number");
                }

                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            StringBuilder rentOffer = new StringBuilder(base.ToString());
            rentOffer.Append(", Price = " + this.PricePerMonth);
            return rentOffer.ToString();
        }
    }
}
