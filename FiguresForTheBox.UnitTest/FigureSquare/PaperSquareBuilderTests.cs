using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureSquare;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureSquare.Tests
{
    [TestClass()]
    public class PaperSquareBuilderTests
    {
        [TestMethod()]
        public void PaperSquareBuilder_Name_CreateObject()
        {
            // Arange               
            FigureBuilder squareBuilder2 = new PaperSquareBuilder("Square", Color.Green);
            Figures squareFigure3 = squareBuilder2.Create(12.0);
            // Assert            
            Assert.IsNotNull(squareFigure3);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void PaperSquareBuilder_Thesize1_CreateObject()
        {
            //Arange            

            double[] thesize1 = { 7.0 };
            double[] thesize2 = { 9.0 };
            PaperSquareBuilder squareBuilder4 = new PaperSquareBuilder(thesize1, thesize2);
        }

        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 9.0 };
            PaperSquareBuilder squareFigure7 = new PaperSquareBuilder("Square", Color.Green);
            SquareFigure squareFigure6 = new SquareFigure(v, "Green");
            //Act
            var result = squareFigure7.Create(v);
            // Assert 
            result.Should().Equals(squareFigure6);
        }
    }
}