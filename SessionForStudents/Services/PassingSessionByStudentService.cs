using SessionForStudents.DTO;
using SessionForStudents.Entities;
using SessionForStudents.Infrastructure;
using SessionForStudents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using SessionForStudents.EF;

namespace SessionForStudents.Services
{
    /// <summary>
    /// Class PassingSessionByStudentService
    /// </summary>
    public class PassingSessionByStudentService : IPassingSessionByStudentService
    {        
        /// <summary>
        /// Constructor PassingSessionByStudentService()
        /// </summary>
        public PassingSessionByStudentService()
        {
        }       
        /// <summary>
        /// Method GetPassingSessionByStudent(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get a list of student grades by student ID</returns>
        public static void GetPassingSessionByStudent(int id)
        {
            using (SessionContext db = new SessionContext())
            {               
                    var passingSessionByStudents = db.PassingSessionByStudents.ToList();
                foreach (var item in passingSessionByStudents)
                {
                    if (item.Id == id)
                    {
                        PassingSessionByStudentDTO passingSessionByStudent = new PassingSessionByStudentDTO();
                        passingSessionByStudent.Id = item.Id;
                        passingSessionByStudent.StudentId = item.StudentId;
                        passingSessionByStudent.SessionId = item.SessionId;                        
                        passingSessionByStudent.CreditScore1 = item.CreditScore1;
                        passingSessionByStudent.CreditScore2 = item.CreditScore2;
                        passingSessionByStudent.CreditScore3 = item.CreditScore3;
                        passingSessionByStudent.ExamMark1 = item.ExamMark1;
                        passingSessionByStudent.ExamMark2 = item.ExamMark2;
                        passingSessionByStudent.ExamMark3 = item.ExamMark3;
                    }
                }               
            }
        }
        /// <summary>
        /// Method CreatePassingSessionByStudent(PassingSessionByStudentDTO passingSessionByStudentDTO)
        /// </summary>
        /// <param name="passingSessionByStudentDTO"></param>
        public static void CreatePassingSessionByStudent(PassingSessionByStudentDTO passingSessionByStudentDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                db.PassingSessionByStudents.Add(new PassingSessionByStudent
                {
                    StudentId = passingSessionByStudentDTO.StudentId,
                    SessionId = passingSessionByStudentDTO.SessionId,
                    CreditScore1 = passingSessionByStudentDTO.CreditScore1,
                    CreditScore2 = passingSessionByStudentDTO.CreditScore2,
                    CreditScore3 = passingSessionByStudentDTO.CreditScore3,
                    ExamMark1 = passingSessionByStudentDTO.ExamMark1,
                    ExamMark2 = passingSessionByStudentDTO.ExamMark2,
                    ExamMark3 = passingSessionByStudentDTO.ExamMark3
                });
            }
        }
        /// <summary>
        /// Method UpdatePassingSessionByStudentDTO(PassingSessionByStudentDTO passingSessionByStudentDTO)
        /// </summary>
        /// <param name="passingSessionByStudentDTO"></param>
        public static void UpdatePassingSessionByStudentDTO(PassingSessionByStudentDTO passingSessionByStudentDTO)
        {
            using (SessionContext db = new SessionContext())
            {
                var passingSessionByStudents = db.PassingSessionByStudents.ToList();
                var passingSessionByStudent = passingSessionByStudents.Find(p => p.Id == passingSessionByStudentDTO.Id);
                if (passingSessionByStudentDTO == null)
                {
                    throw new ValidationException("Список оценок не найдена!", "");
                }
                else
                {
                    passingSessionByStudent.StudentId = passingSessionByStudentDTO.StudentId;
                    passingSessionByStudent.SessionId = passingSessionByStudentDTO.SessionId;
                    passingSessionByStudent.CreditScore1 = passingSessionByStudentDTO.CreditScore1;
                    passingSessionByStudent.CreditScore2 = passingSessionByStudentDTO.CreditScore2;
                    passingSessionByStudent.CreditScore3 = passingSessionByStudentDTO.CreditScore3;
                    passingSessionByStudent.ExamMark1 = passingSessionByStudentDTO.ExamMark1;
                    passingSessionByStudent.ExamMark2 = passingSessionByStudentDTO.ExamMark2;
                    passingSessionByStudent.ExamMark3 = passingSessionByStudentDTO.ExamMark3;
                    db.PassingSessionByStudents.Update(passingSessionByStudent);
                }                
            }
        }
        /// <summary>
        /// Method DeletePassingSessionByStudentDTO(int id)
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePassingSessionByStudentDTO(int id)
        {
            using (SessionContext db = new SessionContext())
            {
                var passingSessionByStudents = db.PassingSessionByStudents.ToList();
                var passingSessionByStudent = passingSessionByStudents.Find(p => p.StudentId == id);
                if (passingSessionByStudent == null)
                {
                    throw new ValidationException("Список оценок не найден!", "");
                }
                else
                {
                    db.PassingSessionByStudents.Remove(passingSessionByStudent);
                    var studentGroups = db.StudentGroups.ToList();
                    var studentGroup = studentGroups.Find(p => p.StudentId == id);
                    db.StudentGroups.Remove(studentGroup);
                    var students = db.Students.ToList();
                    var student = students.Find(p => p.Id == studentGroup.StudentId);
                    db.Students.Remove(student);
                }
            }
        }
        /// <summary>
        /// Method ResultsOfTheSessionForEachGroup(List<PassingSessionByStudent> passingSessionByStudent,
        /// List<StudentGroup> studentGroup)
        /// </summary>
        /// <param name="passingSessionByStudent"></param>
        /// <param name="studentGroup"></param>
        public static void ResultsOfTheSessionForEachGroup(List<PassingSessionByStudent> passingSessionByStudent,
            List<StudentGroup> studentGroup)
        {
            
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application(); //Excel
            Microsoft.Office.Interop.Excel.Workbook xlWB; //рабочая книга              
            Microsoft.Office.Interop.Excel.Worksheet xlSht; //лист Excel   

            xlWB = xlApp.Workbooks.Add(); //создаём рабочую книгу Excel 
            xlSht = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveSheet; //Лист1           
            int i = 0;
            int j = 0;
            using (SessionContext db = new SessionContext())
            {
                Console.WriteLine("Итоги сессии2 по каждой группе:");
                foreach (var u in passingSessionByStudent)
                {
                    foreach (var z in studentGroup)
                    {
                        if (u.SessionId == 2 && u.StudentId == z.StudentId && z.GroupId == 1)
                        {
                            List<double> bal6 = new List<double>();
                            Console.WriteLine("По группе 1:");
                            bal6.Add(Int32.Parse(u.CreditScore1)); bal6.Add(Int32.Parse(u.CreditScore2)); bal6.Add(Int32.Parse(u.CreditScore3));
                            bal6.Add(Int32.Parse(u.ExamMark1)); bal6.Add(Int32.Parse(u.ExamMark2)); bal6.Add(Int32.Parse(u.ExamMark3));
                            var bal7 = from st3 in bal6
                                       orderby st3
                                       select st3;
                            Console.WriteLine("Сортировка по возрастанию оценок по студенту");
                            Console.WriteLine($"{u.Id} {u.StudentId} {u.SessionId} ");
                            foreach (var st3 in bal7)
                            {
                                Console.WriteLine(st3);
                            }
                            i++;
                            xlSht.Cells[i, j + 1] = "По группе 1:";
                            i++;
                            xlSht.Cells[i, j + 1] = u.Id; xlSht.Cells[i, j + 2] = u.StudentId; xlSht.Cells[i, j + 3] = u.SessionId;
                            xlSht.Cells[i, j + 4] = u.CreditScore1; xlSht.Cells[i, j + 5] = u.CreditScore2; xlSht.Cells[i, j + 6] = u.CreditScore3;
                            xlSht.Cells[i, j + 7] = u.ExamMark1; xlSht.Cells[i, j + 8] = u.ExamMark2; xlSht.Cells[i, j + 9] = u.ExamMark3;

                            break;
                        }
                        else if (u.SessionId == 2 && u.StudentId == z.StudentId && z.GroupId == 2)
                        {
                            List<double> bal6 = new List<double>();
                            Console.WriteLine("По группе 2:");
                            bal6.Add(Int32.Parse(u.CreditScore1)); bal6.Add(Int32.Parse(u.CreditScore2)); bal6.Add(Int32.Parse(u.CreditScore3));
                            bal6.Add(Int32.Parse(u.ExamMark1)); bal6.Add(Int32.Parse(u.ExamMark2)); bal6.Add(Int32.Parse(u.ExamMark3));
                            var bal7 = from st3 in bal6
                                       orderby st3
                                       select st3;
                            Console.WriteLine("Сортировка по возрастанию оценок по студенту");
                            Console.WriteLine($"{u.Id} {u.StudentId} {u.SessionId} ");
                            foreach (var st3 in bal7)
                            {
                                Console.WriteLine(st3);
                            }
                            i++;
                            xlSht.Cells[i, j + 1] = "По группе 2:";
                            i++;
                            xlSht.Cells[i, j + 1] = u.Id; xlSht.Cells[i, j + 2] = u.StudentId; xlSht.Cells[i, j + 3] = u.SessionId;
                            xlSht.Cells[i, j + 4] = u.CreditScore1; xlSht.Cells[i, j + 5] = u.CreditScore2; xlSht.Cells[i, j + 6] = u.CreditScore3;
                            xlSht.Cells[i, j + 7] = u.ExamMark1; xlSht.Cells[i, j + 8] = u.ExamMark2; xlSht.Cells[i, j + 9] = u.ExamMark3;

                            break;
                        }
                        else if (u.SessionId == 2 && u.StudentId == z.StudentId && z.GroupId == 3)
                        {
                            List<double> bal6 = new List<double>();
                            Console.WriteLine("По группе 3:");
                            bal6.Add(Int32.Parse(u.CreditScore1)); bal6.Add(Int32.Parse(u.CreditScore2)); bal6.Add(Int32.Parse(u.CreditScore3));
                            bal6.Add(Int32.Parse(u.ExamMark1)); bal6.Add(Int32.Parse(u.ExamMark2)); bal6.Add(Int32.Parse(u.ExamMark3));
                            var bal7 = from st3 in bal6
                                       orderby st3
                                       select st3;
                            Console.WriteLine("Сортировка по возрастанию оценок по студенту");
                            Console.WriteLine($"{u.Id} {u.StudentId} {u.SessionId} ");
                            foreach (var st3 in bal7)
                            {
                                Console.WriteLine(st3);
                            }
                            i++;
                            xlSht.Cells[i, j + 1] = "По группе 3:";
                            i++;
                            xlSht.Cells[i, j + 1] = u.Id; xlSht.Cells[i, j + 2] = u.StudentId; xlSht.Cells[i, j + 3] = u.SessionId;
                            xlSht.Cells[i, j + 4] = u.CreditScore1; xlSht.Cells[i, j + 5] = u.CreditScore2; xlSht.Cells[i, j + 6] = u.CreditScore3;
                            xlSht.Cells[i, j + 7] = u.ExamMark1; xlSht.Cells[i, j + 8] = u.ExamMark2; xlSht.Cells[i, j + 9] = u.ExamMark3;
                            break;
                        }
                    }
                }
                var results = from appraisals in db.PassingSessionByStudents
                              join students in db.Students on appraisals.StudentId equals students.Id
                              join stgroups in db.StudentGroups on appraisals.StudentId equals stgroups.StudentId
                              join specialties in db.Specialties on stgroups.GroupId equals specialties.GroupId
                              select new
                              {
                                  SpecialtyName = specialties.SpecialtyName,
                                  SessionId = appraisals.SessionId,
                                  CreditScore1 = appraisals.CreditScore1,
                                  CreditScore2 = appraisals.CreditScore2,
                                  CreditScore3 = appraisals.CreditScore3,
                                  ExamMark1 = appraisals.ExamMark1,
                                  ExamMark2 = appraisals.ExamMark2,
                                  ExamMark3 = appraisals.ExamMark3,
                              };

                List<int> sumbal66 = new List<int>();
                List<int> sumbal67 = new List<int>();
                List<int> sumbal68 = new List<int>();
                int zk = i;
                Console.WriteLine("В рамках одной сессии средний балл по каждой специальности: ");
                foreach (var st in results)
                {
                    if (st.SessionId == 2 && st.SpecialtyName == "Инженер-электроник-программист")
                    {
                        Console.WriteLine("По специальности, Инженер - электроник - программист: ");
                        sumbal66.Add(Int32.Parse(st.CreditScore1)); sumbal66.Add(Int32.Parse(st.CreditScore2)); sumbal66.Add(Int32.Parse(st.CreditScore3));
                        sumbal66.Add(Int32.Parse(st.ExamMark1)); sumbal66.Add(Int32.Parse(st.ExamMark2)); sumbal66.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal66.Average());                                   
                        zk++;
                        xlSht.Cells[zk, j + 1] = "По сессии2, По специальности: Инженер - электроник - программист ";
                        zk++;
                        xlSht.Cells[zk, j + 1] = sumbal66.Average();
                        zk = i;
                        // break;
                    }
                    else if (st.SessionId == 2 && st.SpecialtyName == "Инженер по радиоэлектронике")
                    {
                        Console.WriteLine("По специальности, Инженер по радиоэлектронике: ");
                        sumbal67.Add(Int32.Parse(st.CreditScore1)); sumbal67.Add(Int32.Parse(st.CreditScore2)); sumbal67.Add(Int32.Parse(st.CreditScore3));
                        sumbal67.Add(Int32.Parse(st.ExamMark1)); sumbal67.Add(Int32.Parse(st.ExamMark2)); sumbal67.Add(Int32.Parse(st.ExamMark3));                        
                        Console.WriteLine(sumbal67.Average());                       
                        zk = i + 2;
                        zk++;
                        xlSht.Cells[zk, j + 1] = "По сессии2, По специальности: Инженер по радиоэлектронике ";
                        zk++;
                        xlSht.Cells[zk, j + 1] = sumbal67.Average();
                        zk = i;                       
                    }
                    else if (st.SessionId == 2 && st.SpecialtyName == "Инженер-проектировщик")
                    {
                        Console.WriteLine("По специальности, Инженер-проектировщик: ");
                        sumbal68.Add(Int32.Parse(st.CreditScore1)); sumbal68.Add(Int32.Parse(st.CreditScore2)); sumbal68.Add(Int32.Parse(st.CreditScore3));
                        sumbal68.Add(Int32.Parse(st.ExamMark1)); sumbal68.Add(Int32.Parse(st.ExamMark2)); sumbal68.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal68.Average());                        
                        zk = i + 4;
                        zk++;
                        xlSht.Cells[zk, j + 1] = "По сессии2, По специальности: Инженер-проектировщик ";
                        zk++;
                        xlSht.Cells[zk, j + 1] = sumbal68.Average();
                        zk = i;                       
                    }
                }
                var bal73 = from st33 in sumbal66
                            orderby st33
                            select st33;
                Console.WriteLine("Сортировка по возрастанию оценок по студентам, по специальности Инженер-электроник-программист, по сессии 2");               
                foreach (var st3 in bal73)
                {
                    Console.WriteLine(st3);
                }
                var bal74 = from st33 in sumbal67
                            orderby st33
                            select st33;
                Console.WriteLine("Сортировка по возрастанию оценок по студентам, по специальности Инженер по радиоэлектронике, по сессии 2");                
                foreach (var st3 in bal74)
                {
                    Console.WriteLine(st3);
                }
                var bal75 = from st33 in sumbal68
                            orderby st33
                            select st33;
                Console.WriteLine("Сортировка по возрастанию оценок по студентам, по специальности Инженер-проектировщик, по сессии 2");                
                foreach (var st3 in bal75)
                {
                    Console.WriteLine(st3);
                }

