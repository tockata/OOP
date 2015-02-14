using System;

namespace StringDisperser
{
    class StringDisperserTest
    {
        static void Main()
        {
            StringDisperser sd1 = new StringDisperser("gosho", "pesho", "tanio");
            StringDisperser sd2 = new StringDisperser("Gosho", "pesho", "tanio");

            Console.WriteLine("sd1.Equals(sd2): " + sd1.Equals(sd2) + "\n");
            Console.WriteLine("sd1.GetHashCode(): " + sd1.GetHashCode() + "\n");

            Console.WriteLine("sd1 == sd2: {0}", sd1 == sd2);
            Console.WriteLine("sd1 != sd2: {0}", sd1 != sd2);
            Console.WriteLine();

            StringDisperser cloning = (StringDisperser)sd1.Clone();
            Console.WriteLine("cloning of sd1: " + cloning);
            cloning.AddCharacters("TODOR");
            Console.WriteLine("cloning: " + cloning);
            Console.WriteLine("sd1: " + sd1);
            Console.WriteLine();

            Console.WriteLine("sd1.CompareTo(sd2): " + sd1.CompareTo(sd2));
            Console.WriteLine("sd1.CompareTo(cloning): " + sd1.CompareTo(cloning));
            Console.WriteLine();

            Console.WriteLine("IEnumerable implementation: ");
            foreach (var ch in sd1)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
        }
    }
}
