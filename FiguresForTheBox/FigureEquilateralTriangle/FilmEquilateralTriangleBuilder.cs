using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureEquilateralTriangle
{
    /// <summary>
    /// Class FilmEquilateralTriangleBuilder
    /// </summary>
    public class FilmEquilateralTriangleBuilder: FigureBuilder
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
        /// Constructor FilmEquilateralTriangleBuilder(string n, Color color) : base(n, color)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public FilmEquilateralTriangleBuilder(string n, Color color) : base(n, color)
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
        /// Constructor FilmEquilateralTriangleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public FilmEquilateralTriangleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        {
            double[] TheSize = new double[6];
            TheSize[0] = thesize1[0];
            TheSize[1] = thesize1[1];
            TheSize[2] = thesize1[2];
            TheSize[3] = thesize2[0];
            TheSize[4] = thesize2[1];
            TheSize[5] = thesize2[2];
            double radius1 = 1;
            double side1 = 0;
            double side2 = 0;
            double side3 = 0;
            if ((TheSize[0] + TheSize[1] + TheSize[2]) <= (TheSize[3] + TheSize[4] + TheSize[5]))
            {
                radius1 = 0;
            }
            if (radius1 == 0)
            {
                throw new Exception("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            side1 = TheSize[3];
            side2 = TheSize[4];
            side3 = TheSize[5];

            Console.WriteLine("Вырезан равносторонний треугольник со сторонами " + side1 + " " + side2 + " " + side3);
        }
        /// <summary>
        /// Method Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Instantiates the EquilateralTriangleFigure class with radius and color parameters (film shape)</returns>
        public override Figures Create(params double[] v)
        {
            return new EquilateralTriangleFigure(v, Color);
        }
    }
}
