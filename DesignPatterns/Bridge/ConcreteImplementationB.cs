using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Bridge
{
    class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform B.\n";
        }
    }
}
