using Microsoft.EntityFrameworkCore;
using SessionForStudents.EF;
using SessionForStudents.Entities;
using SessionForStudents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionForStudents.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private SessionContext db;
        public StudentRepository(SessionContext context)
        {
            this.db = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.Include(o => o.Surname);
        }

        public Student Get(int id)
        {
            return db.Students.Include(o => o.Id).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Student> Read(Func<Student, Boolean> predicate)
        {
            return db.Students.Include(o => o.Id).Include(o => o.Surname).Where(predicate).ToList();
        }


        public void Create(Student item)
        {
            db.Students.Add(item);
        }

        public void Delete(int id)
        {
            Student item = db.Students.Find(id);
            if (item != null) db.Students.Remove(item);
        }
       

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
