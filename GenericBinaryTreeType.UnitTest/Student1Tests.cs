using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericBinaryTreeType;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace GenericBinaryTreeType.Tests
{
    /// <summary>
    /// Class Student1Tests
    /// </summary>
    [TestClass()]
    public class Student1Tests
    {
        Student1 student6 = new Student1("Medvedev", "Physics", new DateTime(2020, 7, 5), 6);
        /// <summary>
        /// Method Student1_Stname_CreateObject()
        /// </summary>
        [TestMethod()]
        public void Student1_Stname_CreateObject()
        {
            // Arange           
            Student1 student7 = new Student1("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7);
            // Assert
            Assert.IsNotNull(student6);
            Assert.IsNotNull(student7);
        }
        /// <summary>
        /// Method CompareTo_Student1Other_TestScore()
        /// </summary>
        [TestMethod()]
        public void CompareTo_Student1Other_TestScore()
        {
            // Arange
            Student1 student7 = new Student1("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7);
            int expected  = -1;
            //Act
           var result = student6.CompareTo(student7);
           // Console.WriteLine(result);
            // Assert
            result.Should().Be(expected);
        }
        /// <summary>
        /// Method ToString_StudentName_String()
        /// </summary>
        [TestMethod()]
        public void ToString_StudentName_String()
        {
            // Arange
            Student1 student7 = new Student1("Karasev", "Astronomy", new DateTime(2020, 8, 6), 7);
            string expected = student7.StudentName + " " + student7.TestName + " (" + student7.DateOfTest.Date.ToString("d") + " ) testScore= " + student7.TestScore;          
            //Act 
            string result = student7.ToString();
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}