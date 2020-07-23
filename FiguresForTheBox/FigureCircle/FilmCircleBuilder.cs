using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureCircle
{
    public class FilmCircleBuilder : FigureBuilder
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
        /// Конструктор
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public FilmCircleBuilder(string n, Color color) : base(n, color)
        {
            if (Color == "ImpToPoint")
            {
                Color = null;
            }
            if (Color == null)
            {
                throw new NullReferenceException("Фигуры из пленки окрашивать нельзя");
            }
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public FilmCircleBuilder(double[] thesize1, params double[] thesize2) : base(thesize1, thesize2)
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
                throw new NullReferenceException("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            radius = TheSize[1];
            Console.WriteLine("Вырезана окружность с радиусом " + radius);
        }
        /// <summary>
        /// Метод Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Создает экземпляр класса CircleFigure с параметрами радиус и цвет(фигура из пленки)</returns>
        public override Figures Create(params double[] v)
        {
            return new CircleFigure(v, this.Color);
        }
    }
}
