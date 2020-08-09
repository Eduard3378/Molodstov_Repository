using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericBinaryTreeType
{
    /// <summary>
    /// Class BinaryTree<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : ICollection<T>
    {
        private TreeNode<T> root;  //tree root
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
        /// Constructor BinaryTree(): this(Comparer<T>.Default)
        /// </summary>
        public BinaryTree() : this(Comparer<T>.Default)
        {
            root = null; //root is not defined when created
        }
        /// <summary>
        /// Constructor BinaryTree(IComparer<T> defComp)
        /// </summary>
        /// <param name="defComp"></param>
        public BinaryTree(IComparer<T> defComp)
        {
            comparer = defComp ?? throw new ArgumentNullException("Default comparer is null");
        }
        /// <summary>
        /// Constructor BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        /// </summary>
        /// <param name="collection"></param>
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {

        }
        /// <summary>
        /// Constructor BinaryTree(IEnumerable<T> collection, IComparer<T> defComp) : this(defComp)
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="defComp"></param>
        public BinaryTree(IEnumerable<T> collection, IComparer<T> defComp) : this(defComp)
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
        /// Method Height(TreeNode<T> item)
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Binary tree height</returns>
        private int Height(TreeNode<T> item)
        {
            return item != null ? Convert.ToInt32(item.Value) : 0;
        }
        /// <summary>
        /// Method BalancingCondition(TreeNode<T> node)
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Balancing state</returns>
        private int BalancingCondition(TreeNode<T> node)
        {
            return Height(node.Right) - Height(node.Left);
        }
        /// <summary>
        /// Method HeightCont(TreeNode<T> node)
        /// </summary>
        /// <param name="node"></param>
        private void HeightCont(TreeNode<T> node)
        {
            int heightl = Height(node.Left);
            int heightr = Height(node.Right);
            int p;
            p = (heightl > heightr ? heightl : heightr) + 1;
        }
        /// <summary>
        /// Method Turnright(TreeNode<T> p) 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Right turn</returns>
        private TreeNode<T> Turnright(TreeNode<T> p) 
        {
            TreeNode<T> q = p.Left;
            p.Left = q.Right;
            q.Right = p;
            HeightCont(p);
            HeightCont(q);
            return q;
        }
        /// <summary>
        /// Method Turnleft(TreeNode<T> q)
        /// </summary>
        /// <param name="q"></param>
        /// <returns>Left turn</returns>
        private TreeNode<T> Turnleft(TreeNode<T> q) 
        {
            TreeNode<T> p = q.Right;
            q.Right = p.Left;
            p.Left = q;
            HeightCont(q);
            HeightCont(p);
            return p;
        }
        /// <summary>
        /// Method Balance(TreeNode<T> p) 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Tree balancing</returns>
        private TreeNode<T> Balance(TreeNode<T> p) 
        {
            HeightCont(p);
            if (BalancingCondition(p) == 2)
            {
                if (BalancingCondition(p.Right) < 0)
                    p.Right = Turnright(p.Right);
                return Turnleft(p);
            }
            if (BalancingCondition(p) == -2)
            {
                if (BalancingCondition(p.Left) > 0)
                    p.Left = Turnleft(p.Left);
                return Turnright(p);
            }
            return p; // balancing is not needed
        }
        public bool IsReadOnly => throw new NotImplementedException();
        /// <summary>
        ///  Method Add(T item)
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
           // var count = TreeNode<T>.Count;
            var node = new TreeNode<T>(item);
            Balance(node);
            // if this is the first item
            if (root == null)
                root = node;
            // if it is not the first item
            else
            {
                TreeNode<T> current = root, parent = null;
                while (current != null)
                {
                    parent = current;
                    if (comparer.Compare(item, current.Value) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
                if (comparer.Compare(item, parent.Value) < 0)
                    parent.Left = node;                    
                else
                    parent.Right = node;
            }
            ++Count;            
        }
        /// <summary>
        /// Method Clear()
        /// </summary>
        public void Clear()
        {
            if (root != null)
            {
                root = null;
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
        /// Method TreeTraversal()
        /// </summary>
        /// <returns>Tree traversal</returns>
        public IEnumerable<T>TreeTraversal()
        {
            if (root == null)
                yield break;

            var stack = new Stack<TreeNode<T>>();
            var node = root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;                  
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
        }
        /// <summary>
        /// Method GetEnumerator()
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return TreeTraversal().GetEnumerator();
        }
        /// <summary>
        /// Method Remove(T item)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
