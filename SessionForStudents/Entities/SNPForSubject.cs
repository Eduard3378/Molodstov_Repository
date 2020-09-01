using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SessionForStudents.Entities
{
    public class SNPForSubject
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SessionId { get; set; }       
        public Session Session { get; set; }
        public int GroupDateOfOffsetId { get; set; }
        public DateTime DateOfOffset { get; set; }
        public string SNPOfOffset { get; set; }
        public int GroupDateOfOffset1Id { get; set; }
        public DateTime DateOfOffset1 { get; set; }
        public string SNPOfOffset1 { get; set; }
        public int GroupDateOfOffset2Id { get; set; }
        public DateTime DateOfOffset2 { get; set; }
        public string SNPOfOffset2 { get; set; }
        public int GroupDateOfExaminationId { get; set; }
        public DateTime DateOfExamination { get; set; }
        public string SNPOfExamination { get; set; }
        public int GroupDateOfExamination1Id { get; set; }
        public DateTime DateOfExamination1 { get; set; }
        public string SNPOfExamination1 { get; set; }
        public int GroupDateOfExamination2Id { get; set; }
        public DateTime DateOfExamination2 { get; set; }
        public string SNPOfExamination2 { get; set; }
    }
}
