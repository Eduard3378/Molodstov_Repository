using AutoMapper;
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
    /// Class GroupService
    /// </summary>
    public class GroupService : IGroupService
    {       
        /// <summary>
        /// Constructor GroupService()
        /// </summary>
        public GroupService()
        {
        }       
        /// <summary>
        /// Method AddToGroup(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        public static void AddToGroup(int groupId, int studentId)
        {
            using (SessionContext db = new SessionContext())
            {               
                var groups = db.StudentGroups.ToList();
                var group = groups.Find(p => p.GroupId == groupId);
                if (group == null) throw new ValidationException("Группа не найдена!", "");
                var inGroup = groups.Find(p => p.GroupId == groupId && p.StudentId == studentId);
                if (inGroup == null)
                {
                    db.StudentGroups.Add(new StudentGroup { GroupId = groupId, StudentId = studentId });
                }
                else if (inGroup != null)
                {
                    throw new ValidationException("Студент уже добавлен в эту группу!", "");
                }
            }
        }
        /// <summary>
        /// Method ExcludeFromGroup(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        public static void ExcludeFromGroup(int groupId, int studentId)
        {
            using (SessionContext db = new SessionContext())
            {
                var groups = db.StudentGroups.ToList();
                var group = groups.Find(p => p.GroupId == groupId);
                var inGroup = groups.Find(p => p.GroupId == groupId && p.StudentId == studentId);
                if (inGroup!=null)
                {
                    db.StudentGroups.Remove(group);                    
                }
                else
                {
                    throw new ValidationException("Студент не записан в группу!", "");
                }
            }
        }
        /// <summary>
        /// Method GetGroup(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get a group by id</returns>
        public static GroupDTO GetGroup(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var groups = db.StudentGroups.ToList();
                var group = groups.Find(p => p.StudentId == id);
                if (group == null)
                {
                    throw new ValidationException("Студент не записан в группу!", "");
                }
                else
                {
                    var mapperGroup = new MapperConfiguration(cfg => cfg.CreateMap<StudentGroup, GroupDTO>()).CreateMapper();
                    var dtoParty = mapperGroup.Map<StudentGroup, GroupDTO>(group);
                    return dtoParty;
                }
            }
        }
        /// <summary>
        /// Method CreateGroup(GroupDTO groupDTO)
        /// </summary>
        /// <param name="groupDTO"></param>
        public static void CreateGroup(GroupDTO groupDTO)
        {
            using (SessionContext db = new SessionContext())
            {                        
                db.Groups.Add(new Group
                {
                    StudentId = groupDTO.StudentId,
                    GroupName = groupDTO.GroupName,
                    DateOfOffsetId = groupDTO.DateOfOffsetId,
                    DateOfOffset1Id = groupDTO.DateOfOffset1Id,
                    DateOfOffset2Id = groupDTO.DateOfOffset2Id,
                    DateOfExaminationId = groupDTO.DateOfExaminationId,
                    DateOfExamination1Id = groupDTO.DateOfExamination1Id,
                    DateOfExamination2Id = groupDTO.DateOfExamination2Id,
                });               
            }
        }
        /// <summary>
        /// Method UpdateGroup(GroupDTO groupDTO)
        /// </summary>
        /// <param name="groupDTO"></param>
        public static void UpdateGroup(GroupDTO groupDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                var groups = db.Groups.ToList();
                var group = groups.Find(p => p.Id == groupDTO.Id);
                if (group == null)
                {
                    throw new ValidationException("Группа не найдена!", "");
                }
                else
                {
                    group.StudentId = groupDTO.StudentId;
                    group.GroupName = groupDTO.GroupName;
                    group.DateOfOffsetId = groupDTO.DateOfOffsetId;
                    group.DateOfOffset1Id = groupDTO.DateOfOffset1Id;
                    group.DateOfOffset2Id = groupDTO.DateOfOffset2Id;
                    group.DateOfExaminationId = groupDTO.DateOfExaminationId;
                    group.DateOfExamination1Id = groupDTO.DateOfExamination1Id;
                    group.DateOfExamination2Id = groupDTO.DateOfExamination2Id;
                    db.Groups.Update(group);                    
                }
            }
        }
        /// <summary>
        /// Method DeleteGroup(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteGroup(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var groups = db.Groups.ToList();
                var group = groups.Find(p => p.Id == id);
                if (group == null)
                {
                    throw new ValidationException("Группа не найдена!", "");
                }
                else
                {
                    db.Groups.Remove(group);
                    var studentGroups = db.StudentGroups.ToList();
                    var studentGroup = studentGroups.Find(p => p.GroupId == id);
                    db.StudentGroups.Remove(studentGroup);
                    var students = db.Students.ToList();
                    var student = students.Find(p => p.Id == studentGroup.StudentId);
                    db.Students.Remove(student);
                }
            }
        }
    }
}
