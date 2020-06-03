using Observer = DesignPatterns.Observer;
using Startegy = DesignPatterns.Strategy;
using System;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Command;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strategy();
            // Observer();
            // ChainOfResponsibility();
            Command();
           // Console.ReadLine();
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

        private static void ChainOfResponsibility()
        {
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Client.ClientCode(squirrel);
        }
        private static void Command()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
        }

    }
}
