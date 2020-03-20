using System;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy, który umożliwia zmianę zachowania obiektu poprzez zmianę jego stanu wewnętrznego[1].
     * Innymi słowy – uzależnia sposób działania obiektu od stanu w jakim się aktualnie znajduje
     *
     *
     */
    public class StateDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var c = new Context(new ConcreteStateA());

                c.Request();
                c.Request();
                c.Request();
                c.Request();


                Console.ReadKey();
            }
        }

        abstract class State
        {
            public abstract void Handle(Context context);
        }

        private class ConcreteStateA : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateB();
            }
        }


        private class ConcreteStateB : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateA();
            }
        }

        private class Context
        {
            private State _state;

            public Context(State state)
            {
                State = state;
            }

            public State State
            {
                get => _state;
                set

                {
                    _state = value;
                    Console.WriteLine("State: " +  _state.GetType().Name);
                }
            }

            public void Request()
            {
                _state.Handle(this);
            }
        }
    }
}