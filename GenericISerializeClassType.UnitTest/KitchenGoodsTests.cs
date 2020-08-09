using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericISerializeClassType;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace GenericISerializeClassType.Tests
{
    /// <summary>
    /// Class KitchenGoodsTests
    /// </summary>
    [TestClass()]
    public class KitchenGoodsTests
    {
        KitchenGoods product3 = new KitchenGoods(3, "Кухонные товары", "Refrigerator 280", 2100);
        /// <summary>
        /// Method KitchenGoods_IdCategpryTitlePrice_CreateObject()
        /// </summary>
        [TestMethod()]
        public void KitchenGoods_IdCategpryTitlePrice_CreateObject()
        {
            // Arange
            KitchenGoods product4 = new KitchenGoods(4, "Кухонные товары", "Set of forks 12", 85);
            // Assert
            Assert.IsNotNull(product3);
            Assert.IsNotNull(product4);
        }
        /// <summary>
        /// Method ToString_IdCategpryTitlePrice_String()
        /// </summary>
        [TestMethod()]
        public void ToString_IdCategpryTitlePrice_String()
        {
            // Arange
            KitchenGoods product4 = new KitchenGoods(4, "Кухонные товары", "Set of forks 12", 85);
            string expected = product4.Id + " " + product4.Category + " " + product4.Title + " " + product4.Price;
            //Act 
            string result = product4.ToString();
            // Assert
            Assert.AreEqual(result, expected);
        }
        /// <summary>
        ///  Method CompareToTest_Product_Int()
        /// </summary>
        [TestMethod()]
        public void CompareToTest_Product_Int()
        {
            // Arange
            KitchenGoods product4 = new KitchenGoods(4, "Кухонные товары", "Set of forks 12", 85);
            int expected = 1;
            //Act
            var result = product3.CompareTo(product4);
            // Console.WriteLine(result);
            // Assert
            result.Should().Be(expected);
        }
    }
}