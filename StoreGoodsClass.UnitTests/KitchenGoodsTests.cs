using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreGoodsClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass.Tests
{
    [TestClass()]
    public class KitchenGoodsTests
    {
        KitchenGoods tovar1 = new KitchenGoods(1, "Кухонные товары", "Refrigerator 280", 2100.45);
        [TestMethod]
        public void MobilePhones1_IdCategpryTitlePrice_CreateObject()
        {
            // Arange           
            KitchenGoods tovar2 = new KitchenGoods(2, "Кухонные товары", "Set of forks 12", 85.12);
            // Assert
            Assert.IsNotNull(tovar1);
            Assert.IsNotNull(tovar2);
        }
        [TestMethod]
        public void ToString1_Tov1Tov2_String()
        {
            // Arange           
            KitchenGoods tovar2 = new KitchenGoods(1, "Кухонные товары", "Set of forks 12", 85.12);
            KitchenGoods tovar3 = new KitchenGoods(1, "Кухонные товары", "Refrigerator 1040", 1800.85);

            string expected = "Сложения двух одинаковых видов товаров: " + tovar2.Title + "-" + tovar3.Title
                + " Стоимость: " + (tovar2.Price + tovar3.Price) / 2;
            //Act 
            string result = KitchenGoods.ToString(tovar2, tovar3);
            // Assert
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void BringingOneTypeToAnother1_Tov1Tov2_MobilePhonesObject()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475.40);
            KitchenGoods tovar3 = new KitchenGoods(2, "Кухонные товары", "Refrigerator 280", 2100.45);
            KitchenGoods expected = new KitchenGoods(2, "Кухонные товары", "Samsung 2600", 2100.45);
            //Act 
            KitchenGoods result = KitchenGoods.BringingOneTypeToAnother(tovar2, tovar3);
            // Assert
            Assert.AreEqual(result.Title, expected.Title);
        }

        [TestMethod]
        public void CastTypeToInteger1_Tov1_Integer()
        {
            // Arange           
            KitchenGoods tovar2 = new KitchenGoods(2, "Кухонные товары", "Set of forks 12", 85.12);
            int expected = 8512;
            //Act 
            int result = KitchenGoods.CastTypeToInteger(tovar2);
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CastTypeToDouble1_Tov1_Double()
        {
            // Arange           
            KitchenGoods tovar2 = new KitchenGoods(2, "Кухонные товары", "Set of forks 12", 85);
            double expected = 85.00;
            //Act 
            double result = KitchenGoods.CastTypeToDouble(tovar2);
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}