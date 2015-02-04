using System;
using System.Text;
using Lab_Multimedia_Shop.Interfaces;
using Lab_Multimedia_Shop.Enums;

namespace Lab_Multimedia_Shop.Model
{
    public class Rent : IRent
    {
        private Item item;
        private RentStatus rentStatus;
        private decimal rentFine;

        public Rent(Item item, DateTime rentDate, DateTime deadLine)
        {
            this.Item = item;
            RentDate = rentDate;
            DeadLine = deadLine;
            this.RentStatus = RentStatus.Pending;
            this.RentFine = 0;
        }

        public Rent(Item item, DateTime rentDate)
            : this (item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(Item item)
            : this (item, DateTime.Now, DateTime.Now.AddDays(30))
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
                    throw new ArgumentNullException("Item cannot be null!");
                }

                this.item = value;
            }
        }

        public RentStatus RentStatus
        {
            get
            {
                return CheckRentStatus();
            }
            set
            {
                this.rentStatus = value;
            }
        }

        public decimal RentFine
        {
            get
            {
                return this.CalculateFine();
            }
            private set
            {
                this.rentFine = value;
            }
        }

        public DateTime RentDate { get; set; }

        public DateTime DeadLine { get; set; }

        public DateTime DateOfReturn { get; set; }

        public decimal CalculateFine()
        {
            decimal fine = 0;
            int days = (DateTime.Now - this.DeadLine).Days;
            if (days > 0)
            {
                fine = 0.01m * days * this.Item.Price;
            }

            return fine;
        }

        private RentStatus CheckRentStatus()
        {
            if (this.rentStatus == RentStatus.Returned)
            {
                return RentStatus.Returned;
            }
            else if (DateTime.Now <= this.DeadLine)
            {
                return RentStatus.Pending;
            }

            return RentStatus.Overdue;
        }

        public void ReturnItem()
        {
            this.DateOfReturn = DateTime.Now;
            this.RentStatus = RentStatus.Returned;
        }

        public override string ToString()
        {
            StringBuilder rent = new StringBuilder();
            rent.AppendFormat("- Rent {0}\n", this.RentStatus);
            rent.Append(this.Item);

            if (this.Item.GetType().Name == "Book")
            {
                rent.AppendFormat("Author: {0}", (this.Item as Book).Author);
            }

            if (this.Item.GetType().Name == "Video")
            {
                rent.AppendFormat("Length: {0}", (this.Item as Video).Length);
            }

            if (this.Item.GetType().Name == "Game")
            {
                rent.AppendFormat("Age Restriction: {0}", (this.Item as Game).AgeRestriction);
            }

            rent.AppendLine();
            rent.AppendFormat("Rent fine: {0:F2}", this.RentFine);

            return rent.ToString();
        }
    }
}
