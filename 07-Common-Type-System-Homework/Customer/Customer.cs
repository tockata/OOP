using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private long id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private IList<Payment> payments;
        private CustomerType customerType;

        public Customer(string firstName, string middleName, string lastName, long id,
            string permanentAddress, string mobilePhone, string email, IList<Payment> payments,
            CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public CustomerType CustomerType
        {
            get { return this.customerType; }
            set { this.customerType = value; }
        }

        public IList<Payment> Payments
        {
            get { return this.payments; }
            set { this.payments = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set { this.mobilePhone = value; }
        }


        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set { this.permanentAddress = value; }
        }

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public override bool Equals(object other)
        {
            Customer customer = other as Customer;
            if (customer == null)
            {
                return false;
            }

            bool isFirstNameEqual = object.Equals(this.FirstName, customer.FirstName);
            bool isMiddleNameEqual = object.Equals(this.MiddleName, customer.MiddleName);
            bool isLastNameEqual = object.Equals(this.LastName, customer.LastName);
            bool isIdEqual = this.Id == customer.Id;
            bool isPermanentAddressEqual = object.Equals(this.PermanentAddress, customer.PermanentAddress);
            bool ismobilePhoneEqual = object.Equals(this.MobilePhone, customer.MobilePhone);
            bool isEmailEqual = object.Equals(this.Email, customer.Email);

            var thisPayments = this.Payments.OrderBy(p => p).ToList();
            var customerPayments = customer.Payments.OrderBy(p => p).ToList();
            bool isPaymentsEqual = thisPayments.SequenceEqual(customerPayments);

            // Second way to calculate isPaymentsEqual:
            //var diff = customerPayments.Except(thisPayments).Union(thisPayments.Except(customerPayments)).ToList();
            //bool isPaymentsEqual = diff.Count == 0;

            bool isCustomerTypeEqual = this.CustomerType.CompareTo(customer.CustomerType) == 0;

            if (!isFirstNameEqual || !isMiddleNameEqual || !isLastNameEqual || !isIdEqual ||
                !isPermanentAddressEqual || !ismobilePhoneEqual || !isEmailEqual || !isPaymentsEqual ||
                !isCustomerTypeEqual)
            {
                return false;
            }

            return true;
        }

        public static bool operator == (Customer c1, Customer c2)
        {
            return Equals(c1, c2);
        }

        public static bool operator != (Customer c1, Customer c2)
        {
            return !(Equals(c1, c2));
        }

        public override string ToString()
        {
            string customer = "";
            customer += "Name: " + this.FirstName + " ";
            customer += this.MiddleName + " ";
            customer += this.LastName + "\n";
            customer += "ID: " + this.Id + "\n";
            customer += "Permanent address: " + this.PermanentAddress + "\n";
            customer += "Mobile phoe: " + this.MobilePhone + "\n";
            customer += "Email: " + this.Email + "\n";
            customer += "Customer type: " + this.CustomerType + "\n";
            customer += "Payments:\n";

            foreach (var payment in this.Payments)
            {
                customer += payment + "\n";
            }

            return customer;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^
                this.MiddleName.GetHashCode() ^
                this.LastName.GetHashCode() ^
                this.Id.GetHashCode() ^
                this.PermanentAddress.GetHashCode() ^
                this.MobilePhone.GetHashCode() ^
                this.Email.GetHashCode() ^
                this.Payments.GetHashCode() ^
                this.CustomerType.GetHashCode();
        }

        public object Clone()
        {
            var newCustomer = new Customer(this.FirstName, this.MiddleName, this.LastName, this.Id,
                this.PermanentAddress, this.MobilePhone, this.Email, new List<Payment>(), this.CustomerType);

            foreach (var payment in this.Payments)
            {
                newCustomer.Payments.Add(new Payment(payment.ProductName, payment.Price));
            }

            return newCustomer;
        }

        public int CompareTo(Customer other)
        {
            string thisFullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string otherFullName = other.FirstName + " " + other.MiddleName + " " + other.LastName;

            if (!thisFullName.Equals(otherFullName))
            {
                return String.Compare(thisFullName, otherFullName, true, CultureInfo.CurrentCulture);
            }

            if (this.Id > other.Id)
            {
                return 1;
            }

            if (this.Id < other.Id)
            {
                return -1;
            }

            return 0;
        }
    }
}
