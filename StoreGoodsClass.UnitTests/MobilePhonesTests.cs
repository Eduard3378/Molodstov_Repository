using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StoreGoodsClass.UnitTests
{
    [TestClass]
    public class MobilePhonesTests
    {
        MobilePhones tovar1 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2200", 340.75);
        [TestMethod]
        public void MobilePhones_IdCategpryTitlePrice_CreateObject()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475.40);
            // Assert
            Assert.IsNotNull(tovar1);
            Assert.IsNotNull(tovar2);
        }
        [TestMethod]
        public void ToString_Tov1Tov2_String()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475.40);
            MobilePhones tovar3 = new MobilePhones(2, "Мобильные телефоны", "Samsung 3200", 540.20);
           
            string expected = "Сложения двух одинаковых видов товаров: " + tovar2.Title + "-" + tovar3.Title
                + " Стоимость: " + (tovar2.Price + tovar3.Price) / 2;
            //Act 
            string result = MobilePhones.ToString(tovar2, tovar3);
            // Assert
            Assert.AreEqual(result, expected);           
        }
        [TestMethod]
        public void BringingOneTypeToAnother_Tov1Tov2_MobilePhonesObject()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475.40);            
            KitchenGoods tovar3 = new KitchenGoods(4, "Кухонные товары", "Refrigerator 280", 2100.45);                      
            MobilePhones expected = new MobilePhones(1, "Мобильные телефоны", "Refrigerator 280", 475.40);
            //Act 
            MobilePhones result = MobilePhones.BringingOneTypeToAnother(tovar3, tovar2);           
            // Assert
            Assert.AreEqual(result.Title, expected.Title);
        }

        [TestMethod]
        public void CastTypeToInteger_Tov1_Integer()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475.40);           
            int expected = 47540;
            //Act 
            int result = MobilePhones.CastTypeToInteger(tovar2);
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CastTypeToDouble_Tov1_Double()
        {
            // Arange           
            MobilePhones tovar2 = new MobilePhones(1, "Мобильные телефоны", "Samsung 2600", 475);
            double expected = 475.00;
            //Act 
            double result = MobilePhones.CastTypeToDouble(tovar2);
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
