using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureRectangle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureRectangle.Tests
{
    [TestClass()]
    public class FilmRectangleBuilderTests
    {
        [TestMethod()]
        public void FilmRectangle_Name_CreateObject()
        {
            // Arange               
            FigureBuilder rectangleBuilder2 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure3 = rectangleBuilder2.Create(12.0, 14.0);
            // Assert            
            Assert.IsNotNull(rectangleFigure3);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilmRectangle_Color_CreateObject()
        {
            //Arange
            FigureBuilder rectangleBuilder3 = new FilmRectangleBuilder("RectangleFilm", Color.ImpToPoint);
            Figures rectangleFigure4 = rectangleBuilder3.Create(14.0, 15.0);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilmRectangle_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 5.0, 7.0 };
            double[] thesize2 = { 6.0, 8.0 };
            FilmRectangleBuilder rectangleBuilder4 = new FilmRectangleBuilder(thesize1, thesize2);
        }

        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 7.0, 8.0 };
            FilmRectangleBuilder rectangleFigure7 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            RectangleFigure rectangleFigure6 = new RectangleFigure(v, "Colorless");
            //Act
            var result = rectangleFigure7.Create(v);
            // Assert 
            result.Should().Equals(rectangleFigure6);
        }
    }
}