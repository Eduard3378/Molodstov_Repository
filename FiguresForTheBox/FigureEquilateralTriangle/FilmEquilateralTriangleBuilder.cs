using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureEquilateralTriangle
{
    public class FilmEquilateralTriangleBuilder: FigureBuilder
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
        public FilmEquilateralTriangleBuilder(string n, Color color) : base(n, color)
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
                throw new NullReferenceException("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            side1 = TheSize[3];
            side2 = TheSize[4];
            side3 = TheSize[5];

            Console.WriteLine("Вырезан равносторонний треугольник со сторонами " + side1 + " " + side2 + " " + side3);
        }
        /// <summary>
        /// Метод Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Создает экземпляр класса EquilateralTriangleFigure с параметрами радиус и цвет(фигура из пленки)</returns>
        public override Figures Create(params double[] v)
        {
            return new EquilateralTriangleFigure(v, Color);
        }
    }
}
