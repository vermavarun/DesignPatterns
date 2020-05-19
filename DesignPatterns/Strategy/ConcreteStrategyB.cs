using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithim(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }
}
