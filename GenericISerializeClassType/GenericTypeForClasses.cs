using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenericISerializeClassType
{
    /// <summary>
    /// Class GenericTypeForClasses<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [XmlType]
    public class GenericTypeForClasses<T> : ICollection<T>
    {
        private const string Filename = "store.xml";      
        static readonly XmlSerializer Serializer = new XmlSerializer(typeof(T[]));
        static readonly DataContractJsonSerializer Serializer1 = new DataContractJsonSerializer(typeof(T[]));
        public static ListClass<T> list;
        private IComparer<T> comparer;
        /// <summary>
        /// Property Count
        /// </summary>
        public int Count
        {
            get;
            protected set;
        }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public GenericTypeForClasses() : this(Comparer<T>.Default)
        {            
        }
        /// <summary>
        /// Constructor GenericTypeForClasses(IComparer<T> defComp)
        /// </summary>
        /// <param name="defComp"></param>
        public GenericTypeForClasses(IComparer<T> defComp)
        {
            comparer = defComp ?? throw new ArgumentNullException("Default comparer is null");
        }
        /// <summary>
        /// Constructor GenericTypeForClasses(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        /// </summary>
        /// <param name="collection"></param>
        public GenericTypeForClasses(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {

        }
        /// <summary>
        /// Constructor GenericTypeForClasses(IEnumerable<T> collection, IComparer<T> defComp) : this(defComp)
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="defComp"></param>
        public GenericTypeForClasses(IEnumerable<T> collection, IComparer<T> defComp) : this(defComp)
        {
            AddRange(collection);
        }
        /// <summary>
        /// Method AddRange(IEnumerable<T> collection)
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);
        }
        /// <summary>
        /// Method SerialToXmlFile(T product)
        /// </summary>
        /// <param name="product"></param>
        public static void SerialToXmlFile(T product)
        {
            ISerialize[] iserialize = new ISerialize[]
             {
                    new MobilePhones(),
                    new KitchenGoods(),
                    new ProductsForGarden()                    
             };
            Type[] types = iserialize.Select(b => b.GetType()).ToArray();            

            foreach (Type t in types)
            {
                Type[] itf = t.GetInterfaces();
                foreach (Type i in itf)
                {                    
                    if (("GenericISerializeClassType"+ '.'+t.Name) == Convert.ToString(product.GetType()))
                    {
                        var products = Products.ToList();
                        products.Add(product);
                        using (var fileStream = new FileStream(Filename, FileMode.Create))
                        {
                            Serializer.Serialize(fileStream, products.ToArray());
                        }
                        break;
                    }                  
                }               
            }            
        }
        /// <summary>
        /// Property Products
        /// </summary>
        public static IEnumerable<T> Products
        {           
            get
            {
                try
                {
                    using (var fileStream = new FileStream(Filename, FileMode.Open))
                    {
                        return (IEnumerable<T>)Serializer.Deserialize(fileStream);
                    }
                }
                catch
                {
                    return Enumerable.Empty<T>();
                }
            }
        }
        /// <summary>
        /// Method SerialToBinaryFile(GenericTypeForClasses<T> typprodclass)
        /// </summary>
        /// <param name="typprodclass"></param>
        public static void SerialToBinaryFile(GenericTypeForClasses<T> typprodclass)
        {            
            string localVersionFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "store1.txt");
            if (File.Exists(localVersionFile))
            {
                string localVersion = null;               
                string serverVersion = "1.0.0.0";
                StreamReader sr = File.OpenText(localVersionFile);
                while (!sr.EndOfStream)
                {
                    string sr1 = sr.ReadLine();                    
                    string pattern = "1"+"." + @"\w+" + "." + @"\w+" + "." + @"\w+";

                    foreach (Match m in Regex.Matches(sr1, pattern, RegexOptions.IgnoreCase))
                    {
                        localVersion = m.Value;                       
                    }                    
                    Console.WriteLine();                    
                }
                sr.Close();
                Console.WriteLine("Текущая версия {0}", localVersion);
                Console.WriteLine();

                if (serverVersion == localVersion)
                {
                    Console.WriteLine("Текущая версия актуальна", localVersion);                    
                }
            }

            ISerialize[] iserialize = new ISerialize[]
             {
                    new MobilePhones(),
                    new KitchenGoods(),
                    new ProductsForGarden()
             };
            Type[] types = iserialize.Select(b => b.GetType()).ToArray();

            foreach (Type t in types)
            {
                Type[] itf = t.GetInterfaces();
                foreach (Type i in itf)
                {                   
                    if (("GenericISerializeClassType" + '.' + "GenericTypeForClasses`1[GenericISerializeClassType."+t.Name+']') 
                            == Convert.ToString(typprodclass.GetType()))
                    {
                        using (var stream = File.Create("store1.txt"))
                        {
                            var formatter = new BinaryFormatter();
                            formatter.Serialize(stream, typprodclass);
                        }
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Disserialization()
        /// </summary>
        public static void Disserialization()
        {
            GenericTypeForClasses<MobilePhones> list34;
            using (var stream = File.OpenRead("store1.txt"))
            {
                var formatter = new BinaryFormatter();
                list34 = (GenericTypeForClasses<MobilePhones>)formatter.Deserialize(stream);
            }
            foreach (MobilePhones product in list34)
            {
                Console.WriteLine("{0} ", product);
            }
        }
        /// <summary>
        /// SerialToJSONFile(T product)
        /// </summary>
        /// <param name="product"></param>
        public static void SerialToJSONFile(T product)
        {
            ISerialize[] iserialize = new ISerialize[]
             {
                    new MobilePhones(),
                    new KitchenGoods(),
                    new ProductsForGarden()                    
             };
            Type[] types = iserialize.Select(b => b.GetType()).ToArray();

            foreach (Type t in types)
            {
                Type[] itf = t.GetInterfaces();
                foreach (Type i in itf)
                {                    
                    if (("GenericISerializeClassType" + '.' + t.Name) == Convert.ToString(product.GetType()))
                    {
                        var products = Products1.ToList();
                        products.Add(product);                       
                        using (var stream1 = new FileStream("store2.json", FileMode.Create))
                        {                           
                            Serializer1.WriteObject(stream1, products.ToArray());
                        }
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Property Products1
        /// </summary>
        public static IEnumerable<T> Products1
        {
            get
            {
                try
                {
                    using (var stream1 = new FileStream("store2.json", FileMode.Open))
                    {                        
                        stream1.Position = 0;
                        return (IEnumerable<T>)Serializer1.ReadObject(stream1);
                    }
                }
                catch
                {
                    return Enumerable.Empty<T>();
                }
            }
        }
        public bool IsReadOnly => throw new NotImplementedException();
        /// <summary>
        /// Method Add(T item)
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {            
            var collection1 = new ListClass<T>(item);
           
            if (list == null)
            {
                list = collection1;
            }
            else
            {
                ListClass<T> current = list, parent = null;
                while (current != null)
                {
                    parent = current;
                    if (comparer.Compare(item, current.Value) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
                if (comparer.Compare(item, parent.Value) < 0)
                    parent.Left = collection1;
                else
                    parent.Right = collection1;
            }
            ++Count;           
        }
        /// <summary>
        /// Method Clear()
        /// </summary>
        public void Clear()
        {
            if (list != null)
            {
                list = null;
                comparer = null;
            }
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method CollectionTraversal()
        /// </summary>
        /// <returns>Tree traversal</returns>
        public IEnumerable<T>CollectionTraversal()
        {            
            if (list == null)
                yield break;
            var stack = new Stack<ListClass<T>>();
            var collection1 = list;
            while (stack.Count > 0 || collection1 != null)
            {
                if (collection1 == null)
                {
                    collection1 = stack.Pop();
                    yield return collection1.Value;
                    collection1 = collection1.Right;
                }
                else
                {
                    stack.Push(collection1);
                    collection1 = collection1.Left;
                }
            }
        }
        /// <summary>
        /// Method GetEnumerator()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return CollectionTraversal().GetEnumerator();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method IEnumerable.GetEnumerator()
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }        
    }    
}
