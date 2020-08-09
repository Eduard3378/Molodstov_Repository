using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericISerializeClassType;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace GenericISerializeClassType.Tests
{
    /// <summary>
    /// Class MobilePhonesTests
    /// </summary>
    [TestClass()]
    public class MobilePhonesTests
    {
        MobilePhones product1 = new MobilePhones(1, "Мобильные телефоны", "Samsung 3300", 450);
        /// <summary>
        /// Method  MobilePhones_IdCategpryTitlePrice_CreateObject()
        /// </summary>
        [TestMethod()]
        public void MobilePhones_IdCategpryTitlePrice_CreateObject()
        {
            // Arange
            MobilePhones product2 = new MobilePhones(2, "Мобильные телефоны", "Samsung Galaxy1", 830);
            // Assert
            Assert.IsNotNull(product1);
            Assert.IsNotNull(product2);
        }
        /// <summary>
        /// Method ToString_IdCategpryTitlePrice_String()
        /// </summary>
        [TestMethod()]
        public void ToString_IdCategpryTitlePrice_String()
        {
            // Arange
            MobilePhones product7 = new MobilePhones(7, "Мобильные телефоны", "Samsung Galaxy99", 835);
            string expected = product7.Id + " " + product7.Category + " " + product7.Title + " " + product7.Price;           
            //Act 
            string result = product7.ToString();
            // Assert
            Assert.AreEqual(result, expected);
        }
        /// <summary>
        /// Method CompareToTest_Product_Int()
        /// </summary>
        [TestMethod()]
        public void CompareToTest_Product_Int()
        {
            // Arange
            MobilePhones product7 = new MobilePhones(7, "Мобильные телефоны", "Samsung Galaxy99", 835);
            int expected = -1;
            //Act
            var result = product1.CompareTo(product7);
            // Console.WriteLine(result);
            // Assert
            result.Should().Be(expected);
        }
    }
}