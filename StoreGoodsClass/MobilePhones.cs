﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass
{
    /// <summary>
    /// Class MobilePhones
    /// </summary>
    public class MobilePhones : StoreGoods
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
        /// Property Price
        /// </summary>
        public override decimal Price { get; set; }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public MobilePhones() : base()
        {
        }
        /// <summary>
        /// Constructor MobilePhones(int id, string category, string title, double price) : base(id, category, title, price)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public MobilePhones(int id, string category, string title, decimal price) : base(id, category, title, price)
        {
            Id = id;
            Category = category;
            Title = title;
            Price = price;
        }

        /// <summary>
        /// Operator +(MobilePhones tov1, MobilePhones tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>Returns the sum of two identical products</returns>
        public static MobilePhones operator +(MobilePhones tov1, MobilePhones tov2)
        {
            return new MobilePhones
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title + "-" + tov2.Title,
                Price = (tov1.Price + tov2.Price) / 2
            };           
        }

        /// <summary>
        /// Operator MobilePhones(KitchenGoods tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator MobilePhones(KitchenGoods tov1)
        {
            return new MobilePhones
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title,
                Price = tov1.Price
            };
        }

        /// <summary>
        ///  MobilePhones(ProductsForGarden tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator MobilePhones(ProductsForGarden tov1) 
        {
            return new MobilePhones
            {
                Id = tov1.Id,
                Category = tov1.Category,
                Title = tov1.Title,
                Price = tov1.Price
            };
        }

        /// <summary>
        /// Operator int(MobilePhones tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator int(MobilePhones tov1)
        {
           return (int)tov1.Price * Kopeek;
        }

        /// <summary>
        /// Operator double(MobilePhones tov1)
        /// </summary>
        /// <param name="tov1"></param>
        public static explicit operator double(MobilePhones tov1)
        {
          return  (double)tov1.Price;
        }

        /// <summary>
        /// Method ToString(MobilePhones tov1, MobilePhones tov2)
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>The operation of adding two identical types of goods</returns>
        public static string ToString(MobilePhones tov1, MobilePhones tov2)
        {
            string str;
            str = "Сложения двух одинаковых видов товаров: " + tov1.Title + "-" + tov2.Title
                + " Стоимость: " + (tov1.Price + tov2.Price) / 2;
            return str;
        }

        /// <summary>
        /// Метод GetHashCode()
        /// </summary>
        /// <returns>Returns the HashCode of the object</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Category, Title, Price);
        }
    }
}
