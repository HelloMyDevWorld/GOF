using System;
using System.Collections.Generic;

namespace GOF
{
    /*
     *  wzorzec projektowy, którego zadaniem jest odseparowanie algorytmu od struktury obiektowej na której operuje.
     * Praktycznym rezultatem tego odseparowania jest możliwość dodawania nowych operacji
     * do aktualnych struktur obiektów bez konieczności ich modyfikacji
     *
     *
     */
    public class VisitorDesignPattern
    {
        private class MainApp
        {
            private static void Test()
            {
                var o = new ObjectStructure();
                o.Attach(new ConcreteElementA());
                o.Attach(new ConcreteElementB());

                var v1 = new ConcreteVisitor1();
                var v2 = new ConcreteVisitor2();

                o.Accept(v1);
                o.Accept(v2);

                Console.ReadKey();
            }
        }

        abstract class Visitor
        {
            public abstract void VisitConcreteElementA(
                ConcreteElementA concreteElementA);

            public abstract void VisitConcreteElementB(
                ConcreteElementB concreteElementB);
        }

        private class ConcreteVisitor1 : Visitor
        {
            public override void VisitConcreteElementA(
                ConcreteElementA concreteElementA)
            {
                Console.WriteLine("{0} visited by {1}",
                    concreteElementA.GetType().Name, GetType().Name);
            }

            public override void VisitConcreteElementB(
                ConcreteElementB concreteElementB)
            {
                Console.WriteLine("{0} visited by {1}",
                    concreteElementB.GetType().Name, GetType().Name);
            }
        }

        private class ConcreteVisitor2 : Visitor
        {
            public override void VisitConcreteElementA(
                ConcreteElementA concreteElementA)
            {
                Console.WriteLine("{0} visited by {1}",
                    concreteElementA.GetType().Name, GetType().Name);
            }

            public override void VisitConcreteElementB(
                ConcreteElementB concreteElementB)
            {
                Console.WriteLine("{0} visited by {1}",
                    concreteElementB.GetType().Name, GetType().Name);
            }
        }

        abstract class Element
        {
            public abstract void Accept(Visitor visitor);
        }

        private class ConcreteElementA : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementA(this);
            }

            public void OperationA()
            {
            }
        }

        private class ConcreteElementB : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementB(this);
            }

            public void OperationB()
            {
            }
        }

        private class ObjectStructure
        {
            private readonly List<Element> _elements = new List<Element>();

            public void Attach(Element element)
            {
                _elements.Add(element);
            }

            public void Detach(Element element)
            {
                _elements.Remove(element);
            }

            public void Accept(Visitor visitor)
            {
                foreach (var element in _elements) element.Accept(visitor);
            }
        }
    }
}