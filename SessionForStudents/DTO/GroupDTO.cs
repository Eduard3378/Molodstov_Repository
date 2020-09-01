using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.DTO
{
    /// <summary>
    /// class GroupDTO
    /// </summary>
    public class GroupDTO
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property StudentId
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Property Student
        /// </summary>
        public string Student { get; set; }
        /// <summary>
        /// Property GroupId
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Property Group
        /// </summary>
        public string Group { get; set; }
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
        public DateTime DateOfExamination { get; set; }
        /// <summary>
        /// Property DateOfExamination1
        /// </summary>
        public DateTime DateOfExamination1 { get; set; }
        /// <summary>
        /// Property DateOfExamination2
        /// </summary>
        public DateTime DateOfExamination2 { get; set; }
    }
}
