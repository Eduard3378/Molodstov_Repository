using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SessionForStudents.Entities
{
    /// <summary>
    /// Class Student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Property Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Property Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Property Patronymic
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Property GenderId
        /// </summary>
        public int GenderId { get; set; }
        /// <summary>
        /// Property Gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property DateOfBirth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Property PassingSessionByStudentId
        /// </summary>
        public int PassingSessionByStudentId { get; set; }
        /// <summary>
        /// Property PassingSessionByStudent
        /// </summary>
        public PassingSessionByStudent PassingSessionByStudent { get; set; }
        /// <summary>
        /// Property Groups
        /// </summary>
        public ICollection<Group> Groups { get; set; }
        /// <summary>
        /// Property StudentGroups
        /// </summary>
        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
