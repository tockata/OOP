using System;
using Lab_Multimedia_Shop.Interfaces;
using System.Text;

namespace Lab_Multimedia_Shop.Model
{
    public class Sale : ISale
    {
        private Item item;

        public Sale(Item item, DateTime saleDate)
        {
            this.Item = item;
            this.SaleDate = saleDate;
        }

        public Sale(Item item)
            :this (item, DateTime.Now)
        {
        }

        public Item Item
        {
            get
            {
                return this.item;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Item cannot be null");
                }

                this.item = value;
            }
        }

        public DateTime SaleDate { get; set; }

        public override string ToString()
        {
            StringBuilder sale = new StringBuilder();
            sale.AppendFormat("- Sale {0}\n", this.SaleDate);
            sale.Append(this.Item);

            if (this.Item.GetType().Name == "Book")
            {
                sale.AppendFormat("Author: {0}", (this.Item as Book).Author);
            }

            if (this.Item.GetType().Name == "Video")
            {
                sale.AppendFormat("Length: {0}", (this.Item as Video).Length);
            }

            if (this.Item.GetType().Name == "Game")
            {
                sale.AppendFormat("Age Restriction: {0}", (this.Item as Game).AgeRestriction);
            }

            return sale.ToString();
        }
    }
}
