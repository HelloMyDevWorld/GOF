using System;

namespace GOF
{
    /*
     * strukturalny wzorzec projektowy, który pozwala oddzielić abstrakcję obiektu od jego implementacji.

        Zaleca się stosowanie tego wzorca aby:

        odseparować implementację od interfejsu,
        poprawić możliwości rozbudowy klas, zarówno implementacji, jak i interfejsu (m.in. przez dziedziczenie),
        ukryć implementację przed klientem, co umożliwia zmianę implementacji bez zmian interfejsu.
     */
    public class BridgeDesignPattern
    {
        private class MainApp
        {

            private static void Test()
            {
                Abstraction ab = new RefinedAbstraction();

                ab.Implementor = new ConcreteImplementorA();
                ab.Operation();

                ab.Implementor = new ConcreteImplementorB();
                ab.Operation();

                Console.ReadKey();
            }
        }


        private class Abstraction
        {
            protected Implementor implementor;

            public Implementor Implementor
            {
                set => implementor = value;
            }

            public virtual void Operation()
            {
                implementor.Operation();
            }
        }

        private class RefinedAbstraction : Abstraction
        {
            public override void Operation()
            {
                implementor.Operation();
            }
        }

        abstract class Implementor
        {
            public abstract void Operation();
        }

        private class ConcreteImplementorA : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteImplementorA Operation");
            }
        }

        private class ConcreteImplementorB : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteImplementorB Operation");
            }
        }
    }
}