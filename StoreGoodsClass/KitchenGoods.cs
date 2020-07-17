using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass
{
    public class KitchenGoods : StoreGoods
    {
        public override int Id { get; set; }
        public override string Category { get; set; }
        public override string Title { get; set; }
        public override double Price { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public KitchenGoods() : base()
        {
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public KitchenGoods(int id, string category, string title, double price) : base(id, category, title, price)
        {
            Id = id;
            Category = category;
            Title = title;
            Price = price;
        }
        /// <summary>
        /// Метод ToString(MobilePhones tov1, MobilePhones tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>Операция сложения двух одинаковых видов товаров</returns>
        public static string ToString(KitchenGoods tov1, KitchenGoods tov2)
        {
            string str;
            str = "Сложения двух одинаковых видов товаров: " + tov1.Title + "-" + tov2.Title
                + " Стоимость: " + (tov1.Price + tov2.Price) / 2;
            return str;
        }
        /// <summary>
        /// Метод GetHashCode()
        /// </summary>
        /// <returns>Возвращает HashCode объекта</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        /// <summary>
        /// Метод BringingOneTypeToAnother(StoreGoods tov1, MobilePhones tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>Приведения одного типа товара к другому </returns>
        public static KitchenGoods BringingOneTypeToAnother(StoreGoods tov1, KitchenGoods tov2)
        {
            KitchenGoods tov3 = new KitchenGoods(tov2.Id, tov2.Category, tov2.Title, tov2.Price);
            tov3.Title = tov1.Title;
            return tov3;
        }
        /// <summary>
        /// Метод CastTypeToInteger(StoreGoods tov1)
        /// </summary>
        /// <param name="tov1"></param>
        /// <returns>Приведение типа товара к целочисленному (цена возвращается в копейках)</returns>
        public static int CastTypeToInteger(StoreGoods tov1)
        {
            int price = 0;
            int rubles = 0;
            double pennies = 0.0;
            rubles = ((int)tov1.Price);            
            pennies = (tov1.Price - (double)rubles)*100;
            pennies = Math.Round(pennies, 2);           
            price = (int)(rubles * 100) + (int)pennies;
            return price;
        }
        /// <summary>
        /// CastTypeToDouble(StoreGoods tov1)
        /// </summary>
        /// <param name="tov1"></param>
        /// <returns>Приведение к вещественному типу </returns>
        public static double CastTypeToDouble(StoreGoods tov1)
        {
            return tov1.Price;
        }
    }
}
