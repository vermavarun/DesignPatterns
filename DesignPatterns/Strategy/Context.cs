using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    class Context
    {
        private IStrategy _strategy;
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public Context()
        {
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Console.WriteLine($"Sorting numbers by startegy {_strategy}");
            var result= this._strategy.DoAlgorithim(new List<string> { "a", "c", "b" });

            string resultStr = string.Empty;
            foreach (var i in result as List<string>)
            {
                resultStr += i + ",";
            }
            Console.WriteLine(resultStr);
        }
    }
}
