using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureCircle
{
    /// <summary>
    /// Class PaperCircleBuilder
    /// </summary>
    public class PaperCircleBuilder : FigureBuilder
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
        /// Constructor PaperCircleBuilder(string n, Color color) : base(n, color)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public PaperCircleBuilder(string n, Color color) : base(n, color)
        {           
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Constructor PaperCircleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public PaperCircleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        {
            double[] TheSize = new double[2];
            TheSize[0] = thesize1[0];
            TheSize[1] = thesize2[0];
            double radius1 = 1;
            double radius = 0;
            if (TheSize[0] <= TheSize[1])
            {
                radius1 = 0;                
            }
            if (radius1 == 0)
            {
                throw new Exception("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            radius = TheSize[1];
            Console.WriteLine("Вырезана окружность с радиусом " + radius);
        }
        /// <summary>
        /// Method Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Creates an instance of the CircleFigure class with radius and color parameters (paper shape)</returns>
        public override Figures Create(params double[] v)
        {
            return new CircleFigure(v, Color);
        }
    }
}
