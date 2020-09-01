using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SessionForStudents.Entities
{
    /// <summary>
    /// Class Session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property Name
        /// </summary>
        [StringLength(12)]
        public string Name { get; set; }
        /// <summary>
        /// Property PassingSessionByStudents
        /// </summary>
        public ICollection<PassingSessionByStudent> PassingSessionByStudents { get; set; }
        public ICollection<SNPForSubject> SNPForSubjects { get; set; }
    }
}
