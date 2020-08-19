using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureRectangle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureRectangle.Tests
{
    /// <summary>
    /// Class PaperRectangleBuilderTests
    /// </summary>
    [TestClass()]
    public class PaperRectangleBuilderTests
    {
        /// <summary>
        /// Method PaperRectangleBuilder_Name_CreateObject()
        /// </summary>
        [TestMethod()]
        public void PaperRectangleBuilder_Name_CreateObject()
        {
            // Arange               
            FigureBuilder rectangleBuilder2 = new PaperRectangleBuilder("Rectangle", Color.Green);
            Figures rectangleFigure3 = rectangleBuilder2.Create(12.0, 14.0);
            // Assert            
            Assert.IsNotNull(rectangleFigure3);
        }
        /// <summary>
        /// Method PaperRectangleBuilder_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void PaperRectangleBuilder_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 7.0, 8.0 };
            double[] thesize2 = { 9.0, 10.0 };
            PaperRectangleBuilder rectangleBuilder4 = new PaperRectangleBuilder(thesize1, thesize2);
        }
        /// <summary>
        /// Method Create_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 9.0, 9.0, 9.0 };
            PaperRectangleBuilder rectangleFigure7 = new PaperRectangleBuilder("Rectangle", Color.Green);
            RectangleFigure rectangleFigure6 = new RectangleFigure(v, "Green");
            //Act
            var result = rectangleFigure7.Create(v);
            // Assert 
            result.Should().Equals(rectangleFigure6);
        }
    }
}