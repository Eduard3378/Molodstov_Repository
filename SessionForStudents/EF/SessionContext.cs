using Microsoft.EntityFrameworkCore;
using SessionForStudents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.EF
{
    /// <summary>
    /// Class SessionContext
    /// </summary>
    public class SessionContext : DbContext
    {
        /// <summary>
        /// Property Students
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// Property Genders
        /// </summary>
        public DbSet<Gender> Genders { get; set; }
        /// <summary>
        /// Property Sessions
        /// </summary>
        public DbSet<Session> Sessions { get; set; }
        /// <summary>
        /// Property Groups
        /// </summary>
        public DbSet<Group> Groups { get; set; }
        /// <summary>
        /// Property StudentGroups
        /// </summary>
        public DbSet<StudentGroup> StudentGroups { get; set; }
        /// <summary>
        /// Property PassingSessionByStudents
        /// </summary>
        public DbSet<PassingSessionByStudent> PassingSessionByStudents { get; set; }
        /// <summary>
        /// Constructor SessionContext()
        /// </summary>
        public SessionContext()
        {            
            Database.EnsureCreated();
        }
        /// <summary>
        /// Method OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=SessionForStudents; Trusted_Connection=True;");
        }
        /// <summary>
        /// Method OnModelCreating(ModelBuilder modelBuilder)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связи          
            modelBuilder.Entity<Student>()
                .HasOne(p => p.Gender)
                .WithMany(t => t.Students)
                .HasForeignKey(p => p.GenderId);
            modelBuilder.Entity<Student>()
              .HasOne(p => p.PassingSessionByStudent)
              .WithMany(t => t.Students)
              .HasForeignKey(p => p.PassingSessionByStudentId);
            modelBuilder.Entity<Group>()
                .HasOne(p => p.Student)
                .WithMany(t => t.Groups)
                .HasForeignKey(p => p.StudentId);
            modelBuilder.Entity<StudentGroup>()
                 .HasOne(p => p.Student)
                 .WithMany(t => t.StudentGroups)
                 .HasForeignKey(p => p.StudentId)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StudentGroup>()
                .HasOne(p => p.Group)
                .WithMany(t => t.StudentGroups)
                .HasForeignKey(p => p.GroupId);
            modelBuilder.Entity<StudentGroup>()
                .HasKey(p => new { p.GroupId, p.StudentId });
            modelBuilder.Entity<PassingSessionByStudent>()
            .HasOne(p => p.Session)
            .WithMany(t => t.PassingSessionByStudents)
            .HasForeignKey(p => p.SessionId);

            // Начальные данные
            modelBuilder.Entity<Gender>().HasData(new Gender[]
                {
                    new Gender { Id = 1, Name = "Не определен", Design = "н/о" },
                    new Gender { Id = 2, Name = "Мужской", Design = "м" },
                    new Gender { Id = 3, Name = "Женский", Design = "ж" }
                });
            modelBuilder.Entity<Session>().HasData(new Session[]
               {
                    new Session { Id = 1, Name = "Сессия1" },
                    new Session { Id = 2, Name = "Сессия2" }                    
               });
            modelBuilder.Entity<PassingSessionByStudent>().HasData(new PassingSessionByStudent[]
               {
                    new PassingSessionByStudent { Id = 1, StudentId = 1, SessionId=1, CreditScore1 = "4", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "5", ExamMark2 = "6", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 2, StudentId = 2,  SessionId=1, CreditScore1 = "5", CreditScore2 = "6", CreditScore3 = "7", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 3, StudentId = 3,  SessionId=1, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "7", ExamMark2 = "8", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 4, StudentId = 4, SessionId=1, CreditScore1 = "5", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "6", ExamMark2 = "8", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 5, StudentId = 5, SessionId=1, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "5", ExamMark2 = "6", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 6, StudentId = 6, SessionId=1, CreditScore1 = "4", CreditScore2 = "3", CreditScore3 = "4", ExamMark1 = "3", ExamMark2 = "4", ExamMark3 = "3" },
                    new PassingSessionByStudent { Id = 7, StudentId = 7, SessionId=1, CreditScore1 = "3", CreditScore2 = "4", CreditScore3 = "3", ExamMark1 = "4", ExamMark2 = "3", ExamMark3 = "4" },
                    new PassingSessionByStudent { Id = 8, StudentId = 8, SessionId=1, CreditScore1 = "2", CreditScore2 = "3", CreditScore3 = "4", ExamMark1 = "2", ExamMark2 = "3", ExamMark3 = "4" },

                    new PassingSessionByStudent { Id = 9, StudentId = 1, SessionId=2, CreditScore1 = "5", CreditScore2 = "6", CreditScore3 = "7", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 10, StudentId = 2,  SessionId=2, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "7", ExamMark2 = "8", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 11, StudentId = 3,  SessionId=2, CreditScore1 = "7", CreditScore2 = "8", CreditScore3 = "9", ExamMark1 = "8", ExamMark2 = "9", ExamMark3 = "10" },
                    new PassingSessionByStudent { Id = 12, StudentId = 4, SessionId=2, CreditScore1 = "4", CreditScore2 = "2", CreditScore3 = "3", ExamMark1 = "4", ExamMark2 = "4", ExamMark3 = "4" },
                    new PassingSessionByStudent { Id = 13, StudentId = 5, SessionId=2, CreditScore1 = "7", CreditScore2 = "8", CreditScore3 = "9", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 14, StudentId = 6, SessionId=2, CreditScore1 = "4", CreditScore2 = "3", CreditScore3 = "4", ExamMark1 = "3", ExamMark2 = "4", ExamMark3 = "3" },
                    new PassingSessionByStudent { Id = 15, StudentId = 7, SessionId=2, CreditScore1 = "3", CreditScore2 = "4", CreditScore3 = "3", ExamMark1 = "4", ExamMark2 = "3", ExamMark3 = "4" },
                    new PassingSessionByStudent { Id = 16, StudentId = 8, SessionId=2, CreditScore1 = "2", CreditScore2 = "3", CreditScore3 = "4", ExamMark1 = "2", ExamMark2 = "3", ExamMark3 = "4" },


               });
            modelBuilder.Entity<Student>().HasData(new Student[]
               {
                    new Student { Id = 1, Name = "Иван", Surname = "Иванов", Patronymic = "Иванович", GenderId = 2, DateOfBirth = new DateTime(2002, 1, 10), PassingSessionByStudentId = 1 },
                    new Student { Id = 2, Name = "Петр", Surname = "Петров", Patronymic = "Васильевич", GenderId = 2, DateOfBirth = new DateTime(2003, 2, 11), PassingSessionByStudentId = 2 },
                    new Student { Id = 3, Name = "Артем", Surname = "Сидоров", Patronymic = "Петрович", GenderId = 2, DateOfBirth = new DateTime(2004, 4, 9), PassingSessionByStudentId = 3 },
                    new Student { Id = 4, Name = "Виктория", Surname = "Соколова", Patronymic = "Сергеевна", GenderId = 3, DateOfBirth = new DateTime(2003, 3, 7), PassingSessionByStudentId = 4 },
                    new Student { Id = 5, Name = "Елена", Surname = "Воробьева", Patronymic = "Васильевна", GenderId = 3, DateOfBirth = new DateTime(2002, 5, 10), PassingSessionByStudentId = 5 },
                    new Student { Id = 6, Name = "Елена1", Surname = "Воробьева1", Patronymic = "Васильевна1", GenderId = 3, DateOfBirth = new DateTime(2003, 5, 11), PassingSessionByStudentId = 6 },
                    new Student { Id = 7, Name = "Елена2", Surname = "Воробьева2", Patronymic = "Васильевна2", GenderId = 3, DateOfBirth = new DateTime(2004, 5, 12), PassingSessionByStudentId = 7 },
                    new Student { Id = 8, Name = "Елена3", Surname = "Воробьева3", Patronymic = "Васильевна3", GenderId = 3, DateOfBirth = new DateTime(2005, 5, 13), PassingSessionByStudentId = 8 }
               });

            modelBuilder.Entity<Group>().HasData(new Group[]
                {
                    new Group { Id = 1, StudentId = 1, GroupName = "П24041", DateOfOffset = new DateTime(2020, 3, 11), DateOfOffset1 = new DateTime(2020, 4, 12), DateOfOffset2 = new DateTime(2020, 5, 13),
                    DateOfExamination = new DateTime(2020, 6, 10), DateOfExamination1 = new DateTime(2020, 6, 15), DateOfExamination2 = new DateTime(2020, 6, 20)},
                    new Group { Id = 2, StudentId = 3, GroupName = "П24027", DateOfOffset = new DateTime(2020, 3, 14), DateOfOffset1 = new DateTime(2020, 4, 16), DateOfOffset2 = new DateTime(2020, 5, 17),
                    DateOfExamination = new DateTime(2020, 6, 15), DateOfExamination1 = new DateTime(2020, 6, 20), DateOfExamination2 = new DateTime(2020, 6, 25)},
                    new Group { Id = 3, StudentId = 5, GroupName = "П24042", DateOfOffset = new DateTime(2020, 3, 17), DateOfOffset1 = new DateTime(2020, 4, 19), DateOfOffset2 = new DateTime(2020, 5, 20),
                    DateOfExamination = new DateTime(2020, 6, 18), DateOfExamination1 = new DateTime(2020, 6, 23), DateOfExamination2 = new DateTime(2020, 6, 28)}
                });           
            modelBuilder.Entity<StudentGroup>().HasData(new StudentGroup[]
                {
                    new StudentGroup { GroupId = 1, StudentId = 1 },
                    new StudentGroup { GroupId = 1, StudentId = 4 },
                    new StudentGroup { GroupId = 2, StudentId = 3 },
                    new StudentGroup { GroupId = 2, StudentId = 2 },
                    new StudentGroup { GroupId = 3, StudentId = 5 },
                    new StudentGroup { GroupId = 3, StudentId = 6 },
                    new StudentGroup { GroupId = 3, StudentId = 7 },
                    new StudentGroup { GroupId = 1, StudentId = 8 },
                });
        }
    }
}
