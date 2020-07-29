using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass
{
    /// <summary>
    /// class KitchenGoods
    /// </summary>
    public class KitchenGoods : StoreGoods
    {
        private const int Kopeek = 100;
        /// <summary>
        /// Property Id
        /// </summary>
        public override int Id { get; set; }
        /// <summary>
        /// Property Category
        /// </summary>
        public override string Category { get; set; }
        /// <summary>
        /// Property Title
        /// </summary>
        public override string Title { get; set; }
        /// <summary>
        ///  Property Price
        /// </summary>
        public override decimal Price { get; set; }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public KitchenGoods() : base()
        {
        }
        /// <summary>
        /// Constructor KitchenGoods(int id, string category, string title, double price) : base(id, category, title, price)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public KitchenGoods(int id, string category, string title, decimal price) : base(id, category, title, price)
        {
            Id = id;
            Category = category;
            Title = title;
            Price = price;
        }
        /// <summary>
        /// Operator +(KitchenGoods tov1, KitchenGoods tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>Returns the sum of two identical products</returns>
        public static KitchenGoods operator +(KitchenGoods tov1, KitchenGoods tov2) 
        {
            return new KitchenGoods
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title + "-" + tov2.Title,
                Price = (tov1.Price + tov2.Price) / 2
            };
        }
        /// <summary>
        /// Operator KitchenGoods(MobilePhones tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator KitchenGoods(MobilePhones tov1) 
        {
            return new KitchenGoods
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title,
                Price = tov1.Price
            };
        }

        /// <summary>
        /// Operator KitchenGoods(ProductsForGarden tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator KitchenGoods(ProductsForGarden tov1)
        {
            return new KitchenGoods
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title,
                Price = tov1.Price
            };
        }

        /// <summary>
        /// Operator int(KitchenGoods tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator int(KitchenGoods tov1)
        { 
           return (int)tov1.Price * Kopeek;
        }

        /// <summary>
        /// operator double(KitchenGoods tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator double(KitchenGoods tov1)
        {
          return (double)tov1.Price;
        }

        /// <summary>
        /// Method ToString(KitchenGoods tov1, KitchenGoods tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>The operation of adding two identical types of goods</returns>
        public static string ToString(KitchenGoods tov1, KitchenGoods tov2)
        {
            string str;
            str = "Сложения двух одинаковых видов товаров: " + tov1.Title + "-" + tov2.Title
                + " Стоимость: " + (tov1.Price + tov2.Price) / 2;
            return str;
        }
        /// <summary>
        /// Method GetHashCode()
        /// </summary>
        /// <returns>Returns the HashCode of the object</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Category, Title, Price);
        }
    }
}
