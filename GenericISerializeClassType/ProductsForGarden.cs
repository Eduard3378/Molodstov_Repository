﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace GenericISerializeClassType
{
    /// <summary>
    /// Class ProductsForGarden
    /// </summary>
    [DataContract]
    [Serializable]
    [XmlType]
    public class ProductsForGarden : IComparable<ProductsForGarden>, ISerialize
    {
        private const int Kopeek = 100;
        /// <summary>
        /// Property Id
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Property Category
        /// </summary>
        [DataMember]
        public string Category { get; set; }
        /// <summary>
        /// Property Title
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        ///  Property Price
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }       
        /// <summary>
        /// Empty constructor
        /// </summary>
        public ProductsForGarden() 
        {
        }
        /// <summary>
        /// Constructor ProductsForGarden(int id, string category, string title, decimal price) : base(id, category, title, price)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public ProductsForGarden(int id, string category, string title, decimal price) 
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
        /// <summary>
        /// Method CompareTo(ProductsForGarden other)
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Implementation of the IComparable interface</returns>
        public int CompareTo(ProductsForGarden other)
        {
            return Price.CompareTo(other.Price);
        }
    }
}