using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureEquilateralTriangle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureEquilateralTriangle.Tests
{
    /// <summary>
    /// Class FilmEquilateralTriangleBuilderTests
    /// </summary>
    [TestClass()]
    public class FilmEquilateralTriangleBuilderTests
    {
        /// <summary>
        /// Method FilmEquilateralTriangle_Name_CreateObject()
        /// </summary>
        [TestMethod()]
        public void FilmEquilateralTriangle_Name_CreateObject()
        {
            // Arange               
            FigureBuilder triangleBuilder2 = new FilmEquilateralTriangleBuilder("EquilateralTriangleFilm", Color.Colorless);
            Figures triangleFigure3 = triangleBuilder2.Create(12.0, 12.0, 12.0);
            // Assert            
            Assert.IsNotNull(triangleFigure3);
        }
        /// <summary>
        /// Method FilmEquilateralTriangle_Color_CreateObject()
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FilmEquilateralTriangle_Color_CreateObject()
        {
            //Arange
            FigureBuilder triangleBuilder3 = new FilmEquilateralTriangleBuilder("EquilateralTriangleFilm", Color.ImpToPoint);
            Figures triangleFigure4 = triangleBuilder3.Create(14.0, 14.0, 14.0);
        }
        /// <summary>
        /// Method FilmEquilateralTriangle_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FilmEquilateralTriangle_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 5.0, 5.0, 5.0 };
            double[] thesize2 = { 6.0, 6.0, 6.0 };
            FilmEquilateralTriangleBuilder triangleBuilder4 = new FilmEquilateralTriangleBuilder(thesize1, thesize2);
        }
        /// <summary>
        /// Method Create_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 7.0, 7.0, 7.0 };
            FilmEquilateralTriangleBuilder triangleFigure7 = new FilmEquilateralTriangleBuilder("EquilateralTriangleFilm", Color.Colorless);
            EquilateralTriangleFigure triangleFigure6 = new EquilateralTriangleFigure(v, "Colorless");
            //Act
            var result = triangleFigure7.Create(v);
            // Assert 
            result.Should().Equals(triangleFigure6);
        }
    }
}