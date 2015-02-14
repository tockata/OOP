using System;
using System.Globalization;

namespace Customer
{
    public class Payment : IComparable<Payment>
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int CompareTo(Payment other)
        {
            if (!this.ProductName.Equals(other.ProductName))
            {
                return String.Compare(this.ProductName, other.ProductName, true, CultureInfo.CurrentCulture);
            }

            if (this.Price > other.Price)
            {
                return 1;
            }

            if (this.Price < other.Price)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return "Product name: " + this.ProductName + ", price: " + this.Price;
        }
    }
}
