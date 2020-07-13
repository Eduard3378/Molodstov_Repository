using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class TriangleFigure : Figures, IFigure
    {
        public double Width { get; set; }
        public double Hight { get; set; }
        public double Hypotenuse { get; set; }

        public TriangleFigure(double[] v)
        {
            this.Width = v[0];
            this.Hight = v[1];
            this.Hypotenuse = v[2];
        }

        override public double GetArea()
        {
            if (Width == 0  || Hight == 0 || Hypotenuse == 0)
            {
                throw new NullReferenceException("Одна из сторон не задан");
            }
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p*(p- Width)*(p-Hight)*(p-Hypotenuse));           
        }

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

        public int GetHashCode(CircleFigure obj)
        {
            return obj.GetHashCode();
        }

        public override string ToString()
        {
            return "Треугольник с площадью " + GetArea() + " и периметром " + GetPerimeter();
        }
        public double GetPerimeter()
        {
            return Hight + Width + Hypotenuse;
        }

        void IFigure.Print()
        {
            Console.WriteLine("Прямоугольник с площадью " + GetArea());
        }
    }
}
