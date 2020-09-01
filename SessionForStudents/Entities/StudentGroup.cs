using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.Entities
{
    /// <summary>
    /// Class StudentGroup
    /// </summary>
    public class StudentGroup
    {
        /// <summary>
        /// Property GroupId
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Property Group
        /// </summary>
        public Group Group { get; set; }
        /// <summary>
        /// Property StudentId
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Property Student
        /// </summary>
        public Student Student { get; set; }
       
    }
}
