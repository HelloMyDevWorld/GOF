using System;

namespace GOF
{
    /*
     *Abstrakcyjna fabryka pozwala na tworzenie obiektów za pomocą klasy abstrakcyjnej lub interfejsu
     * bez pokazywania jakiego typu produkty chcemy wytworzyć
     *
     *Fabryka abstrakcyjna (ang. Abstract Factory) – kreacyjny wzorzec projektowy, którego celem jest dostarczenie interfejsu do
     * tworzenia różnych obiektów jednego typu (tej samej rodziny) bez specyfikowania ich konkretnych klas[1].
     * Umożliwia jednemu obiektowi tworzenie różnych, powiązanych ze sobą, reprezentacji podobiektów określając ich typy podczas działania programu[2].
     * Fabryka abstrakcyjna różni się od Budowniczego tym, że kładzie nacisk na tworzenie produktów z konkretnej rodziny,
     * a Budowniczy kładzie nacisk na sposób tworzenia obiektów[3].
     *
     *
     * Jednym z plusów wykorzystania wzorca jest możliwość ukrycia szczegółów implementacyjnych klas reprezentujących konkretny produkt
     * - klient widzi tylko interfejs. Ukryciu ulegają także nazwy tych klas, co nie wymusza ich zapamiętywania
     * i odizolowuje klienta od problemu określenia do której klasy należy obiekt[3].

        Do zysków należy także możliwość całkowitego ukrycia implementacji obiektów przed klientem. Klient widzi tylko interfejs 
        i nie ma możliwości zajrzenia do kodu oraz to, że wymuszana jest spójność produktów[7].

        Do minusów należy zaliczyć trudność rozszerzania rodziny obiektów o nowe podobiekty.
        Wymusza to modyfikację klasy fabryki abstrakcyjnej oraz wszystkich obiektów, które są tworzone przez nią[3].
     */

    public class AbstractFactoryDesignPattern
    {

        private class MainApp
        {

            public static void Test()
            {
                AbstractFactory factory1 = new ConcreteFactory1();
                var client1 = new Client(factory1);
                client1.Run();

                AbstractFactory factory2 = new ConcreteFactory2();
                var client2 = new Client(factory2);
                client2.Run();

                Console.ReadKey();
            }
        }


        abstract class AbstractFactory
        {
            public abstract AbstractProductA CreateProductA();
            public abstract AbstractProductB CreateProductB();
        }

        //Tworzy rózne ale pozwiązane ze sobą produkty dana fabryka widac powiżaanie w obiekcie Client w metodzie Run();
        private class ConcreteFactory1 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA1();
            }

            public override AbstractProductB CreateProductB()
            {
                return new ProductB1();
            }
        }

        private class ConcreteFactory2 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA2();
            }

            public override AbstractProductB CreateProductB()
            {
                return new ProductB2();
            }
        }


        abstract class AbstractProductA
        {
        }

        private class ProductA1 : AbstractProductA
        {
        }

        private class ProductA2 : AbstractProductA
        {
        }
        
        abstract class AbstractProductB
        {
            public abstract void Interact(AbstractProductA a);
        }


        private class ProductB1 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine(GetType().Name +  " interacts with " + a.GetType().Name);
            }
        }

        private class ProductB2 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine(GetType().Name +  " interacts with " + a.GetType().Name);
            }
        }


        private class Client
        {
            private readonly AbstractProductA _abstractProductA;
            private readonly AbstractProductB _abstractProductB;

            public Client(AbstractFactory factory)
            {
                _abstractProductB = factory.CreateProductB();
                _abstractProductA = factory.CreateProductA();
            }

            public void Run()
            {
                _abstractProductB.Interact(_abstractProductA);
            }
        }
    }
}