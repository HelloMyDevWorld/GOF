using System;

namespace GOF
{
    /*
     * Polega na kopiowaniu juz istniejacego obiektu
     *
     * kreacyjny wzorzec projektowy,
     * którego celem jest umożliwienie tworzenia obiektów danej klasy
     * bądź klas z wykorzystaniem już istniejącego obiektu, zwanego prototypem.
     *
     * Omawiany wzorzec stosujemy między innymi wtedy, gdy nie chcemy tworzyć
     * w budowanej aplikacji podklas obiektu budującego (jak to jest w przypadku wzorca fabryki abstrakcyjnej).
     * Wzorzec ten stosujemy podczas stosowania klas specyfikowanych podczas działania aplikacji
     */

    public class PrototypeDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var p1 = new ConcretePrototype1("I");
                var c1 = (ConcretePrototype1) p1.Clone();
                Console.WriteLine("Cloned: {0}", c1.Id);

                var p2 = new ConcretePrototype2("II");
                var c2 = (ConcretePrototype2) p2.Clone();
                Console.WriteLine("Cloned: {0}", c2.Id);

                Console.ReadKey();
            }
        }

        abstract class Prototype
        {
            public Prototype(string id)
            {
                Id = id;
            }

            public string Id { get; }

            public abstract Prototype Clone();
        }

        private class ConcretePrototype1 : Prototype
        {
            public ConcretePrototype1(string id)
                : base(id)
            {
            }
            public override Prototype Clone()
            {
                return (Prototype) MemberwiseClone();
            }
        }

        private class ConcretePrototype2 : Prototype
        {
            public ConcretePrototype2(string id)
                : base(id)
            {
            }

            public override Prototype Clone()
            {
                return (Prototype) MemberwiseClone();
            }
        }
    }
}