using System;
using System.Collections;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy (obiektowy), którego celem jest zapewnienie sekwencyjnego dostępu do podobiektów zgrupowanych w większym obiekci
     *
     * Ze wzorca Iterator należy korzystać w następujących warunkach:[2]

        Kiedy chcesz uzyskać dostęp do zawartości obiektu zagregowanego bez ujawniania jego wewnętrznej reprezentacji
        Jeśli chcesz umożliwić jednoczesne działanie wielu procesów, przechodzenia po obiektach zagregowanych
        Jeżeli chcesz udostępnić jednolity interfejs do poruszania się po różnych zagregowanych strukturach
        (czyli zapewnić obsługę iteracji polimorficznej)
     */
    public class IteratorDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var a = new ConcreteAggregate();
                a[0] = "Item A";
                a[1] = "Item B";
                a[2] = "Item C";
                a[3] = "Item D";

                var i = a.CreateIterator();

                Console.WriteLine("Iterating over collection:");

                var item = i.First();
                while (item != null)
                {
                    Console.WriteLine(item);
                    item = i.Next();
                }

                Console.ReadKey();
            }
        }

        abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        private class ConcreteAggregate : Aggregate
        {
            private readonly ArrayList _items = new ArrayList();

            public override Iterator CreateIterator()
            {
                return new ConcreteIterator(this);
            }

            public int Count => _items.Count;

            public object this[int index]
            {
                get => _items[index];
                set => _items.Insert(index, value);
            }
        }

        abstract class Iterator
        {
            public abstract object First();
            public abstract object Next();
            public abstract bool IsDone();
            public abstract object CurrentItem();
        }

        private class ConcreteIterator : Iterator
        {
            private readonly ConcreteAggregate _aggregate;
            private int _current;

            public ConcreteIterator(ConcreteAggregate aggregate)
            {
                _aggregate = aggregate;
            }

            public override object First()
            {
                return _aggregate[0];
            }

            public override object Next()
            {
                object ret = null;
                if (_current < _aggregate.Count - 1) ret = _aggregate[++_current];

                return ret;
            }

            public override object CurrentItem()
            {
                return _aggregate[_current];
            }

            public override bool IsDone()
            {
                return _current >= _aggregate.Count;
            }
        }
    }
}