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
            Console.WriteLine("Итоги сессии2 по каждой группе:");
            foreach (var u in passingSessionByStudent)
            {
                foreach (var z in studentGroup)
                {
                    if (u.SessionId == 2 && u.StudentId == z.StudentId && z.GroupId==1)
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
                        xlSht.Cells[i, j + 1]=u.Id; xlSht.Cells[i, j + 2] = u.StudentId; xlSht.Cells[i, j + 3] = u.SessionId;
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
            xlApp.Visible = true; //не отображается сам файл
            xlApp.UserControl = true;

            string folder = @"D:\EPAM\avgust\zadan25_08_2020\SessionForStudents\SessionForStudents\App_Data"; //путь папке  

            // ЕСЛИ НУЖНО СОХРАНИТЬ ФАЙЛ В ФОРМАТЕ EXCEL 2007 (XLSX) 
            string filename = "Students.xlsx"; //имя Excel файла, формат Excel 2007
            string fullfilename = System.IO.Path.Combine(folder, filename);
            if (System.IO.File.Exists(fullfilename)) System.IO.File.Delete(fullfilename);
            xlWB.SaveAs(fullfilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault); //формат Excel 2007

            xlWB.Close(false); //false - закрыть рабочую книгу не сохраняя изменения
            xlApp.Quit(); //закрываем приложение Excel
            Console.WriteLine("Файл сохранён!");

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
                List<int> sumbal1 = new List<int>();
                List<int> sumbal2 = new List<int>();
                List<int> sumbal3 = new List<int>();
                List<int> sumbal4 = new List<int>();
                List<int> sumbal5 = new List<int>();
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
                }
                xlApp.Visible = true; //не отображается сам файл
                xlApp.UserControl = true;

                string folder = @"D:\EPAM\avgust\zadan25_08_2020\SessionForStudents\SessionForStudents\App_Data"; //путь папке  

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
