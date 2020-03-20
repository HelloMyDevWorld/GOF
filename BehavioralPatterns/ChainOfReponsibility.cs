using System;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy, w którym żądanie może być przetwarzane przez różne obiekty, w zależności od jego typu
     *
     * Zalety:

        elementy łańcucha mogą być dynamicznie dodawane i usuwane w trakcie działania programu[1],
        zmniejszenie liczby zależności między nadawcą a odbiorcami,
        implementacja pojedynczej procedury nie musi znać struktury łańcucha oraz innych procedur.

        Wady:

        wzorzec nie gwarantuje, że każde żądanie zostanie obsłużone[1],
        śledzenie i debugowanie pracy działania łańcucha może być trudne[1]

        Wzorzec znajduje zastosowanie wszędzie tam, gdzie mamy do czynienia z różnymi mechanizmami podobnych żądań,
        które można zaklasyfikować do różnych kategorii. 
        Dodatkową motywacją do jego użycia są często zmieniające się wymagania.
     */
    public class ChainOfReponsibility
    {
        private class MainApp
        {
            private static void Test()
            {
     
                Handler h1 = new ConcreteHandler1();
                Handler h2 = new ConcreteHandler2();
                Handler h3 = new ConcreteHandler3();
                h1.SetSuccessor(h2);
                h2.SetSuccessor(h3);

                int[] requests = {2, 5, 14, 22, 18, 3, 27, 20};

                foreach (var request in requests) h1.HandleRequest(request);

                Console.ReadKey();
            }
        }


        abstract class Handler
        {
            protected Handler successor;

            public void SetSuccessor(Handler successor)
            {
                this.successor = successor;
            }

            public abstract void HandleRequest(int request);
        }

        private class ConcreteHandler1 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 0 && request < 10)
                    Console.WriteLine("{0} handled request {1}",
                        GetType().Name, request);
                else if (successor != null) successor.HandleRequest(request);
            }
        }

        private class ConcreteHandler2 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 10 && request < 20)
                    Console.WriteLine("{0} handled request {1}",
                        GetType().Name, request);
                else if (successor != null) successor.HandleRequest(request);
            }
        }

        private class ConcreteHandler3 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 20 && request < 30)
                    Console.WriteLine("{0} handled request {1}",
                        GetType().Name, request);
                else if (successor != null) successor.HandleRequest(request);
            }
        }
    }
}