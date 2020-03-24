using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GOF
{
    struct MyStruct
    {
        string xx { get; set; }
    }

    public abstract class MyStruct2
    {
        protected string xx { get; set; }

        public virtual void DoWork() {/*...*/ }

        public abstract void DoWork2();
    }

    public class  DDD : MyStruct2
    {
        public override void DoWork2()
        { 
            var test = this.xx;
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var xx = new MyStruct2();
            //xx.xx;

            /*
             *https://www.youtube.com/watch?v=4s44rXRdmhQ&list=PL0NHOHZVAjfCioTcerGybx123MRMFBS5w
             *
             *BABLE SORT
             * Sortowanie babelkowe polega na przesuwaniu od poczatku do konca i porównywaniu ze soba kolenych elementów
             *
             *SELECT SORT
             * Poszukujemy najmiejszych elementów w całej liście przechodzac poczatkowo po całej liście i wstawia na poczatek
             *
             * Insert sort
             * Przesuwanie tablicy i porownuuje  kazdy kolejny element z tablica poprzednich
             *
             *
             *
             *
             *
             * Merge sort -> dziel i zwyciezaj diamet
             *
             * Heap sort - > drzewo binarne
             *
             * Quick sort
             *
             */

            var dic = new Dictionary<string,int>()
            {
                {"a",1},
                {"a", 1}
            };

           var result =  dic.GroupBy(el => el.Key);


        }
    }
}
