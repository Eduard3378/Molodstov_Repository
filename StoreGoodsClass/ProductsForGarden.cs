using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass
{
    /// <summary>
    /// Class ProductsForGarden
    /// </summary>
    public class ProductsForGarden : StoreGoods
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
        public ProductsForGarden() : base()
        {
        }
        /// <summary>
        /// Constructor ProductsForGarden(int id, string category, string title, decimal price) : base(id, category, title, price)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public ProductsForGarden(int id, string category, string title, decimal price) : base(id, category, title, price)
        {
            Id = id;
            Category = category;
            Title = title;
            Price = price;
        }
        /// <summary>
        /// Operator +(ProductsForGarden tov1, ProductsForGarden tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>Returns the sum of two identical products</returns>
        public static ProductsForGarden operator +(ProductsForGarden tov1, ProductsForGarden tov2) 
        {
            return new ProductsForGarden
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title + "-" + tov2.Title,
                Price = (tov1.Price + tov2.Price) / 2
            };
        }
        /// <summary>
        ///  ProductsForGarden(MobilePhones tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator ProductsForGarden(MobilePhones tov1) 
        {
            return new ProductsForGarden
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title,
                Price = tov1.Price
            };
        }

        /// <summary>
        /// ProductsForGarden(KitchenGoods tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator ProductsForGarden(KitchenGoods tov1) 
        {
            return new ProductsForGarden
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title,
                Price = tov1.Price
            };
        }

        /// <summary>
        /// Operator int(ProductsForGarden tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator int(ProductsForGarden tov1)
        { 
           return (int)tov1.Price * Kopeek;
        }

        /// <summary>
        /// Operator double(ProductsForGarden tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator double(ProductsForGarden tov1)
        {
            return (double)tov1.Price;
        }

        /// <summary>
        /// Method ToString(ProductsForGarden tov1, ProductsForGarden tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>The operation of adding two identical types of goods</returns>
        public static string ToString(ProductsForGarden tov1, ProductsForGarden tov2)
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
