using System;

namespace GOF
{

    /*
        Aplikacja wykorzystująca metody wytwórcze jest niezależna od konkretnych implementacji zasobów oraz procesu ich tworzenia.
        Mogą być one ustalane dynamicznie w trakcie uruchomienia lub zmieniane podczas działania aplikacji.
     
        Wzorzec hermetyzuje proces tworzenia obiektów, zamykając go za ściśle zdefiniowanym interfejsem.
        Właściwość ta jest wykorzystywana, gdy tworzenie nowego obiektu jest złożoną operacją (np. wymaga wstrzyknięcia dodatkowych zależności).

        W wielu obiektowych językach programowania konstruktory klas muszą posiadać ściśle określone nazwy,
        co może być źródłem niejednoznaczności podczas korzystania z nich. 
        Wzorzec umożliwia zastosowanie nazwy opisowej oraz wprowadzenie kilku metod fabryki tworzących obiekt na różne sposoby.


     */
    public class FactoryMethodDesignPattern
    {
        private class MainApp
        {

            private static void Test()
            {

                var creators = new Creator[2];

                creators[0] = new ConcreteCreatorA();
                creators[1] = new ConcreteCreatorB();

                foreach (var creator in creators)
                {
                    var product = creator.FactoryMethod();
                    Console.WriteLine("Created {0}", product.GetType().Name);
                }

                Console.ReadKey();
            }
        }

        abstract class Product
        {
        }

        private class ConcreteProductA : Product
        {
        }

        private class ConcreteProductB : Product
        {
        }


        abstract class Creator
        {
            public abstract Product FactoryMethod();
        }


        private class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }

        private class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }
    }
}