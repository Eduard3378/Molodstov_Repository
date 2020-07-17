using System;
using System.Collections.Generic;
using System.Text;

namespace StoreGoodsClass
{
    public class StoreGoods
    {        
        public virtual int Id { get; set; }
        public virtual string Category { get; set; }
        public virtual string Title { get; set; }
        public virtual double Price { get; set; }
        public StoreGoods()
        {           
        }
        public StoreGoods(int id, string category, string title, double price)
        {
            Id = id;
            Category = category;
            Title = title;
            Price = price;
        }

        public static string ToString(StoreGoods tov1, StoreGoods tov2)
        {
            string str;
            str = "Сложения двух одинаковых видов товаров: " + tov1.Title + "-" + tov2.Title
                + " Стоимость: " + (tov1.Price + tov2.Price) / 2;
            return str;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
