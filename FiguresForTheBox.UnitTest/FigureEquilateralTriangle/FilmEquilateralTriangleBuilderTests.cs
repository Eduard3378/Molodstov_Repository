using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureEquilateralTriangle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureEquilateralTriangle.Tests
{
    [TestClass()]
    public class FilmEquilateralTriangleBuilderTests
    {
        [TestMethod()]
        public void FilmEquilateralTriangle_Name_CreateObject()
        {
            // Arange               
            FigureBuilder triangleBuilder2 = new FilmEquilateralTriangleBuilder("EquilateralTriangleFilm", Color.Colorless);
            Figures triangleFigure3 = triangleBuilder2.Create(12.0, 12.0, 12.0);
            // Assert            
            Assert.IsNotNull(triangleFigure3);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilmEquilateralTriangle_Color_CreateObject()
        {
            //Arange
            FigureBuilder triangleBuilder3 = new FilmEquilateralTriangleBuilder("EquilateralTriangleFilm", Color.ImpToPoint);
            Figures triangleFigure4 = triangleBuilder3.Create(14.0, 14.0, 14.0);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilmEquilateralTriangle_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 5.0, 5.0, 5.0 };
            double[] thesize2 = { 6.0, 6.0, 6.0 };
            FilmEquilateralTriangleBuilder triangleBuilder4 = new FilmEquilateralTriangleBuilder(thesize1, thesize2);
        }

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