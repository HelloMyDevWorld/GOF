using System;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy. Jego zadaniem jest zdefiniowanie metody, będącej szkieletem algorytmu.
     * Algorytm ten może być następnie dokładnie definiowany w klasach pochodnych.
     * Niezmienna część algorytmu zostaje opisana w metodzie szablonowej, której klient nie może nadpisać.
     * W metodzie szablonowej wywoływane są inne metody, reprezentujące zmienne kroki algorytmu.
     * Mogą one być abstrakcyjne lub definiować domyślne zachowania.
     * Klient, który chce skorzystać z algorytmu, może wykorzystać domyślną implementację bądź może utworzyć klasę pochodną
     * i nadpisać metody opisujące zmienne fragmenty algorytmu. Najczęściej metoda szablonowa ma widoczność publiczną,
     * natomiast metody do przesłonięcia mają widoczność chronioną lub prywatną, tak, aby klient nie mógł ich użyć bezpośrednio[1][2].
     * Inna popularna nazwa tego wzorca to niewirtualny interfejs (ang. non virtual interface).
     * Mimo zbieżnej nazwy, wzorzec ten nie ma niczego wspólnego z szablonami, stosowanymi w programowaniu uogólnionym.
     */

    public class TemplateMethod
    {
        private class MainApp
        {
            private static void Test()
            {
                AbstractClass aA = new ConcreteClassA();
                aA.TemplateMethod();

                AbstractClass aB = new ConcreteClassB();
                aB.TemplateMethod();

                Console.ReadKey();
            }
        }

        abstract class AbstractClass
        {
            public abstract void PrimitiveOperation1();
            public abstract void PrimitiveOperation2();


            public void TemplateMethod()
            {
                PrimitiveOperation1();
                PrimitiveOperation2();
                Console.WriteLine("");
            }
        }

        private class ConcreteClassA : AbstractClass

        {
            public override void PrimitiveOperation1()
            {
                Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
            }

            public override void PrimitiveOperation2()
            {
                Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
            }
        }


        private class ConcreteClassB : AbstractClass

        {
            public override void PrimitiveOperation1()
            {
                Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
            }

            public override void PrimitiveOperation2()
            {
                Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
            }
        }
    }
}