                var results1 = from appraisals in db.PassingSessionByStudents
                              join students in db.Students on appraisals.StudentId equals students.Id
                              join stgroups in db.StudentGroups on appraisals.StudentId equals stgroups.StudentId
                              join snpforsubjects in db.SNPForSubjects on stgroups.GroupId equals snpforsubjects.GroupId
                              select new
                              {
                                  GroupId = stgroups.GroupId,
                                  Snp = snpforsubjects.SNPOfExamination,
                                  Snp1 = snpforsubjects.SNPOfExamination1,
                                  Snp2 = snpforsubjects.SNPOfExamination2,
                                  SessionId = appraisals.SessionId,
                                  CreditScore1 = appraisals.CreditScore1,
                                  CreditScore2 = appraisals.CreditScore2,
                                  CreditScore3 = appraisals.CreditScore3,
                                  ExamMark1 = appraisals.ExamMark1,
                                  ExamMark2 = appraisals.ExamMark2,
                                  ExamMark3 = appraisals.ExamMark3,
                              };

                List<int> sumbal69 = new List<int>();
                List<int> sumbal70 = new List<int>();
                List<int> sumbal71 = new List<int>();
                List<int> sumbal72 = new List<int>();
                List<int> sumbal73 = new List<int>();
                List<int> sumbal74 = new List<int>();
                List<int> sumbal75 = new List<int>();
                List<int> sumbal76 = new List<int>();
                List<int> sumbal77 = new List<int>();
                int zl = i;
                Console.WriteLine("В рамках одной сессии средний балл по каждому экзаменатору: ");
                foreach (var st in results1)
                {
                    if (st.SessionId == 2 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId==1)
                    {                        
                        sumbal69.Add(Int32.Parse(st.ExamMark1));                        
                        zl = i + 6;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Павлова Татьяна Федоровна, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal69.Average();
                        zl = i;
                        // break;
                    }
                    if (st.SessionId == 2 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {                                               
                        sumbal70.Add(Int32.Parse(st.ExamMark2));                      
                        zl = i + 8;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Соколова Алина Петровна, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal70.Average();
                        zl = i;
                    }
                    if (st.SessionId == 2 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {                       
                        sumbal71.Add(Int32.Parse(st.ExamMark3));                     
                        zl = i + 10;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Тарасов Сергей Петрович, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal71.Average();
                        zl = i;
                    }
                    if (st.SessionId == 2 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal72.Add(Int32.Parse(st.ExamMark1));
                        zl = i + 12;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Иванов Федор Петрович, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal72.Average();
                        zl = i;
                        // break;
                    }
                    if (st.SessionId == 2 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal73.Add(Int32.Parse(st.ExamMark2));
                        zl = i + 14;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Петров Сергей Сидорович, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal73.Average();
                        zl = i;
                    }
                    if (st.SessionId == 2 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal74.Add(Int32.Parse(st.ExamMark3));
                        zl = i + 16;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Сидорова Мирина Сергеевна, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal74.Average();
                        zl = i;
                    }
                    if (st.SessionId == 2 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal75.Add(Int32.Parse(st.ExamMark1));
                        zl = i + 18;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Соколов Дмитрий Петрович, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal75.Average();
                        zl = i;
                        // break;
                    }
                    if (st.SessionId == 2 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal76.Add(Int32.Parse(st.ExamMark2));
                        zl = i + 20;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Книга Василий Васильевич, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal76.Average();
                        zl = i;
                    }
                    if (st.SessionId == 2 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal77.Add(Int32.Parse(st.ExamMark3));
                        zl = i + 22;
                        zl++;
                        xlSht.Cells[zl, j + 1] = "По сессии2, По экзаменатору: Солнцева Лариса Петровна, ";
                        zl++;
                        xlSht.Cells[zl, j + 1] = sumbal77.Average();
                        zl = i;
                    }
                }
                Console.WriteLine("По экзаменатору, Павлова Татьяна Федоровна: ");
                Console.WriteLine(sumbal69.Average());
                Console.WriteLine("По экзаменатору, Соколова Алина Петровна: ");
                Console.WriteLine(sumbal70.Average());
                Console.WriteLine("По экзаменатору, Тарасов Сергей Петрович: ");
                Console.WriteLine(sumbal71.Average());
                Console.WriteLine("По экзаменатору, Иванов Федор Петрович: ");
                Console.WriteLine(sumbal72.Average());
                Console.WriteLine("По экзаменатору, Петров Сергей Сидорович: ");
                Console.WriteLine(sumbal73.Average());
                Console.WriteLine("По экзаменатору, Сидорова Мирина Сергеевна: ");
                Console.WriteLine(sumbal74.Average());
                Console.WriteLine("По экзаменатору, Соколов Дмитрий Петрович: ");
                Console.WriteLine(sumbal75.Average());
                Console.WriteLine("По экзаменатору, Книга Василий Васильевич: ");
                Console.WriteLine(sumbal76.Average());
                Console.WriteLine("По экзаменатору, Солнцева Лариса Петровна: ");
                Console.WriteLine(sumbal77.Average());
                var ocen74 = from st33 in sumbal69
                            orderby st33 descending
                             select st33;
                Console.WriteLine("Сортировка экзаменационных оценок, по экзаменатору Павлова Татьяна Федоровна");
                foreach (var st3 in ocen74)
                {
                    Console.WriteLine(st3);
                }
                var ocen75 = from st33 in sumbal70
                             orderby st33 descending
                             select st33;
                Console.WriteLine("Сортировка экзаменационных оценок, по экзаменатору Соколова Алина Петровна");
                foreach (var st3 in ocen75)
                {
                    Console.WriteLine(st3);
                }
                var ocen76 = from st33 in sumbal71
                             orderby st33 descending
                             select st33;
                Console.WriteLine("Сортировка экзаменационных оценок, по экзаменатору Тарасов Сергей Петрович");
                foreach (var st3 in ocen76)
                {
                    Console.WriteLine(st3);
                }
                xlApp.Visible = true; 
                xlApp.UserControl = true;

                string folder = @"D:\EPAM\september\zadan01_09_2020\SessionForStudents\SessionForStudents\App_Data"; //путь папке  

                // ЕСЛИ НУЖНО СОХРАНИТЬ ФАЙЛ В ФОРМАТЕ EXCEL 2007 (XLSX) 
                string filename = "Students.xlsx"; //имя Excel файла, формат Excel 2007
                string fullfilename = System.IO.Path.Combine(folder, filename);
                if (System.IO.File.Exists(fullfilename)) System.IO.File.Delete(fullfilename);
                xlWB.SaveAs(fullfilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault); //формат Excel 2007

                xlWB.Close(false); //false - закрыть рабочую книгу не сохраняя изменения
                xlApp.Quit(); //закрываем приложение Excel
                Console.WriteLine("Файл сохранён!");
            }

        }
        /// <summary>
        /// Method AverMinMaxScoreForEachGroup()
        /// </summary>
        public static void AverMinMaxScoreForEachGroup()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application(); //Excel
            Microsoft.Office.Interop.Excel.Workbook xlWB; //рабочая книга              
            Microsoft.Office.Interop.Excel.Worksheet xlSht; //лист Excel   

