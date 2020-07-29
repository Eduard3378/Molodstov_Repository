using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Task2ClassVektor;

namespace ClassVektor.UnitTests
{
    /// <summary>
    /// Class Vector1Tests
    /// </summary>
    [TestClass]
    public class Vector1Tests
    {
        static int nmemb = 3;
        static double[] v1 = { 2.0, 3.0, 4.0 };
        static double[] v2 = { 5.0, 6.0, 7.0 };
        Vector1 vectorOne = new Vector1(v1);
        Vector1 vectorTwo = new Vector1(v2);

        /// <summary>
        /// testing vector creation
        /// </summary>
        [TestMethod]
        public void Vector1_VectorOneTwo_Exception()
        {
            // Arange           
            Vector1 vector = new Vector1(nmemb);
            // Assert
            Assert.IsNotNull(vector);
            Assert.IsNotNull(vectorOne);
            Assert.IsNotNull(vectorTwo);
        }

        /// <summary>
        /// Addition test
        /// </summary>
        [TestMethod]
        public void OperPlus_VectorOneTwo_Result1()
        {
            // Arange             
            double[] v3 = { 7.0, 9.0, 11.0 };           
            Vector1 expected = new Vector1(v3);
            //Act 
            var result = vectorOne + vectorTwo;
            // Assert
            result.Should().Equals(expected);         
        }

        /// <summary>
        /// Subtraction test
        /// </summary>
        [TestMethod]
        public void OperSub_VectorOneTwo_Result()
        {
            // Arange
            double[] v3 = { -3.0, -3.0, -3.0 };
            Vector1 expected = new Vector1(v3);
            //Act 
            var result = vectorOne - vectorTwo;            
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Test the product of a vector by a number
        /// </summary>
        [TestMethod]
        public void OperMult_VectorOne_Result()
        {
            // Arange
            double nmemb = 3.5;
            double[] v3 = { 7.0, 10.5, 14.0 };
            Vector1 expected = new Vector1(v3);
            //Act 
            Vector1 result = nmemb * vectorOne;
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// vector cross product test
        /// </summary>
        [TestMethod]
        public void DotProduct_VectorOneTwo_Result()
        {
            // Arange           
            double expected = 56.0;
            //Act
            var result = Vector1.DotProduct(vectorOne, vectorTwo);
            // Assert           
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Test for dividing a vector by a number
        /// </summary>
        [TestMethod]
        public void OperDiv_VectorOne_Result()
        {
            // Arange  
            double nmemb = 10;
            double[] v3 = { 0.2, 0.3, 0.4 };
            Vector1 expected = new Vector1(v3);
            //Act
            var result = vectorOne / nmemb;
            // Assert  
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Equality test
        /// </summary>
        [TestMethod]
        public void OperEqually_VectorOne_Result()
        {                   
            Vector1 vector = new Vector1(v1);
            Vector1 vector1 = new Vector1(v2);
            Assert.IsTrue(vector == vectorOne);            
            Assert.IsFalse(vector1 != vectorTwo);         
        }
    }
}
