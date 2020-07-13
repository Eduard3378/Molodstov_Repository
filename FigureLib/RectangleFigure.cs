using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class RectangleFigure : Figures, IFigure
    {
        public double Width { get; set; }
        public double Hight { get; set; }

        public RectangleFigure(double[] v)
        {
            this.Width = v[0];
            this.Hight = v[1];
        }       

        override public double GetArea()
        {
            return (Width * Hight);
        }

        public override string ToString()
        {
            return "Прямоугольник с площадью " + GetArea() + " и периметром " + GetPerimeter();
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
        public double GetPerimeter()
        {
            return 2 * (Hight + Width);
        }

        void IFigure.Print()
        {
            Console.WriteLine("Прямоугольник с площадью " + GetArea());
        }
    }
}
