using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib
{
    public abstract class FigureBuilder
    {
        public string Name { get; set; }

        public FigureBuilder(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public Figures Create(params double[] v);
    }
}
