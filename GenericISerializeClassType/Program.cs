using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace GenericISerializeClassType
{
    /// <summary>
    /// Class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //The collection list
            MobilePhones product1 = new MobilePhones(1, "Мобильные телефоны", "Samsung 3300", 450);
            MobilePhones product2 = new MobilePhones(2, "Мобильные телефоны", "Samsung Galaxy1", 830);
            MobilePhones product7 = new MobilePhones(7, "Мобильные телефоны", "Samsung Galaxy99", 835);
            KitchenGoods product3 = new KitchenGoods(3, "Кухонные товары", "Refrigerator 280", 2100);
            KitchenGoods product4 = new KitchenGoods(4, "Кухонные товары", "Set of forks 12", 85);
            ProductsForGarden product5 = new ProductsForGarden(5, "Товары для огорода", "Товар 1", 220);
            ProductsForGarden product6 = new ProductsForGarden(6, "Товары для огорода", "Товар 2", 235);
            //Collection of goods
            List<MobilePhones> productList = new List<MobilePhones>
            {
                product1,
                product2,
                product7
            };
            //Creating a native generic type
            GenericTypeForClasses<MobilePhones> typprodclass = new GenericTypeForClasses<MobilePhones>(productList);
            //Inference of generic type MobilePhones
            foreach (MobilePhones product in typprodclass)
            {
                Console.WriteLine("{0} ", product);
            }
            Console.WriteLine();
            //Collection of goods
            List<KitchenGoods> productList1 = new List<KitchenGoods>
            {
                product3,
                product4
            };
            //Creating a native generic type
            GenericTypeForClasses<KitchenGoods> typprodclass1 = new GenericTypeForClasses<KitchenGoods>(productList1);
            //Inference of generic type KitchenGoods
            foreach (KitchenGoods product in typprodclass1)
            {
                Console.WriteLine("{0} ", product);
            }
            Console.WriteLine();

            List<ProductsForGarden> productList2 = new List<ProductsForGarden>
            {
                product5,
                product6
            };
            GenericTypeForClasses<ProductsForGarden> typprodclass2 = new GenericTypeForClasses<ProductsForGarden>(productList2);
            foreach (ProductsForGarden product in typprodclass2)
            {
                Console.WriteLine("{0} ", product);
            }
            Console.WriteLine();

            System.IO.File.Delete("store.xml");
            Console.WriteLine("Сериализация в XmlFile");
            foreach (MobilePhones pr in typprodclass)
            {
                GenericTypeForClasses<MobilePhones>.SerialToXmlFile(pr);
            }
            //foreach (KitchenGoods pr in typprodclass1)
            //{
            //    GenericTypeForClasses<KitchenGoods>.SerialToXmlFile(pr);
            //}
            // GenericTypeForClasses<ProductsForGarden>.SerialToXmlFile(product6);
            //StoreGoods product8 = new StoreGoods(7, "Товар базового класса", "Товар 3", 245);
            //GenericTypeForClasses<StoreGoods>.SerialToXmlFile(product8);

            Console.WriteLine("XML файл после десерилизации");
            string localVersionFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "store.xml");
            if (File.Exists(localVersionFile))
            {
                string localVersion = null;
                string serverVersion = "1.0";
                StreamReader sr = File.OpenText(localVersionFile);
                while (!sr.EndOfStream)
                {
                    string sr1 = sr.ReadLine();                  
                    string pattern = "\"1" + "." + @"\w+";
                    foreach (Match m in Regex.Matches(sr1, pattern, RegexOptions.IgnoreCase))
                    {
                        localVersion = m.Value;                  
                    }                   
                }
                sr.Close();
                localVersion = localVersion.Replace("\"", "");
                Console.WriteLine("Текущая версия {0}", localVersion);
                Console.WriteLine();
                if (serverVersion == localVersion)
                {
                    Console.WriteLine("Текущая версия актуальна", localVersion);
                }
            }

            IEnumerable<MobilePhones> pr2 = GenericTypeForClasses<MobilePhones>.Products;
            productList.Clear();
            productList = pr2.ToList();
            Console.WriteLine("");
            foreach (MobilePhones product32 in productList)
            {
                Console.WriteLine("{0} ", product32);
            }
            Console.WriteLine();
            productList.Clear();
            //   typprodclass.Clear();
            //IEnumerable<KitchenGoods> pr2 = GenericTypeForClasses<KitchenGoods>.Products;
            //productList1.Clear();
            //productList1 = pr2.ToList();
            //Console.WriteLine("");
            //foreach (KitchenGoods product32 in productList1)
            //{
            //    Console.WriteLine("{0} ", product32);
            //}
            //Console.WriteLine();
            //productList.Clear();
            //typprodclass1.Clear();
            System.IO.File.Delete("store1.xml");

            Console.WriteLine("Сериализация в бинарный файл");           
            GenericTypeForClasses<MobilePhones>.SerialToBinaryFile(typprodclass);

            Console.WriteLine("Бинарный файл после десерилизации");
            GenericTypeForClasses<MobilePhones>.Disserialization();
            //StoreGoods product8 = new StoreGoods(7, "Товар базового класса", "Товар 3", 245);
            //List<StoreGoods> productList8 = new List<StoreGoods>
            //{
            //    product8
            //};
            //GenericTypeForClasses<StoreGoods> typprodclass3 =
            //    new GenericTypeForClasses<StoreGoods>(productList8);
            //GenericTypeForClasses<StoreGoods>.SerialToBinaryFile(typprodclass3);
            //Console.WriteLine("Бинарный файл после десерилизации");
            //GenericTypeForClasses<StoreGoods>.Disserialization();
            System.IO.File.Delete("store2.json");

            Console.WriteLine("Сериализация в текстовый файл в формате JSON ");
            GenericTypeForClasses<MobilePhones> typprodclass22 = new GenericTypeForClasses<MobilePhones>(productList);
            //foreach (MobilePhones product in typprodclass22)
            //{
            //    Console.WriteLine("{0} ", product);
            //}
            //Console.WriteLine();
            foreach (MobilePhones pr in typprodclass22)
            {
                GenericTypeForClasses<MobilePhones>.SerialToJSONFile(pr);
            }

            //foreach (KitchenGoods pr in typprodclass1)
            //{
            //    GenericTypeForClasses<KitchenGoods>.SerialToJSONFile(pr);
            //}

            //StoreGoods product8 = new StoreGoods(7, "Товар базового класса", "Товар 3", 245);
            //GenericTypeForClasses<StoreGoods>.SerialToJSONFile(product8);
            //List<StoreGoods> productList23 = new List<StoreGoods>
            //{
            //    product8
            //};

            Console.WriteLine("JSONFile файл после десерилизации");

            IEnumerable<MobilePhones> pr22 = GenericTypeForClasses<MobilePhones>.Products1;
            productList.Clear();
            productList = pr22.ToList();
            Console.WriteLine("");
            foreach (MobilePhones product32 in productList)
            {
                Console.WriteLine("{0} ", product32);
            }
            Console.WriteLine();
            productList.Clear();
            typprodclass22.Clear();
            //productList1.Clear();
            //typprodclass1.Clear();

            //IEnumerable<KitchenGoods> pr22 = GenericTypeForClasses<KitchenGoods>.Products1;
            //productList1.Clear();
            //productList1 = pr22.ToList();
            //Console.WriteLine("");
            //foreach (KitchenGoods product32 in productList1)
            //{
            //    Console.WriteLine("{0} ", product32);
            //}
            //Console.WriteLine();
            //productList.Clear();
            //typprodclass1.Clear();

            //IEnumerable<StoreGoods> pr23 = GenericTypeForClasses<StoreGoods>.Products1;
            //productList23.Clear();
            //productList23 = pr23.ToList();
            //Console.WriteLine("");
            //foreach (StoreGoods product32 in productList23)
            //{
            //    Console.WriteLine("{0} ", product32);
            //}
            //Console.WriteLine();
            //productList23.Clear();

            Console.ReadKey();
        }       
    }
}
