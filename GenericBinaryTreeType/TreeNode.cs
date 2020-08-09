using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBinaryTreeType
{
    /// <summary>
    /// Class TreeNode<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        /// <summary>
        /// Property T Value { get; set; }
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Property Left { get; set; }
        /// </summary>
        public TreeNode<T> Left { get; set; }
        /// <summary>
        /// Property Right { get; set; }
        /// </summary>
        public TreeNode<T> Right { get; set; }
        /// <summary>
        /// Constructor TreeNode(T value)
        /// </summary>
        /// <param name="value"></param>
        public TreeNode(T value)
        {
            this.Value = value;           
        }
    }
}
