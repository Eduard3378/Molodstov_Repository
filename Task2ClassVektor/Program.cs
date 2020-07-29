using System;

namespace Task2ClassVektor
{
    /// <summary>
    /// Class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Vector1 v1 = new Vector1(new double[] { 10.0, 9.0, 8.0 });
            Vector1 v2 = new Vector1(new double[] { 5.0, 4.0, 3.0 });           
            double d = 10.0;          
            Console.WriteLine("\nv1 = {0}", v1);
            Console.WriteLine("v2 = {0}", v2);
            Console.WriteLine("d = {0}", d);
            Console.WriteLine("v2 + v1 = {0}", (v2 + v1));
            Console.WriteLine("v2 - v1 = {0}", (v2 - v1));
            Console.WriteLine("v1 * d = {0}", (v1 * d));
            Console.WriteLine("v1 / d = {0}", (v1 / d));
            Console.WriteLine("Dot product of v1 and v2 = {0}", Vector1.DotProduct(v1, v2));
            Console.WriteLine("Cross product of v1 and v2 = {0}", Vector1.CrossProduct(v1, v2).ToString());
            Console.WriteLine("Angle between v1 and v2 = {0}", Vector1.Angle(v1, v2));           

            Console.ReadLine();
        }
    }
}
