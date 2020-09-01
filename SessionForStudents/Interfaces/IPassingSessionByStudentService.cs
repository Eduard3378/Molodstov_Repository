using SessionForStudents.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.Interfaces
{
    /// <summary>
    /// Interface IPassingSessionByStudentService
    /// </summary>
    public interface IPassingSessionByStudentService
    {       
        /// <summary>
        /// Method GetPassingSessionByStudent(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Choice of student grades</returns>
        public static void GetPassingSessionByStudent(int id)
        {
        }
        /// <summary>
        /// Method CreatePassingSessionByStudent(PassingSessionByStudentDTO student)
        /// </summary>
        /// <param name="student"></param>
        public static void CreatePassingSessionByStudent(PassingSessionByStudentDTO student)
        {
        }
        /// <summary>
        /// Method UpdatePassingSessionByStudentDTO(PassingSessionByStudentDTO student)
        /// </summary>
        /// <param name="student"></param>
        public static void UpdatePassingSessionByStudentDTO(PassingSessionByStudentDTO student)
        {
        }
        /// <summary>
        /// Method DeletePassingSessionByStudentDTO(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePassingSessionByStudentDTO(int id)
        {
        }
    }
}
