using System.ComponentModel;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private StringMaterial stringMaterial;

        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, 
            string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial) 
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; private set; }

        public StringMaterial StringMaterial
        {
            get { return this.stringMaterial; }
            set
            {
                if (value == StringMaterial.Steel || value == StringMaterial.Brass ||
                    value == StringMaterial.Bronze || value == StringMaterial.Nylon)
                {
                    this.stringMaterial = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException(
                        "Strings can be made of one of the following materials: steel, brass, bronze, or nylon");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder acousticGuitar = new StringBuilder(base.ToString());
            acousticGuitar.AppendFormat("\nCase included: {0}", this.CaseIncluded ? "yes" : "no");
            acousticGuitar.AppendFormat("\nString material: {0}", this.StringMaterial);

            return acousticGuitar.ToString();
        }
    }
}
