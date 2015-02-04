using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Multimedia_Shop.Exceptions
{
    public class InsufficientSuppliesException : ApplicationException
    {
        public InsufficientSuppliesException()
        {
            Console.WriteLine("Insufficient supplies Exception!");
        }
        public InsufficientSuppliesException(string message)
            : base (message)
        {
        }
        public InsufficientSuppliesException(string message, Exception inner)
            : base (message, inner)
        {
        }
    }
}
