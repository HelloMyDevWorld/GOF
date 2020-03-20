using System;
using System.Collections;

namespace GOF
{
    /*
     * czynnościowy wzorzec projektowy, którego celem jest zdefiniowanie opisu gramatyki pewnego języka interpretowalnego,
     * a także stworzenie dla niej interpretera, dzięki któremu będzie możliwe rozwiązanie opisanego problemu
     */
    public class Interpreter
    {
        private class MainApp
        {
            private static void Test()
            {
                var context = new Context();

                ArrayList list = new ArrayList();

                list.Add(new TerminalExpression());
                list.Add(new NonterminalExpression());
                list.Add(new TerminalExpression());
                list.Add(new TerminalExpression());

                foreach (AbstractExpression exp in list) exp.Interpret(context);

                Console.ReadKey();
            }
        }

        private class Context
        {
        }

        abstract class AbstractExpression
        {
            public abstract void Interpret(Context context);
        }

        private class TerminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
                Console.WriteLine("Called Terminal.Interpret()");
            }
        }

        private class NonterminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
                Console.WriteLine("Called Nonterminal.Interpret()");
            }
        }
    }
}