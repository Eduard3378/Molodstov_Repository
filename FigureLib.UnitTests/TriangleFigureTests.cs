using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLib.UnitTests
{
    [TestClass()]
    public class TriangleFigureTests
    {
        [TestMethod]
        public void GetArea_Radius_Result()
        {
            // Arange
            FigureBuilder triangleBuilder1 = new TriangleBuilder("TriangleFigure");
            Figures triangleFigure1 = triangleBuilder1.Create(3, 4, 4);
            double expected = 5.56;
            //Act
            var result = triangleFigure1.GetArea();
            // Assert
            Assert.AreEqual(expected, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetArea_Radius_Exception()
        {
            // Arange
            double[] v = { 3, 4, 0 };
            FigureBuilder triangleBuilder1 = new TriangleBuilder("TriangleFigure");
            Figures triangleFigure1 = triangleBuilder1.Create(v);
            //Act
            var result = triangleFigure1.GetArea();
        }

        [TestMethod]
        public void TriangleFigure_abc_True()
        {
            // Arange           
            var result = false;
            double a = 3;
            double b = 4;
            double c = 4;
            double[] v = { 3, 4, 4 };
            TriangleFigure triangleFigure1 = new TriangleFigure(v);
            //Act            
            if (triangleFigure1.Width.Equals(a) && triangleFigure1.Hight.Equals(b) 
                && triangleFigure1.Hypotenuse.Equals(c))
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

        [TestMethod]
        public void TriangleFigure_String_String()
        {
            // Arange   
            double[] v = { 3, 4, 4 };
            TriangleFigure triangleFigure2 = new TriangleFigure(v);
            FigureBuilder triangleBuilder1 = new TriangleBuilder("TriangleFigure");
            Figures triangleFigure1 = triangleBuilder1.Create(3, 4, 4);
            string expected = "Треугольник с площадью " + triangleFigure2.GetArea() + " и периметром " + triangleFigure2.GetPerimeter();
            //Act
            var result = triangleFigure1.ToString();
            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Equals1_TriangleFigure_True()
        {
            // Arange   
            double[] v = { 3, 4, 4 };
            TriangleFigure triangleFigure2 = new TriangleFigure(v);

            FigureBuilder triangleBuilder1 = new TriangleBuilder("TriangleFigure");
            Figures triangleFigure1 = triangleBuilder1.Create(3, 4, 4);
            //Act
            var result = TriangleFigure.Equals1(triangleFigure1, triangleFigure2);
            // Assert
            Assert.IsTrue(result);
        }
    }
}