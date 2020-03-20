using System;

namespace GOF
{
    /*
     * strukturalny wzorzec projektowy, którego celem jest umożliwienie współpracy dwóm klasom o niekompatybilnych interfejsach.
     * Adapter przekształca interfejs jednej z klas na interfejs drugiej klasy
     *
     * Wzorzec adaptera stosowany jest najczęściej w przypadku, gdy wykorzystanie istniejącej klasy jest niemożliwe ze względu na jej
     * niekompatybilny interfejs.
     * Drugim powodem użycia może być chęć stworzenia klasy, która będzie współpracowała z klasami o nieokreślonych interfejsach
     *
     * Istnieją dwa warianty wzorca Adapter:

        klasowy,
        obiektowy.

        Różnią się one nieznacznie budową oraz właściwościami. Do stworzenia adaptera klasowego wykorzystywane jest wielokrotne dziedziczenie.
        Klasa adaptera dziedziczy prywatnie po klasie adaptowanej oraz publicznie implementuje interfejs klienta[1]. 
        W przypadku tego adaptera wywołanie funkcji jest przekierowywane do bazowej klasy adaptowanej[4].

        W przypadku adaptera obiektowego klasa adaptera dziedziczy interfejs, którym posługuje się klient 
        oraz zawiera w sobie klasę adaptowaną. Rozwiązanie takie umożliwia oddzielenie klasy klienta od klasy adaptowanej[1].
        Komplikuje to proces przekazywania żądania: klient wysyła je do adaptera wywołując jedną z jego metod. 
        Następnie adapter konwertuje wywołanie na jedno bądź kilka wywołań i kieruje je do obiektu/obiektów adaptowanych. 
        Te przekazują wyniki działania bezpośrednio do klienta
    */

    //Obiektowy
    public class AdapterDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {

                Target target = new Adapter();
                target.Request();
                Console.ReadKey();
            }
        }

        private class Target
        {
            public virtual void Request()
            {
                Console.WriteLine("Called Target Request()");
            }
        }

        private class Adapter : Target
        {
            private readonly Adaptee _adaptee = new Adaptee();

            public override void Request()
            {
                _adaptee.SpecificRequest();
            }
        }

        private class Adaptee
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Called SpecificRequest()");
            }
        }
    }
}