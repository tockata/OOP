using System;
using System.Collections.Generic;

namespace Customer
{
    public class Test
    {
        static void Main()
        {
            Payment p1 = new Payment("Coffee", 2.53m);
            Payment p2 = new Payment("Tea", 1.41m);
            Payment p3 = new Payment("Beer", 3.78m);
            Payment p4 = new Payment("Cheese", 6.33m);
            Payment p5 = new Payment("Bread", 1.02m);

            IList<Payment> payments1 = new List<Payment> {p1, p2};
            IList<Payment> payments2 = new List<Payment> { p1, p2 };
            IList<Payment> payments3 = new List<Payment> { p2, p3, p4, p5 };
            IList<Payment> payments4 = new List<Payment> { p3, p4 };
            IList<Payment> payments5 = new List<Payment> { p4, p5 };

            Customer pesho = new Customer("Petar", "Dimitrov", "Petrov", 6005121315, "Sofia", "0888-888888",
                "pesho.abv.bg", payments1, CustomerType.Diamond);
            Customer gosho1 = new Customer("Georgi", "Mihajlov", "Georgiev", 7510124567, "Plovdiv", "0777-777777",
                "gosho.abv.bg", payments3, CustomerType.Golden);
            Customer gosho2 = new Customer("Georgi", "Mihajlov", "Georgiev", 7510124567, "Plovdiv", "0777-777777",
                "gosho.abv.bg", payments3, CustomerType.Golden);
            Customer gosho3 = new Customer("Georgi", "Mihajlov", "Georgiev", 6510124567, "Plovdiv", "0777-777777",
                "gosho.abv.bg", payments3, CustomerType.Golden);
            Customer misho = new Customer("Mihail", "Todorov", "Todorov", 5512024567, "Ruse", "0666-666666",
                "email.abv.bg", payments4, CustomerType.OneTime);

            IList<Customer> customers = new List<Customer>
            {
                pesho, gosho1, gosho2, gosho3, misho
            };

            Console.WriteLine("Print HashCodes:");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.GetHashCode());
            }
            Console.WriteLine();

            Console.WriteLine("Print equalities: ");
            Console.WriteLine(pesho.Equals(gosho1));
            Console.WriteLine(pesho == gosho1);
            Console.WriteLine(gosho1 == gosho2);
            Console.WriteLine(gosho1 != gosho3);
            Console.WriteLine();

            Console.WriteLine("Prnt cloning:");
            Customer cloning = (Customer)pesho.Clone();
            Console.WriteLine("cloning == pesho? {0}", cloning == pesho);
            Console.WriteLine("Cloning:\n" + cloning);
            Console.WriteLine("Pesho:\n" + pesho);
            cloning.FirstName = "Joro";
            Console.WriteLine("Cloning after changing first name:\n" + cloning);
            Console.WriteLine("Pesho:\n" + pesho);

            Console.WriteLine("Compare to:");
            Console.WriteLine("gosho1 compareTo gosho2: {0}", gosho1.CompareTo(gosho2));
            Console.WriteLine("gosho1 compareTo gosho3: {0}", gosho1.CompareTo(gosho3));
            Console.WriteLine("gosho3 compareTo gosho1: {0}", gosho3.CompareTo(gosho1));
        }
    }
}
