using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericBinaryTreeType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenericBinaryTreeType.Tests
{
    /// <summary>
    /// Class RepositoryTests
    /// </summary>
    [TestClass()]
    public class RepositoryTests
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
        /// <summary>
        /// Method Add_Student_Serialize()
        /// </summary>
        [TestMethod()]
        public void Add_Student_Serialize()
        {
            //Creating a binary tree
            BinaryTree<Student1> binstudtree2 = new BinaryTree<Student1>(studentList1);
            System.IO.File.Delete("stud.xml");
            //Binary tree serialization
            foreach (Student1 st in binstudtree2)
            {
                Repository.Add(st);
            }
        }
        /// <summary>
        /// Method Students_Student_Deserialize()
        /// </summary>
        [TestMethod()]
        public void Students_Student_Deserialize()
        {
            Console.WriteLine("XML файл после десерилизации");
            //Binary tree deserialization
            IEnumerable<Student1> st2 = Repository.Students;
            studentList1.Clear();
            studentList1 = st2.ToList();           
            //Introducing students after deserialization
            foreach (Student1 student32 in studentList1)
            {
                Console.WriteLine("{0} ", student32);
            }           
            studentList1.Clear();            
        }
    }
}