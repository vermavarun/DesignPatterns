using DesignPatterns.Strategy;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy Starts");

            
            Context context = new Context();
            context.SetStrategy(new ConcreteStrategyB()); // context.SetStrategy(new ConcreteStrategyA()); for Strategy A
            context.DoSomeBusinessLogic();
            Console.WriteLine("Strategy Ends");
        }
    }
}
