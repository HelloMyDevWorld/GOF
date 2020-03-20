using System;

namespace GOF
{
    /*
     * Tylko jedna instancja danego obiektu
     *
     * kreacyjny wzorzec projektowy, którego celem jest ograniczenie możliwości
     * tworzenia obiektów danej klasy do jednej instancji oraz zapewnienie globalnego dostępu do stworzonego obiektu
     *
    Zalety:

    singleton nie musi ograniczać się do obsługi pojedynczej instancji klasy – 
    przy niewielkiej zmianie podejścia można za jego pomocą zarządzać także większą liczbą obiektów,

    klasa zaimplementowana z użyciem wzorca singleton może samodzielnie kontrolować liczbę swoich instancji istniejących w systemie,

    proces pobierania instancji klasy jest niewidoczny dla użytkownika. Nie musi on wiedzieć,
    czy w chwili wywołania metody instancja istnieje czy dopiero jest tworzona,

    tworzenie nowej instancji ma charakter leniwy, tj. zachodzi dopiero przy pierwszej próbie użycia.
    Jeśli żaden komponent nie zdecyduje się korzystać z klasy, jej instancji nie będą niepotrzebnie przydzielone zasoby.

    Wady:

    brak elastyczności, bo już na poziomie kodu jest na sztywno określona liczba instancji, jakie mogą istnieć w systemie

    poważnie utrudnia testowanie aplikacji przez wprowadzenie do niej globalnego stanu[5]

    łamie zasadę jednej odpowiedzialności

    łamie zasadę otwarte-zamknięte

    nie można go rozszerzyć

    Singleton musi być ostrożnie stosowany w systemach wielowątkowych. 
    Zażądanie instancji klasy przez dwa wątki równocześnie może doprowadzić do utworzenia dwóch niezależnych instancji, 
    dlatego metoda dostępowa powinna być wtedy zaimplementowana z wykorzystaniem wzajemnego wykluczania.
     */
    public class SingletonDesignPattern
    {
        private class MainApp
        {

            private static void Test()
            {
                var s1 = Singleton.Instance();
                var s2 = Singleton.Instance();

                if (s1 == s2) Console.WriteLine("Objects are the same instance");

                Console.ReadKey();
            }
        }

        private class Singleton
        {
            private static Singleton _instance;

            protected Singleton()
            {
            }

            public static Singleton Instance()
            {
                if (_instance == null) _instance = new Singleton();

                return _instance;
            }
        }
    }
}