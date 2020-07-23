using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureEquilateralTriangle;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureEquilateralTriangle.Tests
{
    [TestClass()]
    public class EquilateralTriangleFigureTests
    {
        static double[] a = { 14.0, 14.0, 14.0 };
        EquilateralTriangleFigure triangleFigure3 = new EquilateralTriangleFigure(a, "White");

        static FigureBuilder triangleBuilder1 = new PaperEquilateralTriangleBuilder("EquilateralTriangle", Color.Black);
        Figures triangleFigure2 = triangleBuilder1.Create(9.0, 9.0, 9.0);
        [TestMethod]
        public void Create_ABC_CreateObject()
        {
            // Arange           
            FigureBuilder triangleBuilder2 = new PaperEquilateralTriangleBuilder("EquilateralTriangle", Color.Black);
            Figures triangleFigure3 = triangleBuilder2.Create(12.0, 12.0, 12.0);
            // Assert
            Assert.IsNotNull(triangleFigure2);
            Assert.IsNotNull(triangleFigure3);
        }

        [TestMethod]
        public void EquilateralTriangleFigure_Radius_CreateObject()
        {
            // Arange 
            double[] b = { 12.0, 12.0, 12.0 };            
            EquilateralTriangleFigure triangleFigure3 = new EquilateralTriangleFigure(b, "White");
            // Assert
            Assert.IsNotNull(triangleFigure3);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetArea_Radius_Exception()
        {
            // Arange
            double[] b = { 0.0, 0.0, 0.0 };
            FigureBuilder triangleBuilder3 = new FilmEquilateralTriangleBuilder("EquilateralTriangle", Color.Colorless);
            Figures triangleFigure4 = triangleBuilder3.Create(b);
            //Act
            var result = triangleFigure4.GetArea();
        }

        [TestMethod]
        public void ToString_Line_Line()
        {
            // Arange   
            double[] b = { 13.0, 13.0, 13.0 };
            EquilateralTriangleFigure triangleFigure2 = new EquilateralTriangleFigure(b, "Blue");
            FigureBuilder triangleBuilder4 = new PaperEquilateralTriangleBuilder("EquilateralTriangle", Color.Blue);
            Figures triangleFigure5 = triangleBuilder4.Create(13.0, 13.0, 13.0);
            string expected = "Треугольник с площадью " + triangleFigure2.GetArea() + " и периметром " + triangleFigure2.GetPerimeter() + " цвет " + Color.Blue;
            //Act
            var result = triangleFigure5.ToString();
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Equals1_EquilateralTriangleFigure_True()
        {
            // Arange   
            double[] b = { 14.0, 14.0, 14.0 };
            EquilateralTriangleFigure triangleFigure5 = new EquilateralTriangleFigure(b, "Black");

            FigureBuilder triangleBuilder5 = new PaperEquilateralTriangleBuilder("EquilateralTriangle", Color.Black);
            Figures triangleFigure6 = triangleBuilder5.Create(14.0, 14.0, 14.0);
            //Act
            var result = EquilateralTriangleFigure.Equals1(triangleFigure6, triangleFigure5);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EquilateralTriangleFigure_ABC_True()
        {
            // Arange           
            var result = false;
            double a = 15.0;
            double d = 15.0;
            double c = 15.0;
            double[] b = { 15.0, 15.0, 15.0 };
            EquilateralTriangleFigure triangleFigure1 = new EquilateralTriangleFigure(b, "Black");
            //Act            
            if (triangleFigure1.A.Equals(a) && triangleFigure1.B.Equals(d) && triangleFigure1.C.Equals(c))
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
        //    double[] b = { 15.0, 15.0, 15.0 };
        //    EquilateralTriangleFigure triangleFigure6 = new EquilateralTriangleFigure(b, "Black");
        //    int expected = 65110521;
        //    var result1 = false;
        //    //Act
        //    var result = EquilateralTriangleFigure.GetHashCode(triangleFigure6);
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
            var expected = 42;
            //Act
            var result = triangleFigure3.GetPerimeter();           
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}