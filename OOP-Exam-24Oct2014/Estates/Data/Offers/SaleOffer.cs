using System.Text;
using Estates.Interfaces;
using System;

namespace Estates.Data.Offers
{
    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer(OfferType offerType)
            : base (offerType)
        {
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Sell price must be positive number");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder saleOffer = new StringBuilder(base.ToString());
            saleOffer.Append(", Price = " + this.Price);
            return saleOffer.ToString();
        }
    }
}
