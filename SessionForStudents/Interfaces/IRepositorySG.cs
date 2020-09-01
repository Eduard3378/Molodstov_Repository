using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.Interfaces
{
    /// <summary>
    /// Interface IRepositorySG<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorySG<T> where T : class
    {
        /// <summary>
        /// Method GetAll()
        /// </summary>
        /// <returns>Get all records</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Method Read(Func<T, Boolean> predicate)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Read the entry</returns>
        IEnumerable<T> Read(Func<T, Boolean> predicate);
        /// <summary>
        /// Method Create(T item)
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);
        /// <summary>
        /// Method Update(T item)
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        /// <summary>
        /// Method Delete(int groupId, int studentId)
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="studentId"></param>
        void Delete(int groupId, int studentId);
    }
}
