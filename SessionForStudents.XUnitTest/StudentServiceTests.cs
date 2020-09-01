using Microsoft.EntityFrameworkCore;
using SessionForStudents.DTO;
using SessionForStudents.EF;
using SessionForStudents.Entities;
using SessionForStudents.Interfaces;
using SessionForStudents.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace SessionForStudents.XUnitTest
{
    /// <summary>
    /// Class StudentService1 
    /// </summary>
    public class StudentService1 
    {
        /// <summary>
        /// Method StudentDTO GetStudent()
        /// </summary>
        /// <returns></returns>
        public static StudentDTO GetStudent()
        {
            return new StudentDTO
            {
                Id = 12,
                Name = "Елена7",
                Surname = "Воробьева7",
                Patronymic = "Васильевна7",
                GenderId = 3,               
                DateOfBirth = new DateTime(2004, 3, 11),
                PassingSessionByStudentId = 11, 
            };           
        }
        /// <summary>
        /// Method StudentDTO GetStudent1()
        /// </summary>
        /// <returns></returns>
        public static StudentDTO GetStudent1()
        {
            return new StudentDTO
            {
                Id = 11,
                Name = "Елена8",
                Surname = "Воробьева8",
                Patronymic = "Васильевна8",
                GenderId = 3,
                DateOfBirth = new DateTime(2003, 3, 11),
                PassingSessionByStudentId = 11,
            };            
        }
    }
    /// <summary>
    /// Class StudentServiceTests
    /// </summary>
    public class StudentServiceTests
    {
        /// <summary>
        /// Method GetStudent_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetStudent_Id_Void(int id)
        {           
            SessionForStudents.Services.StudentService.GetStudent(id);
        }
        /// <summary>
        /// Method CreateStudent_StudentDTO_Void()
        /// </summary>
        [Fact]       
        public void CreateStudent_StudentDTO_Void()
        {
           SessionForStudents.Services.StudentService.CreateStudent(StudentService1.GetStudent());
        }
        /// <summary>
        /// Method UpdateStudent_StudentDTO_Void()
        /// </summary>
        [Fact]
        public void UpdateStudent_StudentDTO_Void()
        {
            SessionForStudents.Services.StudentService.UpdateStudent(StudentService1.GetStudent1());
        }
        /// <summary>
        /// Method DeleteStudent_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        public void DeleteStudent_Id_Void(int id)
        {
            SessionForStudents.Services.StudentService.DeleteStudent(id);
        }
    }
}
