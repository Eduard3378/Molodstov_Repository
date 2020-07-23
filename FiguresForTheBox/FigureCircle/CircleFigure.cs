using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureCircle
{
    public class CircleFigure : Figures
    {
        const double pi = 3.1415;
        /// <summary>
        /// Свойство Width
        /// </summary>
        override public double Width { get; set; }
        /// <summary>
        /// Свойство Hight
        /// </summary>
        override public double Hight { get; set; }

        /// <summary>
        /// Свойство Radius
        /// </summary>
        public double Radius
        {
            get; set;
        }
        /// <summary>
        /// Свойство Color
        /// </summary>
        override public string Color
        {
            get; set;
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="v"></param>
        /// <param name="color"></param>
        public CircleFigure(double[] v, string color)
        {
            this.Radius = v[0];
            this.Color = color;
        }
        /// <summary>
        /// Метод GetArea()
        /// </summary>
        /// <returns>Возвращает площадь объекта</returns>
        override public double GetArea()
        {
            if (Radius == 0)
            {
                throw new NullReferenceException("Радиус не задан");
            }
            return (pi * Radius * Radius);
        }
        /// <summary>
        /// Метод ToString()
        /// </summary>
        /// <returns>Возвращает строковое представление экземпляра класса</returns>
        public override string ToString()
        {
            return "Окружность с площадью " + GetArea() + " и периметром " + GetPerimeter() + " цвет " + Color;
        }
        /// <summary>
        /// Метод Equals1(Figures x, Figures y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Сравнивает площадь экземиляр класса с площадью экземпляром другого класса</returns>
        public static bool Equals1(Figures x, Figures y)
        {
            if (x.GetArea() == y.GetArea())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// GetHashCode(CircleFigure obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Возвращает HashCode объекта</returns>
        public static int GetHashCode(CircleFigure obj)
        {
            return obj.GetHashCode();            
        }
        /// <summary>
        /// GetPerimeter()
        /// </summary>
        /// <returns>Возвращает периметр объекта</returns>
        override public double GetPerimeter()
        {
            return (2 * pi * Radius);
        }        
    }
}
