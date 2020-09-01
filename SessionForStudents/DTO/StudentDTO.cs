using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.DTO
{
    /// <summary>
    /// Class StudentDTO
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// Property Id
        /// </summary>
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
        public string Gender { get; set; }
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
        public string PassingSessionByStudent { get; set; }
    }
}
