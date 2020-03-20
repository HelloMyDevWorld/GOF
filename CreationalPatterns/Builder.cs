using System;
using System.Collections.Generic;

namespace GOF
{
    /*
     * Ułatwie przede wszystkim budowanie obiektów, załózmy ze mamy konstukror ktory tworzy nam postać, i przekazujemy 100 różnych parametrów i
     * większośc z nich może byc po prostu ustawiona deafaultowo (kreator tworzenia postaci - wąsy, broda, oczy, kolor, rozstaw etc.)
     *
     * Separuje konsturkcję duzych obiektów od reprezentacji, wiec ten sam proces kreacji może tworzyć rózne reprezentacje
     *
     * Budowniczy różni się od wzorca fabryki abstrakcyjnej oraz pozostałych wzorców kreacyjnych tym,
     * że skupia się na sposobie tworzenia obiektów reprezentujących produkty.
     * Tworzy drobną część skomplikowanego produktu za każdym swoim wywołaniem jednocześnie kontrolując stan wykonanej pracy.
     * Klient otrzymuje produkt po zakończeniu jego pracy, a nie – tak jak w przypadku Fabryki abstrakcyjnej – bezzwłocznie.
     * W przypadku Fabryki abstrakcyjnej możliwe jest także tworzenie kilku obiektów jednocześnie. Często oba wzorce są łączone
     *
     * Ponizej jest jedna z implementacji
     */
    public class BuilderDesignPattern
    {
        public class MainApp
        {

            public static void Test()
            {
                var director = new Director();

                Builder b1 = new ConcreteBuilder1();
                Builder b2 = new ConcreteBuilder2();

                director.Construct(b1);
                var p1 = b1.GetResult();
                p1.Show();

                director.Construct(b2);
                var p2 = b2.GetResult();
                p2.Show();

                Console.ReadKey();
            }
        }

        private class Director
        {
            public void Construct(Builder builder)
            {
                builder.BuildPartA();
                builder.BuildPartB();
            }
        }

        abstract class Builder
        {
            public abstract void BuildPartA();
            public abstract void BuildPartB();
            public abstract Product GetResult();
        }

        private class ConcreteBuilder1 : Builder
        {
            private readonly Product _product = new Product();

            public override void BuildPartA()
            {
                _product.Add("PartA");
            }

            public override void BuildPartB()
            {
                _product.Add("PartB");
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

        private class ConcreteBuilder2 : Builder
        {
            private readonly Product _product = new Product();

            public override void BuildPartA()
            {
                _product.Add("PartX");
            }

            public override void BuildPartB()
            {
                _product.Add("PartY");
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

        private class Product
        {
            private readonly List<string> _parts = new List<string>();

            public void Add(string part)
            {
                _parts.Add(part);
            }

            public void Show()
            {
                Console.WriteLine("\nProduct Parts -------");
                foreach (string part in _parts)
                    Console.WriteLine(part);
            }
        }
    }
}