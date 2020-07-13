using NUnit.Framework;
using System;


namespace FigureLib.NUnitTests
{
    [TestFixture]
    public class CircleFigureTests
    {


        [Test]
        public void GetArea_Radius_Result()
        {
            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(3);
            // Arange
            double expected = 28.27;
            //Act
            var result = circleFigure1.GetArea();
            // Assert
            Assert.AreEqual(expected, result, 0.01);
        }

        [Test]       
        public void GetArea_Radius_False()
        {
            double Radius = 0;
            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(0);
            // Arange
          //  double expected = 28.27;
            //Act
            var result = circleFigure1.GetArea();
            // Assert
           // Assert.IsTrue(expected, result, 0.01);
        }

        //[Test]
        //public void GetArea_Radius_False()
        //{
        //    int radius = 3;
        //    CircleFigure circleFigure1 = new CircleFigure(radius);
        //    // Arange
        //    double expected = 28.27;
        //    //Act
        //    var result = circleFigure1.GetArea();
        //    // Assert
        //    Assert.IsTrue(expected, result, 0.01);
        //}


    }
}