using System;
using FiguresForTheBox;
using FiguresForTheBox.FigureCircle;
using FluentAssertions;
using Xunit;
using FiguresForTheBox.FigureRectangle;

namespace FigureForTheBox.XUnitTest
{
    /// <summary>
    /// Class SavePaperShapesXmlWriterTests
    /// </summary>
    public class SavePaperShapesXmlWriterTests
    {
        Figures[] box = new Figures[20];
        /// <summary>
        /// Method SavePaperShapesXmlWriter_Box_File()
        /// </summary>
        [Fact]
        public void SavePaperShapesXmlWriter_Box_File()
        {
            box = ReadTheXmlReader.ReadTheXmlReader1();
            Box.AddShape(box);
            FigureBuilder rectangleBuilder2 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure3 = rectangleBuilder2.Create(9.0, 10.0);
            box[4] = rectangleFigure3;
            //Act
            SavePaperShapesXmlWriter.SavePaperShapesXmlWriter1(box);
        }
    }
}
