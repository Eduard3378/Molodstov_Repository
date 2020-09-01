using SessionForStudents.DTO;
using SessionForStudents.EF;
using SessionForStudents.Entities;
using SessionForStudents.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionForStudents.Services
{
    /// <summary>
    /// Class SNPForSubjectService
    /// </summary>
    public class SNPForSubjectService
    {
        /// <summary>
        /// Constructor SNPForSubjectService()
        /// </summary>
        public SNPForSubjectService()
        {
        }
        /// <summary>
        /// Method GetSNPForSubject(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void GetSNPForSubject(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var snpforsubjects = db.SNPForSubjects.ToList();
                foreach (var item in snpforsubjects)
                {
                    if (item.Id == id)
                    {
                        SNPForSubjectDTO snpforsubject = new SNPForSubjectDTO();
                        snpforsubject.Id = item.Id;
                        snpforsubject.GroupId = item.GroupId;                        
                        snpforsubject.SessionId = item.SessionId;                        
                        snpforsubject.GroupDateOfOffsetId = item.GroupDateOfOffsetId;
                        snpforsubject.DateOfOffset = item.DateOfOffset;
                        snpforsubject.SNPOfOffset = item.SNPOfOffset;
                        snpforsubject.GroupDateOfOffset1Id = item.GroupDateOfOffset1Id;
                        snpforsubject.DateOfOffset1 = item.DateOfOffset1;
                        snpforsubject.SNPOfOffset1 = item.SNPOfOffset1;
                        snpforsubject.GroupDateOfOffset2Id = item.GroupDateOfExamination2Id;
                        snpforsubject.DateOfOffset2 = item.DateOfOffset2;
                        snpforsubject.SNPOfOffset2 = item.SNPOfOffset2;
                        snpforsubject.GroupDateOfExaminationId = item.GroupDateOfExaminationId;
                        snpforsubject.DateOfExamination = item.DateOfExamination;
                        snpforsubject.SNPOfExamination = item.SNPOfExamination;
                        snpforsubject.GroupDateOfExamination1Id = item.GroupDateOfExamination1Id;
                        snpforsubject.DateOfExamination1 = item.DateOfExamination1;
                        snpforsubject.SNPOfExamination1 = item.SNPOfExamination1;
                        snpforsubject.GroupDateOfExamination2Id = item.GroupDateOfExamination2Id;
                        snpforsubject.DateOfExamination2 = item.DateOfExamination2;
                        snpforsubject.SNPOfExamination2 = item.SNPOfExamination2;
                    }
                }
            }
        }
        /// <summary>
        /// Method CreateSNPForSubject(SNPForSubjectDTO sNPForSubjectDTO)
        /// </summary>
        /// <param name="sNPForSubjectDTO"></param>
        public static void CreateSNPForSubject(SNPForSubjectDTO sNPForSubjectDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                db.SNPForSubjects.Add(new SNPForSubject
                {
                    GroupId = sNPForSubjectDTO.GroupId,
                    SessionId = sNPForSubjectDTO.SessionId,
                    GroupDateOfOffsetId = sNPForSubjectDTO.GroupDateOfOffsetId,
                    DateOfOffset = sNPForSubjectDTO.DateOfOffset,
                    SNPOfOffset = sNPForSubjectDTO.SNPOfOffset,
                    GroupDateOfOffset1Id = sNPForSubjectDTO.GroupDateOfOffset1Id,
                    DateOfOffset1 = sNPForSubjectDTO.DateOfOffset1,
                    SNPOfOffset1 = sNPForSubjectDTO.SNPOfOffset1,
                    GroupDateOfOffset2Id = sNPForSubjectDTO.GroupDateOfOffset2Id,
                    DateOfOffset2 = sNPForSubjectDTO.DateOfOffset2,
                    SNPOfOffset2 = sNPForSubjectDTO.SNPOfOffset2,
                    GroupDateOfExaminationId = sNPForSubjectDTO.GroupDateOfExaminationId,
                    DateOfExamination = sNPForSubjectDTO.DateOfExamination,
                    SNPOfExamination = sNPForSubjectDTO.SNPOfExamination,
                    GroupDateOfExamination1Id = sNPForSubjectDTO.GroupDateOfExamination1Id,
                    DateOfExamination1 = sNPForSubjectDTO.DateOfExamination1,
                    SNPOfExamination1 = sNPForSubjectDTO.SNPOfExamination1,
                    GroupDateOfExamination2Id = sNPForSubjectDTO.GroupDateOfExamination2Id,
                    DateOfExamination2 = sNPForSubjectDTO.DateOfExamination2,
                    SNPOfExamination2 = sNPForSubjectDTO.SNPOfExamination2
            });
            }
        }
        /// <summary>
        /// Method UpdateSNPForSubject(SNPForSubjectDTO sNPForSubjectDTO)
        /// </summary>
        /// <param name="sNPForSubjectDTO"></param>

        public static void UpdateSNPForSubject(SNPForSubjectDTO sNPForSubjectDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                var snpforsubjects = db.SNPForSubjects.ToList();
                var snpforsubject = snpforsubjects.Find(p => p.Id == sNPForSubjectDTO.Id);
                if (sNPForSubjectDTO == null)
                {
                    throw new ValidationException("Список преподавателей не найден!", "");
                }
                else
                {
                    snpforsubject.GroupId = sNPForSubjectDTO.GroupId;
                    snpforsubject.SessionId = sNPForSubjectDTO.SessionId;
                    snpforsubject.GroupDateOfOffsetId = sNPForSubjectDTO.GroupDateOfOffsetId;
                    snpforsubject.DateOfOffset = sNPForSubjectDTO.DateOfOffset;
                    snpforsubject.SNPOfOffset = sNPForSubjectDTO.SNPOfOffset;
                    snpforsubject.GroupDateOfOffset1Id = sNPForSubjectDTO.GroupDateOfOffset1Id;
                    snpforsubject.DateOfOffset1 = sNPForSubjectDTO.DateOfOffset1;
                    snpforsubject.SNPOfOffset1 = sNPForSubjectDTO.SNPOfOffset1;
                    snpforsubject.GroupDateOfOffset2Id = sNPForSubjectDTO.GroupDateOfOffset2Id;
                    snpforsubject.DateOfOffset2 = sNPForSubjectDTO.DateOfOffset2;
                    snpforsubject.SNPOfOffset2 = sNPForSubjectDTO.SNPOfOffset2;
                    snpforsubject.GroupDateOfExaminationId = sNPForSubjectDTO.GroupDateOfExaminationId;
                    snpforsubject.DateOfExamination = sNPForSubjectDTO.DateOfExamination;
                    snpforsubject.SNPOfExamination = sNPForSubjectDTO.SNPOfExamination;
                    snpforsubject.GroupDateOfExamination1Id = sNPForSubjectDTO.GroupDateOfExamination1Id;
                    snpforsubject.DateOfExamination1 = sNPForSubjectDTO.DateOfExamination1;
                    snpforsubject.SNPOfExamination1 = sNPForSubjectDTO.SNPOfExamination1;
                    snpforsubject.GroupDateOfExamination2Id = sNPForSubjectDTO.GroupDateOfExamination2Id;
                    snpforsubject.DateOfExamination2 = sNPForSubjectDTO.DateOfExamination2;
                    snpforsubject.SNPOfExamination2 = sNPForSubjectDTO.SNPOfExamination2;
                }
            }
        }
        /// <summary>
        /// Method DeleteSNPForSubject(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteSNPForSubject(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var snpforsubjects = db.SNPForSubjects.ToList();
                var snpforsubject = snpforsubjects.Find(p => p.Id == id);
                if (snpforsubject == null)
                {
                    throw new ValidationException("Список преподавателей не найден!", "");
                }
                else
                {
                    db.SNPForSubjects.Remove(snpforsubject);                   
                }
            }
        }
    }
}
