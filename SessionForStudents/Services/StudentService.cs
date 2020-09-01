using SessionForStudents.DTO;
using SessionForStudents.EF;
using SessionForStudents.Entities;
using SessionForStudents.Infrastructure;
using SessionForStudents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionForStudents.Services
{
    /// <summary>
    /// Class StudentService
    /// </summary>
    public class StudentService : IStudentService
    {       
        /// <summary>
        /// Constructor StudentService()
        /// </summary>
        public StudentService()
        {
        }      
        /// <summary>
        /// Method GetStudent(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get a student by id</returns>
        public static void GetStudent(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var students = db.Students.ToList();
                foreach(var item in students)
                {
                    if (item.Id == id)
                    {                        
                        StudentDTO student = new StudentDTO();
                        student.Id = item.Id;
                        student.Name = item.Name;
                        student.Surname = item.Surname;
                        student.Patronymic = item.Patronymic;
                        student.GenderId = item.GenderId;                      
                        student.DateOfBirth = item.DateOfBirth;                      
                    }
                }                      
            }          
        }
        /// <summary>
        /// Method CreateStudent(StudentDTO studentDTO)
        /// </summary>
        /// <param name="studentDTO"></param>
        public static void CreateStudent(StudentDTO studentDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                var students = db.Students.ToList();
                var student = students.Select(p => p.Id == studentDTO.Id).FirstOrDefault();
                if (student == false)
                {
                    db.Students.Add(new Student
                    {
                        Id = studentDTO.Id,
                        Name = studentDTO.Name,
                        Surname = studentDTO.Surname,
                        Patronymic = studentDTO.Patronymic,
                        GenderId = studentDTO.GenderId,
                        DateOfBirth = studentDTO.DateOfBirth,
                        PassingSessionByStudentId = studentDTO.PassingSessionByStudentId
                    });                    
                }
                else
                {
                    throw new ValidationException("Студент с таким id уже есть!", "");
                }
            }
        }
        /// <summary>
        /// Method UpdateStudent(StudentDTO studentDTO)
        /// </summary>
        /// <param name="studentDTO"></param>
        public static void UpdateStudent(StudentDTO studentDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                var students = db.Students.ToList();
                var student = students.Find(p => p.Id == studentDTO.Id);
                if (student == null)
                {
                    throw new ValidationException("Студент не найден!", "");
                }
                else
                {
                    student.Name = studentDTO.Name;
                    student.Surname = studentDTO.Surname;
                    student.Patronymic = studentDTO.Patronymic;
                    student.GenderId = studentDTO.GenderId;
                    student.DateOfBirth = studentDTO.DateOfBirth;
                    db.Students.Update(student);                   
                }
            }
        }
        /// <summary>
        /// Method DeleteStudent(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteStudent(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var students = db.Students.ToList();
                var student = students.Find(p => p.Id == id);
                if (student == null)
                {
                    throw new ValidationException("Студент не найден!", "");
                }
                else
                {
                    db.Students.Remove(student);
                    var studentGroups = db.StudentGroups.ToList();
                    var studentGroup = studentGroups.Find(p => p.StudentId == id);
                    db.StudentGroups.Remove(studentGroup);
                }
            }
        }
    }
}
