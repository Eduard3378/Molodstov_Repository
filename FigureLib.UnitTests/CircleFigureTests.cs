using FigureLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FigureLib.UnitTests
{
    [TestClass]
    public class CircleFigureTests
    {
        [TestMethod]
        public void GetArea_Radius_Result()
        {
            // Arange
            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(3);            
            double expected = 28.27;
            //Act
            var result = circleFigure1.GetArea();
            // Assert
            Assert.AreEqual(expected, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetArea_Radius_Exception()
        {
            // Arange
            double Radius = 0;
            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(Radius);
            //Act
            var result = circleFigure1.GetArea();            
        }

        [TestMethod]
        public void CircleFigure_Radius_True()
        {
            // Arange           
            var result=false;
            double a = 4;
            double[] radius = { 4 };
            CircleFigure circleFigure1 = new CircleFigure(radius);
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

        [TestMethod]
        public void CircleFigure_String_String()
        {
            // Arange   
            double[] radius = { 3 };
            CircleFigure circleFigure2 = new CircleFigure(radius);
            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(3);
            string expected = "Окружность с площадью " + circleFigure2.GetArea() + " и периметром " + circleFigure2.GetPerimeter();           
            //Act
            var result = circleFigure1.ToString();
            // Assert
            Assert.AreEqual(expected, result);           

        }

        [TestMethod]
        public void Equals1_CircleFigure_True()
        {
            // Arange   
            double[] radius = { 3 };
            CircleFigure circleFigure2 = new CircleFigure(radius);

            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(3);
            //Act
            var result = CircleFigure.Equals1(circleFigure1, circleFigure2);
            // Assert
            Assert.IsTrue(result);
        }
    }
}
