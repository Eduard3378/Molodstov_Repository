using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureRectangle
{
    /// <summary>
    /// Class FilmRectangleBuilder
    /// </summary>
    public class FilmRectangleBuilder : FigureBuilder
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
        /// Constructor FilmRectangleBuilder(string n, Color color) : base(n, color)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public FilmRectangleBuilder(string n, Color color) : base(n, color)
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
        /// Constructor FilmRectangleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public FilmRectangleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
        {
            double[] TheSize = new double[4];
            TheSize[0] = thesize1[0];
            TheSize[1] = thesize1[1];
            TheSize[2] = thesize2[0];
            TheSize[3] = thesize2[1];
            double radius1 = 1;
            double width = 0;
            double hight = 0;            
            if ((TheSize[0] <= TheSize[2] && TheSize[1] <= TheSize[3])               
            || ((TheSize[0] > TheSize[2] && TheSize[3] > TheSize[1]) 
            && (TheSize[0] > TheSize[2] && TheSize[3] > TheSize[0])))
            {
                radius1 = 0;
            }
            if (radius1 == 0)
            {
                throw new Exception("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            width = TheSize[2];
            hight = TheSize[3];
            Console.WriteLine("Вырезан прямоугольник с длиной " + width + " и шириной " + hight);
        }
        /// <summary>
        /// Method Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Creates an instance of the RectangleFigure class with radius and color parameters (film shape)</returns>
        public override Figures Create(params double[] v)
        {
            return new RectangleFigure(v, Color);
        }
    }
}
