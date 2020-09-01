using SessionForStudents.DTO;
using SessionForStudents.EF;
using SessionForStudents.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionForStudents.Interfaces
{
    /// <summary>
    /// Interface IStudentService
    /// </summary>
    public interface IStudentService
    {       
        /// <summary>
        /// Method  GetStudent(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get student by id</returns>
        public static void GetStudent(int id)
        {           
        }        
        /// <summary>
        /// Method CreateStudent(StudentDTO student)
        /// </summary>
        /// <param name="student"></param>
        public static void CreateStudent(StudentDTO student)
        {
        }
        /// <summary>
        /// Method UpdateStudent(StudentDTO student)
        /// </summary>
        /// <param name="student"></param>
        public static void UpdateStudent(StudentDTO student)
        {
        }
        /// <summary>
        /// Method DeleteStudent(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteStudent(int id)
        {
        }
    }
}
