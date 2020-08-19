using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureSquare
{
    /// <summary>
    /// Class PaperSquareBuilder
    /// </summary>
    public class PaperSquareBuilder : FigureBuilder
    {
        /// <summary>
        /// Property Name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Property Color
        /// </summary>
        public override string Color { get; set; }
        /// <summary>
        /// Constructor PaperSquareBuilder(string n, Color color) : base(n, color)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public PaperSquareBuilder(string n, Color color) : base(n, color)
        {           
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Constructor PaperSquareBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public PaperSquareBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
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
        /// <returns>Creates an instance of the SquareFigure class with radius and color parameters (paper shape)</returns>
        public override Figures Create(params double[] v)
        {
            return new SquareFigure(v, Color);
        }
    }
}
