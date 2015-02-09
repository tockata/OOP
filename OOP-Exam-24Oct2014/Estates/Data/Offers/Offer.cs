using System.Text;
using Estates.Interfaces;

namespace Estates.Data.Offers
{
    public abstract class Offer : IOffer
    {
        public Offer(OfferType offerType)
        {
            this.Type = offerType;
        }

        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            StringBuilder offer = new StringBuilder();
            offer.Append(this.Type + ": Estate = ");
            offer.Append(this.Estate.Name);
            offer.Append(", Location = " + this.Estate.Location);
            return offer.ToString();
        }
    }
}
