using FiguresForTheBox;
using FiguresForTheBox.FigureCircle;
using System;
using FluentAssertions;
using Xunit;
using FiguresForTheBox.FigureRectangle;

namespace FigureForTheBox.XUnitTest
{
    /// <summary>
    /// Class ReadTheStreamReaderTests
    /// </summary>
    public class ReadTheStreamReaderTests
    {
        Figures[] box2 = new Figures[4];
        /// <summary>
        /// Method ReadTheStreamReader1_File_Box()
        /// </summary>
        [Fact]
        public void ReadTheStreamReader1_File_Box()
        {
            //Act
            box2 = ReadTheStreamReader.ReadTheStreamReader1();
        }
    }
}
