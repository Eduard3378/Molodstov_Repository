using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericISerializeClassType
{
    /// <summary>
    /// Class ListClass<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListClass<T>
    {
        /// <summary>
        /// Property T Value { get; set; }
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Property Left { get; set; }
        /// </summary>
        public ListClass<T> Left { get; set; }
        /// <summary>
        /// Property Right { get; set; }
        /// </summary>
        public ListClass<T> Right { get; set; }
        /// <summary>
        /// Constructor ListClass(T value)
        /// </summary>
        /// <param name="value"></param>
        public ListClass(T value)
        {
            this.Value = value;
        }        
    }
}
