using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class RectangleBuilder : FigureBuilder
    {
        public RectangleBuilder(string n) : base(n)
        { }

        public override Figures Create(params double[] v)
        {
            return new RectangleFigure(v);
        }
    }
}
