using System;

namespace GOF
{
    /*
     * wzorzec projektowy należący do grupy wzorców strukturalnych.
     * Pozwala na dodanie nowej funkcji do istniejących klas dynamicznie podczas działania programu.
     *
     * Wzorzec dekoratora polega na opakowaniu oryginalnej klasy w nową klasę "dekorującą"
     * Zwykle przekazuje się oryginalny obiekt jako parametr konstruktora dekoratora,
     * metody dekoratora wywołują metody oryginalnego obiektu i dodatkowo implementują nową funkcję.
     *
     * Dekoratory są alternatywą dla dziedziczenia. Dziedziczenie rozszerza zachowanie klasy w trakcie kompilacji,
     * w przeciwieństwie do dekoratorów, które rozszerzają klasy w czasie działania programu.
     *
        Zapewnia większą elastyczność niż statyczne dziedziczenie[1].
        Pozwala uniknąć tworzenia przeładowanych funkcjami klas na wysokich poziomach hierarchii[1].
        Dekorator i powiązany z nim komponent nie są identyczne[1].
        Powstawanie wielu małych obiektów
     */
    public class DecoratorDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var c = new ConcreteComponent();
                var d1 = new ConcreteDecoratorA();
                var d2 = new ConcreteDecoratorB();

                //Tutaj widac dekoracje
                d1.SetComponent(c);
                d2.SetComponent(d1);

                d2.Operation();

                Console.ReadKey();
            }
        }

        abstract class Component
        {
            public abstract void Operation();
        }

        private class ConcreteComponent : Component
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteComponent.Operation()");
            }
        }

        abstract class Decorator : Component
        {
            protected Component component;

            public void SetComponent(Component component)
            {
                this.component = component;
            }

            public override void Operation()
            {
                if (component != null) component.Operation();
            }
        }

        private class ConcreteDecoratorA : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                Console.WriteLine("ConcreteDecoratorA.Operation()");
            }
        }

        private class ConcreteDecoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                AddedBehavior();
                Console.WriteLine("ConcreteDecoratorB.Operation()");
            }

            private void AddedBehavior()
            {
            }
        }
    }
}