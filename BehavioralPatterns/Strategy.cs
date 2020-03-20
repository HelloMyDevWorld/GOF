using System;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy, który definiuje rodzinę wymiennych algorytmów i kapsułkuje je w postaci klas.
     * Umożliwia wymienne stosowanie każdego z nich w trakcie działania aplikacji niezależnie od korzystających z nich użytkowników
     *
     * Zalety:

        wzorzec pozwala na ścisłe, formalne zdefiniowanie rozszerzalnych rodzin algorytmów dzięki wprowadzeniu interfejsu Strategia,
        bazuje na koncepcji kompozycji, a nie na dziedziczeniu — nie ma sztywnego powiązania między algorytmem a miejscem jego wykorzystania. Może on być wymieniany w trakcie działania programu,
        eliminacja instrukcji warunkowych,
        umożliwia wybór implementacji — algorytmy mogą rozwiązywać ten sam problem, lecz różnić się uzyskiwanymi korzyściami (zużycie pamięci, złożoność obliczeniowa, optymalizacja pod kątem pewnych szczególnych przypadków).
        możliwość niezależnego testowania klientów i strategii[1]

        Wady:

        dodatkowy koszt komunikacji między klientem a strategią (wywołania metod, przekazywanie danych),
        zwiększenie liczby obiektów.

     */
    public class StrategyDesignPattern
    {
        private static void Test()
        {
            Context context;

            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            Console.ReadKey();
        }
    }

    internal abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    internal class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine( "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    internal class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(  "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    internal class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(  "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    internal class Context
    {
        private readonly Strategy _strategy;

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
    
}