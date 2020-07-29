using System;

namespace StoreGoodsClass
{
    /// <summary>
    /// class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ProductsForGarden tovar1 = new ProductsForGarden(1, "Товары для огорода", "Товар 1", 220);
            ProductsForGarden tovar2 = new ProductsForGarden(2, "Товары для огорода", "Товар 2", 235);
            ProductsForGarden tovar3 = new ProductsForGarden(3, "Товары для огорода", "Товар 3", 240);
            MobilePhones tovar4 = new MobilePhones(4, "Мобильные телефоны", "Samsung 3300", 450);
            MobilePhones tovar5 = new MobilePhones(5, "Мобильные телефоны", "Samsung Galaxy", 830);
            MobilePhones tovar6 = new MobilePhones(6, "Мобильные телефоны", "Nokia 2100", 520);
            KitchenGoods tovar7 = new KitchenGoods(7, "Кухонные товары", "Refrigerator 280", 2100);
            KitchenGoods tovar8 = new KitchenGoods(8, "Кухонные товары", "Set of forks 12", 85);
            KitchenGoods tovar9 = new KitchenGoods(9, "Кухонные товары", "Refrigerator 1040", 1800);


            Console.WriteLine("Сложения двух одинаковых видов товаров ");
            Console.WriteLine(MobilePhones.ToString(tovar4, tovar5));
            Console.WriteLine(KitchenGoods.ToString(tovar8, tovar9));
            MobilePhones tovar10 =  tovar4 + tovar5;
            Console.WriteLine("Сложения двух одинаковых видов товаров: " + tovar10.Id + " " + tovar10.Category + " "
                + tovar10.Title + " " + tovar10.Price);
            KitchenGoods tovar11 = tovar7 + tovar8;
            Console.WriteLine("Сложения двух одинаковых видов товаров: " + tovar11.Id + " " + tovar11.Category + " "
                + tovar11.Title + " " + tovar11.Price);
            ProductsForGarden tovar12 = tovar1 + tovar2;
            Console.WriteLine("Сложения двух одинаковых видов товаров: " + tovar12.Id + " " + tovar12.Category + " "
                + tovar12.Title + " " + tovar12.Price);

            Console.WriteLine("Приведения одного типа товара к другому");
            MobilePhones tovar13 = new MobilePhones();
            tovar13 = (MobilePhones)tovar7;
            Console.WriteLine(tovar13 + " " + tovar13.Id + " " + tovar13.Category + " "
                + tovar13.Title + " " + tovar13.Price);
            MobilePhones tovar14 = new MobilePhones();
            tovar14 = (MobilePhones)tovar1;
            Console.WriteLine(tovar14 + " " + tovar14.Id + " " + tovar14.Category + " "
                + tovar14.Title + " " + tovar14.Price);
            KitchenGoods tovar15 = new KitchenGoods();
            tovar15 = (KitchenGoods)tovar4;
            Console.WriteLine(tovar15 + " " + tovar15.Id + " " + tovar15.Category + " "
                + tovar15.Title + " " + tovar15.Price);
            KitchenGoods tovar16 = new KitchenGoods();
            tovar16 = (KitchenGoods)tovar2;
            Console.WriteLine(tovar16 + " " + tovar16.Id + " " + tovar16.Category + " "
                + tovar16.Title + " " + tovar16.Price);
            ProductsForGarden tovar17 = new ProductsForGarden();
            tovar17 = (ProductsForGarden)tovar5;
            Console.WriteLine(tovar17 + " " + tovar17.Id + " " + tovar17.Category + " "
                + tovar17.Title + " " + tovar17.Price);
            ProductsForGarden tovar18 = new ProductsForGarden();
            tovar18 = (ProductsForGarden)tovar8;
            Console.WriteLine(tovar18 + " " + tovar18.Id + " " + tovar18.Category + " "
                + tovar18.Title + " " + tovar18.Price);

            Console.WriteLine("Предусмотреть возможность приведения типа товара к целочисленному (цена возвращается в копейках)");            
            int kop = (int)tovar4;
            Console.WriteLine(kop);
            int kop1 = (int)tovar7;
            Console.WriteLine(kop1);
            int kop2 = (int)tovar1;
            Console.WriteLine(kop2);

            Console.WriteLine("Предусмотреть возможность приведения типа товара к вещественному");
            double realtype = (double)tovar5;
            Console.WriteLine($"{realtype:f2}");
            double realtype1 = (double)tovar8;
            Console.WriteLine($"{realtype1:f2}");
            double realtype2 = (double)tovar2;
            Console.WriteLine($"{realtype2:f2}");


            Console.ReadKey();

        }
    }
}
