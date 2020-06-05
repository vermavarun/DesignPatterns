using Observer = DesignPatterns.Observer;
using Startegy = DesignPatterns.Strategy;
using System;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Command;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;
using DesignPatterns.Memento;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strategy();
            // Observer();
            // ChainOfResponsibility();
            // Command();
            // Iterator();
            // Mediator();
            Memento();
           // Console.ReadLine();
        }

        private static void Memento()
        {
            Originator originator = new Originator("Super-duper-super-puper-super.");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine();
            caretaker.ShowHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            caretaker.Undo();

        }

        private static void Mediator()
        {
            // The client code.
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggets operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }

        private static void Iterator()
        {
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
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
