using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.Interfaces
{
    /// <summary>
    /// Interface IRepository<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Method GetAll()
        /// </summary>
        /// <returns>Get all records</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Method Get(int id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get a record by ID</returns>
        T Get(int id);
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
        /// Method Delete(int id)
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
