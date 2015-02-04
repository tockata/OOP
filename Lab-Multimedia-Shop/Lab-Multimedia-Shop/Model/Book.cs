using System;
using System.Collections.Generic;

namespace Lab_Multimedia_Shop.Model
{
    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, IList<string> genres) 
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genre)
            : this(id, title, price, author, new List<string>{genre})
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Author must be at least three symbols long!");
                }

                this.author = value;
            }
        }
    }
}
