using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory
{
    // Concrete Products provide various implementations of the Product
    // interface.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }
}
