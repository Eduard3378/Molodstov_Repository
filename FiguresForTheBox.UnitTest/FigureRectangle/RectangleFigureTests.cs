using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureRectangle;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureRectangle.Tests
{
    [TestClass()]
    public class RectangleFigureTests
    {
        static double[] a = { 12.0, 14.0 };
        RectangleFigure rectangleFigure3 = new RectangleFigure(a, "White");

        static FigureBuilder rectangleBuilder1 = new PaperRectangleBuilder("Rectangle", Color.Black);
        Figures rectangleFigure2 = rectangleBuilder1.Create(13.0, 15.0);
        [TestMethod]
        public void Create_WidthHight_CreateObject()
        {
            // Arange           
            FigureBuilder rectangleBuilder2 = new PaperRectangleBuilder("Rectangle", Color.Black);
            Figures rectangleFigure3 = rectangleBuilder2.Create(16.0, 17.0);
            // Assert
            Assert.IsNotNull(rectangleFigure2);
            Assert.IsNotNull(rectangleFigure3);
        }

        [TestMethod]
        public void RectangleFigure_WidthHight_CreateObject()
        {
            // Arange 
            double[] b = { 12.0, 19.0 };
            RectangleFigure rectangleFigure3 = new RectangleFigure(b, "White");
            // Assert
            Assert.IsNotNull(rectangleFigure3);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetArea_00_Exception()
        {
            // Arange
            double[] b = { 0.0, 0.0 };
            FigureBuilder rectangleBuilder3 = new FilmRectangleBuilder("Rectangle", Color.Colorless);
            Figures rectangleFigure4 = rectangleBuilder3.Create(b);
            //Act
            var result = rectangleFigure4.GetArea();
        }

        [TestMethod]
        public void ToString_Line_Line()
        {
            // Arange   
            double[] b = { 13.0, 18.0 };
            RectangleFigure rectangleFigure2 = new RectangleFigure(b, "Blue");
            FigureBuilder rectangleBuilder4 = new PaperRectangleBuilder("Rectangle", Color.Blue);
            Figures rectangleFigure5 = rectangleBuilder4.Create(13.0, 18.0);
            string expected = "Прямоугольник с площадью " + rectangleFigure2.GetArea() + " и периметром " + rectangleFigure2.GetPerimeter() + " цвет " + Color.Blue;
            //Act
            var result = rectangleFigure5.ToString();
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Equals1_RectangleFigure_True()
        {
            // Arange   
            double[] b = { 14.0, 19.0 };
            RectangleFigure rectangleFigure5 = new RectangleFigure(b, "Black");

            FigureBuilder rectangleBuilder5 = new PaperRectangleBuilder("Rectangle", Color.Black);
            Figures rectangleFigure6 = rectangleBuilder5.Create(14.0, 19.0);
            //Act
            var result = RectangleFigure.Equals1(rectangleFigure6, rectangleFigure5);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RectangleFigure_WidthHight_True()
        {
            // Arange           
            var result = false;
            double width = 19.0;
            double hight = 20.0;
            
            double[] b = { 19.0, 20.0 };
            RectangleFigure rectangleFigure1 = new RectangleFigure(b, "Black");
            //Act            
            if (rectangleFigure1.Width.Equals(width) && rectangleFigure1.Hight.Equals(hight))
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
        //    double[] b = { 15.0, 17.0 };
        //    RectangleFigure rectangleFigure6 = new RectangleFigure(b, "Black");
        //    int expected = 59460700;
        //    var result1 = false;
        //    //Act
        //    var result = RectangleFigure.GetHashCode(rectangleFigure6);
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
        public void GetPerimeter_WidthHight_Result()
        {
            // Arange                       
            var expected = 52;
            //Act
            var result = rectangleFigure3.GetPerimeter();            
            // Assert
            Assert.AreEqual(result, expected);
        }

    }
}