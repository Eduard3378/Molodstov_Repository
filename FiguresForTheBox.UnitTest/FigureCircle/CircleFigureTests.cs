using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureCircle;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureCircle.Tests
{
    [TestClass()]
    public class CircleFigureTests
    {
        static double[] a = { 14.0 };
        CircleFigure circleFigure3 = new CircleFigure(a, "White");

        static FigureBuilder circleBuilder1 = new PaperCircleBuilder("Circle", Color.Black);
        Figures circleFigure2 = circleBuilder1.Create(9.0);
        [TestMethod]
        public void Create_Radius_CreateObject()
        {
            // Arange           
            FigureBuilder circleBuilder2 = new PaperCircleBuilder("Circle", Color.Black);
            Figures circleFigure3 = circleBuilder2.Create(12.0);
            // Assert
            Assert.IsNotNull(circleFigure2);
            Assert.IsNotNull(circleFigure3);
        }

        [TestMethod]
        public void CircleFigure_Radius_CreateObject()
        {
            // Arange 
            double[] b = { 12.0 };
            // FigureBuilder circleBuilder2 = new PaperCircleBuilder("Circle", Color.Black);
            CircleFigure circleFigure3 = new CircleFigure(b, "White");
            // Assert
            Assert.IsNotNull(circleFigure3);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetArea_Radius_Exception()
        {
            // Arange
            double Radius = 0;
            FigureBuilder circleBuilder3 = new FilmCircleBuilder("Circle", Color.Colorless);
            Figures circleFigure4 = circleBuilder3.Create(Radius);
            //Act
            var result = circleFigure4.GetArea();
        }

        [TestMethod]
        public void ToString_Line_Line()
        {
            // Arange   
            double[] radius = { 3.0 };
            CircleFigure circleFigure2 = new CircleFigure(radius, "Blue");
            FigureBuilder circleBuilder4 = new PaperCircleBuilder("Circle", Color.Blue);
            Figures circleFigure5 = circleBuilder4.Create(3.0);
            string expected = "Окружность с площадью " + circleFigure2.GetArea() + " и периметром " + circleFigure2.GetPerimeter() + " цвет " + Color.Blue;
            //Act
            var result = circleFigure5.ToString();
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Equals1_CircleFigure_True()
        {
            // Arange   
            double[] radius = { 3.0 };
            CircleFigure circleFigure5 = new CircleFigure(radius, "Black");

            FigureBuilder circleBuilder5 = new PaperCircleBuilder("Circle", Color.Black);
            Figures circleFigure6 = circleBuilder5.Create(3);
            //Act
            var result = CircleFigure.Equals1(circleFigure6, circleFigure5);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CircleFigure_Radius_True()
        {
            // Arange           
            var result = false;
            double a = 15.0;
            double[] radius = { 15.0 };
            CircleFigure circleFigure1 = new CircleFigure(radius, "Black");
            //Act            
            if (circleFigure1.Radius.Equals(a))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            // Assert
            Assert.IsTrue(result);
        }

        //[TestMethod]
        //public void GetHashCode_Object_True()
        //{
        //    // Arange   
        //    double[] radius = { 3.0 };
        //    CircleFigure circleFigure6 = new CircleFigure(radius, "Black");
        //    int expected = 34622967;
        //    var result1 = false;
        //    //Act
        //    var result = CircleFigure.GetHashCode(circleFigure6);
        //    Console.WriteLine(result);
        //    if (result.Equals(expected))
        //    {
        //        result1 = true;
        //    }
        //    else
        //    {
        //        result1 = false;
        //    }
        //    // Assert
        //    Assert.IsTrue(result1);
        //}

        [TestMethod]
        public void GetPerimeter_Radius_Result()
        {
            // Arange                       
            var expected = 87.962;
            //Act
            var result = circleFigure3.GetPerimeter();            
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}