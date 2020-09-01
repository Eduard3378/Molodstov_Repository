using System;
using System.Collections.Generic;
using System.Text;

namespace SessionForStudents.Infrastructure
{
    /// <summary>
    /// Class ValidationException
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Property Property
        /// </summary>
        public string Property { get; protected set; }
        /// <summary>
        /// Constructor ValidationException(string message, string prop) : base(message)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="prop"></param>
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
