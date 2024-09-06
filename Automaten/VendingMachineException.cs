using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public class VendingMachineException
    {
        public class InvalidNumberException : Exception 
        {
            public InvalidNumberException(string message): base(message) { }
        }
        public class OutOfStockException : Exception 
        {
            public OutOfStockException(string message): base(message) { }
        }
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message): base(message) { }
        }
        public class IdAlreadyExistsException : Exception
        {
            public IdAlreadyExistsException(string message) : base(message) { }
        }
    }
}
