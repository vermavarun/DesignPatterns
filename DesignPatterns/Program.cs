using Observer = DesignPatterns.Observer;
using Startegy = DesignPatterns.Strategy;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strategy();
            Observer();
            Console.ReadLine();
        }

        private static void Observer()
        {
            // The client code.
            var subject = new Observer.Subject();
            var observerA = new Observer.ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new Observer.ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }

        private static void Strategy()
        {
            Console.WriteLine("Strategy Starts");
            Startegy.Context context = new Startegy.Context();
            context.SetStrategy(new Startegy.ConcreteStrategyB()); // context.SetStrategy(new Startegy.ConcreteStrategyA()); for Strategy A
            context.DoSomeBusinessLogic();
            Console.WriteLine("Strategy Ends");
        }
    }
}
