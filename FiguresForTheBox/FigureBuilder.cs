using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox
{
    /// <summary>
    /// Abstract class FigureBuilder
    /// </summary>
    public abstract class FigureBuilder
    {
        /// <summary>
        /// Virtual Property Name
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Virtual Property Color
        /// </summary>
        public virtual string Color { get; set; }
        /// <summary>
        /// Constructor FigureBuilder(string n, Color color)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="color"></param>
        public FigureBuilder(string n, Color color)
        {
            Name = n;
            Color = Convert.ToString(color);
        }
        /// <summary>
        /// Constructor FigureBuilder(double[] thesize1, params double[] thesize2)
        /// </summary>
        /// <param name="thesize1"></param>
        /// <param name="thesize2"></param>
        public FigureBuilder(double[] thesize1, params double[] thesize2)
        {
        }
        /// <summary>
        /// Method Create(params double[] v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        abstract public Figures Create(params double[] v);
    }
}
