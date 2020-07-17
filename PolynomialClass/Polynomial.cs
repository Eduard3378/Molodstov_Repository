using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Text;

namespace PolynomialClass
{
    public class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private static double numsigns;
        public double[] Coefficients { get; set; }

        static Polynomial()
        {
            try
            {
                var appSettingsReader = new System.Configuration.AppSettingsReader();
                numsigns = (double)appSettingsReader.GetValue("numsigns", typeof(double));
            }
            catch (Exception)
            {
                numsigns = 0.0001;
            }
        }
        public Polynomial(params double[] coef)
        {
            ArrayDimension(coef);

            for (int i = 0; i < coef.Length; i++)
            {
                if (Math.Abs(coef[i]) < numsigns)
                {
                    coef[i] = 0;
                }
            }

            double[] newArray = new double[coef.Length];
            Array.Copy(coef, newArray, coef.Length);
            Coefficients = newArray;
        }
        public double Numsigns
        {
            get
            {
                return numsigns;
            }
        }
        //  Степень полинома
        public int Power
        {
            get { return Coefficients.Length-1; }
        }

        public double[] GetCoefficients()
        {
            double[] coef = new double[this.Coefficients.Length];
            Array.Copy(this.Coefficients, coef, coef.Length);
            return coef;
        }

        public override string ToString()
        {
            string coefString = string.Empty;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                coefString += string.Format($"a{i} = {Coefficients[i]}; ");
            }

            return coefString.TrimEnd(' ');
        }

        //  Быстрый расчет значения полинома по схеме Горнера.
        public double Calculate(double x)
        {
            int n = Coefficients.Length - 1;
            //  Console.WriteLine(n);
            double result = Coefficients[n];
            //  Console.WriteLine(result);
            for (int i = n - 1; i >= 0; i--)
            {
                result = x * result + Coefficients[i];
                // Console.WriteLine(result);
            }
            return result;
        }       

        //Получение или установка значения коэффициента полинома.
        public double this[int n]
        {
            get 
            {
                if (n > Power || n < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return Coefficients[n]; 
            }
            set 
            { 
                Coefficients[n] = value; 
            }
        }



        //  Равенство полиномов
        public static bool operator ==(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, null) || ReferenceEquals(pSecond, null))
            {
                return false;
            }

            if (ReferenceEquals(pFirst, pSecond))
            {
                return true;
            }

            return pFirst.Equals(pSecond);
        }

        public static bool operator !=(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, null) || ReferenceEquals(pSecond, null))
            {
                return false;
            }

            if (ReferenceEquals(pFirst, pSecond))
            {
                return true;
            }

            return !pFirst.Equals(pSecond);
        }
        //  Сложение полиномов
        public static Polynomial operator +(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, null) || ReferenceEquals(pSecond, null))
            {
                throw new ArgumentNullException();
            }

            return new Polynomial(
                AddPol(pFirst.Coefficients, pSecond.Coefficients));
        }
        //  Вычитание полиномов
        public static Polynomial operator -(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, null) || ReferenceEquals(pSecond, null))
            {
                throw new ArgumentNullException();
            }

            Polynomial result = pFirst + (-pSecond);

            return result;
        }

        public static Polynomial operator -(Polynomial polinom)
        {
            if (ReferenceEquals(polinom, null))
            {
                throw new ArgumentNullException(nameof(polinom) + " is null!");
            }

            double[] arr = new double[polinom.Coefficients.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = polinom.Coefficients[i] * -1;
            }

            return new Polynomial(arr);
        }
        //  Умножение полиномов
        public static Polynomial operator *(Polynomial pFirst, Polynomial pSecond)
        {
            if (ReferenceEquals(pFirst, null) || ReferenceEquals(pSecond, null))
            {
                throw new ArgumentNullException();
            }

            double[] firstCoef = pFirst.Coefficients;
            double[] secondCoef = pSecond.Coefficients;

            int resultArrayLength = firstCoef.Length + secondCoef.Length - 1;
            double[] resultArray = new double[resultArrayLength];

            for (int i = 0; i < firstCoef.Length; i++)
            {
                for (int j = 0; j < secondCoef.Length; j++)
                {
                    resultArray[i + j] += firstCoef[i] * secondCoef[j];
                }
            }

            return new Polynomial(resultArray);
        }

        public override int GetHashCode()
        {
            int hashcode = 13;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                hashcode = hashcode * 7 + Coefficients[i].GetHashCode();
            }

            return hashcode;
        }

        private static void ArrayDimension(double[] arr)
        {
            if (ReferenceEquals(arr, null))
            {
                throw new ArgumentNullException("Array is null!");
            }
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty!");
            }
        }

        private static double[] AddPol(double[] arr1, double[] arr2)
        {
            int size = Math.Max(arr1.Length, arr2.Length);
            double[] resultSum = new double[size];

            for (int i = 0; i < arr1.Length; i++)
            {
                resultSum[i] = arr1[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                resultSum[i] = resultSum[i] + arr2[i];
            }

            return resultSum;
        }

        public object Clone()
        {
            double[] coefficients = new double[this.Coefficients.Length];
            Array.Copy(this.Coefficients, coefficients, coefficients.Length);

            return new Polynomial(coefficients);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial polinom)
        {
            if (ReferenceEquals(null, polinom))
            {
                return false;
            }

            if (ReferenceEquals(this, polinom))
            {
                return true;
            }

            if (this.Coefficients.Length != polinom.Coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (!(Math.Abs(this.Coefficients[i] - polinom.Coefficients[i]) <= numsigns))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
