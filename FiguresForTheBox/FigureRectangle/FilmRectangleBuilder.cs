using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureRectangle
{
    public class FilmRectangleBuilder : FigureBuilder
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
        public FilmRectangleBuilder(string n, Color color) : base(n, color)
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
                throw new NullReferenceException("Фигуру 2 нельзя вырезать из фигуры 1");
            }
            width = TheSize[2];
            hight = TheSize[3];
            Console.WriteLine("Вырезан прямоугольник с длиной " + width + " и шириной " + hight);
        }
        /// <summary>
        /// Метод Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Создает экземпляр класса RectangleFigure с параметрами радиус и цвет(фигура из пленки)</returns>
        public override Figures Create(params double[] v)
        {
            return new RectangleFigure(v, Color);
        }
    }
}
