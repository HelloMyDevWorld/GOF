using System;

namespace GOF
{
    /*
     * strukturalny wzorzec projektowy, którego celem jest utworzenie obiektu zastępującego inny obiekt.
     * Stosowany jest w celu kontrolowanego tworzenia na żądanie kosztownych obiektów oraz kontroli dostępu do nich.
     *
     * Istnieją cztery rodzaje tego wzorca, które jednocześnie definiują sytuacje, w których może zostać użyty[1]:

        wirtualny – przechowuje obiekty, których utworzenie jest kosztowne; tworzy je na żądanie

        ochraniający – kontroluje dostęp do obiektu sprawdzając, czy obiekt wywołujący ma odpowiednie prawa do obiektu wywoływanego

        zdalny – czasami nazywany ambasadorem; reprezentuje obiekty znajdujące się w innej przestrzeni adresowej

        sprytne odwołanie – czasami nazywany sprytnym wskaźnikiem; pozwala na wykonanie dodatkowych akcji podczas dostępu do obiektu,
        takich jak: zliczanie referencji do obiektu czy ładowanie obiektu do pamięci
     */

    public class ProxyDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var proxy = new Proxy();
                proxy.Request();

                Console.ReadKey();
            }
        }

        abstract class Subject
        {
            public abstract void Request();
        }

        private class RealSubject : Subject
        {
            public override void Request()
            {
                Console.WriteLine("Called RealSubject.Request()");
            }
        }

        private class Proxy : Subject
        {
            private RealSubject _realSubject;

            public override void Request()
            {
                if (_realSubject == null) _realSubject = new RealSubject();

                _realSubject.Request();
            }
        }
    }
}