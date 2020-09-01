using SessionForStudents.DTO;
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
    /// Class GrroupService1
    /// </summary>
    public class GrroupService1
    {
        /// <summary>
        /// Method GroupDTO GetGroup()
        /// </summary>
        /// <returns></returns>
        public static GroupDTO GetGroup()
        {
            return new GroupDTO
            {
                Id = 4,
                StudentId = 7,
                GroupName = "Ï24043",
                DateOfOffset = new DateTime(2020, 03, 19),
                DateOfOffset1 = new DateTime(2020, 03, 21),
                DateOfOffset2 = new DateTime(2020, 03, 23),
                DateOfExamination = new DateTime(2020, 03, 25),
                DateOfExamination1 = new DateTime(2020, 03, 27),
                DateOfExamination2 = new DateTime(2020, 03, 30)
            };
        }
        /// <summary>
        /// Method GetGroup1()
        /// </summary>
        /// <returns></returns>
        public static GroupDTO GetGroup1()
        {
            return new GroupDTO
            {
                Id = 3,
                StudentId = 9,
                GroupName = "Ï24045",
                DateOfOffset = new DateTime(2020, 03, 23),
                DateOfOffset1 = new DateTime(2020, 03, 27),
                DateOfOffset2 = new DateTime(2020, 04, 01),
                DateOfExamination = new DateTime(2020, 04, 04),
                DateOfExamination1 = new DateTime(2020, 04, 07),
                DateOfExamination2 = new DateTime(2020, 04, 10)
            };
        }
    }
    /// <summary>
    /// Class GroupServiceTests
    /// </summary>
    public class GroupServiceTests
    {
        /// <summary>
        /// Method AddToGroup_GrIdStId_Void(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        [Theory]
        [InlineData(3, 12)]
        [InlineData(3, 13)]
        public void AddToGroup_GrIdStId_Void(int groupId, int studentId)
        {
            SessionForStudents.Services.GroupService.AddToGroup(groupId, studentId);
        }
        /// <summary>
        /// Method ExcludeFromGroup_GrIdStId_Void(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        [Theory]
        [InlineData(3, 10)]
        [InlineData(3, 11)]
        public void ExcludeFromGroup_GrIdStId_Void(int groupId, int studentId)
        {
            SessionForStudents.Services.GroupService.ExcludeFromGroup(groupId, studentId);
        }
        /// <summary>
        /// Method GetGroup_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        public void GetGroup_Id_Void(int id)
        {
            SessionForStudents.Services.GroupService.GetGroup(id);
        }
        /// <summary>
        /// Method CreateGroup_GroupDTO_Void()
        /// </summary>
        [Fact]
        public void CreateGroup_GroupDTO_Void()
        {
            SessionForStudents.Services.GroupService.CreateGroup(GrroupService1.GetGroup());
        }
        /// <summary>
        /// Method UpdateGroup_GroupDTO_Void()
        /// </summary>
        [Fact]
        public void UpdateGroup_GroupDTO_Void()
        {
            SessionForStudents.Services.GroupService.UpdateGroup(GrroupService1.GetGroup1());
        }
        /// <summary>
        /// Method DeleteGroup_Id_Void(int id)
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteGroup_Id_Void(int id)
        {
            SessionForStudents.Services.GroupService.DeleteGroup(id);
        }
    }
}
