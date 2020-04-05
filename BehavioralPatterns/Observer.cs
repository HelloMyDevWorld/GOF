using System;
using System.Collections.Generic;

namespace GOF
{

    // EVENT HANDER I DELEGATE += subskrypowanie sie do nich przez metohdy
    /*
     * Używany jest do powiadamiania zainteresowanych obiektów o zmianie stanu pewnego innego obiektu.
     *
     * Zalety:

    luźna zależność między obiektem obserwującym i obserwowanym. Ponieważ nie wiedzą one wiele o sobie nawzajem, mogą być niezależnie rozszerzane i rozbudowywane bez wpływu na drugą stronę,
    relacja między obiektem obserwowanym a obserwatorem tworzona jest podczas wykonywania programu i może być dynamicznie zmieniana,
    domyślnie powiadomienie otrzymują wszystkie obiekty. Obiekt obserwowany jest zwolniony z zarządzania subskrypcją — o tym czy obsłużyć powiadomienie, decyduje sam obserwator.
    
    Wady:

    obserwatorzy nie znają innych obserwatorów, co w pewnych sytuacjach może wywołać trudne do znalezienia skutki uboczne.
     */
    public struct ObserverDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var s = new ConcreteSubject();

                s.Attach(new ConcreteObserver(s, "X"));
                s.Attach(new ConcreteObserver(s, "Y"));
                s.Attach(new ConcreteObserver(s, "Z"));

                s.SubjectState = "ABC";
                s.Notify();

                Console.ReadKey();
            }
        }

        abstract class Subject
        {
            private readonly List<Observer> _observers = new List<Observer>();

            public void Attach(Observer observer)
            {
                _observers.Add(observer);
            }

            public void Detach(Observer observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var o in _observers) o.Update();
            }
        }

        private class ConcreteSubject : Subject
        {
            public string SubjectState { get; set; }
        }

        abstract class Observer
        {
            public abstract void Update();
        }

        private class ConcreteObserver : Observer
        {
            private readonly string _name;
            private string _observerState;

            public ConcreteObserver(
                ConcreteSubject subject, string name)
            {
                Subject = subject;
                _name = name;
            }

            public override void Update()
            {
                _observerState = Subject.SubjectState;
                Console.WriteLine("Observer {0}'s new state is {1}",
                    _name, _observerState);
            }

            public ConcreteSubject Subject { get; }
        }
    }
}