using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureSquare
{
    /// <summary>
    /// Class FilmSquareBuilder
    /// </summary>
    public class FilmSquareBuilder : FigureBuilder
    {
        /// <summary>
        /// Property Name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Свойство Color
        /// </summary>
        public override string Color { get; set; }
        /// <summary>
        /// Constructor FilmSquareBuilder(string n, Color color) : base(n, color)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public FilmSquareBuilder(string n, Color color) : base(n, color)
        {
            if (Color == "ImpToPoint")
            {
                Color = null;
            }
            if (Color == null)
            {
                throw new Exception("Цвет не задан");
            }
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Constructor FilmSquareBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public FilmSquareBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        {
            double[] TheSize = new double[4];
            TheSize[0] = thesize1[0];
            TheSize[1] = thesize1[0];
            TheSize[2] = thesize2[0];
            TheSize[3] = thesize2[0];
            double side1 = 1;
            double side = 0;

            if (TheSize[0] <= TheSize[2])
            {
                side1 = 0;
            }
            if (side1 == 0)
            {
                throw new Exception("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            side = TheSize[2];
            
            Console.WriteLine("Вырезан прямоугольник со стороной " + side);
        }
        /// <summary>
        /// Method Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Creates an instance of the SquareFigure class with radius and color parameters (film shape)</returns>
        public override Figures Create(params double[] v)
        {
            return new SquareFigure(v, Color);
        }
    }
}
