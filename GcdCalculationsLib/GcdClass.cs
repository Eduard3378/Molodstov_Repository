using System;
using System.Diagnostics;
using System.Linq;

namespace GcdCalculationsLib
{
    public static class GcdClass
    {
        //алгоритм Евклида для вычисления НОД двух целых чисел
        private static int GcdMod(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
        //дополнительную функциональность в виде перегруженных методов
        //вычисления НОД для трех целых чисел
        //вычисления НОД для четырех целых чисел
        //вычисления НОД для пяти целых чисел
        public static int FindGcd(int a, int b) => GcdMod(a, b);
        public static int FindGcd(int a, int b, int c) => GcdMod(GcdMod, a, b, c);
        public static int FindGcd(params int[] numbers) => GcdMod(GcdMod, numbers);


        //метод должен принимать выходной параметр, содержащий значение времени, затраченное для выполнения расчетов 
        public static int FindGcd(int a, int b, out double time)
        {
            var sw = new Stopwatch();
            sw.Start();
            var gcd = GcdMod(a, b);
            time = sw.Elapsed.TotalMilliseconds;
            return gcd;
        }


        public static int FindGcd(int a, int b, int c, out double time) => GcdMod(GcdMod, a, b, c, out time);

        public static int FindGcd(out double time, params int[] numbers) => GcdMod(GcdMod, out time, numbers);


        private static int GcdMod(Func<int, int, int> function, out double time, params int[] numbers)
        {
            var sw = new Stopwatch();
            sw.Start();
            int gcd = GcdMod(function, numbers);
            time = sw.Elapsed.TotalMilliseconds;
            return gcd;
        }

        private static int GcdMod(Func<int, int, int> function, params int[] numbers) => numbers.Aggregate(function);

        private static int GcdMod(Func<int, int, int> function, int a, int b, int c, out double time)
        {
            var sw = new Stopwatch();
            sw.Start();
            var gcd = GcdMod(function, a, b, c);
            time = sw.Elapsed.TotalMilliseconds;
            return gcd;
        }
        private static int GcdMod(Func<int, int, int> function, int a, int b, int c) => function(function(a, b), c);



        //добавить к разработанному типу метод, реализующий алгоритм Стейна (бинарный алгоритм Эвклида) 
        private static int GcdStev(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == b)
            {
                return a;
            }

            if (a % 2 == 0 && b % 2 == 0)
            {
                return 2 * GcdStev(a / 2, b / 2);
            }

            if (a % 2 == 0 && b % 2 != 0)
            {
                return GcdStev(a / 2, b);
            }

            if (a % 2 != 0 && b % 2 == 0)
            {
                return GcdStev(a, b / 2);
            }
            return GcdStev(b, Math.Abs(a - b));
        }
        //метод должен принимать выходной параметр, содержащий значение времени, затраченное для выполнения расчетов (алгоритм Стейна)
        public static int FindGcdStev(int a, int b, out double time)
        {
            var sw = new Stopwatch();
            sw.Start();
            var gcd = GcdStev(a, b);
            time = sw.Elapsed.TotalMilliseconds;
            return gcd;
        }
        public static int FindGcdStev(int a, int b) => GcdStev(a, b);    
        public static int FindGcdStev(int a, int b, int c) => GcdMod(GcdStev, a, b, c);
        public static int FindGcdStev(params int[] numbers) => GcdMod(GcdStev, numbers);
        public static int FindGcdStev(int a, int b, int c, out double time) => GcdMod(GcdStev, a, b, c, out time);
        public static int FindGcdStev(out double time, params int[] numbers) => GcdMod(GcdStev, out time, numbers);
    }
}
