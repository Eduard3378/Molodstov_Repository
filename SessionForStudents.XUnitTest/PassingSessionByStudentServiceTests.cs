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
    /// Class PassingSessionByStudent1
    /// </summary>
    public class PassingSessionByStudent1
    {
        /// <summary>
        /// Method PassingSessionByStudentDTO GetPassingSessionByStudent()
        /// </summary>
        /// <returns>Class object PassingSessionByStudentDTO</returns>
        public static PassingSessionByStudentDTO GetPassingSessionByStudent()
        {
            return new PassingSessionByStudentDTO
            {
                Id = 23,
                StudentId = 12,
                SessionId = 1,
                CreditScore1 = "7",
                CreditScore2 = "8",
                CreditScore3 = "9",
                ExamMark1 = "6",
                ExamMark2 = "7",
                ExamMark3 = "8"
            };
        }
        /// <summary>
        /// Method PassingSessionByStudentDTO GetPassingSessionByStudent1()
        /// </summary>
        /// <returns>Class object PassingSessionByStudentDTO</returns>
        public static PassingSessionByStudentDTO GetPassingSessionByStudent1()
        {
            return new PassingSessionByStudentDTO
            {
                Id = 20,
                StudentId = 13,
                SessionId = 2,
                CreditScore1 = "6",
                CreditScore2 = "5",
                CreditScore3 = "7",
                ExamMark1 = "8",
                ExamMark2 = "7",
                ExamMark3 = "6"
            };
        }
    }
    /// <summary>
    /// Class PassingSessionByStudentServiceTests
    /// </summary>
    public class PassingSessionByStudentServiceTests
    {
        /// <summary>
        /// Method GetPassingSessionByStudent_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetPassingSessionByStudent_Id_Void(int id)
        {
            SessionForStudents.Services.PassingSessionByStudentService.GetPassingSessionByStudent(id);
        }
        /// <summary>
        /// Method CreatePassingSessionByStudent_PassingSessionByStudentDTO_Void()
        /// </summary>
        [Fact]
        public void CreatePassingSessionByStudent_PassingSessionByStudentDTO_Void()
        {
            SessionForStudents.Services.PassingSessionByStudentService.CreatePassingSessionByStudent(PassingSessionByStudent1.GetPassingSessionByStudent());
        }
        /// <summary>
        /// Method UpdatePassingSessionByStudentDTO_PassingSessionByStudentDTO_Void()
        /// </summary>
        [Fact]
        public void UpdatePassingSessionByStudentDTO_PassingSessionByStudentDTO_Void()
        {
            SessionForStudents.Services.PassingSessionByStudentService.UpdatePassingSessionByStudentDTO(PassingSessionByStudent1.GetPassingSessionByStudent1());
        }
        /// <summary>
        /// Method DeletePassingSessionByStudentDTO_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        public void DeletePassingSessionByStudentDTO_Id_Void(int id)
        {
            SessionForStudents.Services.PassingSessionByStudentService.DeletePassingSessionByStudentDTO(id);
        }
        /// <summary>
        /// Method ResultsOfTheSessionForEachGroup_PassingSessionByStudentDTO_Void()
        /// </summary>
        [Fact]
        public void ResultsOfTheSessionForEachGroup_PassingSessionByStudentDTO_Void()
        {
            using (SessionContext db = new SessionContext())
            {
                // получаем итоги сессии по каждой группе в виде таблицы
                var passingSessionByStudent = db.PassingSessionByStudents.ToList();
                var studentGroup = db.StudentGroups.ToList();
                SessionForStudents.Services.PassingSessionByStudentService.ResultsOfTheSessionForEachGroup(passingSessionByStudent, studentGroup);
            }
        }
        /// <summary>
        /// Method AverMinMaxScoreForEachGroup_Students_Void()
        /// </summary>
        [Fact]
        public void AverMinMaxScoreForEachGroup_Students_Void()
        {
            SessionForStudents.Services.PassingSessionByStudentService.AverMinMaxScoreForEachGroup();
        }
        /// <summary>
        /// Method ListOfStudentsToBeExpelled_Result_Void()
        /// </summary>
        [Fact]
        public void ListOfStudentsToBeExpelled_Result_Void()
        {
            SessionForStudents.Services.PassingSessionByStudentService.ListOfStudentsToBeExpelled();
        }
    }
}
