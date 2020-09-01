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
    /// class SNPForSubject1
    /// </summary>
    public class SNPForSubject1
    {
        /// <summary>
        /// Method SNPForSubjectDTO GetSNPForSubject()
        /// </summary>
        /// <returns>Class object SNPForSubjectDTO</returns>
        public static SNPForSubjectDTO GetSNPForSubject()
        {
            return new SNPForSubjectDTO
            {
                Id = 19,
                GroupId = 3,
                SessionId = 1,
                GroupDateOfOffsetId = 1,
                DateOfOffset = new DateTime(2020, 3, 11),
                SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1,
                DateOfOffset1 = new DateTime(2020, 4, 12),
                SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1,
                DateOfOffset2 = new DateTime(2020, 5, 13),
                SNPOfOffset2 = "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1,
                DateOfExamination = new DateTime(2020, 6, 10),
                SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1,
                DateOfExamination1 = new DateTime(2020, 6, 10),
                SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1,
                DateOfExamination2 = new DateTime(2020, 6, 20),
                SNPOfExamination2 = "Тарасов Сергей Петрович"
            };
        }
        /// <summary>
        /// Method SNPForSubjectDTO GetSNPForSubject1()
        /// </summary>
        /// <returns>Class object SNPForSubjectDTO</returns>
        public static SNPForSubjectDTO GetSNPForSubject1()
        {
            return new SNPForSubjectDTO
            {
                Id = 18,
                GroupId = 3,
                SessionId = 6,
                GroupDateOfOffsetId = 3,
                DateOfOffset = new DateTime(2022, 7, 16),
                SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3,
                DateOfOffset1 = new DateTime(2022, 7, 17),
                SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3,
                DateOfOffset2 = new DateTime(2022, 8, 18),
                SNPOfOffset2 = "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3,
                DateOfExamination = new DateTime(2022, 9, 15),
                SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3,
                DateOfExamination1 = new DateTime(2022, 9, 20),
                SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3,
                DateOfExamination2 = new DateTime(2022, 9, 25),
                SNPOfExamination2 = "Солнцева Лариса Петровна"
            };
        }
    }
    /// <summary>
    /// Class SNPForSubjectServiceTests
    /// </summary>
    public class SNPForSubjectServiceTests
    {
        /// <summary>
        /// Method GetSNPForSubject_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetSNPForSubject_Id_Void(int id)
        {
            SessionForStudents.Services.SNPForSubjectService.GetSNPForSubject(id);
        }
        /// <summary>
        /// Method CreateSNPForSubject_SNPForSubjectDTO_Void()
        /// </summary>
        [Fact]
        public void CreateSNPForSubject_SNPForSubjectDTO_Void()
        {
            SessionForStudents.Services.SNPForSubjectService.CreateSNPForSubject(SNPForSubject1.GetSNPForSubject());
        }
        /// <summary>
        /// Method UpdateSNPForSubject_SNPForSubjectDTO_Void()
        /// </summary>
        [Fact]
        public void UpdateSNPForSubject_SNPForSubjectDTO_Void()
        {
            SessionForStudents.Services.SNPForSubjectService.UpdateSNPForSubject(SNPForSubject1.GetSNPForSubject1());
        }
        /// <summary>
        /// Method DeletePassingSessionByStudentDTO_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(18)]
        public void DeletePassingSessionByStudentDTO_Id_Void(int id)
        {
            SessionForStudents.Services.SNPForSubjectService.DeleteSNPForSubject(id);
        }
    }
}
