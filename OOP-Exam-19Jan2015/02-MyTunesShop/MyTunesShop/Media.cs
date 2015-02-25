using System;

namespace MyTunesShop
{
    public abstract class Media : IMedia
    {
        private string title;
        private decimal price;

        protected Media(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title can not be null or empty.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price can not be negative number.");
                }

                this.price = value;
            }
        }
    }
}
