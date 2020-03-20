using System;

namespace GOF
{
    /*
     * Wzorzec mediatora umożliwia zmniejszenie liczby powiązań między różnymi klasami, poprzez utworzenie mediatora będącego jedyną klasą,
     * która dokładnie zna metody wszystkich innych klas, którymi zarządza. Nie muszą one nic o sobie wiedzieć,
     * jedynie przekazują polecenia mediatorowi, a ten rozsyła je do odpowiednich obiektów.
     *
     * Umozliwia rozmowe np. dwoch klas ze soba
     */
    public class MediatorDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var m = new ConcreteMediator();

                var c1 = new ConcreteColleague1(m);
                var c2 = new ConcreteColleague2(m);

                m.Colleague1 = c1;
                m.Colleague2 = c2;

                c1.Send("How are you?");
                c2.Send("Fine, thanks");

                Console.ReadKey();
            }
        }

        abstract class Mediator
        {
            public abstract void Send(string message,
                Colleague colleague);
        }

        private class ConcreteMediator : Mediator
        {
            private ConcreteColleague1 _colleague1;
            private ConcreteColleague2 _colleague2;

            public ConcreteColleague1 Colleague1
            {
                set => _colleague1 = value;
            }

            public ConcreteColleague2 Colleague2
            {
                set => _colleague2 = value;
            }

            public override void Send(string message,
                Colleague colleague)
            {
                if (colleague == _colleague1)
                    _colleague2.Notify(message);
                else
                    _colleague1.Notify(message);
            }
        }

        abstract class Colleague
        {
            protected readonly Mediator mediator;

            public Colleague(Mediator mediator)
            {
                this.mediator = mediator;
            }
        }

        private class ConcreteColleague1 : Colleague
        {
            public ConcreteColleague1(Mediator mediator)
                : base(mediator)
            {
            }

            public void Send(string message)
            {
                mediator.Send(message, this);
            }

            public void Notify(string message)
            {
                Console.WriteLine("Colleague1 gets message: "  + message);
            }
        }

        private class ConcreteColleague2 : Colleague
        {
            public ConcreteColleague2(Mediator mediator)
                : base(mediator)
            {
            }

            public void Send(string message)
            {
                mediator.Send(message, this);
            }

            public void Notify(string message)
            {
                Console.WriteLine("Colleague2 gets message: "   + message);
            }
        }
    }
}