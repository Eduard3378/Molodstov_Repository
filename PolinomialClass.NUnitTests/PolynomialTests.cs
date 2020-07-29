using NUnit.Framework;
using PolynomialClass;
using System;

namespace PolinomialClass.NUnitTests
{
    /// <summary>
    /// Class PolynomialTests
    /// </summary>
    [TestFixture]
    public class PolynomialTests
    {
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>testing the ToString method</returns>
        [TestCase(new double[] { -12.21, 0.241, 4.245, 2.1, -6, 1 },
             ExpectedResult = "a0 = -12,21; a1 = 0,241; a2 = 4,245; a3 = 2,1; a4 = -6; a5 = 1;")]
        public string ToString_CoefDouble_String(double[] arr)
             => new Polynomial(arr).ToString();
        /// <summary>
        /// Method testing ArgumentNullException
        /// </summary>
        [Test]
        public void Polynomial_NullArray_ArgumentNullException()
           => Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        /// <summary>
        /// Method testing ArgumentException
        /// </summary>
        [Test]
        public void Polynomial_EmptyArray_ArgumentException()
           => Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));
        /// <summary>
        /// Method operator +(Polynomial pFirst, Polynomial pSecond)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="expected"></param>
        /// <returns>Method operator + testing</returns>
        [TestCase(new double[] { 100, 205, 33, 401 }, new double[] { -100.2, -200.124, -4 },
            new double[] { -0.2, 4.876, 29, 401 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { -1, -2, -3, -4 },
            new double[] { 0, 0, 0, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 1.3, -3.2, 0.3, -4 }, new double[] { 10.34, 7.5 },
            new double[] { 11.64, 4.3, 0.3, -4 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.1, 0.213, 0.3, 0.4 }, new double[] { -1, -2, -3, -4 },
            new double[] { -0.9, -1.787, -2.7, -3.6 }, ExpectedResult = true)]
        public bool OperAddPol_Polynomials_result(double[] arr1, double[] arr2, double[] expected)
        {

            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = new Polynomial(arr2);
            Polynomial p3 = p1 + p2;

            return p3.Equals(new Polynomial(expected));

        }
        /// <summary>
        /// Method operator *(Polynomial pFirst, Polynomial pSecond)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="expected"></param>
        /// <returns>Method operator * testing</returns>
        [TestCase(new double[] { -0.23, 1, 2.3 }, new double[] { -3, 1 }, new double[] { 0.69, -3.23, -5.9, 2.3 },
            ExpectedResult = true)]
        [TestCase(new double[] { -1, 0, 2 }, new double[] { -6, 0, -1 }, new double[] { 6, 0, -11, 0, -2 },
            ExpectedResult = true)]
        [TestCase(new double[] { 6, 0, -11, 0, -2 }, new double[] { -6, 0, -1 }, new double[] { -36, 0, 60, 0, 23, 0, 2 },
            ExpectedResult = true)]
        public bool OperMult_TwoPolynomials_result(double[] arr1, double[] arr2, double[] expected)
        {
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = new Polynomial(arr2);

            Polynomial p3 = p1 * p2;

            return p3.Equals(new Polynomial(expected));

        }
        /// <summary>
        /// Method GetCoefficients()
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Method GetCoefficients() testing</returns>
        [TestCase(new double[] { 0.23, 0.000001, -0.000000001 }, ExpectedResult = new double[] { 0.23, 0, 0 })]
        public double[] GetCoefficients_Coefficients0000001_ReplaceToZero(double[] array)
        {
            Polynomial polynomial = new Polynomial(array);
            return polynomial.GetCoefficients();
        }
        /// <summary>
        /// Method Equals(Polynomial polinom)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns>Method Equals(Polynomial polinom) testing</returns>
        [TestCase(new double[] { 23, -3, 3.33 }, new double[] { 23, -3, 3.33 }, ExpectedResult = true)]
        public bool Equals_CoefDouble_True(double[] arr1, double[] arr2)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);

            return pol1.Equals(pol2);
        }
        /// <summary>
        /// Method Equals(Polynomial polinom)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns>Method Equals(Polynomial polinom) testing</returns>
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = false)]
        public bool lsEquals_CoefDouble_False(double[] arr1, double[] arr2)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);

            return pol1.Equals(pol2);
        }
        /// <summary>
        /// Method ReferenceEquals(pol1, pol2)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns>Method ReferenceEquals(pol1, pol2) testing</returns>
        [TestCase(new double[] { 1 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        public bool ReferenceEquals_DiffCoef_False(double[] arr1, double[] arr2)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);

            return ReferenceEquals(pol1, pol2);
        }
        /// <summary>
        /// Method ReferenceEquals(pol1, pol2)
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>Method ReferenceEquals(pol1, pol2) testing</returns>
        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = true)]
        public bool ReferenceEquals_SuchRef_ResultTrue1(double[] arr1)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = pol1;

            return ReferenceEquals(pol1, pol2);
        }
        /// <summary>
        /// Method operator ==(Polynomial pFirst, Polynomial pSecond)
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns>Method testing ==</returns>
        [TestCase(new double[] { 0.001, -2, 3 }, new double[] { 0.001, -2, 3 }, ExpectedResult = true)]
        public bool OperEqual_CoefDouble_True(double[] arr1, double[] arr2)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(arr2);

            return pol1 == pol2;
        }
        /// <summary>
        /// Method operator ==(Polynomial pFirst, Polynomial pSecond)
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>Method testing ==</returns>
        [TestCase(new double[] { 0.001, -2, 3 }, ExpectedResult = true)]
        public bool OperEqual_Sign_True(double[] arr1)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = pol1;

            return pol1 == pol2;
        }
        /// <summary>
        /// Method GetHashCode()
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>Method testing GetHashCode()</returns>
        [TestCase(new double[] { 0.001, -2, 3 }, ExpectedResult = false)]
        public bool GetHashCode_DiffCoef_False(double[] arr1)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(new double[] { -2, 0.001, 3 });

            return pol1.GetHashCode() == pol2.GetHashCode();
        }
        /// <summary>
        /// Method GetHashCode()
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns>Method testing GetHashCode()</returns>
        [TestCase(new double[] { 0.001, -2, 3 }, ExpectedResult = true)]
        public bool GetHashCode_DiffCoef_True(double[] arr1)
        {
            Polynomial pol1 = new Polynomial(arr1);
            Polynomial pol2 = new Polynomial(new double[] { 0.001, -2, 3 });

            return pol1.GetHashCode() == pol2.GetHashCode();
        }


    }
}