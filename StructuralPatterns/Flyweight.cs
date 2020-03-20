using System;
using System.Collections;

namespace GOF
{
    /*
     * strukturalny wzorzec projektowy, którego celem jest zmniejszenie wykorzystania pamięci
     * poprzez poprawę efektywności obsługi dużych obiektów zbudowanych
     * z wielu mniejszych elementów poprzez współdzielenie wspólnych małych elementów
     *
     * Korzyści wynikające z zastosowania tego wzorca to:

        ograniczenie liczby obiektów używanych w trakcie wykonywania programu, 
        a co za tym idzie zaoszczędzenie pamięci aplikacji – tym większe, im więcej obiektów jest współdzielonych
        składowanie danych stanu współdzielonych obiektów odbywa się w jednej lokalizacji.

        Wady wzorca Pyłek to:

        zmniejszenie wydajności aplikacji[2]
        utrata przez pojedyncze, logiczne egzemplarze klasy możliwości posiadania zachowań niezależnych od pozostałych egzemplarzy.
     */
    public class FlyweightDesignPattern
    {
        private class MainApp
        {

            private static void Test()
            {

                var extrinsicstate = 22;

                var factory = new FlyweightFactory();

                var fx = factory.GetFlyweight("X");
                fx.Operation(--extrinsicstate);

                var fy = factory.GetFlyweight("Y");
                fy.Operation(--extrinsicstate);

                var fz = factory.GetFlyweight("Z");
                fz.Operation(--extrinsicstate);

                var fu = new UnsharedConcreteFlyweight();

                fu.Operation(--extrinsicstate);

                Console.ReadKey();
            }
        }

        private class FlyweightFactory
        {
            private readonly Hashtable flyweights = new Hashtable();

            public FlyweightFactory()
            {
                flyweights.Add("X", new ConcreteFlyweight());
                flyweights.Add("Y", new ConcreteFlyweight());
                flyweights.Add("Z", new ConcreteFlyweight());
            }

            public Flyweight GetFlyweight(string key)
            {
                return (Flyweight) flyweights[key];
            }
        }

        abstract class Flyweight
        {
            public abstract void Operation(int extrinsicstate);
        }

        private class ConcreteFlyweight : Flyweight
        {
            public override void Operation(int extrinsicstate)
            {
                Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
            }
        }

        private class UnsharedConcreteFlyweight : Flyweight
        {
            public override void Operation(int extrinsicstate)
            {
                Console.WriteLine("UnsharedConcreteFlyweight: " +   extrinsicstate);
            }
        }
    }
}