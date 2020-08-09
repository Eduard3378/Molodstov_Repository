using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace GenericBinaryTreeType
{
    /// <summary>
    /// Class Student1
    /// </summary>
    [Serializable]
    [XmlType]
    public class Student1 : IComparable<Student1>
    {
        /// <summary>
        /// Property StudentName { get; set; }
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        ///  Property TestName { get; set; }
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// Property DateOfTest { get; set; }
        /// </summary>
        public DateTime DateOfTest { get; set; }
        /// <summary>
        /// Property TestScore { get; set; }
        /// </summary>
        public int TestScore { get; set; }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Student1()
        {
            
        }
        /// <summary>
        /// Constructor Student1(string stname, string tsname, DateTime date, int tsscore)
        /// </summary>
        /// <param name="stname"></param>
        /// <param name="tsname"></param>
        /// <param name="date"></param>
        /// <param name="tsscore"></param>
        public Student1(string stname, string tsname, DateTime date, int tsscore)
        {
            StudentName = stname;
            TestName = tsname;
            DateOfTest = date;
            TestScore = tsscore;
        }
        /// <summary>
        /// Method CompareTo(Student1 other)
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Implementation of the IComparable interface</returns>
        public int CompareTo(Student1 other)
        {
            return TestScore.CompareTo(other.TestScore);
        }
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            string str = StudentName + " " + TestName + " (" + DateOfTest.Date.ToString("d") + " ) testScore= " + TestScore;
            return str;
        }
    }
}
