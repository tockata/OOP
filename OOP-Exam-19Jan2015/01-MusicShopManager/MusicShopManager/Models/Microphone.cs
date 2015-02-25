using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; private set; }

        public override string ToString()
        {
            StringBuilder microphone = new StringBuilder(base.ToString());
            microphone.AppendFormat("\nCable: {0}", this.HasCable ? "yes" : "no");

            return microphone.ToString();
        }
    }
}
