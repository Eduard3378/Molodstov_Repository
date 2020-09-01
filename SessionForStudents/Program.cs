using SessionForStudents.EF;
using SessionForStudents.Entities;
using System;
using System.Linq;


namespace SessionForStudents
{
    /// <summary>
    /// Class SingletonDatabase
    /// </summary>
    public class SingletonDatabase
    {
        /// <summary>
        /// Constructor SingletonDatabase()
        /// </summary>
        private SingletonDatabase()
        {
            using (SessionContext db = new SessionContext())
            {
                var students = db.Students.ToList();
                var sortedStudents = from st4 in students
                                     orderby st4.Surname descending
                                     select st4;
                Console.WriteLine("Сортировка по фамилии студентов");
                foreach (var st3 in sortedStudents)
                {
                    Console.WriteLine($"{st3.Id}.{st3.Surname} - {st3.DateOfBirth}");
                }

                // получаем наименования сесий из бд и выводим на консоль
                var session = db.Sessions.ToList();
                Console.WriteLine("Наименования сессий:");
                foreach (var u in session)
                {
                    Console.WriteLine($"{u.Id} - {u.Name}");
                }
                // получаем итоги сессии по каждой группе в виде таблицы
                var passingSessionByStudent = db.PassingSessionByStudents.ToList();
                var studentGroup = db.StudentGroups.ToList();
                SessionForStudents.Services.PassingSessionByStudentService.ResultsOfTheSessionForEachGroup(passingSessionByStudent, studentGroup);
                SessionForStudents.Services.PassingSessionByStudentService.AverMinMaxScoreForEachGroup();
                SessionForStudents.Services.PassingSessionByStudentService.ListOfStudentsToBeExpelled();
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Field instance
        /// </summary>
        private static readonly Lazy<SingletonDatabase> instance =
        new Lazy<SingletonDatabase>(() =>  new SingletonDatabase());
        /// <summary>
        /// Property Instance
        /// </summary>
        public static SingletonDatabase Instance => instance.Value; 
    }
    /// <summary>
    /// Class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;           
        }
    }
}
