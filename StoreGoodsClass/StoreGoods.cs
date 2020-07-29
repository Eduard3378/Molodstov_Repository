using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass
{
    /// <summary>
    /// class StoreGoods
    /// </summary>
    public class StoreGoods
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Property Category
        /// </summary>
        public virtual string Category { get; set; }
        /// <summary>
        /// Property Title
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// Property Price
        /// </summary>
        public virtual decimal Price { get; set; }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public StoreGoods()
        {
        }
        /// <summary>
        /// Constructor StoreGoods(int id, string category, string title, double price)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public StoreGoods(int id, string category, string title, decimal price)
        {
            Id = id;
            Category = category;
            Title = title;
            Price = price;
        }
        /// <summary>
        /// Method ToString(StoreGoods tov1, StoreGoods tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>The operation of adding two identical types of goods</returns>
        public static string ToString(StoreGoods tov1, StoreGoods tov2)
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
