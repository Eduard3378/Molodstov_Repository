using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace GenericISerializeClassType
{
    /// <summary>
    /// Class StoreGoods
    /// </summary>
    [DataContract]
    [Serializable]
    [XmlType]
    public class StoreGoods
    {
        /// <summary>
        /// Property Id
        /// </summary>
        [DataMember]
        public virtual int Id { get; set; }
        /// <summary>
        /// Property Category
        /// </summary>
        [DataMember]
        public virtual string Category { get; set; }
        /// <summary>
        /// Property Title
        /// </summary>
        [DataMember]
        public virtual string Title { get; set; }
        /// <summary>
        /// Property Price
        /// </summary>
        [DataMember]
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
        /// Method ToString()
        /// </summary>
        /// <param name="tov1"></param>
        /// <param name="tov2"></param>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            string str = Id + " " + Category + " " + Title + " " + Price;
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
