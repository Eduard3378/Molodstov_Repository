using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericISerializeClassType;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace GenericISerializeClassType.Tests
{
    /// <summary>
    /// Class ProductsForGardenTests
    /// </summary>
    [TestClass()]
    public class ProductsForGardenTests
    {
        ProductsForGarden product5 = new ProductsForGarden(5, "Товары для огорода", "Товар 1", 220);
        /// <summary>
        /// Method ProductsForGarden_IdCategpryTitlePrice_CreateObject()
        /// </summary>
        [TestMethod()]
        public void ProductsForGarden_IdCategpryTitlePrice_CreateObject()
        {
            // Arange
            ProductsForGarden product6 = new ProductsForGarden(6, "Товары для огорода", "Товар 2", 235);
            // Assert
            Assert.IsNotNull(product5);
            Assert.IsNotNull(product6);
        }
        /// <summary>
        /// Method ToString_IdCategpryTitlePrice_String()
        /// </summary>
        [TestMethod()]
        public void ToString_IdCategpryTitlePrice_String()
        {
            // Arange
            ProductsForGarden product6 = new ProductsForGarden(6, "Товары для огорода", "Товар 2", 235);
            string expected = product6.Id + " " + product6.Category + " " + product6.Title + " " + product6.Price;
            //Act
            string result = product6.ToString();
           // Assert
            Assert.AreEqual(result, expected);
        }
        /// <summary>
        /// Method CompareToTest_Product_Int()
        /// </summary>
        [TestMethod()]
        public void CompareToTest_Product_Int()
        {
            //Arange
            ProductsForGarden product6 = new ProductsForGarden(6, "Товары для огорода", "Товар 2", 235); 
            int expected = -1;
           // Act
            var result = product5.CompareTo(product6);
            Console.WriteLine(result);
          // Assert
            result.Should().Be(expected);
        }
    }
}