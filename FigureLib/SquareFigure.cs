using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class SquareFigure : Figures, IFigure, IPrintable
    {        
        public double Width { get; set; }

        public SquareFigure(double[] width)
        {
            this.Width = width[0];
        }

        override public double GetArea()
        {
            return (Width * Width);
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
            return "Квадрат с площадью " + GetArea() + " и периметром " + GetPerimeter();
        }
        public double GetPerimeter()
        {
            return 2 * (Width + Width);
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Квадрат со стороной " + Width);
        }

        void IFigure.Print()
        {
            Console.WriteLine("Квадрат с площадью " + GetArea());
        }
    }
}
