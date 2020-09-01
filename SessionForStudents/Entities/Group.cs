using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SessionForStudents.Entities
{
    /// <summary>
    /// Class Group
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Property Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Property StudentId
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Property Student
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Property GroupName
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Property DateOfOffset
        /// </summary>
        public DateTime DateOfOffset { get; set; }
        /// <summary>
        /// Property DateOfOffset1
        /// </summary>
        public DateTime DateOfOffset1 { get; set; }
        /// <summary>
        /// Property DateOfOffset2
        /// </summary>
        public DateTime DateOfOffset2 { get; set; }
        /// <summary>
        /// Property DateOfExamination
        /// </summary>
        public DateTime DateOfExamination  { get; set; }
        /// <summary>
        /// Property DateOfExamination1
        /// </summary>
        public DateTime DateOfExamination1 { get; set; }
        /// <summary>
        /// Property DateOfExamination2
        /// </summary>
        public DateTime DateOfExamination2 { get; set; }
        /// <summary>
        /// Property StudentGroups
        /// </summary>
        public ICollection<StudentGroup> StudentGroups { get; set; }
       
    }
}
