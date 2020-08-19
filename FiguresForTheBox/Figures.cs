using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox
{
    /// <summary>
    /// Abstract class Figures
    /// </summary>
    public abstract class Figures
    {
        /// <summary>
        /// Property Color
        /// </summary>
        public abstract string Color { get; set; }
        /// <summary>
        /// Property Width
        /// </summary>
        public abstract double Width { get; set; }
        /// <summary>
        /// Property Hight
        /// </summary>
        public abstract double Hight { get; set; }
        /// <summary>
        /// Abstract method GetArea()
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();
        /// <summary>
        /// Abstract method GetPerimeter()
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();

    }
}
