using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureEquilateralTriangle
{
    /// <summary>
    /// Class EquilateralTriangleFigure
    /// </summary>
    public class EquilateralTriangleFigure : Figures
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
        /// Property A
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// Property B
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// Property C
        /// </summary>
        public double C { get; set; }
        /// <summary>
        /// Property Color
        /// </summary>
        override public string Color
        {
            get; set;
        }
        /// <summary>
        /// Constructor EquilateralTriangleFigure(double[] v, string color)
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
        /// Method GetArea()
        /// </summary>
        /// <returns>Returns the area of an object</returns>
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
        /// Method GetHashCode(EquilateralTriangleFigure obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns the HashCode of the object</returns>
        public static int GetHashCode(EquilateralTriangleFigure obj)
        {
            return obj.GetHashCode();
        }
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <returns>Returns a string representation of an instance of a class</returns>
        public override string ToString()
        {
            return "Треугольник с площадью " + GetArea() + " и периметром " + GetPerimeter() + " цвет " + Color;
        }
        /// <summary>
        /// Method GetPerimeter()
        /// </summary>
        /// <returns>Returns the perimeter of the object</returns>
        override public double GetPerimeter()
        {
            return A + B + C;
        }      
    }
}
