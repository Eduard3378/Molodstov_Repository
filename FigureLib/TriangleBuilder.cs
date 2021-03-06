﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public class TriangleBuilder : FigureBuilder
    {
        public TriangleBuilder(string n) : base(n)
        { }

        public override Figures Create(params double[] v)
        {
            return new TriangleFigure(v);
        }
    }
}
