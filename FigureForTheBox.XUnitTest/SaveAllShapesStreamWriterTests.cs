using System;
using FiguresForTheBox;
using FiguresForTheBox.FigureCircle;
using FluentAssertions;
using Xunit;
using FiguresForTheBox.FigureRectangle;

namespace FigureForTheBox.XUnitTest
{
    /// <summary>
    /// Class SaveAllShapesStreamWriterTests
    /// </summary>
    public class SaveAllShapesStreamWriterTests
    {
        Figures[] box2 = new Figures[4];
        /// <summary>
        /// Method SaveAllShapesStreamWriter_Box_File()
        /// </summary>
        [Fact]
        public void SaveAllShapesStreamWriter_Box_File()
        {           
            box2 = ReadTheStreamReader.ReadTheStreamReader1();
            FigureBuilder rectangleBuilder7 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure8 = rectangleBuilder7.Create(9.0, 10.0);
            box2[3] = rectangleFigure8;
            //Act
            SaveAllShapesStreamWriter.SaveAllShapesStreamWriter1(box2);
        }
    }
}
