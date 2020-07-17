using System;

namespace PolynomialClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial(new double[] { 1, 2 });
            Polynomial p2 = new Polynomial(new double[] { 1, -3, -10, 24 });
            Console.WriteLine(p1 + p2);
            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1 * p2);
            Console.WriteLine(p1 == p2);
            Console.WriteLine((p1 * p2).Calculate(1.2d));
            Console.ReadKey();
        }
    }
}
