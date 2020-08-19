using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureCircle
{
    /// <summary>
    /// Class CircleFigure
    /// </summary>
    public class CircleFigure : Figures
    {
        const double pi = 3.1415;
        /// <summary>
        /// Property Width
        /// </summary>
        override public double Width { get; set; }
        /// <summary>
        /// Property Hight
        /// </summary>
        override public double Hight { get; set; }

        /// <summary>
        /// Property Radius
        /// </summary>
        public double Radius
        {
            get; set;
        }
        /// <summary>
        /// Property Color
        /// </summary>
        override public string Color
        {
            get; set;
        }
        /// <summary>
        /// Constructor CircleFigure(double[] v, string color)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="color"></param>
        public CircleFigure(double[] v, string color)
        {
            this.Radius = v[0];
            this.Color = color;
        }
        /// <summary>
        /// Method GetArea()
        /// </summary>
        /// <returns>Returns the area of an object</returns>
        override public double GetArea()
        {
            if (Radius == 0)
            {
                throw new NullReferenceException("Радиус не задан");
            }
            return (pi * Radius * Radius);
        }
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <returns>Returns a string representation of an instance of a class</returns>
        public override string ToString()
        {
            return "Окружность с площадью " + GetArea() + " и периметром " + GetPerimeter() + " цвет " + Color;
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
        /// Method GetHashCode(CircleFigure obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns the HashCode of the object</returns>
        public static int GetHashCode(CircleFigure obj)
        {
            return obj.GetHashCode();            
        }
        /// <summary>
        /// Method GetPerimeter()
        /// </summary>
        /// <returns>Returns the perimeter of the object</returns>
        override public double GetPerimeter()
        {
            return (2 * pi * Radius);
        }        
    }
}
