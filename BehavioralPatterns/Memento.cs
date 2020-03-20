using System;

namespace GOF
{
    /*
     * Jego zadaniem jest zapamiętanie i udostępnienie na zewnątrz wewnętrznego stanu obiektu bez naruszania hermetyzacji.
     * Umożliwia to przywracanie zapamiętanego stanu obiektu
     *
     * Pamiątka może zostać wykorzystana w procesorze tekstu do zaimplementowania operacji "Cofnij" oraz "Ponów"
     *
     * Jedną z konsekwencji stosowania tego wzorca jest umożliwienie zachowania hermetyzacji obiektu dla którego tworzona jest pamiątka.
     * Jedną z wad Pamiątki jest to, że ich używanie może być kosztowne jeżeli chodzi o wykorzystywaną pamięć
     */
    public class MementoDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var o = new Originator();
                o.State = "On";

                var c = new Caretaker();
                c.Memento = o.CreateMemento();

                o.State = "Off";

                o.SetMemento(c.Memento);

                Console.ReadKey();
            }
        }

        private class Originator
        {
            private string _state;

            public string State
            {
                get => _state;
                set

                {
                    _state = value;
                    Console.WriteLine("State = " + _state);
                }
            }

            public Memento CreateMemento()
            {
                return new Memento(_state);
            }

            public void SetMemento(Memento memento)
            {
                Console.WriteLine("Restoring state...");
                State = memento.State;
            }
        }

        private class Memento
        {
            public Memento(string state)
            {
                State = state;
            }

            public string State { get; }
        }

        private class Caretaker
        {
            public Memento Memento { set; get; }
        }
    }
}