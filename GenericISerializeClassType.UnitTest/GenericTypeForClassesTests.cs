using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericISerializeClassType;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.Linq;

namespace GenericISerializeClassType.Tests
{
    /// <summary>
    /// Class GenericTypeForClassesTests
    /// </summary>
    [TestClass()]
    public class GenericTypeForClassesTests
    {
        //The collection list
        static MobilePhones product1 = new MobilePhones(1, "Мобильные телефоны", "Samsung 3300", 450);
        static MobilePhones product2 = new MobilePhones(2, "Мобильные телефоны", "Samsung Galaxy1", 830);
        static MobilePhones product7 = new MobilePhones(7, "Мобильные телефоны", "Samsung Galaxy99", 835);
        static  KitchenGoods product3 = new KitchenGoods(3, "Кухонные товары", "Refrigerator 280", 2100);
        static KitchenGoods product4 = new KitchenGoods(4, "Кухонные товары", "Set of forks 12", 85);
        //Collection of goods
        static List<MobilePhones> productList = new List<MobilePhones>
            {
                product1,
                product2,
                product7
            };
        //Creating a native generic type
        GenericTypeForClasses<MobilePhones> typprodclass = new GenericTypeForClasses<MobilePhones>(productList);
        //Collection of goods
       static List<KitchenGoods> productList1 = new List<KitchenGoods>
            {
                product3,
                product4
            };
        //Creating a native generic type
        GenericTypeForClasses<KitchenGoods> typprodclass1 = new GenericTypeForClasses<KitchenGoods>(productList1);
        /// <summary>
        ///  Method GenericTypeForClasses_Collection_CreateObject()
        /// </summary>
        [TestMethod()]
        public void GenericTypeForClasses_Collection_CreateObject()
        {
            // Arange           
            GenericTypeForClasses<MobilePhones> typprodclass2 = new GenericTypeForClasses<MobilePhones>(productList);
            // Assert
            Assert.IsNotNull(typprodclass);
            Assert.IsNotNull(typprodclass2);
        }
        /// <summary>
        /// Method AddRange_Collection_Add()
        /// </summary>
        [TestMethod()]
        public void AddRange_Collection_Add()
        {
            // Arange 
            GenericTypeForClasses<KitchenGoods> typprodclass3 = new GenericTypeForClasses<KitchenGoods>();
            typprodclass3.AddRange(productList1);
            productList1.Clear();
            typprodclass1.Clear();
        }
        /// <summary>
        /// Method Add_TItem_Root()
        /// </summary>
        [TestMethod()]
        public void Add_TItem_Root()
        {
            // Arange
            GenericTypeForClasses<KitchenGoods> typprodclass4 = new GenericTypeForClasses<KitchenGoods>();
          //  Student1 student6 = new Student1("Medvedev", "Physics", new DateTime(2020, 7, 5), 6);
            KitchenGoods product3 = new KitchenGoods(3, "Кухонные товары", "Refrigerator 280", 2100);
            var expected = product3;
            typprodclass4.Add(product3);
            //Act
            var result = typprodclass4.ElementAt(0);
            // Assert
            result.Should().Be(expected);
        }
        /// <summary>
        /// Method Clear_Collection_Empty()
        /// </summary>
        [TestMethod()]
        public void Clear_Collection_Empty()
        {
            // Arange 
            productList.Clear();
            //Act
            List<MobilePhones> result = productList;
            // Assert
            result.Should().BeEmpty(null);
        }
        /// <summary>
        /// Method SerialToXmlFile_TProduct_File()
        /// </summary>
        [TestMethod()]
        public void SerialToXmlFile_TProduct_File()
        {
            // Arange
            //Creating a native generic type          
            System.IO.File.Delete("store.xml");
            Console.WriteLine("Сериализация в XmlFile");
            foreach (KitchenGoods pr in typprodclass1)
            {
                GenericTypeForClasses<KitchenGoods>.SerialToXmlFile(pr);
            }
        }
        /// <summary>
        /// Method Products_Product_Deserialize()
        /// </summary>
        [TestMethod()]
        public void Products_Product_Deserialize()
        {
            Console.WriteLine("XML файл после десерилизации");
            IEnumerable<KitchenGoods> pr2 = GenericTypeForClasses<KitchenGoods>.Products;
            productList1.Clear();
            productList1 = pr2.ToList();
            Console.WriteLine("");
            foreach (KitchenGoods product32 in productList1)
            {
                Console.WriteLine("{0} ", product32);
            }
            Console.WriteLine();
            productList.Clear();
            typprodclass1.Clear();
        }
        /// <summary>
        /// Method SerialToBinaryFile_Collection_File()
        /// </summary>
        [TestMethod()]
        public void SerialToBinaryFile_Collection_File()
        {
            GenericTypeForClasses<MobilePhones>.SerialToBinaryFile(typprodclass);
        }
        /// <summary>
        /// Method Disserialization_Collection_Deserialize()
        /// </summary>
        [TestMethod()]
        public void Disserialization_Collection_Deserialize()
        {
            GenericTypeForClasses<MobilePhones>.Disserialization();
        }
        /// <summary>
        /// Method SerialToJSONFile__TProduct_File()
        /// </summary>
        [TestMethod()]
        public void SerialToJSONFile__TProduct_File()
        {
            System.IO.File.Delete("store2.json");
            Console.WriteLine("Сериализация в текстовый файл в формате JSON ");
            foreach (KitchenGoods pr in typprodclass1)
            {
                GenericTypeForClasses<KitchenGoods>.SerialToJSONFile(pr);
            }
        }
        /// <summary>
        /// Method Products1_Product_Deserialize()
        /// </summary>
        [TestMethod()]
        public void Products1_Product_Deserialize()
        {
            Console.WriteLine("JSONFile файл после десерилизации");
            IEnumerable<KitchenGoods> pr22 = GenericTypeForClasses<KitchenGoods>.Products1;
            productList1.Clear();
            productList1 = pr22.ToList();
            Console.WriteLine("");
            foreach (KitchenGoods product32 in productList1)
            {
                Console.WriteLine("{0} ", product32);
            }
            Console.WriteLine();
            productList.Clear();
            typprodclass1.Clear();
        }
        /// <summary>
        /// Method CollectionTraversal_List_Collection1()
        /// </summary>
        [TestMethod()]
        public void CollectionTraversal_List_Collection1()
        {
            // Arange             
            //Creating a native generic type
            GenericTypeForClasses<MobilePhones> typprodclass = new GenericTypeForClasses<MobilePhones>(productList);
            typprodclass.CollectionTraversal();
        }
        /// <summary>
        /// Method GetEnumeratorTest_Collection_IEnumerator<T>()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [TestMethod()]
        public void GetEnumeratorTest_Collection_IEnumerator<T>()
        {
            // Arange 
            GenericTypeForClasses<MobilePhones> typprodclass = new GenericTypeForClasses<MobilePhones>(productList);
            typprodclass.GetEnumerator();
        }
    }
}