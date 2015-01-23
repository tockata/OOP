using System;

namespace _01_Defining_Classes_Homework
{
    class PersonMain
    {
        static void Main(string[] args)
        {
            Person a = new Person("Pesho Goshev", 25);
            Person b = new Person("Penka Georgieva", 34, "penka@abv.bg");

            Console.WriteLine(a);
            Console.WriteLine(b);

            //a.Name = ""; //this will throw exception
            //b.Age = 102; //this will throw exception
            //b.Email = "penkaAtabv.bg"; //this will throw exceptions
        }
    }
}
