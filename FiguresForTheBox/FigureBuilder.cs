using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox
{
    public abstract class FigureBuilder
    {
        /// <summary>
        /// Виртуальное войство Name
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Виртуальное войство Color
        /// </summary>
        public virtual string Color { get; set; }   
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public FigureBuilder(string n, Color color)
        {
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public FigureBuilder(double[] thesize1, params double[] thesize2)
        {
        }
        /// <summary>
        /// Метод Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        abstract public Figures Create(params double[] v);
    }
}
