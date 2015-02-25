using System.Text;
using MusicShopManager.Interfaces;
using System;

namespace MusicShopManager.Models
{
    public abstract class Article : IArticle
    {
        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get { return this.make; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The make is required.");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model is required.");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price must be positive.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder article = new StringBuilder();
            article.AppendFormat("= {0} {1} =", this.Make, this.Model);
            article.AppendFormat("\nPrice: ${0:F2}", this.Price);

            return article.ToString();
        }
    }
}
