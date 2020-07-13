using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib.UnitTests
{
    [TestClass()]
    public class SquareFigureTests
    {
        [TestMethod()]
        public void SquareFigureTest()
        {
            // Arange 
            double[] v = { 3 };
            FigureBuilder squareBuilder = new SquareBuilder("SquareFigure");
            Figures squareFigure1 = squareBuilder.Create(3);
            var expected = Convert.ToString(squareFigure1);
            //Act
            var result = new SquareFigure(v);
            var result1 = Convert.ToString(result);
            // Assert
            Assert.AreEqual(expected, result1);
            // Assert.Fail();
        }

        [TestMethod()]
        public void GetAreaTest()
        {
            // Arange
            FigureBuilder squareBuilder = new SquareBuilder("SquareFigure");
            Figures squareFigure1 = squareBuilder.Create(3);
            double expected = 9;
            //Act
            var result = squareFigure1.GetArea();
            // Assert
            Assert.AreEqual(result, expected, 0.01);
        }

        [TestMethod()]
        public void Equals1_SquareFigure_True()
        {
            // Arange   
            double[] v = { 3 };
            SquareFigure squareFigure2 = new SquareFigure(v);

            FigureBuilder squareBuilder1 = new SquareBuilder("SquareFigure");
            Figures squareFigure1 = squareBuilder1.Create(3);
            //Act
            var result = SquareFigure.Equals1(squareFigure1, squareFigure2);
            // Assert
            Assert.IsTrue(result);
        }        

        [TestMethod()]
        public void ToStringTest()
        {
            // Arange
            double[] v = { 2 };
            SquareFigure squareFigure = new SquareFigure(v);
            string str = "Квадрат с площадью " + squareFigure.GetArea() + " и периметром " + squareFigure.GetPerimeter();
            string expected = str;
            //Act
            string result = squareFigure.ToString();
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void GetPerimeterTest()
        {
            // Arange
            double[] v = { 2 };
            SquareFigure squareFigure2 = new SquareFigure(v);
            FigureBuilder squareBuilder = new SquareBuilder("SquareFigure");
            Figures squareFigure1 = squareBuilder.Create(2);
            double expected = 8;
            //Act
            var result = squareFigure2.GetPerimeter();
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}