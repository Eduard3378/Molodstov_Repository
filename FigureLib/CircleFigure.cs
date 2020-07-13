using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class CircleFigure : Figures, IFigure, IPrintable
    {        
        const double pi = 3.1415;        
        public double Radius
        {
            get; set;
        }

        public CircleFigure(double[] v)
        {
            this.Radius = v[0];
        }
        
        override public double GetArea()
        {
            if (Radius == 0)
            {
                throw new NullReferenceException("Радиус не задан");
            }
            return (pi * Radius * Radius);
        }

        public override string ToString()
        {
            return "Окружность с площадью " + GetArea() + " и периметром " + GetPerimeter();
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
            return (2 * pi * Radius);
        }

        void IFigure.Print()
        {
            Console.WriteLine("Окружность с площадью " + GetArea());
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Окружность с радиусом " + Radius);
        }
    }
}
