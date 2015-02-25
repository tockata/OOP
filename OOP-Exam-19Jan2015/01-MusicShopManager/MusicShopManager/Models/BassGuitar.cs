using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int BassGuitarnumberOfStrings = 4;
        private const bool bassGuitarIsElectronic = true;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, 
            string fingerboardWood) 
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.numberOfStrings = BassGuitarnumberOfStrings;
            this.isElectronic = bassGuitarIsElectronic;
        }
    }
}
