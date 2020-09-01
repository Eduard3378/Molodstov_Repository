using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SessionForStudents.Entities
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }        
        public string SpecialtyName { get; set; }
      //  public ICollection<Group> Groups { get; set; }
    }
}
