using System;

namespace StoreGoodsClass
{
    class Program
    {
        static void Main(string[] args)
        {
            MobilePhones tovar1 = new MobilePhones(1, "Мобильные телефоны", "Samsung 3300", 450.99);
            MobilePhones tovar2 = new MobilePhones(2, "Мобильные телефоны", "Samsung Galaxy", 830.75);
            MobilePhones tovar3 = new MobilePhones(3, "Мобильные телефоны", "Nokia 2100", 520.25);
            KitchenGoods tovar4 = new KitchenGoods(4, "Кухонные товары", "Refrigerator 280", 2100.05);
            KitchenGoods tovar5 = new KitchenGoods(5, "Кухонные товары", "Set of forks 12", 85.12);
            KitchenGoods tovar6 = new KitchenGoods(6, "Кухонные товары", "Refrigerator 1040", 1800.85);

            Console.WriteLine(MobilePhones.ToString(tovar1, tovar2));
            Console.WriteLine(KitchenGoods.ToString(tovar5, tovar6));

            MobilePhones tov7 = new MobilePhones();
            tov7 = MobilePhones.BringingOneTypeToAnother(tovar4, tovar3);
            Console.WriteLine("После приведения типа товара3 к типу товара4: " + tov7.Id + " " 
                + tov7.Category + " "  + tov7.Title + " "  + tov7.Price);

            string str =  MobilePhones.CastTypeToInteger(tovar3).ToString();
            Console.WriteLine("Цена товара3 в копейках: " + str);

            string str1 = KitchenGoods.CastTypeToInteger(tovar4).ToString();
            Console.WriteLine("Цена товара4 в копейках: " + str1);

            MobilePhones tovar7 = new MobilePhones(7, "Мобильные телефоны", "Huawai P30", 550);
            double str2 = MobilePhones.CastTypeToDouble(tovar7);          
            Console.WriteLine($"Цена товара7 после приведения к вещественному типу: {str2:f2}");
            KitchenGoods tovar8 = new KitchenGoods(8, "Кухонные товары", "Set of spoons 24", 92);
            double str3 = KitchenGoods.CastTypeToDouble(tovar8);          
            Console.WriteLine($"Цена товара8 после приведения к вещественному типу: {str3:f2}");
            Console.ReadKey();

        }
    }
}
