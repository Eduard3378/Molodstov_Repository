using System;
using FiguresForTheBox;
using FiguresForTheBox.FigureCircle;
using FluentAssertions;
using Xunit;
using FiguresForTheBox.FigureRectangle;

namespace FigureForTheBox.XUnitTest
{
    /// <summary>
    /// Class SaveAllShapesXmlWriterTests
    /// </summary>
    public class SaveAllShapesXmlWriterTests
    {
        Figures[] box = new Figures[20];
        /// <summary>
        /// Method SaveAllShapesXmlWriter_Box_File()
        /// </summary>
        [Fact]
        public void SaveAllShapesXmlWriter_Box_File()
        {
            box = ReadTheXmlReader.ReadTheXmlReader1();
            Box.AddShape(box);
            FigureBuilder rectangleBuilder2 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure3 = rectangleBuilder2.Create(9.0, 10.0);
            box[4] = rectangleFigure3;                   
            //Act
            SaveAllShapesXmlWriter.SaveAllShapesXmlWriter1(box);
        }
    }
}
