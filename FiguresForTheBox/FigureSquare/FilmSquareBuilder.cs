using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureSquare
{
    public class FilmSquareBuilder : FigureBuilder
    {
        /// <summary>
        /// Свойство Name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Свойство Color
        /// </summary>
        public override string Color { get; set; }
        /// <summary>
        /// Констрактор
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
                throw new NullReferenceException("Цвет не задан");
            }
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Конструктор
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
                throw new NullReferenceException("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            side = TheSize[2];
            
            Console.WriteLine("Вырезан прямоугольник со стороной " + side);
        }
        /// <summary>
        /// Метод Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Создает экземпляр класса SquareFigure с параметрами радиус и цвет(фигура из пленки)</returns>
        public override Figures Create(params double[] v)
        {
            return new SquareFigure(v, Color);
        }
    }
}
