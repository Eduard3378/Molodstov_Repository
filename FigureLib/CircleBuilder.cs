using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class CircleBuilder : FigureBuilder
    {

        public CircleBuilder(string n) : base(n)
        { }

        public override Figures Create(params double[] v)
        {
            return new CircleFigure(v);
        }
    }
}
