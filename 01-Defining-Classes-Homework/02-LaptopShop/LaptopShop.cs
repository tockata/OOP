using System;

namespace _02_LaptopShop
{
    public class LaptopShop
    {
        static void Main(string[] args)
        {
            Laptop laptop1 = new Laptop("Lenovo B5400", 1400, "Lenovo", "Intel i5-4200m", 8, "Intel HD 4600", "500GB HDD",
                "15.6\"", new Battery("Li-Ion", 4500, 6), 4.5f);
            Laptop laptop2 = new Laptop("Acer Aspire", 999.99m);
            Laptop laptop3 = new Laptop("Sony Vaio", 1399, "Sony", "Intel i3-4000m");

            Console.WriteLine(laptop1);
            Console.WriteLine();
            Console.WriteLine(laptop2);
            Console.WriteLine();
            Console.WriteLine(laptop3);
        }
    }
}
