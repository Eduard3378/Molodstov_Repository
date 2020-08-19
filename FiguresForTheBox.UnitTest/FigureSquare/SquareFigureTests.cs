using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureSquare;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresForTheBox.FigureSquare.Tests
{
    /// <summary>
    /// Class SquareFigureTests
    /// </summary>
    [TestClass()]
    public class SquareFigureTests
    {
        static double[] a = { 12.0 };
        SquareFigure squareFigure3 = new SquareFigure(a, "White");

        static FigureBuilder squareBuilder1 = new PaperSquareBuilder("Square", Color.Black);
        Figures squareFigure2 = squareBuilder1.Create(13.0);
        /// <summary>
        /// Method Create_Side1_CreateObject()
        /// </summary>
        [TestMethod]
        public void Create_Side1_CreateObject()
        {
            // Arange           
            FigureBuilder squareBuilder2 = new PaperSquareBuilder("Square", Color.Black);
            Figures squareFigure3 = squareBuilder2.Create(16.0);
            // Assert
            Assert.IsNotNull(squareFigure2);
            Assert.IsNotNull(squareFigure3);
        }
        /// <summary>
        /// Method SquareFigure_Side1_CreateObject()
        /// </summary>
        [TestMethod]
        public void SquareFigure_Side1_CreateObject()
        {
            // Arange 
            double[] b = { 12.0 };
            SquareFigure squareFigure3 = new SquareFigure(b, "White");
            // Assert
            Assert.IsNotNull(squareFigure3);
        }
        /// <summary>
        /// Method GetArea_00_Exception()
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetArea_00_Exception()
        {
            // Arange
            double[] b = { 0.0 };
            FigureBuilder squareBuilder3 = new FilmSquareBuilder("Square", Color.Colorless);
            Figures squareFigure4 = squareBuilder3.Create(b);
            //Act
            var result = squareFigure4.GetArea();
        }
        /// <summary>
        /// Method ToString_Line_Line()
        /// </summary>
        [TestMethod]
        public void ToString_Line_Line()
        {
            // Arange   
            double[] b = { 13.0 };
            SquareFigure squareFigure2 = new SquareFigure(b, "Blue");
            FigureBuilder squareBuilder4 = new PaperSquareBuilder("Square", Color.Blue);
            Figures squareFigure5 = squareBuilder4.Create(13.0);
            string expected = "Квадрат с площадью " + squareFigure2.GetArea() + " и периметром " + squareFigure2.GetPerimeter() + " цвет " + Color.Blue;
            //Act
            var result = squareFigure5.ToString();
            // Assert
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Method Equals1_SquareFigure_True()
        /// </summary>
        [TestMethod]
        public void Equals1_SquareFigure_True()
        {
            // Arange   
            double[] b = { 14.0 };
            SquareFigure squareFigure5 = new SquareFigure(b, "Black");

            FigureBuilder squareBuilder5 = new PaperSquareBuilder("Square", Color.Black);
            Figures squareFigure6 = squareBuilder5.Create(14.0);
            //Act
            var result = SquareFigure.Equals1(squareFigure6, squareFigure5);
            // Assert
            Assert.IsTrue(result);
        }
        /// <summary>
        /// Method SquareFigure_Side1_True()
        /// </summary>
        [TestMethod]
        public void SquareFigure_Side1_True()
        {
            // Arange           
            var result = false;
            double side1 = 19.0;            

            double[] b = { 19.0 };
            SquareFigure squareFigure1 = new SquareFigure(b, "Black");
            //Act            
            if (squareFigure1.Side1.Equals(side1))
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
        //    double[] b = { 15.0 };
        //    SquareFigure squareFigure6 = new SquareFigure(b, "Black");
        //    int expected = 38354326;
        //    var result1 = false;
        //    //Act
        //    var result = SquareFigure.GetHashCode(squareFigure6);
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
        /// <summary>
        /// Method GetPerimeter_Side1_Result()
        /// </summary>
        [TestMethod]
        public void GetPerimeter_Side1_Result()
        {
            // Arange                       
            var expected = 48;
            //Act
            var result = squareFigure3.GetPerimeter();
            Console.WriteLine(result);
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}