            xlWB = xlApp.Workbooks.Add(); //создаём рабочую книгу Excel 
            xlSht = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveSheet; //Лист1
            
            int i = 0;
            int j = 0;           
            Console.WriteLine("Средний/минимальный/максимальный балл по каждой группе :");
            using (SessionContext db = new SessionContext())
            {
                var students = db.PassingSessionByStudents.Join(db.StudentGroups, // второй набор
                p => p.StudentId, // свойство-селектор объекта из первого набора
                s => s.StudentId, // свойство-селектор объекта из второго набора
                (p, s) => new // результат
                {
                    StudentId = p.StudentId,
                    SGStudentId = s.StudentId,
                    SGGroupId = s.GroupId,
                    SessionId = p.SessionId,
                    CreditScore1 = p.CreditScore1,
                    CreditScore2 = p.CreditScore2,
                    CreditScore3 = p.CreditScore3,
                    ExamMark1 = p.ExamMark1,
                    ExamMark2 = p.ExamMark2,
                    ExamMark3 = p.ExamMark3,
                });
                List<int> sumbal = new List<int>();
                List<int> sumbal1 = new List<int>(); List<int> sumbal2 = new List<int>();
                List<int> sumbal3 = new List<int>(); List<int> sumbal4 = new List<int>();
                List<int> sumbal5 = new List<int>(); List<int> sumbal6 = new List<int>();
                List<int> sumbal7 = new List<int>(); List<int> sumbal8 = new List<int>();
                List<int> sumbal9 = new List<int>(); List<int> sumbal10 = new List<int>();
                List<int> sumbal11 = new List<int>(); List<int> sumbal12 = new List<int>();
                List<int> sumbal13 = new List<int>(); List<int> sumbal14 = new List<int>();
                List<int> sumbal15 = new List<int>(); List<int> sumbal16 = new List<int>();
                List<int> sumbal17 = new List<int>();

                foreach (var st in students)
                {                    
                    if (st.SGGroupId == 1 && st.SessionId == 1)
                    {
                        Console.WriteLine("По группе 1, по сессии1 cредний/минимальный/максимальный балл:");                      
                        sumbal.Add(Int32.Parse(st.CreditScore1)); sumbal.Add(Int32.Parse(st.CreditScore2)); sumbal.Add(Int32.Parse(st.CreditScore3));
                        sumbal.Add(Int32.Parse(st.ExamMark1)); sumbal.Add(Int32.Parse(st.ExamMark2)); sumbal.Add(Int32.Parse(st.ExamMark3));                     
                        Console.WriteLine(sumbal.Average());
                        Console.WriteLine(sumbal.Min());
                        Console.WriteLine(sumbal.Max());
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 1:"; xlSht.Cells[i, j + 2] = "По группе 1:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal.Average(); 
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal.Max();
                        i = 0;                      
                    }
                    else if (st.SGGroupId == 2 && st.SessionId == 1)
                    {
                        Console.WriteLine("По группе 2, по сессии1 cредний/минимальный/максимальный балл:");                        
                        sumbal1.Add(Int32.Parse(st.CreditScore1)); sumbal1.Add(Int32.Parse(st.CreditScore2)); sumbal1.Add(Int32.Parse(st.CreditScore3));
                        sumbal1.Add(Int32.Parse(st.ExamMark1)); sumbal1.Add(Int32.Parse(st.ExamMark2)); sumbal1.Add(Int32.Parse(st.ExamMark3));                       
                        Console.WriteLine(sumbal1.Average());
                        Console.WriteLine(sumbal1.Min());
                        Console.WriteLine(sumbal1.Max());
                        i = 2;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 1:"; xlSht.Cells[i, j + 2] = "По группе 2:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal1.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal1.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal1.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 3 && st.SessionId == 1)
                    {
                        Console.WriteLine("По группе 3, по сессии1 cредний/минимальный/максимальный балл:");
                        sumbal2.Add(Int32.Parse(st.CreditScore1)); sumbal2.Add(Int32.Parse(st.CreditScore2)); sumbal2.Add(Int32.Parse(st.CreditScore3));
                        sumbal2.Add(Int32.Parse(st.ExamMark1)); sumbal2.Add(Int32.Parse(st.ExamMark2)); sumbal2.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal2.Average());
                        Console.WriteLine(sumbal2.Min());
                        Console.WriteLine(sumbal2.Max());
                        i = 4;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 1:"; xlSht.Cells[i, j + 2] = "По группе 3:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal2.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal2.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal2.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 1 && st.SessionId == 2)
                    {
                        Console.WriteLine("По группе 1, по сессии2 cредний/минимальный/максимальный балл:");
                        sumbal3.Add(Int32.Parse(st.CreditScore1)); sumbal3.Add(Int32.Parse(st.CreditScore2)); sumbal3.Add(Int32.Parse(st.CreditScore3));
                        sumbal3.Add(Int32.Parse(st.ExamMark1)); sumbal3.Add(Int32.Parse(st.ExamMark2)); sumbal3.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal3.Average());
                        Console.WriteLine(sumbal3.Min());
                        Console.WriteLine(sumbal3.Max());
                        i = 6;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 2:"; xlSht.Cells[i, j + 2] = "По группе 1:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal3.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal3.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal3.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 2 && st.SessionId == 2)
                    {
                        Console.WriteLine("По группе 2, по сессии2 cредний/минимальный/максимальный балл:");
                        sumbal4.Add(Int32.Parse(st.CreditScore1)); sumbal4.Add(Int32.Parse(st.CreditScore2)); sumbal4.Add(Int32.Parse(st.CreditScore3));
                        sumbal4.Add(Int32.Parse(st.ExamMark1)); sumbal4.Add(Int32.Parse(st.ExamMark2)); sumbal4.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal4.Average());
                        Console.WriteLine(sumbal4.Min());
                        Console.WriteLine(sumbal4.Max());
                        i = 8;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 2:"; xlSht.Cells[i, j + 2] = "По группе 2:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal4.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal4.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal4.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 3 && st.SessionId == 2)
                    {
                        Console.WriteLine("По группе 3, по сессии2 cредний/минимальный/максимальный балл:");
                        sumbal5.Add(Int32.Parse(st.CreditScore1)); sumbal5.Add(Int32.Parse(st.CreditScore2)); sumbal5.Add(Int32.Parse(st.CreditScore3));
                        sumbal5.Add(Int32.Parse(st.ExamMark1)); sumbal5.Add(Int32.Parse(st.ExamMark2)); sumbal5.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal5.Average());
                        Console.WriteLine(sumbal5.Min());
                        Console.WriteLine(sumbal5.Max());
                        i = 10;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 2:"; xlSht.Cells[i, j + 2] = "По группе 3:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal5.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal5.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal5.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 1 && st.SessionId == 3)
                    {
                        Console.WriteLine("По группе 1, по сессии3 cредний/минимальный/максимальный балл:");
                        sumbal6.Add(Int32.Parse(st.CreditScore1)); sumbal6.Add(Int32.Parse(st.CreditScore2)); sumbal6.Add(Int32.Parse(st.CreditScore3));
                        sumbal6.Add(Int32.Parse(st.ExamMark1)); sumbal6.Add(Int32.Parse(st.ExamMark2)); sumbal6.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal6.Average());
                        Console.WriteLine(sumbal6.Min());
                        Console.WriteLine(sumbal6.Max());
                        i = 12;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 3:"; xlSht.Cells[i, j + 2] = "По группе 1:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal6.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal6.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal6.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 2 && st.SessionId == 3)
                    {
                        Console.WriteLine("По группе 2, по сессии3 cредний/минимальный/максимальный балл:");
                        sumbal7.Add(Int32.Parse(st.CreditScore1)); sumbal7.Add(Int32.Parse(st.CreditScore2)); sumbal7.Add(Int32.Parse(st.CreditScore3));
                        sumbal7.Add(Int32.Parse(st.ExamMark1)); sumbal7.Add(Int32.Parse(st.ExamMark2)); sumbal7.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal7.Average());
                        Console.WriteLine(sumbal7.Min());
                        Console.WriteLine(sumbal7.Max());
                        i = 14;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 3:"; xlSht.Cells[i, j + 2] = "По группе 2:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal7.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal7.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal7.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 3 && st.SessionId == 3)
                    {
                        Console.WriteLine("По группе 3, по сессии3 cредний/минимальный/максимальный балл:");
                        sumbal8.Add(Int32.Parse(st.CreditScore1)); sumbal8.Add(Int32.Parse(st.CreditScore2)); sumbal8.Add(Int32.Parse(st.CreditScore3));
                        sumbal8.Add(Int32.Parse(st.ExamMark1)); sumbal8.Add(Int32.Parse(st.ExamMark2)); sumbal8.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal8.Average());
                        Console.WriteLine(sumbal8.Min());
                        Console.WriteLine(sumbal8.Max());
                        i = 16;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 3:"; xlSht.Cells[i, j + 2] = "По группе 3:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal8.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal8.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal8.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 1 && st.SessionId == 4)
                    {
                        Console.WriteLine("По группе 1, по сессии4 cредний/минимальный/максимальный балл:");
                        sumbal9.Add(Int32.Parse(st.CreditScore1)); sumbal9.Add(Int32.Parse(st.CreditScore2)); sumbal9.Add(Int32.Parse(st.CreditScore3));
                        sumbal9.Add(Int32.Parse(st.ExamMark1)); sumbal9.Add(Int32.Parse(st.ExamMark2)); sumbal9.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal9.Average());
                        Console.WriteLine(sumbal9.Min());
                        Console.WriteLine(sumbal9.Max());
                        i = 18;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 4:"; xlSht.Cells[i, j + 2] = "По группе 1:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal9.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal9.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal9.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 2 && st.SessionId == 4)
                    {
                        Console.WriteLine("По группе 2, по сессии4 cредний/минимальный/максимальный балл:");
                        sumbal10.Add(Int32.Parse(st.CreditScore1)); sumbal10.Add(Int32.Parse(st.CreditScore2)); sumbal10.Add(Int32.Parse(st.CreditScore3));
                        sumbal10.Add(Int32.Parse(st.ExamMark1)); sumbal10.Add(Int32.Parse(st.ExamMark2)); sumbal10.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal10.Average());
                        Console.WriteLine(sumbal10.Min());
                        Console.WriteLine(sumbal10.Max());
                        i = 20;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 4:"; xlSht.Cells[i, j + 2] = "По группе 2:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal10.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal10.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal10.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 3 && st.SessionId == 4)
                    {
                        Console.WriteLine("По группе 3, по сессии4 cредний/минимальный/максимальный балл:");
                        sumbal11.Add(Int32.Parse(st.CreditScore1)); sumbal11.Add(Int32.Parse(st.CreditScore2)); sumbal11.Add(Int32.Parse(st.CreditScore3));
                        sumbal11.Add(Int32.Parse(st.ExamMark1)); sumbal11.Add(Int32.Parse(st.ExamMark2)); sumbal11.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal11.Average());
                        Console.WriteLine(sumbal11.Min());
                        Console.WriteLine(sumbal11.Max());
                        i = 22;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 4:"; xlSht.Cells[i, j + 2] = "По группе 3:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal11.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal11.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal11.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 1 && st.SessionId == 5)
                    {
                        Console.WriteLine("По группе 1, по сессии 5 cредний/минимальный/максимальный балл:");
                        sumbal12.Add(Int32.Parse(st.CreditScore1)); sumbal12.Add(Int32.Parse(st.CreditScore2)); sumbal12.Add(Int32.Parse(st.CreditScore3));
                        sumbal12.Add(Int32.Parse(st.ExamMark1)); sumbal12.Add(Int32.Parse(st.ExamMark2)); sumbal12.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal12.Average());
                        Console.WriteLine(sumbal12.Min());
                        Console.WriteLine(sumbal12.Max());
                        i = 24;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 5:"; xlSht.Cells[i, j + 2] = "По группе 1:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal12.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal12.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal12.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 2 && st.SessionId == 5)
                    {
                        Console.WriteLine("По группе 2, по сессии 5 cредний/минимальный/максимальный балл:");
                        sumbal13.Add(Int32.Parse(st.CreditScore1)); sumbal13.Add(Int32.Parse(st.CreditScore2)); sumbal13.Add(Int32.Parse(st.CreditScore3));
                        sumbal13.Add(Int32.Parse(st.ExamMark1)); sumbal13.Add(Int32.Parse(st.ExamMark2)); sumbal13.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal13.Average());
                        Console.WriteLine(sumbal13.Min());
                        Console.WriteLine(sumbal13.Max());
                        i = 26;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 5:"; xlSht.Cells[i, j + 2] = "По группе 2:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal13.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal13.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal13.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 3 && st.SessionId == 5)
                    {
                        Console.WriteLine("По группе 3, по сессии 5 cредний/минимальный/максимальный балл:");
                        sumbal14.Add(Int32.Parse(st.CreditScore1)); sumbal14.Add(Int32.Parse(st.CreditScore2)); sumbal14.Add(Int32.Parse(st.CreditScore3));
                        sumbal14.Add(Int32.Parse(st.ExamMark1)); sumbal14.Add(Int32.Parse(st.ExamMark2)); sumbal14.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal14.Average());
                        Console.WriteLine(sumbal14.Min());
                        Console.WriteLine(sumbal14.Max());
                        i = 28;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 5:"; xlSht.Cells[i, j + 2] = "По группе 3:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal14.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal14.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal14.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 1 && st.SessionId == 6)
                    {
                        Console.WriteLine("По группе 1, по сессии 6 cредний/минимальный/максимальный балл:");
                        sumbal15.Add(Int32.Parse(st.CreditScore1)); sumbal15.Add(Int32.Parse(st.CreditScore2)); sumbal15.Add(Int32.Parse(st.CreditScore3));
                        sumbal15.Add(Int32.Parse(st.ExamMark1)); sumbal15.Add(Int32.Parse(st.ExamMark2)); sumbal15.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal15.Average());
                        Console.WriteLine(sumbal15.Min());
                        Console.WriteLine(sumbal15.Max());
                        i = 30;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 6:"; xlSht.Cells[i, j + 2] = "По группе 1:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal15.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal15.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal15.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 2 && st.SessionId == 6)
                    {
                        Console.WriteLine("По группе 2, по сессии 6 cредний/минимальный/максимальный балл:");
                        sumbal16.Add(Int32.Parse(st.CreditScore1)); sumbal16.Add(Int32.Parse(st.CreditScore2)); sumbal16.Add(Int32.Parse(st.CreditScore3));
                        sumbal16.Add(Int32.Parse(st.ExamMark1)); sumbal16.Add(Int32.Parse(st.ExamMark2)); sumbal16.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal16.Average());
                        Console.WriteLine(sumbal16.Min());
                        Console.WriteLine(sumbal16.Max());
                        i = 32;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 6:"; xlSht.Cells[i, j + 2] = "По группе 2:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal16.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal16.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal16.Max();
                        i = 0;
                    }
                    else if (st.SGGroupId == 3 && st.SessionId == 6)
                    {
                        Console.WriteLine("По группе 3, по сессии 6 cредний/минимальный/максимальный балл:");
                        sumbal17.Add(Int32.Parse(st.CreditScore1)); sumbal17.Add(Int32.Parse(st.CreditScore2)); sumbal17.Add(Int32.Parse(st.CreditScore3));
                        sumbal17.Add(Int32.Parse(st.ExamMark1)); sumbal17.Add(Int32.Parse(st.ExamMark2)); sumbal17.Add(Int32.Parse(st.ExamMark3));
                        Console.WriteLine(sumbal17.Average());
                        Console.WriteLine(sumbal17.Min());
                        Console.WriteLine(sumbal17.Max());
                        i = 34;
                        i++;
                        xlSht.Cells[i, j + 1] = "По сессии 6:"; xlSht.Cells[i, j + 2] = "По группе 3:";
                        i++;
                        xlSht.Cells[i, j + 1] = "Средний бал:"; xlSht.Cells[i, j + 2] = sumbal17.Average();
                        xlSht.Cells[i, j + 3] = "Минимальный бал:"; xlSht.Cells[i, j + 4] = sumbal17.Min();
                        xlSht.Cells[i, j + 5] = "Максимальный бал:"; xlSht.Cells[i, j + 6] = sumbal17.Max();
                        i = 0;
                    }

                }

                var results11 = from appraisals1 in db.PassingSessionByStudents
                               join students1 in db.Students on appraisals1.StudentId equals students1.Id
                               join stgroups1 in db.StudentGroups on appraisals1.StudentId equals stgroups1.StudentId
                               join snpforsubjects1 in db.SNPForSubjects on stgroups1.GroupId equals snpforsubjects1.GroupId
                               select new
                               {
                                   GroupId = stgroups1.GroupId,
                                   Snp = snpforsubjects1.SNPOfExamination,
                                   Snp1 = snpforsubjects1.SNPOfExamination1,
                                   Snp2 = snpforsubjects1.SNPOfExamination2,
                                   SessionId = appraisals1.SessionId,
                                   //CreditScore1 = appraisals.CreditScore1,
                                   //CreditScore2 = appraisals.CreditScore2,
                                   //CreditScore3 = appraisals.CreditScore3,
                                   ExamMark1 = appraisals1.ExamMark1,
                                   ExamMark2 = appraisals1.ExamMark2,
                                   ExamMark3 = appraisals1.ExamMark3,
                               };

                List<int> sumbal71 = new List<int>(); List<int> sumbal72 = new List<int>();
                List<int> sumbal73 = new List<int>(); List<int> sumbal74 = new List<int>();
                List<int> sumbal75 = new List<int>(); List<int> sumbal76 = new List<int>();
                List<int> sumbal77 = new List<int>(); List<int> sumbal78 = new List<int>();
                List<int> sumbal79 = new List<int>(); List<int> sumbal80 = new List<int>();
                List<int> sumbal81 = new List<int>(); List<int> sumbal82 = new List<int>();
                List<int> sumbal83 = new List<int>(); List<int> sumbal84 = new List<int>();
                List<int> sumbal85 = new List<int>(); List<int> sumbal86 = new List<int>();
                List<int> sumbal87 = new List<int>(); List<int> sumbal88 = new List<int>();
                List<int> sumbal89 = new List<int>(); List<int> sumbal90 = new List<int>();
                List<int> sumbal91 = new List<int>(); List<int> sumbal92 = new List<int>();
                List<int> sumbal93 = new List<int>(); List<int> sumbal94 = new List<int>();
                List<int> sumbal95 = new List<int>(); List<int> sumbal96 = new List<int>();
                List<int> sumbal97 = new List<int>();

                int zl = i;
                foreach (var st in results11)
                {
                    if (st.SessionId == 1 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId == 1)
                    {
                        sumbal71.Add(Int32.Parse(st.ExamMark1));                                                                  
                    }
                    if (st.SessionId == 2 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId == 1)
                    {
                        sumbal71.Add(Int32.Parse(st.ExamMark1));                                                               
                    }
                    if (st.SessionId == 1 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {
                        sumbal72.Add(Int32.Parse(st.ExamMark2));                                                          
                    }
                    if (st.SessionId == 2 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {
                        sumbal72.Add(Int32.Parse(st.ExamMark2));                                                         
                    }
                    if (st.SessionId == 1 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {
                        sumbal73.Add(Int32.Parse(st.ExamMark3));                      
                    }
                    if (st.SessionId == 2 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {
                        sumbal73.Add(Int32.Parse(st.ExamMark3));                       
                    }
                    if (st.SessionId == 1 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal74.Add(Int32.Parse(st.ExamMark1));                                                              
                    }
                    if (st.SessionId == 2 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal74.Add(Int32.Parse(st.ExamMark1));                      
                    }
                    if (st.SessionId == 1 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal75.Add(Int32.Parse(st.ExamMark2));                                                            
                    }
                    if (st.SessionId == 2 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal75.Add(Int32.Parse(st.ExamMark2));                      
                    }
                    if (st.SessionId == 1 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal76.Add(Int32.Parse(st.ExamMark3));                        
                    }
                    if (st.SessionId == 2 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal76.Add(Int32.Parse(st.ExamMark3));                        
                    }
                    if (st.SessionId == 1 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal77.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 2 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal77.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 1 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal78.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 2 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal78.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 1 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal79.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 2 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal79.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 3 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId == 1)
                    {
                        sumbal80.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 4 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId == 1)
                    {
                        sumbal80.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 3 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {
                        sumbal81.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 4 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {
                        sumbal81.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 3 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {
                        sumbal82.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 4 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {
                        sumbal82.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 3 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal83.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 4 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal83.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 3 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal84.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 4 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal84.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 3 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal85.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 4 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal85.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 3 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal86.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 4 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal86.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 3 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal87.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 4 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal87.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 3 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal88.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 4 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal88.Add(Int32.Parse(st.ExamMark3));
                    }

                    if (st.SessionId == 5 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId == 1)
                    {
                        sumbal89.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 6 && st.Snp == "Павлова Татьяна Федоровна" && st.GroupId == 1)
                    {
                        sumbal89.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 5 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {
                        sumbal90.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 6 && st.Snp1 == "Соколова Алина Петровна" && st.GroupId == 1)
                    {
                        sumbal90.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 5 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {
                        sumbal91.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 6 && st.Snp2 == "Тарасов Сергей Петрович" && st.GroupId == 1)
                    {
                        sumbal91.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 5 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal92.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 6 && st.Snp == "Иванов Федор Петрович" && st.GroupId == 2)
                    {
                        sumbal92.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 5 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal93.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 6 && st.Snp1 == "Петров Сергей Сидорович" && st.GroupId == 2)
                    {
                        sumbal93.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 5 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal94.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 6 && st.Snp2 == "Сидорова Мирина Сергеевна" && st.GroupId == 2)
                    {
                        sumbal94.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 5 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal95.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 6 && st.Snp == "Соколов Дмитрий Петрович" && st.GroupId == 3)
                    {
                        sumbal95.Add(Int32.Parse(st.ExamMark1));
                    }
                    if (st.SessionId == 5 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal96.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 6 && st.Snp1 == "Книга Василий Васильевич" && st.GroupId == 3)
                    {
                        sumbal96.Add(Int32.Parse(st.ExamMark2));
                    }
                    if (st.SessionId == 5 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal97.Add(Int32.Parse(st.ExamMark3));
                    }
                    if (st.SessionId == 6 && st.Snp2 == "Солнцева Лариса Петровна" && st.GroupId == 3)
                    {
                        sumbal97.Add(Int32.Parse(st.ExamMark3));
                    }
                }
                Console.WriteLine("По группе 1, по сессии 1 и 2, Павлова Татьяна Федоровна(JavaScript), 2020:");
                Console.WriteLine(sumbal71.Average());
                Console.WriteLine("По группе 1, по сессии 1 и 2, Соколова Алина Петровна(C++), 2020:");
                Console.WriteLine(sumbal72.Average());
                Console.WriteLine("По группе 1, по сессии 1 и 2, Тарасов Сергей Петрович(AHR), 2020:");
                Console.WriteLine(sumbal73.Average());
                Console.WriteLine("По группе 2, по сессии 1 и 2, Иванов Федор Петрович(C#), 2020:");
                Console.WriteLine(sumbal74.Average());
                Console.WriteLine("По группе 2, по сессии 1 и 2, Петров Сергей Сидорович(PHP), 2020:");
                Console.WriteLine(sumbal75.Average());
                Console.WriteLine("По группе 2, по сессии 1 и 2, Сидорова Мирина Сергеевна(InfSecurity), 2020:");
                Console.WriteLine(sumbal76.Average());
                Console.WriteLine("По группе 3, по сессии 1 и 2, Соколов Дмитрий Петрович(Java), 2020:");
                Console.WriteLine(sumbal77.Average());
                Console.WriteLine("По группе 3, по сессии 1 и 2, Книга Василий Васильевич(Unity), 2020:");
                Console.WriteLine(sumbal78.Average());
                Console.WriteLine("По группе 3, по сессии 1 и 2, Солнцева Лариса Петровна(C), 2020:");
                Console.WriteLine(sumbal79.Average());

                Console.WriteLine("По группе 1, по сессии 3 и 4, Павлова Татьяна Федоровна(JavaScript), 2021:");
                Console.WriteLine(sumbal80.Average());
                Console.WriteLine("По группе 1, по сессии 3 и 4, Соколова Алина Петровна(C++), 2021:");
                Console.WriteLine(sumbal81.Average());
                Console.WriteLine("По группе 1, по сессии 3 и 4, Тарасов Сергей Петрович(AHR), 2021:");
                Console.WriteLine(sumbal82.Average());
                Console.WriteLine("По группе 2, по сессии 3 и 4, Иванов Федор Петрович(C#), 2021:");
                Console.WriteLine(sumbal83.Average());
                Console.WriteLine("По группе 2, по сессии 3 и 4, Петров Сергей Сидорович(PHP), 2021:");
                Console.WriteLine(sumbal84.Average());
                Console.WriteLine("По группе 2, по сессии 3 и 4, Сидорова Мирина Сергеевна(InfSecurity), 2021:");
                Console.WriteLine(sumbal85.Average());
                Console.WriteLine("По группе 3, по сессии 3 и 4, Соколов Дмитрий Петрович(Java), 2021:");
                Console.WriteLine(sumbal86.Average());
                Console.WriteLine("По группе 3, по сессии 3 и 4, Книга Василий Васильевич(Unity), 2021:");
                Console.WriteLine(sumbal87.Average());
                Console.WriteLine("По группе 3, по сессии 3 и 4, Солнцева Лариса Петровна(C), 2021:");
                Console.WriteLine(sumbal88.Average());

                Console.WriteLine("По группе 1, по сессии 5 и 6, Павлова Татьяна Федоровна(JavaScript), 2022:");
                Console.WriteLine(sumbal89.Average());
                Console.WriteLine("По группе 1, по сессии 5 и 6, Соколова Алина Петровна(C++), 2022:");
                Console.WriteLine(sumbal90.Average());
                Console.WriteLine("По группе 1, по сессии 5 и 6, Тарасов Сергей Петрович(AHR), 2022:");
                Console.WriteLine(sumbal91.Average());
                Console.WriteLine("По группе 2, по сессии 5 и 6, Иванов Федор Петрович(C#), 2022:");
                Console.WriteLine(sumbal92.Average());
                Console.WriteLine("По группе 2, по сессии 5 и 6, Петров Сергей Сидорович(PHP), 2022:");
                Console.WriteLine(sumbal93.Average());
                Console.WriteLine("По группе 2, по сессии 5 и 6, Сидорова Мирина Сергеевна(InfSecurity), 2022:");
                Console.WriteLine(sumbal94.Average());
                Console.WriteLine("По группе 3, по сессии 5 и 6, Соколов Дмитрий Петрович(Java), 2022:");
                Console.WriteLine(sumbal95.Average());
                Console.WriteLine("По группе 3, по сессии 5 и 6, Книга Василий Васильевич(Unity), 2022:");
                Console.WriteLine(sumbal96.Average());
                Console.WriteLine("По группе 3, по сессии 5 и 6, Солнцева Лариса Петровна(C), 2022:");
                Console.WriteLine(sumbal97.Average());

                i = 36;
                i++;
                xlSht.Cells[i, j + 1] = " "; xlSht.Cells[i, j + 2] = "Павлова Т.Ф.(JavaScript):"; xlSht.Cells[i, j + 3] = "Соколова А.П.(C++):";
                xlSht.Cells[i, j + 4] = "Тарасов С.П.(AHR):"; xlSht.Cells[i, j + 5] = "И.Ф.Петрович(C#):"; xlSht.Cells[i, j + 6] = "П.С.Сидорович(PHP):";
                xlSht.Cells[i, j + 7] = "С.М.Сергеевна(InfSecurity):"; xlSht.Cells[i, j + 8] = "С.Д.Петрович(Java):"; xlSht.Cells[i, j + 9] = "К.В.Васильевич(Unity):";
                xlSht.Cells[i, j + 10] = "С.Л.Петровна(C):"; 
                i++;
                xlSht.Cells[i, j + 1] = "2020г:"; xlSht.Cells[i, j + 2] = sumbal71.Average(); xlSht.Cells[i, j + 3] = sumbal72.Average();
                xlSht.Cells[i, j + 4] = sumbal73.Average(); xlSht.Cells[i, j + 5] = sumbal74.Average(); xlSht.Cells[i, j + 6] = sumbal75.Average();
                xlSht.Cells[i, j + 7] = sumbal76.Average(); xlSht.Cells[i, j + 8] = sumbal77.Average(); xlSht.Cells[i, j + 9] = sumbal78.Average();
                xlSht.Cells[i, j + 10] = sumbal79.Average();
                i++;
                xlSht.Cells[i, j + 1] = "2021г:"; xlSht.Cells[i, j + 2] = sumbal80.Average(); xlSht.Cells[i, j + 3] = sumbal81.Average();
                xlSht.Cells[i, j + 4] = sumbal82.Average(); xlSht.Cells[i, j + 5] = sumbal83.Average(); xlSht.Cells[i, j + 6] = sumbal84.Average();
                xlSht.Cells[i, j + 7] = sumbal85.Average(); xlSht.Cells[i, j + 8] = sumbal86.Average(); xlSht.Cells[i, j + 9] = sumbal87.Average();
                xlSht.Cells[i, j + 10] = sumbal88.Average();
                i++;
                xlSht.Cells[i, j + 1] = "2022г:"; xlSht.Cells[i, j + 2] = sumbal89.Average(); xlSht.Cells[i, j + 3] = sumbal90.Average();
                xlSht.Cells[i, j + 4] = sumbal91.Average(); xlSht.Cells[i, j + 5] = sumbal92.Average(); xlSht.Cells[i, j + 6] = sumbal93.Average();
                xlSht.Cells[i, j + 7] = sumbal94.Average(); xlSht.Cells[i, j + 8] = sumbal95.Average(); xlSht.Cells[i, j + 9] = sumbal96.Average();
                xlSht.Cells[i, j + 10] = sumbal97.Average();

                xlApp.Visible = true; //не отображается сам файл
                xlApp.UserControl = true;

                string folder = @"D:\EPAM\september\zadan01_09_2020\SessionForStudents\SessionForStudents\App_Data"; //путь папке  

                // ЕСЛИ НУЖНО СОХРАНИТЬ ФАЙЛ В ФОРМАТЕ EXCEL 2007 (XLSX) 
                string filename = "Students1.xlsx"; //имя Excel файла, формат Excel 2007
                string fullfilename = System.IO.Path.Combine(folder, filename);
                if (System.IO.File.Exists(fullfilename)) System.IO.File.Delete(fullfilename);
                xlWB.SaveAs(fullfilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault); //формат Excel 2007

                xlWB.Close(false); //false - закрыть рабочую книгу не сохраняя изменения
                xlApp.Quit(); //закрываем приложение Excel
                Console.WriteLine("Файл1 сохранён!");               
            }
        }
        /// <summary>
        /// Method ListOfStudentsToBeExpelled()
        /// </summary>
        public static void ListOfStudentsToBeExpelled()
        {
            Console.WriteLine("Список студентов подлежащих отчислению:");
            using (SessionContext db = new SessionContext())
            {
                var result = from appraisals in db.PassingSessionByStudents
                             join students in db.Students on appraisals.StudentId equals students.Id
                             join stgroups in db.StudentGroups on appraisals.StudentId equals stgroups.StudentId
                             join groups in db.Groups on stgroups.GroupId equals groups.Id
                             select new
                             {
                                 Surname = students.Surname,
                                 DateOfBirth = students.DateOfBirth,
                                 GroupId = stgroups.GroupId,
                                 StudentId = stgroups.StudentId,
                                 GroupName = groups.GroupName,
                                 SessionId = appraisals.SessionId,
                                 CreditScore1 = appraisals.CreditScore1,
                                 CreditScore2 = appraisals.CreditScore2,
                                 CreditScore3 = appraisals.CreditScore3,
                                 ExamMark1 = appraisals.ExamMark1,
                                 ExamMark2 = appraisals.ExamMark2,
                                 ExamMark3 = appraisals.ExamMark3,
                             };
                             
               
                List<int> sumbal1 = new List<int>();
                List<double> sumbal5 = new List<double>();
                var sumbal2 = new List<StudentGroup>();
               

                foreach (var st in result)
                {                    
                    List<int> sumbal = new List<int>();
                    
                    sumbal.Add(Int32.Parse(st.CreditScore1)); sumbal.Add(Int32.Parse(st.CreditScore2)); sumbal.Add(Int32.Parse(st.CreditScore3));
                    sumbal.Add(Int32.Parse(st.ExamMark1)); sumbal.Add(Int32.Parse(st.ExamMark2)); sumbal.Add(Int32.Parse(st.ExamMark3));
                    var sumbal3 = from st3 in sumbal
                                         orderby st3
                                         select st3;
                    Console.WriteLine("Сортировка по возрастанию оценок по студенту");
                    foreach (var st3 in sumbal3)
                    {
                        Console.WriteLine(st3);
                    }
                    sumbal.Average();
                    sumbal5.Add(sumbal.Average());
                    var sumbal4 = from st3 in sumbal5
                                  orderby st3
                                  select st3;
                    Console.WriteLine("Сортировка по возрастанию среднего балла");
                    foreach (var st3 in sumbal4)
                    {
                        Console.WriteLine(st3);
                    }
                    
                    if (sumbal.Average() < 5 && st.SessionId == 2)
                    {
                        Console.WriteLine("Студент " + st.Surname + " Год рождения " + st.DateOfBirth +
                        " из группы " + st.GroupName + " имеющий средний балл " + sumbal.Average() + " подлежит отчислению");
                        sumbal2.Add(
                            new StudentGroup { GroupId = st.GroupId, StudentId = st.StudentId }
                        );                       
                    }           
                }
                var query = sumbal2.GroupBy(
                    st => st.GroupId,
                    st => st.StudentId,
                    (baseSt, st1) => new
                    {
                        Key = baseSt,
                        Count = st1.Count(),
                        Student = st1
                    });
                foreach (var st1 in query)
                {
                    Console.WriteLine("\nГруппа студентов: " + st1.Key);
                    Console.WriteLine("Количество отчисляемых студентов в группе: " + st1.Count);
                    foreach (var st3 in st1.Student)
                    {
                        Console.WriteLine("Id отчисляемого студента группы: " + st3);
                    }                  
                }
            }
        }
    }
}
