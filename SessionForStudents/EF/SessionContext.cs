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
        ///         
        public DbSet<Group> Groups { get; set; }
        /// <summary>
        /// Property SNPForSubjects
        /// </summary>
        public DbSet<SNPForSubject> SNPForSubjects { get; set; }
        /// <summary>
        /// Property Specialties
        /// </summary>
        public DbSet<Specialty> Specialties { get; set; }
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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=SessionForStudents1; Trusted_Connection=True;");
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
            modelBuilder.Entity<SNPForSubject>()
               .HasOne(p => p.Group)
               .WithMany(t => t.SNPForSubjects)
               .HasForeignKey(p => p.GroupId);
            modelBuilder.Entity<SNPForSubject>()
             .HasOne(p => p.Session)
             .WithMany(t => t.SNPForSubjects)
             .HasForeignKey(p => p.SessionId)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Specialty>()
               .HasOne(p => p.Group)
               .WithMany(t => t.Specialties)
               .HasForeignKey(p => p.GroupId);
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
                    new Session { Id = 2, Name = "Сессия2" },
                    new Session { Id = 3, Name = "Сессия3" },
                    new Session { Id = 4, Name = "Сессия4" },
                    new Session { Id = 5, Name = "Сессия5" },
                    new Session { Id = 6, Name = "Сессия6" }
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

                    new PassingSessionByStudent { Id = 17, StudentId = 1, SessionId=3, CreditScore1 = "6", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "7", ExamMark2 = "8", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 18, StudentId = 2,  SessionId=3, CreditScore1 = "7", CreditScore2 = "5", CreditScore3 = "7", ExamMark1 = "9", ExamMark2 = "9", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 19, StudentId = 3,  SessionId=3, CreditScore1 = "8", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "9", ExamMark2 = "10", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 20, StudentId = 4, SessionId=3, CreditScore1 = "5", CreditScore2 = "6", CreditScore3 = "6", ExamMark1 = "5", ExamMark2 = "6", ExamMark3 = "6" },
                    new PassingSessionByStudent { Id = 21, StudentId = 5, SessionId=3, CreditScore1 = "8", CreditScore2 = "7", CreditScore3 = "6", ExamMark1 = "9", ExamMark2 = "8", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 22, StudentId = 6, SessionId=3, CreditScore1 = "8", CreditScore2 = "8", CreditScore3 = "8", ExamMark1 = "6", ExamMark2 = "5", ExamMark3 = "4" },
                    new PassingSessionByStudent { Id = 23, StudentId = 7, SessionId=3, CreditScore1 = "5", CreditScore2 = "6", CreditScore3 = "5", ExamMark1 = "6", ExamMark2 = "5", ExamMark3 = "6" },
                    new PassingSessionByStudent { Id = 24, StudentId = 8, SessionId=3, CreditScore1 = "6", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "5", ExamMark2 = "5", ExamMark3 = "6" },

                    new PassingSessionByStudent { Id = 25, StudentId = 1, SessionId=4, CreditScore1 = "5", CreditScore2 = "6", CreditScore3 = "4", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 26, StudentId = 2,  SessionId=4, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "7", ExamMark2 = "8", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 27, StudentId = 3,  SessionId=4, CreditScore1 = "9", CreditScore2 = "8", CreditScore3 = "10", ExamMark1 = "8", ExamMark2 = "9", ExamMark3 = "10" },
                    new PassingSessionByStudent { Id = 28, StudentId = 4, SessionId=4, CreditScore1 = "6", CreditScore2 = "5", CreditScore3 = "5", ExamMark1 = "6", ExamMark2 = "6", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 29, StudentId = 5, SessionId=4, CreditScore1 = "7", CreditScore2 = "8", CreditScore3 = "9", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 30, StudentId = 6, SessionId=4, CreditScore1 = "6", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "7", ExamMark2 = "5", ExamMark3 = "5" },
                    new PassingSessionByStudent { Id = 31, StudentId = 7, SessionId=4, CreditScore1 = "6", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "5", ExamMark2 = "6", ExamMark3 = "5" },
                    new PassingSessionByStudent { Id = 32, StudentId = 8, SessionId=4, CreditScore1 = "5", CreditScore2 = "6", CreditScore3 = "5", ExamMark1 = "6", ExamMark2 = "6", ExamMark3 = "5" },

                    new PassingSessionByStudent { Id = 33, StudentId = 1, SessionId=5, CreditScore1 = "8", CreditScore2 = "7", CreditScore3 = "7", ExamMark1 = "6", ExamMark2 = "6", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 34, StudentId = 2,  SessionId=5, CreditScore1 = "7", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 35, StudentId = 3,  SessionId=5, CreditScore1 = "6", CreditScore2 = "8", CreditScore3 = "7", ExamMark1 = "8", ExamMark2 = "7", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 36, StudentId = 4, SessionId=5, CreditScore1 = "7", CreditScore2 = "5", CreditScore3 = "5", ExamMark1 = "7", ExamMark2 = "5", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 37, StudentId = 5, SessionId=5, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "7", ExamMark2 = "6", ExamMark3 = "5" },
                    new PassingSessionByStudent { Id = 38, StudentId = 6, SessionId=5, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "5", ExamMark1 = "7", ExamMark2 = "6", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 39, StudentId = 7, SessionId=5, CreditScore1 = "7", CreditScore2 = "6", CreditScore3 = "5", ExamMark1 = "6", ExamMark2 = "6", ExamMark3 = "5" },
                    new PassingSessionByStudent { Id = 40, StudentId = 8, SessionId=5, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "6", ExamMark1 = "5", ExamMark2 = "6", ExamMark3 = "7" },

                    new PassingSessionByStudent { Id = 41, StudentId = 1, SessionId=6, CreditScore1 = "7", CreditScore2 = "6", CreditScore3 = "8", ExamMark1 = "6", ExamMark2 = "5", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 42, StudentId = 2,  SessionId=6, CreditScore1 = "8", CreditScore2 = "7", CreditScore3 = "8", ExamMark1 = "8", ExamMark2 = "7", ExamMark3 = "9" },
                    new PassingSessionByStudent { Id = 43, StudentId = 3,  SessionId=6, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "7", ExamMark1 = "8", ExamMark2 = "8", ExamMark3 = "7" },
                    new PassingSessionByStudent { Id = 44, StudentId = 4, SessionId=6, CreditScore1 = "6", CreditScore2 = "6", CreditScore3 = "7", ExamMark1 = "5", ExamMark2 = "7", ExamMark3 = "6" },
                    new PassingSessionByStudent { Id = 45, StudentId = 5, SessionId=6, CreditScore1 = "7", CreditScore2 = "8", CreditScore3 = "9", ExamMark1 = "6", ExamMark2 = "7", ExamMark3 = "8" },
                    new PassingSessionByStudent { Id = 46, StudentId = 6, SessionId=6, CreditScore1 = "8", CreditScore2 = "6", CreditScore3 = "7", ExamMark1 = "5", ExamMark2 = "6", ExamMark3 = "5" },
                    new PassingSessionByStudent { Id = 47, StudentId = 7, SessionId=6, CreditScore1 = "7", CreditScore2 = "5", CreditScore3 = "6", ExamMark1 = "7", ExamMark2 = "8", ExamMark3 = "6" },
                    new PassingSessionByStudent { Id = 48, StudentId = 8, SessionId=6, CreditScore1 = "6", CreditScore2 = "7", CreditScore3 = "6", ExamMark1 = "7", ExamMark2 = "7", ExamMark3 = "6" },
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
                    new Group { Id = 1, StudentId = 1, GroupName = "П24041", DateOfOffsetId = 1, DateOfOffset1Id = 1, DateOfOffset2Id = 1,
                    DateOfExaminationId = 1, DateOfExamination1Id = 1, DateOfExamination2Id = 1},
                    new Group { Id = 2, StudentId = 3, GroupName = "П24027", DateOfOffsetId = 2, DateOfOffset1Id = 2, DateOfOffset2Id = 2,
                    DateOfExaminationId = 2, DateOfExamination1Id = 2, DateOfExamination2Id = 2},
                    new Group { Id = 3, StudentId = 5, GroupName = "П24042", DateOfOffsetId = 3, DateOfOffset1Id = 3, DateOfOffset2Id = 3,
                    DateOfExaminationId = 3, DateOfExamination1Id = 3, DateOfExamination2Id = 3}
                });

            modelBuilder.Entity<Specialty>().HasData(new Specialty[]
            {
                new Specialty { Id = 1, GroupId = 1, SpecialtyName = "Инженер-электроник-программист"},
                new Specialty { Id = 2, GroupId = 2, SpecialtyName = "Инженер по радиоэлектронике"},
                new Specialty { Id = 3, GroupId = 3, SpecialtyName = "Инженер-проектировщик"},
            });

            modelBuilder.Entity<SNPForSubject>().HasData(new SNPForSubject[]
           {
                new SNPForSubject { Id = 1, GroupId = 1, SessionId = 1, GroupDateOfOffsetId = 1, DateOfOffset = new DateTime(2020, 3, 11), SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1, DateOfOffset1 = new DateTime(2020, 4, 12), SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1, DateOfOffset2 = new DateTime(2020, 5, 13), SNPOfOffset2= "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1, DateOfExamination = new DateTime(2020, 6, 10), SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1, DateOfExamination1 = new DateTime(2020, 6, 15),SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1, DateOfExamination2 = new DateTime(2020, 6, 20),SNPOfExamination2 = "Тарасов Сергей Петрович"},
                new SNPForSubject { Id = 2, GroupId = 1, SessionId = 2, GroupDateOfOffsetId = 1, DateOfOffset = new DateTime(2020, 7, 11), SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1, DateOfOffset1 = new DateTime(2020, 7, 12), SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1, DateOfOffset2 = new DateTime(2020, 8, 13), SNPOfOffset2= "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1, DateOfExamination = new DateTime(2020, 9, 10), SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1, DateOfExamination1 = new DateTime(2020, 9, 15),SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1, DateOfExamination2 = new DateTime(2020, 9, 20),SNPOfExamination2 = "Тарасов Сергей Петрович"},
                 new SNPForSubject { Id = 3, GroupId = 2, SessionId = 1, GroupDateOfOffsetId = 2, DateOfOffset = new DateTime(2020, 3, 12), SNPOfOffset = "Иванов Федор Петрович",
                GroupDateOfOffset1Id = 2, DateOfOffset1 = new DateTime(2020, 4, 13), SNPOfOffset1 = "Петров Сергей Сидорович",
                GroupDateOfOffset2Id = 2, DateOfOffset2 = new DateTime(2020, 5, 14), SNPOfOffset2= "Сидорова Мирина Сергеевна",
                GroupDateOfExaminationId = 2, DateOfExamination = new DateTime(2020, 6, 11), SNPOfExamination = "Иванов Федор Петрович",
                GroupDateOfExamination1Id = 2, DateOfExamination1 = new DateTime(2020, 6, 16),SNPOfExamination1 = "Петров Сергей Сидорович",
                GroupDateOfExamination2Id = 2, DateOfExamination2 = new DateTime(2020, 6, 21), SNPOfExamination2 = "Сидорова Мирина Сергеевна"},
                new SNPForSubject { Id = 4, GroupId = 2, SessionId = 2, GroupDateOfOffsetId = 2, DateOfOffset = new DateTime(2020, 7, 12), SNPOfOffset = "Иванов Федор Петрович",
                GroupDateOfOffset1Id = 2, DateOfOffset1 = new DateTime(2020, 7, 13), SNPOfOffset1 = "Петров Сергей Сидорович",
                GroupDateOfOffset2Id = 2, DateOfOffset2 = new DateTime(2020, 8, 14), SNPOfOffset2= "Сидорова Мирина Сергеевна",
                GroupDateOfExaminationId = 2, DateOfExamination = new DateTime(2020, 9, 11), SNPOfExamination = "Иванов Федор Петрович",
                GroupDateOfExamination1Id = 2, DateOfExamination1 = new DateTime(2020, 9, 16),SNPOfExamination1 = "Петров Сергей Сидорович",
                GroupDateOfExamination2Id = 2, DateOfExamination2 = new DateTime(2020, 9, 21), SNPOfExamination2 = "Сидорова Мирина Сергеевна"},
                 new SNPForSubject { Id = 5, GroupId = 3, SessionId = 1, GroupDateOfOffsetId = 3, DateOfOffset = new DateTime(2020, 3, 13), SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3, DateOfOffset1 = new DateTime(2020, 4, 14), SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3, DateOfOffset2 = new DateTime(2020, 5, 15), SNPOfOffset2= "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3, DateOfExamination = new DateTime(2020, 6, 12), SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3, DateOfExamination1 = new DateTime(2020, 6, 17),SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3, DateOfExamination2 = new DateTime(2020, 6, 22), SNPOfExamination2 = "Солнцева Лариса Петровна"},
                new SNPForSubject { Id = 6, GroupId = 3, SessionId = 2, GroupDateOfOffsetId = 3, DateOfOffset = new DateTime(2020, 7, 13), SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3, DateOfOffset1 = new DateTime(2020, 7, 14), SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3, DateOfOffset2 = new DateTime(2020, 8, 15), SNPOfOffset2= "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3, DateOfExamination = new DateTime(2020, 9, 12), SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3, DateOfExamination1 = new DateTime(2020, 9, 17),SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3, DateOfExamination2 = new DateTime(2020, 9, 22), SNPOfExamination2 = "Солнцева Лариса Петровна"},

                 new SNPForSubject { Id = 7, GroupId = 1, SessionId = 3, GroupDateOfOffsetId = 1, DateOfOffset = new DateTime(2021, 3, 12), SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1, DateOfOffset1 = new DateTime(2021, 4, 13), SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1, DateOfOffset2 = new DateTime(2021, 5, 14), SNPOfOffset2= "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1, DateOfExamination = new DateTime(2021, 6, 11), SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1, DateOfExamination1 = new DateTime(2021, 6, 16),SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1, DateOfExamination2 = new DateTime(2021, 6, 21),SNPOfExamination2 = "Тарасов Сергей Петрович"},
                new SNPForSubject { Id = 8, GroupId = 1, SessionId = 4, GroupDateOfOffsetId = 1, DateOfOffset = new DateTime(2021, 7, 12), SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1, DateOfOffset1 = new DateTime(2021, 7, 13), SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1, DateOfOffset2 = new DateTime(2021, 8, 14), SNPOfOffset2= "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1, DateOfExamination = new DateTime(2021, 9, 10), SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1, DateOfExamination1 = new DateTime(2021, 9, 15),SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1, DateOfExamination2 = new DateTime(2021, 9, 20),SNPOfExamination2 = "Тарасов Сергей Петрович"},
                 new SNPForSubject { Id = 9, GroupId = 2, SessionId = 3, GroupDateOfOffsetId = 2, DateOfOffset = new DateTime(2021, 3, 13), SNPOfOffset = "Иванов Федор Петрович",
                GroupDateOfOffset1Id = 2, DateOfOffset1 = new DateTime(2021, 4, 14), SNPOfOffset1 = "Петров Сергей Сидорович",
                GroupDateOfOffset2Id = 2, DateOfOffset2 = new DateTime(2021, 5, 15), SNPOfOffset2= "Сидорова Мирина Сергеевна",
                GroupDateOfExaminationId = 2, DateOfExamination = new DateTime(2021, 6, 12), SNPOfExamination = "Иванов Федор Петрович",
                GroupDateOfExamination1Id = 2, DateOfExamination1 = new DateTime(2021, 6, 17),SNPOfExamination1 = "Петров Сергей Сидорович",
                GroupDateOfExamination2Id = 2, DateOfExamination2 = new DateTime(2021, 6, 22), SNPOfExamination2 = "Сидорова Мирина Сергеевна"},
                new SNPForSubject { Id = 10, GroupId = 2, SessionId = 4, GroupDateOfOffsetId = 2, DateOfOffset = new DateTime(2021, 7, 14), SNPOfOffset = "Иванов Федор Петрович",
                GroupDateOfOffset1Id = 2, DateOfOffset1 = new DateTime(2021, 7, 14), SNPOfOffset1 = "Петров Сергей Сидорович",
                GroupDateOfOffset2Id = 2, DateOfOffset2 = new DateTime(2021, 8, 15), SNPOfOffset2= "Сидорова Мирина Сергеевна",
                GroupDateOfExaminationId = 2, DateOfExamination = new DateTime(2021, 9, 12), SNPOfExamination = "Иванов Федор Петрович",
                GroupDateOfExamination1Id = 2, DateOfExamination1 = new DateTime(2021, 9, 17),SNPOfExamination1 = "Петров Сергей Сидорович",
                GroupDateOfExamination2Id = 2, DateOfExamination2 = new DateTime(2021, 9, 22), SNPOfExamination2 = "Сидорова Мирина Сергеевна"},
                 new SNPForSubject { Id = 11, GroupId = 3, SessionId = 3, GroupDateOfOffsetId = 3, DateOfOffset = new DateTime(2021, 3, 14), SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3, DateOfOffset1 = new DateTime(2021, 4, 15), SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3, DateOfOffset2 = new DateTime(2021, 5, 16), SNPOfOffset2= "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3, DateOfExamination = new DateTime(2021, 6, 13), SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3, DateOfExamination1 = new DateTime(2021, 6, 18),SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3, DateOfExamination2 = new DateTime(2021, 6, 23), SNPOfExamination2 = "Солнцева Лариса Петровна"},
                new SNPForSubject { Id = 12, GroupId = 3, SessionId = 4, GroupDateOfOffsetId = 3, DateOfOffset = new DateTime(2021, 7, 14), SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3, DateOfOffset1 = new DateTime(2021, 7, 15), SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3, DateOfOffset2 = new DateTime(2021, 8, 16), SNPOfOffset2= "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3, DateOfExamination = new DateTime(2021, 9, 13), SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3, DateOfExamination1 = new DateTime(2021, 9, 18),SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3, DateOfExamination2 = new DateTime(2021, 9, 23), SNPOfExamination2 = "Солнцева Лариса Петровна"},

                 new SNPForSubject { Id = 13, GroupId = 1, SessionId = 5, GroupDateOfOffsetId = 1, DateOfOffset = new DateTime(2022, 3, 15), SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1, DateOfOffset1 = new DateTime(2022, 4, 15), SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1, DateOfOffset2 = new DateTime(2022, 5, 16), SNPOfOffset2= "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1, DateOfExamination = new DateTime(2022, 6, 13), SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1, DateOfExamination1 = new DateTime(2022, 6, 18),SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1, DateOfExamination2 = new DateTime(2022, 6, 23),SNPOfExamination2 = "Тарасов Сергей Петрович"},
                new SNPForSubject { Id = 14, GroupId = 1, SessionId = 6, GroupDateOfOffsetId = 1, DateOfOffset = new DateTime(2022, 7, 14), SNPOfOffset = "Павлова Татьяна Федоровна",
                GroupDateOfOffset1Id = 1, DateOfOffset1 = new DateTime(2022, 7, 15), SNPOfOffset1 = "Соколова Алина Петровна",
                GroupDateOfOffset2Id = 1, DateOfOffset2 = new DateTime(2022, 8, 16), SNPOfOffset2= "Тарасов Сергей Петрович",
                GroupDateOfExaminationId = 1, DateOfExamination = new DateTime(2022, 9, 13), SNPOfExamination = "Павлова Татьяна Федоровна",
                GroupDateOfExamination1Id = 1, DateOfExamination1 = new DateTime(2022, 9, 18),SNPOfExamination1 = "Соколова Алина Петровна",
                GroupDateOfExamination2Id = 1, DateOfExamination2 = new DateTime(2022, 9, 23),SNPOfExamination2 = "Тарасов Сергей Петрович"},
                 new SNPForSubject { Id = 15, GroupId = 2, SessionId = 5, GroupDateOfOffsetId = 2, DateOfOffset = new DateTime(2022, 3, 15), SNPOfOffset = "Иванов Федор Петрович",
                GroupDateOfOffset1Id = 2, DateOfOffset1 = new DateTime(2022, 4, 16), SNPOfOffset1 = "Петров Сергей Сидорович",
                GroupDateOfOffset2Id = 2, DateOfOffset2 = new DateTime(2022, 5, 17), SNPOfOffset2= "Сидорова Мирина Сергеевна",
                GroupDateOfExaminationId = 2, DateOfExamination = new DateTime(2022, 6, 14), SNPOfExamination = "Иванов Федор Петрович",
                GroupDateOfExamination1Id = 2, DateOfExamination1 = new DateTime(2022, 6, 19),SNPOfExamination1 = "Петров Сергей Сидорович",
                GroupDateOfExamination2Id = 2, DateOfExamination2 = new DateTime(2022, 6, 24), SNPOfExamination2 = "Сидорова Мирина Сергеевна"},
                new SNPForSubject { Id = 16, GroupId = 2, SessionId = 6, GroupDateOfOffsetId = 2, DateOfOffset = new DateTime(2022, 7, 15), SNPOfOffset = "Иванов Федор Петрович",
                GroupDateOfOffset1Id = 2, DateOfOffset1 = new DateTime(2022, 7, 16), SNPOfOffset1 = "Петров Сергей Сидорович",
                GroupDateOfOffset2Id = 2, DateOfOffset2 = new DateTime(2022, 8, 17), SNPOfOffset2= "Сидорова Мирина Сергеевна",
                GroupDateOfExaminationId = 2, DateOfExamination = new DateTime(2022, 9, 14), SNPOfExamination = "Иванов Федор Петрович",
                GroupDateOfExamination1Id = 2, DateOfExamination1 = new DateTime(2022, 9, 19),SNPOfExamination1 = "Петров Сергей Сидорович",
                GroupDateOfExamination2Id = 2, DateOfExamination2 = new DateTime(2022, 9, 24), SNPOfExamination2 = "Сидорова Мирина Сергеевна"},
                 new SNPForSubject { Id = 17, GroupId = 3, SessionId = 5, GroupDateOfOffsetId = 3, DateOfOffset = new DateTime(2022, 3, 16), SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3, DateOfOffset1 = new DateTime(2022, 4, 17), SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3, DateOfOffset2 = new DateTime(2022, 5, 18), SNPOfOffset2= "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3, DateOfExamination = new DateTime(2022, 6, 15), SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3, DateOfExamination1 = new DateTime(2022, 6, 20),SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3, DateOfExamination2 = new DateTime(2022, 6, 25), SNPOfExamination2 = "Солнцева Лариса Петровна"},
                new SNPForSubject { Id = 18, GroupId = 3, SessionId = 6, GroupDateOfOffsetId = 3, DateOfOffset = new DateTime(2022, 7, 16), SNPOfOffset = "Соколов Дмитрий Петрович",
                GroupDateOfOffset1Id = 3, DateOfOffset1 = new DateTime(2022, 7, 17), SNPOfOffset1 = "Книга Василий Васильевич",
                GroupDateOfOffset2Id = 3, DateOfOffset2 = new DateTime(2022, 8, 18), SNPOfOffset2= "Солнцева Лариса Петровна",
                GroupDateOfExaminationId = 3, DateOfExamination = new DateTime(2022, 9, 15), SNPOfExamination = "Соколов Дмитрий Петрович",
                GroupDateOfExamination1Id = 3, DateOfExamination1 = new DateTime(2022, 9, 20),SNPOfExamination1 = "Книга Василий Васильевич",
                GroupDateOfExamination2Id = 3, DateOfExamination2 = new DateTime(2022, 9, 25), SNPOfExamination2 = "Солнцева Лариса Петровна"},

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
