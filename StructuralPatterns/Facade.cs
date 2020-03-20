using System;

namespace GOF
{
    /*
     * Służy do ujednolicenia dostępu do złożonego systemu poprzez wystawienie uproszczonego,
     * uporządkowanego interfejsu programistycznego, który ułatwia jego użycie
     *
     *
     */
    public class FacadeDesignPattern
    {
        private class MainApp
        {
            public static void Test()
            {
                var facade = new Facade();

                facade.MethodA();
                facade.MethodB();

                Console.ReadKey();
            }
        }

        private class SubSystemOne
        {
            public void MethodOne()
            {
                Console.WriteLine(" SubSystemOne Method");
            }
        }

        private class SubSystemTwo
        {
            public void MethodTwo()
            {
                Console.WriteLine(" SubSystemTwo Method");
            }
        }

        private class SubSystemThree
        {
            public void MethodThree()
            {
                Console.WriteLine(" SubSystemThree Method");
            }
        }

        private class SubSystemFour
        {
            public void MethodFour()
            {
                Console.WriteLine(" SubSystemFour Method");
            }
        }

        private class Facade
        {
            private readonly SubSystemOne _one;
            private readonly SubSystemTwo _two;
            private readonly SubSystemThree _three;
            private readonly SubSystemFour _four;

            public Facade()
            {
                _one = new SubSystemOne();
                _two = new SubSystemTwo();
                _three = new SubSystemThree();
                _four = new SubSystemFour();
            }

            public void MethodA()
            {
                Console.WriteLine("\nMethodA() ---- ");
                _one.MethodOne();
                _two.MethodTwo();
                _four.MethodFour();
            }

            public void MethodB()
            {
                Console.WriteLine("\nMethodB() ---- ");
                _two.MethodTwo();
                _three.MethodThree();
            }
        }
    }
}