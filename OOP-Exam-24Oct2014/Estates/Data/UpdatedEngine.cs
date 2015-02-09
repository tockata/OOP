using System.Linq;
using Estates.Data.Offers;
using Estates.Engine;
using Estates.Interfaces;

namespace Estates.Data
{
    class UpdatedEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocation(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByMinAndMaxPrice(cmdArgs[0], cmdArgs[1]);
                default: return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByMinAndMaxPrice(string minPrice, string maxPrice)
        {
            decimal minP = decimal.Parse(minPrice);
            decimal maxP = decimal.Parse(maxPrice);

            var offers = this.Offers
                .Where(o => o.Type == OfferType.Rent)
                .Where(o => ((RentOffer)o).PricePerMonth >= minP &&
                    ((RentOffer)o).PricePerMonth <= maxP)
                .OrderBy(o => ((RentOffer)o).PricePerMonth)
                .ThenBy(o => ((RentOffer)o).Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocation(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}
