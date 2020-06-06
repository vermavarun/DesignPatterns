using Observer = DesignPatterns.Observer;
using Startegy = DesignPatterns.Strategy;
using System;
using ClientChain = DesignPatterns.ChainOfResponsibility.Client;
using DesignPatterns.Command;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;
using DesignPatterns.Memento;
using DesignPatterns.State;
using DesignPatterns.Template;
using Client = DesignPatterns.Template.Client;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Visitor;
using ClientVisitor = DesignPatterns.Visitor.Client;
using System.Collections.Generic;
using DesignPatterns.Adaptor;
using DesignPatterns.Bridge;
using ClientBridge = DesignPatterns.Bridge.Client;
using DesignPatterns.Composite;
using CompositeClass = DesignPatterns.Composite.Composite;
using ClientComposite = DesignPatterns.Composite.Client;
using DesignPatterns.Decorator;
using DesignPatterns.Facade;
using DesignPatterns.Proxy;
using DesignPatterns.Factory;
using DesignPatterns.AbstractFactory;

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
            // Memento();
            // State();
            // Template();
            // Visitor();
            // Adaptor();
            // Bridge();
            // Composite();
            // Decorator();
            // Facade();
            // Proxy();
            // Factory();
            AbstractFactory();
           // Console.ReadLine();
        }

        private static void AbstractFactory()
        {
            new ClientAbFactory().Main();
        }

        private static void Factory()
        {
            new ClientFactory().Main();
        }

        private static void Proxy()
        {
            ClientProxy client = new ClientProxy();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            DesignPatterns.Proxy.Proxy proxy = new DesignPatterns.Proxy.Proxy(realSubject);
            client.ClientCode(proxy);
        }

        private static void Facade()
        {
            // The client code may have some of the subsystem's objects already
            // created. In this case, it might be worthwhile to initialize the
            // Facade with these objects instead of letting the Facade create
            // new instances.
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            DesignPatterns.Facade.Facade facade = new DesignPatterns.Facade.Facade(subsystem1, subsystem2);
            ClientFacade.ClientCode(facade);
        }

        private static void Decorator()
        {
            ClientDecorator client = new ClientDecorator();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            // ...as well as decorated ones.
            //
            // Note how decorators can wrap not only simple components but the
            // other decorators as well.
            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
        }

        private static void Composite()
        {
            ClientComposite client = new ClientComposite();

            // This way the client code can support the simple leaf
            // components...
            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(leaf);

            // ...as well as the complex composites.
            CompositeClass tree = new CompositeClass();
            CompositeClass branch1 = new CompositeClass();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            CompositeClass branch2 = new CompositeClass();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            client.ClientCode(tree);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            client.ClientCode2(tree, leaf);
        }

        private static void Bridge()
        {
            ClientBridge client = new ClientBridge();

            Abstraction abstraction;
            // The client code should be able to work with any pre-configured
            // abstraction-implementation combination.
            abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);

            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }

        private static void Adaptor()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }

        private static void Visitor()
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitor1();
            ClientVisitor.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitor2();
            ClientVisitor.ClientCode(components, visitor2);
        }

        private static void Template()
        {
            Console.WriteLine("Same client code can work with different subclasses:");

            Client.ClientCode(new ConcreteClass1());

            Console.Write("\n");

            Console.WriteLine("Same client code can work with different subclasses:");
            Client.ClientCode(new ConcreteClass2());
        }

        private static void State()
        {
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
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
            ClientChain.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            ClientChain.ClientCode(squirrel);
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
