﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreGoodsClass;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace StoreGoodsClass.Tests
{
    /// <summary>
    /// Class KitchenGoodsTests
    /// </summary>
    [TestClass()]    
    public class KitchenGoodsTests
    {        
        KitchenGoods tovar1 = new KitchenGoods(1, "Кухонные товары", "Refrigerator 280", 2100);
        /// <summary>
        /// Testing class instantiation
        /// </summary>
        [TestMethod]
        public void KitchenGoods_IdCategpryTitlePrice_CreateObject()
        {
            // Arange           
            KitchenGoods tovar2 = new KitchenGoods(2, "Кухонные товары", "Set of forks 12", 85);
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
            KitchenGoods tovar2 = new KitchenGoods(1, "Кухонные товары", "Set of forks 12", 85);
            KitchenGoods tovar3 = new KitchenGoods(1, "Кухонные товары", "Refrigerator 1040", 1800);

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
        public void OperatorAdd_Tov1Tov2_KitchenGoodsObject()
        {
            // Arange 
            KitchenGoods tovar4 = new KitchenGoods(7, "Кухонные товары", "Refrigerator 280", 2100);
            KitchenGoods tovar5 = new KitchenGoods(8, "Кухонные товары", "Set of forks 12", 85);
            KitchenGoods result = tovar4 + tovar5;
            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Testing the method of converting one type of product to another
        /// </summary>
        [TestMethod]
        public void OperatorKitchenGoods_MobilePhonesTov1_KitchenGoodsObject()
        {
            // Arange 
            MobilePhones tovar7 = new MobilePhones(4, "Мобильные телефоны", "Samsung 3300", 450);
            KitchenGoods expected = new KitchenGoods(4, "Мобильные телефоны", "Samsung 3300", 450);
            //Act 
            KitchenGoods result = (KitchenGoods)tovar7;
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Testing the method of converting one type of product to another
        /// </summary>
        [TestMethod]
        public void OperatorKitchenGoods_ProductsForGardenTov1_KitchenGoodsObject()
        {
            // Arange 
            ProductsForGarden tovar8 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            KitchenGoods expected = new KitchenGoods(1, "Товары для огорода", "Товар 1", 220);
            //Act 
            KitchenGoods result = (KitchenGoods)tovar8;
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
            KitchenGoods tovar2 = new KitchenGoods(2, "Кухонные товары", "Set of forks 12", 85);
            int expected = 8500;
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
            KitchenGoods tovar2 = new KitchenGoods(2, "Кухонные товары", "Set of forks 12", 85);
            double expected = 85.00;
            //Act 
            double result = (double)tovar2;
            // Assert
            result.Should().Be(expected);
        }
    }
}