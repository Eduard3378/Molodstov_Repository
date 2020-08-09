using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace GenericBinaryTreeType
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
            //The collection list for the binary tree
            Student student1 = new Student("Medvedev", "Physics", new DateTime(2020, 7, 5), 6);
            Student student2 = new Student("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7);
            Student student3 = new Student("Puntus", "Geography", new DateTime(2020, 9, 5), 5);
            Student student4 = new Student("Sobolev", "Maths", new DateTime(2020, 6, 6), 7);
            Student student5 = new Student("Kryukov", "History", new DateTime(2020, 6, 5), 8);
            //Collection of students
            List<Student> studentList = new List<Student>
            {
                student1,
                student2,
                student3,
                student4,
                student5
            };
            //Creating a binary tree
            BinaryTree<Student> binstudtree = new BinaryTree<Student>(studentList);
            //Inference of binary tree students
            foreach (Student student in binstudtree)
            {
                Console.WriteLine("{0} ", student);
            }
            Console.WriteLine();
            //The second data type for creating a binary tree
            BinaryTree<Student> binstudtree1 = new BinaryTree<Student>
            {
                new Student("Medvedev", "Physics", new DateTime(2020, 7, 5), 6),
                new Student("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7),
                new Student("Puntus", "Geography", new DateTime(2020, 9, 5), 5),
                new Student("Sobolev", "Maths", new DateTime(2020, 6, 6), 7),
                new Student("Kryukov", "History", new DateTime(2020, 6, 5), 8)
            };
            //Inference of binary tree students
            foreach (Student student in binstudtree1)
            {
                Console.WriteLine("{0} ", student);
            }
            Console.WriteLine();

            //Storing test results performed by students
            BinaryTree<int> scoretree = new BinaryTree<int>
            {
                6,
                7,
                5,
                7,
                8
            };
            //Output of test results
            foreach (int sc in scoretree)
            {
                Console.WriteLine("{0} ", sc);
            }
            Console.WriteLine();

            //Provide the ability to serialize and deserialize a tree to an XML file
            Student1 student6 = new Student1("Medvedev", "Physics", new DateTime(2020, 7, 5), 6);
            Student1 student7 = new Student1("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7);
            Student1 student8 = new Student1("Puntus", "Geography", new DateTime(2020, 9, 5), 5);
            Student1 student9 = new Student1("Sobolev", "Maths", new DateTime(2020, 6, 6), 7);
            Student1 student10 = new Student1("Kryukov", "History", new DateTime(2020, 6, 5), 8);
            //Collection of students
            List<Student1> studentList1 = new List<Student1>
            {
                student6,
                student7,
                student8,
                student9,
                student10
            };
            //Creating a binary tree
            BinaryTree<Student1> binstudtree2 = new BinaryTree<Student1>(studentList1);
            //Inference of binary tree students
            foreach (Student1 student in binstudtree2)
            {
                Console.WriteLine("{0} ", student);
            }
            Console.WriteLine();


            System.IO.File.Delete("stud.xml");
            //Binary tree serialization
            foreach (Student1 st in binstudtree2)
            {                
                Repository.Add(st);
            }

            Console.WriteLine("XML файл после десерилизации");
            //Binary tree deserialization
            IEnumerable<Student1> st2 = Repository.Students;
            studentList1.Clear();
            studentList1 = st2.ToList();
            Console.WriteLine("");
            //Introducing students after deserialization
            foreach (Student1 student32 in studentList1)
            {
                Console.WriteLine("{0} ", student32);
            }
            Console.WriteLine();
            studentList1.Clear();
            binstudtree2.Clear();
            Console.ReadKey();
        }        
    }
}
