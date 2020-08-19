using System;
using FiguresForTheBox;
using FiguresForTheBox.FigureCircle;
using FluentAssertions;
using Xunit;
using FiguresForTheBox.FigureRectangle;

namespace FigureForTheBox.XUnitTest
{
    /// <summary>
    /// Class ReadTheXmlReaderTests
    /// </summary>
    public class ReadTheXmlReaderTests
    {
        Figures[] box = new Figures[20];
        /// <summary>
        /// Method ReadTheXmlReader1_File_Box()
        /// </summary>
        [Fact]
        public void ReadTheXmlReader1_File_Box()
        {
            //Act
            box = ReadTheStreamReader.ReadTheStreamReader1();
        }
    }
}
