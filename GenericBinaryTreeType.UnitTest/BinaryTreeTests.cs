using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericBinaryTreeType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentAssertions;

namespace GenericBinaryTreeType.Tests
{
    /// <summary>
    /// Class BinaryTreeTests
    /// </summary>
    [TestClass()]
    public class BinaryTreeTests
    {
        //Provide the ability to serialize and deserialize a tree to an XML file
        static Student1 student6 = new Student1("Medvedev", "Physics", new DateTime(2020, 7, 5), 6);
        static Student1 student7 = new Student1("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7);
        static Student1 student8 = new Student1("Puntus", "Geography", new DateTime(2020, 9, 5), 5);
        static Student1 student9 = new Student1("Sobolev", "Maths", new DateTime(2020, 6, 6), 7);
        static Student1 student10 = new Student1("Kryukov", "History", new DateTime(2020, 6, 5), 8);
        //Collection of students
        static List<Student1> studentList1 = new List<Student1>
        {
                student6,
                student7,
                student8,
                student9,
                student10
        };
      
        //Storing test results performed by students
        BinaryTree<int> scoretree = new BinaryTree<int>
        {
          5, 4, 6, 7, 8
        };
        /// <summary>
        /// Method BinaryTree_TestScores_CreateObject()
        /// </summary>
        [TestMethod()]
        public void BinaryTree_TestScores_CreateObject()
        {
            // Arange           
            BinaryTree<int> scoretree1 = new BinaryTree<int>
            {
             6, 7, 5, 7, 8
            };
            // Assert
            Assert.IsNotNull(scoretree);
            Assert.IsNotNull(scoretree1);
        }
        /// <summary>
        /// Method  BinaryTree_Collection_CreateObject()
        /// </summary>
        [TestMethod()]
        public void BinaryTree_Collection_CreateObject()
        {
            // Arange 
            //Creating a binary tree
            BinaryTree<Student1> binstudtree2 = new BinaryTree<Student1>(studentList1);
            // Assert
            Assert.IsNotNull(binstudtree2);
        }
        /// <summary>
        /// Method AddRange_Collection_Add()
        /// </summary>
        [TestMethod()]
        public void AddRange_Collection_Add()
        {
            // Arange 
            BinaryTree<Student1> binstudtree3 = new BinaryTree<Student1>();
            binstudtree3.AddRange(studentList1);
        }
        /// <summary>
        /// Method Add_TItem_Root()
        /// </summary>
        [TestMethod()]
        public void Add_TItem_Root()
        {
            // Arange
            BinaryTree<Student1> binstudtree4 = new BinaryTree<Student1>();
            Student1 student6 = new Student1("Medvedev", "Physics", new DateTime(2020, 7, 5), 6);
            var expected = student6;
            binstudtree4.Add(student6);
            //Act
            var result = binstudtree4.ElementAt(0);
            // Assert
            result.Should().Be(expected);
        }
        /// <summary>
        /// Method Clear_()
        /// </summary>
        [TestMethod()]
        public void Clear_Collection_Empty()
        {
            // Arange 
            studentList1.Clear();
            //Act
            List<Student1> result = studentList1;
            // Assert
            result.Should().BeEmpty(null);
        }
        /// <summary>
        /// Method TreeTraversal_Root_Node()
        /// </summary>
        [TestMethod()]
        public void TreeTraversal_Root_Node()
        {
            // Arange 
            BinaryTree<Student1> binstudtree3 = new BinaryTree<Student1>(studentList1);
            binstudtree3.TreeTraversal();
        }
        /// <summary>
        /// Method GetEnumerator_()
        /// </summary>
        [TestMethod()]
        public void GetEnumerator_Collection_IEnumerator<T>()
        {
            // Arange 
            BinaryTree<Student1> binstudtree3 = new BinaryTree<Student1>(studentList1);
            binstudtree3.GetEnumerator();
        }
    }
}