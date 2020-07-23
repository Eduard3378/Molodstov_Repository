using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureRectangle
{
    public class RectangleFigure : Figures
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
        public RectangleFigure(double[] v, string color)
        {
            Width = v[0];
            Hight = v[1];
            Color = color;
        }
        /// <summary>
        /// Метод GetArea()
        /// </summary>
        /// <returns>Возвращает площадь экземпляра класса</returns>
        override public double GetArea()
        {
            if (Width == 0 || Hight == 0)
            {
                throw new NullReferenceException("Одна из сторон не задана");
            }
            return (Width * Hight);
        }
        /// <summary>
        /// метод ToString()
        /// </summary>
        /// <returns>Возвращает строковое представление экземпляра класса</returns>
        public override string ToString()
        {
            return "Прямоугольник с площадью " + GetArea() + " и периметром " + GetPerimeter() + " цвет " + Color;
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
        /// метод GetHashCode(RectangleFigure obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Возвращает HashCode объекта</returns>
        public static int GetHashCode(RectangleFigure obj)
        {
            return obj.GetHashCode();
        }
        /// <summary>
        /// Метод  GetPerimeter()
        /// </summary>
        /// <returns>Возвращает периметр объекта</returns>
        override public double GetPerimeter()
        {
            return 2 * (Hight + Width);
        }

    }
}
