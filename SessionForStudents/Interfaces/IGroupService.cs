using SessionForStudents.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.Interfaces
{
    /// <summary>
    /// Interface IGroupService
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Method InitDB(IUnitOfWork unitOfWork)
        /// </summary>
        /// <param name="unitOfWork"></param>
        // void InitDB(IUnitOfWork unitOfWork);
        /// <summary>
        /// Method AddToGroup(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        public static void AddToGroup(int groupId, int studentId)
        {
        }
        /// <summary>
        /// Method ExcludeFromGroup(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        public static void ExcludeFromGroup(int groupId, int studentId)
        {
        }
        /// <summary>
        /// Method GetGroup(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Group selection</returns>
        //GroupDTO GetGroup(int id);
        /// <summary>
        ///  Method CreateGroup(GroupDTO groupDTO)
        /// </summary>
        /// <param name="groupDTO"></param>
        public static void CreateGroup(GroupDTO groupDTO)
        {
        }
        /// <summary>
        /// Method UpdateGroup(GroupDTO groupDTO)
        /// </summary>
        /// <param name="groupDTO"></param>
        public static void UpdateGroup(GroupDTO groupDTO)
        {
        }
        /// <summary>
        /// Method DeleteGroup(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteGroup(int id)
        {
        }
    }
}
