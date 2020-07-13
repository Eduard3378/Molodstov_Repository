using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class SquareBuilder : FigureBuilder
    {
        public SquareBuilder(string n) : base(n)
        { }

        public override Figures Create(params double[] v)
        {
            return new SquareFigure(v);
        }
    }
}
