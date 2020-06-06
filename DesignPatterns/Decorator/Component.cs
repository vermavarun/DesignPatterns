using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    // The base Component interface defines operations that can be altered by
    // decorators.
    public abstract class Component
    {
        public abstract string Operation();
    }
}
