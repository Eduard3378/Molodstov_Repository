using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureCircle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureCircle.Tests
{
    [TestClass()]
    public class FilmCircleBuilderTests
    {
        [TestMethod()]
        public void FilmCircleBuilder_Name_CreateObject()
        {
            // Arange               
            FigureBuilder circleBuilder2 = new FilmCircleBuilder("CircleFilm", Color.Colorless);
            Figures circleFigure3 = circleBuilder2.Create(12.0);
            // Assert            
            Assert.IsNotNull(circleFigure3);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilmCircleBuilder_Color_CreateObject()
        {
            //Arange
            FigureBuilder circleBuilder3 = new FilmCircleBuilder("CircleFilm", Color.ImpToPoint);
            Figures circleFigure4 = circleBuilder3.Create(14.0);           
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilmCircleBuilder_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 5.0 };
            double[] thesize2 = { 6.0 };
            FilmCircleBuilder circleBuilder4 = new FilmCircleBuilder(thesize1, thesize2);          
        }

        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 7.0 };
            FilmCircleBuilder circleFigure7 = new FilmCircleBuilder("CircleFilm", Color.Colorless);
            CircleFigure circleFigure6 = new CircleFigure(v, "Colorless");          
            //Act
            var result = circleFigure7.Create(v);
            // Assert 
            result.Should().Equals(circleFigure6);
        }
    }
}