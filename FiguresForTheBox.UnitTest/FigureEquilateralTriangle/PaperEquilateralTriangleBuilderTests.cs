using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureEquilateralTriangle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureEquilateralTriangle.Tests
{
    /// <summary>
    /// Class PaperEquilateralTriangleBuilderTests
    /// </summary>
    [TestClass()]
    public class PaperEquilateralTriangleBuilderTests
    {
        /// <summary>
        /// Method PaperEquilateralTriangleBuilder_Name_CreateObject()
        /// </summary>
        [TestMethod()]
        public void PaperEquilateralTriangleBuilder_Name_CreateObject()
        {
            // Arange               
            FigureBuilder triangleBuilder2 = new PaperEquilateralTriangleBuilder("EquilateralTriangle", Color.Green);
            Figures triangleFigure3 = triangleBuilder2.Create(12.0, 12.0, 12.0);
            // Assert            
            Assert.IsNotNull(triangleFigure3);
        }
        /// <summary>
        /// Method PaperEquilateralTriangleBuilder_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void PaperEquilateralTriangleBuilder_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 7.0, 7.0, 7.0 };
            double[] thesize2 = { 9.0, 9.0, 9.0 };
            PaperEquilateralTriangleBuilder triangleBuilder4 = new PaperEquilateralTriangleBuilder(thesize1, thesize2);
        }
        /// <summary>
        /// Method Create_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 9.0, 9.0, 9.0 };
            PaperEquilateralTriangleBuilder triangleFigure7 = new PaperEquilateralTriangleBuilder("EquilateralTriangle", Color.Green);
            EquilateralTriangleFigure triangleFigure6 = new EquilateralTriangleFigure(v, "Green");
            //Act
            var result = triangleFigure7.Create(v);
            // Assert 
            result.Should().Equals(triangleFigure6);
        }
    }
}