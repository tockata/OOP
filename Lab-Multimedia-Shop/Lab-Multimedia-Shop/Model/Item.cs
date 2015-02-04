using System.Text;
using Lab_Multimedia_Shop.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab_Multimedia_Shop.Model
{
    public abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;
        private IList<String> genres = new List<string>();

        protected Item(string id, string title, decimal price, IList<String> genres)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.Genres = genres;
        }

        protected Item(string id, string title, decimal price)
            : this(id, title, price, null)
        {
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentException("Incorrect ID!");
                }

                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Incorrect title!");
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
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public IList<string> Genres
        {
            get
            {
                return this.genres;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Genres list cannot be null!");
                }

                this.genres = value;
            }
        }

        public override string ToString()
        {
            StringBuilder item = new StringBuilder();
            item.AppendFormat("{0} {1}\n", this.GetType().Name, this.Id);
            item.AppendFormat("Title: {0}\n", this.Title);
            item.AppendFormat("Price: {0}\n", this.Price);
            item.AppendFormat("Genres:");

            foreach (var genre in this.Genres)
            {
                item.AppendFormat("{0} ", genre);
            }

            item.AppendLine();
            return item.ToString();
        }
    }
}
