using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace StoreGoodsClass.UnitTests
{
    /// <summary>
    /// class MobilePhonesTests
    /// </summary>
    [TestClass]
    public class MobilePhonesTests
    {
        MobilePhones tovar1 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2200", 340);
        /// <summary>
        /// Testing class instantiation
        /// </summary>
        [TestMethod]
        public void MobilePhones_IdCategpryTitlePrice_CreateObject()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475);
            // Assert
            Assert.IsNotNull(tovar1);
            Assert.IsNotNull(tovar2);
        }
        /// <summary>
        /// Testing the method of adding two identical types of goods
        /// </summary>
        [TestMethod]
        public void ToString_Tov1Tov2_String()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475);
            MobilePhones tovar3 = new MobilePhones(2, "Мобильные телефоны", "Samsung 3200", 540);
           
            string expected = "Сложения двух одинаковых видов товаров: " + tovar2.Title + "-" + tovar3.Title
                + " Стоимость: " + (tovar2.Price + tovar3.Price) / 2;
            //Act 
            string result = MobilePhones.ToString(tovar2, tovar3);
            // Assert
            Assert.AreEqual(result, expected);           
        }
        /// <summary>
        /// Testing the addition operator of two identical types
        /// </summary>
        [TestMethod]
        public void OperatorAdd_Tov1Tov2_MobilePhonesObject()
        {            
            // Arange 
            MobilePhones tovar4 = new MobilePhones(4, "Мобильные телефоны", "Samsung 3300", 450);
            MobilePhones tovar5 = new MobilePhones(5, "Мобильные телефоны", "Samsung Galaxy", 830);
            MobilePhones result = tovar4 + tovar5;            
            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Testing the method of converting one type of product to another
        /// </summary>
        [TestMethod]        
        public void OperatorMobilePhones_KitchenGoodsTov1_MobilePhonesObject()
        {
            // Arange 
            KitchenGoods tovar7 = new KitchenGoods(7, "Кухонные товары", "Refrigerator 280", 2100);        
            MobilePhones expected = new MobilePhones(7, "Кухонные товары", "Refrigerator 280", 2100);
            //Act 
            MobilePhones result = (MobilePhones)tovar7;
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Testing the method of converting one type of product to another
        /// </summary>
        [TestMethod]
        public void OperatorMobilePhones_ProductsForGardenTov1_MobilePhonesObject()
        {
            // Arange 
            ProductsForGarden tovar8 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            MobilePhones expected = new MobilePhones(1, "Товары для огорода", "Товар 1", 220);
            //Act 
            MobilePhones result = (MobilePhones)tovar8;
            // Assert
            result.Should().Equals(expected);
        }

        /// <summary>
        /// Testing the method of converting the product type to an integer type
        /// </summary>
        [TestMethod]
        public void CastTypeToInteger_Tov1_Integer()
        {
            // Arange           
            MobilePhones tovar9 = new MobilePhones(4, "Мобильные телефоны", "Samsung 2600", 475);
            int expected = 47500;
            //Act 
            int result = (int)tovar9;
            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Testing the method of casting a product type to a real type
        /// </summary>
        [TestMethod]
        public void CastTypeToDouble_Tov1_Double()
        {
            // Arange           
            MobilePhones tovar9 = new MobilePhones(4, "Мобильные телефоны", "Samsung 2600", 475);
            double expected = 475.00;
            //Act 
            double result = (double)tovar9;
            // Assert
            result.Should().Be(expected);
        }
    }
}
