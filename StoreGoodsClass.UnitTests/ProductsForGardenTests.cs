using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreGoodsClass;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace StoreGoodsClass.Tests
{
    /// <summary>
    /// Class ProductsForGardenTests
    /// </summary>
    [TestClass()]
    public class ProductsForGardenTests
    {
        ProductsForGarden tovar1 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
        /// <summary>
        /// Testing class instantiation
        /// </summary>
        [TestMethod]
        public void ProductsForGarden_IdCategpryTitlePrice_CreateObject()
        {
            // Arange           
            ProductsForGarden tovar2 = new ProductsForGarden(2, "Товары для огорода", "Товар 2", 235);
            // Assert
            Assert.IsNotNull(tovar1);
            Assert.IsNotNull(tovar2);
        }
        /// <summary>
        /// Testing the method of adding two identical types of goods
        /// </summary>
        [TestMethod]
        public void ToString1_Tov1Tov2_String()
        {
            // Arange           
            ProductsForGarden tovar2 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            ProductsForGarden tovar3 = new ProductsForGarden(2, "Товары для огорода", "Товар 2", 235);

            string expected = "Сложения двух одинаковых видов товаров: " + tovar2.Title + "-" + tovar3.Title
                + " Стоимость: " + (tovar2.Price + tovar3.Price) / 2;
            //Act 
            string result = KitchenGoods.ToString(tovar2, tovar3);
            // Assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Testing the addition operator of two identical types
        /// </summary>
        [TestMethod]
        public void OperatorAdd_Tov1Tov2_ProductsForGardenObject()
        {
            // Arange 
            ProductsForGarden tovar4 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            ProductsForGarden tovar5 = new ProductsForGarden(2, "Товары для огорода", "Товар 2", 235);
            ProductsForGarden result = tovar4 + tovar5;
            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Testing the method of converting one type of product to another
        /// </summary>
        [TestMethod]
        public void OperatorProductsForGarden_MobilePhonesTov1_ProductsForGardenObject()
        {
            // Arange 
            MobilePhones tovar7 = new MobilePhones(4, "Мобильные телефоны", "Samsung 3300", 450);
            ProductsForGarden expected = new ProductsForGarden(4, "Мобильные телефоны", "Samsung 3300", 450);
            //Act 
            ProductsForGarden result = (ProductsForGarden)tovar7;
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Testing the method of converting one type of product to another
        /// </summary>
        [TestMethod]
        public void OperatorProductsForGarden_KitchenGoodsTov1_ProductsForGardenObject()
        {
            // Arange 
            KitchenGoods tovar8 = new KitchenGoods(7, "Кухонные товары", "Refrigerator 280", 2100);
            ProductsForGarden expected = new ProductsForGarden(7, "Кухонные товары", "Refrigerator 280", 2100);
            //Act 
            ProductsForGarden result = (ProductsForGarden)tovar8;
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Testing the method of converting the product type to an integer type
        /// </summary>
        [TestMethod]
        public void CastTypeToInteger1_Tov1_Integer()
        {
            // Arange           
            ProductsForGarden tovar2 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            int expected = 22000;
            //Act 
            int result = (int)(tovar2);
            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Testing the method of casting a product type to a real type
        /// </summary>
        [TestMethod]
        public void CastTypeToDouble1_Tov1_Double()
        {
            // Arange           
            ProductsForGarden tovar2 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            double expected = 220.00;
            //Act 
            double result = (double)tovar2;
            // Assert
            result.Should().Be(expected);
        }
    }
}