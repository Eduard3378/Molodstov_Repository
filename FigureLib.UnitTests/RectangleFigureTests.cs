using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib.UnitTests
{
    [TestClass()]
    public class RectangleFigureTests
    {
        [TestMethod]
        public void RectangleFigureTest()
        {
            // Arange 
            double[] v = { 5, 4 };
          //  RectangleFigure rectangleFigure = new RectangleFigure(v);

            FigureBuilder rectangleBuilder = new RectangleBuilder("RectangleFigure");
            Figures rectangleFigure1 = rectangleBuilder.Create(5, 4);
            var expected = Convert.ToString(rectangleFigure1);
            //Act
            var result = new RectangleFigure(v);
            var result1 = Convert.ToString(result);
            // Assert
            Assert.AreEqual(expected, result1);
            // Assert.Fail();
        }

        [TestMethod()]
        public void GetAreaTest()
        {
            // Arange
            FigureBuilder rectangleBuilder = new RectangleBuilder("RectangleFigure");
            Figures rectangleFigure1 = rectangleBuilder.Create(5, 4);
            double expected = 20;
            //Act
            var result = rectangleFigure1.GetArea();
            // Assert
            Assert.AreEqual(result, expected, 0.01);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arange
            double[] v = { 5, 4 };
            RectangleFigure rectangleFigure = new RectangleFigure(v);
            string str = "Прямоугольник с площадью " + rectangleFigure.GetArea() + " и периметром " + rectangleFigure.GetPerimeter();
            var expected = str;
            //Act
            var result = rectangleFigure.ToString();
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void Equals1_RectangleFigure_True()
        {
            // Arange   
            double[] v = { 3, 6 };
            RectangleFigure rectangleFigure2 = new RectangleFigure(v);

            FigureBuilder rectangleBuilder1 = new RectangleBuilder("RectangleFigure");
            Figures rectangleFigure1 = rectangleBuilder1.Create(3,6);
            //Act
            var result = RectangleFigure.Equals1(rectangleFigure1, rectangleFigure2);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetPerimeterTest()
        {
            // Arange
            double[] v = { 5,4 };
            RectangleFigure rectangleFigure2 = new RectangleFigure(v);
            FigureBuilder rectangleBuilder = new RectangleBuilder("RectangleFigure");
            Figures rectangleFigure1 = rectangleBuilder.Create(5, 4);
            double expected = 18;
            //Act
            var result = rectangleFigure2.GetPerimeter();
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}