using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SessionForStudents.Entities
{
    /// <summary>
    /// Class PassingSessionByStudent
    /// </summary>
    public class PassingSessionByStudent
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
        /// Property SessionId
        /// </summary>
        public int SessionId { get; set; }
        /// <summary>
        /// Property Session
        /// </summary>
        public Session Session { get; set; }
        /// <summary>
        /// Property CreditScore1
        /// </summary>
        public string CreditScore1 { get; set; }
        /// <summary>
        /// Property CreditScore2
        /// </summary>
        public string CreditScore2 { get; set; }
        /// <summary>
        /// Property CreditScore3
        /// </summary>
        public string CreditScore3 { get; set; }
        /// <summary>
        /// Property ExamMark1
        /// </summary>
        public string ExamMark1 { get; set; }
        /// <summary>
        /// Property ExamMark2
        /// </summary>
        public string ExamMark2 { get; set; }
        /// <summary>
        /// Property ExamMark3
        /// </summary>
        public string ExamMark3 { get; set; }
        /// <summary>
        /// Property Students
        /// </summary>
        public ICollection<Student> Students { get; set; }
    }
}
