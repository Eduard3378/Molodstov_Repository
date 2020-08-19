using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureSquare;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;


namespace FiguresForTheBox.FigureSquare.Tests
{
    /// <summary>
    /// Class FilmSquareBuilderTests
    /// </summary>
    [TestClass()]
    public class FilmSquareBuilderTests
    {
        /// <summary>
        /// Method FilmSquare_Name_CreateObject()
        /// </summary>
        [TestMethod()]
        public void FilmSquare_Name_CreateObject()
        {
            // Arange               
            FigureBuilder squareBuilder2 = new FilmSquareBuilder("SquareFilm", Color.Colorless);
            Figures squareFigure3 = squareBuilder2.Create(12.0);
            // Assert            
            Assert.IsNotNull(squareFigure3);
        }
        /// <summary>
        /// Method  FilmSquare_Color_CreateObject()
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FilmSquare_Color_CreateObject()
        {
            //Arange
            FigureBuilder squareBuilder3 = new FilmSquareBuilder("SquareFilm", Color.ImpToPoint);
            Figures squareFigure4 = squareBuilder3.Create(14.0);
        }
        /// <summary>
        /// Method FilmSquare_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FilmSquare_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 5.0 };
            double[] thesize2 = { 6.0 };
            FilmSquareBuilder squareBuilder4 = new FilmSquareBuilder(thesize1, thesize2);
        }
        /// <summary>
        /// Method Create_Thesize1_CreateObject()
        /// </summary>
        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 7.0 };
            FilmSquareBuilder squareFigure7 = new FilmSquareBuilder("SquareFilm", Color.Colorless);
            SquareFigure squareFigure6 = new SquareFigure(v, "Colorless");
            //Act
            var result = squareFigure7.Create(v);
            // Assert 
            result.Should().Equals(squareFigure6);
        }
    }
}