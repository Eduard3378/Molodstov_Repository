using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureSquare
{
    /// <summary>
    /// Class SquareFigure
    /// </summary>
    public class SquareFigure : Figures
    {
        /// <summary>
        /// Property Width
        /// </summary>
        override public double Width { get; set; }
        /// <summary>
        /// Property Hight
        /// </summary>
        override public double Hight { get; set; }
        /// <summary>
        /// Property Width
        /// </summary>
        public double Side1 { get; set; }
        /// <summary>
        /// Property Color
        /// </summary>
        override public string Color
        {
            get; set;
        }
        /// <summary>
        /// Constructor SquareFigure(double[] v, string color)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="color"></param>
        public SquareFigure(double[] v, string color)
        {
            Side1 = v[0];            
            Color = color;
        }
        /// <summary>
        /// Method GetArea()
        /// </summary>
        /// <returns>Returns the area of an instance of a class</returns>
        override public double GetArea()
        {
            if (Side1 == 0)
            {
                throw new NullReferenceException("Сторона не задана");
            }
            return (Side1 * Side1);
        }
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <returns>Returns a string representation of an instance of a class</returns>
        public override string ToString()
        {
            return "Квадрат с площадью " + GetArea() + " и периметром " + GetPerimeter() + " цвет " + Color;
        }
        /// <summary>
        /// Method Equals1(Figures x, Figures y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Compares the area of an instance of a class to the area of an instance of another class</returns>
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
        /// Method GetHashCode(RectangleFigure obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns the HashCode of the object</returns>
        public static int GetHashCode(SquareFigure obj)
        {
            return obj.GetHashCode();
        }
        /// <summary>
        /// Method  GetPerimeter()
        /// </summary>
        /// <returns>Returns the perimeter of the object</returns>
        override public double GetPerimeter()
        {
            return 2 * (Side1 + Side1);
        }
    }
}
