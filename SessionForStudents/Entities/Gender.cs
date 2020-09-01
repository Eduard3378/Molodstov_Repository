using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SessionForStudents.Entities
{
    /// <summary>
    /// Class Gender
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Property Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        /// <summary>
        /// Property Name
        /// </summary>
        [StringLength(12)]
        public string Name { get; set; }
        /// <summary>
        /// Property Design
        /// </summary>
        [StringLength(3)]
        public string Design { get; set; }
        /// <summary>
        /// Property Students
        /// </summary>
        public ICollection<Student> Students { get; set; }
    }
}
