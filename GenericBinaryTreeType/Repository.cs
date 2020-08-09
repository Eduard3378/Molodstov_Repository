using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GenericBinaryTreeType
{
    /// <summary>
    /// Class Repository 
    /// </summary>
    public static class Repository 
    {
        private const string Filename = "stud.xml";

        static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Student1[]));
        /// <summary>
        /// Method Add(Student1 student)
        /// </summary>
        /// <param name="student"></param>
        public static void Add(Student1 student)
        {
            var students = Students.ToList();
            students.Add(student);
            using (var fileStream = new FileStream(Filename, FileMode.Create))
            {
                Serializer.Serialize(fileStream, students.ToArray());
            }
        }
        /// <summary>
        /// Property Students
        /// </summary>
        public static IEnumerable<Student1> Students
        {
            get
            {
                try
                {
                    using (var fileStream = new FileStream(Filename, FileMode.Open))
                    {
                        return (IEnumerable<Student1>)Serializer.Deserialize(fileStream);
                    }
                }
                catch
                {
                    return Enumerable.Empty<Student1>();
                }
            }
        }
    }
}
