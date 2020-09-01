using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.DTO
{
    /// <summary>
    /// Class PassingSessionByStudentDTO
    /// </summary>
    public class PassingSessionByStudentDTO
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
        /// Property SessionId
        /// </summary>
        public int SessionId { get; set; }
        /// <summary>
        /// Property Session
        /// </summary>
        public string Session { get; set; }
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
    }
}
