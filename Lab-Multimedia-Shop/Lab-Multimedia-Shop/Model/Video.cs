using System;
using System.Collections.Generic;

namespace Lab_Multimedia_Shop.Model
{
    public class Video : Item
    {
        private int length;

        public Video(string id, string title, decimal price, int length, IList<string> genres) 
            : base(id, title, price, genres)
        {
            this.Length = length;
        }

        public Video(string id, string title, decimal price, int length, string genre)
            : this(id, title, price, length, new List<string>{genre})
        {
        }

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Movie lenght cannot be negative!");
                }

                this.length = value;
            }
        }
    }
}
