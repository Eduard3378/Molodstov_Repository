using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GenericBinaryTreeType
{
    /// <summary>
    /// Structure Student
    /// </summary>
    public struct Student : IComparable<Student>
    {
        public string studentName;
        public string testName;
        public DateTime dateOfTest;
        public int testScore;
        /// <summary>
        /// Constructor Student(string stname, string tsname, DateTime date, int tsscore)
        /// </summary>
        /// <param name="stname"></param>
        /// <param name="tsname"></param>
        /// <param name="date"></param>
        /// <param name="tsscore"></param>
        public Student(string stname, string tsname, DateTime date, int tsscore)
        {
            studentName = stname;
            testName = tsname;
            dateOfTest = date;
            testScore = tsscore;
        }
        /// <summary>
        /// Method CompareTo(Student other)
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Implementation of the IComparable interface</returns>
        public int CompareTo(Student other)
        {
           return testScore.CompareTo(other.testScore);
        }
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            string str = studentName+ " " + testName + " (" + dateOfTest.Date.ToString("d") + " ) testScore= " + testScore;
            return str;
        }
    }
}
