using System;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy, traktujący żądanie wykonania określonej czynności jako obiekt,
     * dzięki czemu mogą być one parametryzowane w zależności od rodzaju odbiorcy, a także umieszczane w kolejkach i dziennikach.
     *
     * Zalety:

        oddzielenie operacji od obiektów, na których jest ona wykonywana,
        polecenia są reprezentowane jako standardowe obiekty, dzięki czemu możemy na 
        nich stosować wszystkie manipulacje dopuszczalne w programowaniu obiektowym,
        możliwość łączenia elementarnych poleceń w polecenia złożone,
        łatwość dodawania nowych rodzajów poleceń.

        Wady:

        każde polecenie wymaga dodatkowej pamięci na zapamiętanie stanu swojego obiektu.
     */
    public class CommandDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var receiver = new Receiver();
                Command command = new ConcreteCommand(receiver);
                var invoker = new Invoker();

                invoker.SetCommand(command);
                invoker.ExecuteCommand();

                Console.ReadKey();
            }
        }

        abstract class Command
        {
            protected readonly Receiver receiver;

            public Command(Receiver receiver)
            {
                this.receiver = receiver;
            }

            public abstract void Execute();
        }

        private class ConcreteCommand : Command
        {
            public ConcreteCommand(Receiver receiver) :
                base(receiver)
            {
            }

            public override void Execute()
            {
                receiver.Action();
            }
        }

        private class Receiver
        {
            public void Action()
            {
                Console.WriteLine("Called Receiver.Action()");
            }
        }

        private class Invoker
        {
            private Command _command;

            public void SetCommand(Command command)
            {
                _command = command;
            }

            public void ExecuteCommand()
            {
                _command.Execute();
            }
        }
    }
}