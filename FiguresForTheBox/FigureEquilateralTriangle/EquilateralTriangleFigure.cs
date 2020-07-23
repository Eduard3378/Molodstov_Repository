using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureEquilateralTriangle
{
    public class EquilateralTriangleFigure : Figures
    {
        /// <summary>
        /// Свойство Width
        /// </summary>
        override public double Width { get; set; }
        /// <summary>
        /// Свойство Hight
        /// </summary>
        override public double Hight { get; set; }
        /// <summary>
        /// Свойство A
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// Свойство B
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// Свойство C
        /// </summary>
        public double C { get; set; }
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
        public EquilateralTriangleFigure(double[] v, string color)
        {
            this.A = v[0];
            this.B = v[1];
            this.C = v[2];
            Color = color;
        }
        /// <summary>
        /// Метод GetArea()
        /// </summary>
        /// <returns>Возвращает площадь объекта</returns>
        override public double GetArea()
        {
            if (A == 0 || B == 0 || C == 0)
            {
                throw new NullReferenceException("Одна из сторон не задана");
            }
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
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
        /// Метод GetHashCode(EquilateralTriangleFigure obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Возвращает HashCode объекта</returns>
        public static int GetHashCode(EquilateralTriangleFigure obj)
        {
            return obj.GetHashCode();
        }
        /// <summary>
        /// Метод ToString()
        /// </summary>
        /// <returns>Возвращает строковое представление экземпляра класса</returns>
        public override string ToString()
        {
            return "Треугольник с площадью " + GetArea() + " и периметром " + GetPerimeter() + " цвет " + Color;
        }
        /// <summary>
        /// Метод GetPerimeter()
        /// </summary>
        /// <returns>Возвращает периметр объекта</returns>
        override public double GetPerimeter()
        {
            return A + B + C;
        }      
    }
}
