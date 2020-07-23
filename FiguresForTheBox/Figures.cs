using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox
{
    public abstract class Figures
    {
        /// <summary>
        ///  Свойство Color
        /// </summary>
        public abstract string Color { get; set; }
        /// <summary>
        /// Свойство Width
        /// </summary>
        public abstract double Width { get; set; }
        /// <summary>
        /// Свойство Hight
        /// </summary>
        public abstract double Hight { get; set; }
        /// <summary>
        /// Абстрактный метод GetArea()
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();
        /// <summary>
        /// Абстрактный метод GetPerimeter()
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();

    }
}
