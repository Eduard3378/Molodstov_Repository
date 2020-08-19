using FiguresForTheBox;
using FiguresForTheBox.FigureCircle;
using System;
using FluentAssertions;
using Xunit;
using FiguresForTheBox.FigureRectangle;

namespace FigureForTheBox.XUnitTest
{
    /// <summary>
    /// Class BoxTests
    /// </summary>
    public class BoxTests
    {       
        static FigureBuilder circleBuilder1 = new PaperCircleBuilder("Circle", Color.Black);
        static Figures circleFigure2 = circleBuilder1.Create(7.0);
        static FigureBuilder circleBuilder2 = new PaperCircleBuilder("Circle", Color.Green);
        static Figures circleFigure3 = circleBuilder2.Create(8.0);
        static FigureBuilder circleBuilder3 = new PaperCircleBuilder("Circle", Color.Blue);
        static Figures circleFigure4 = circleBuilder3.Create(9.0);        

        static Figures[] box1 = Box.Figures1(circleFigure2, circleFigure3, circleFigure4, null);     
        Figures[] expected = Box.AddShape(box1);
        /// <summary>
        /// Method AddShapeTest_Box_Box()
        /// </summary>
        [Fact]
        public void AddShapeTest_Box_Box()
        {                        
            //Act
            var result = Box.AddShape(box1);            
            // Assert
            result.Should().Equal(expected);
        }
        /// <summary>
        /// Method ViewByNumber_Box_FigureInstance()
        /// </summary>
        [Fact]
        public void ViewByNumber_Box_FigureInstance()
        {            
            //Act
            Box.ViewByNumber(box1);           
        }
        /// <summary>
        /// Method ExtractByNumber_Box_FigureInstance()
        /// </summary>
        [Fact]
        public void ExtractByNumber_Box_FigureInstance()
        {
            //Act
            Box.ExtractByNumber(box1);
        }
        /// <summary>
        /// Method ReplaceByNumber_Box_FigureInstance()
        /// </summary>
        [Fact]
        public void ReplaceByNumber_Box_FigureInstance()
        {
            //Act
            Box.ReplaceByNumber(box1);
        }
        /// <summary>
        /// Method FindShapeByPattern_Box_FigureInstance()
        /// </summary>
        [Fact]
        public void FindShapeByPattern_Box_FigureInstance()
        {
            //Act
            Box.FindShapeByPattern(box1);
        }
        /// <summary>
        /// Method AvailableNumberFigures_Box_P()
        /// </summary>
        [Fact]
        public void AvailableNumberFigures_Box_P()
        {
            //Act
            Box.AvailableNumberFigures(box1);
        }
        /// <summary>
        /// Method TotalArea_Box_SumArea()
        /// </summary>
        [Fact]
        public void TotalArea_Box_SumArea()
        {            
            //Act
            Box.TotalArea(box1);
        }
        /// <summary>
        /// Method TotalPerimeter_Box_SumPerim()
        /// </summary>
        [Fact]
        public void TotalPerimeter_Box_SumPerim()
        {
            //Act
            Box.TotalPerimeter(box1);
        }
        /// <summary>
        /// Method GetAllCircles_Box_FigureInstance()
        /// </summary>
        [Fact]
        public void GetAllCircles_Box_FigureInstance()
        {
            //Act
            Box.GetAllCircles(box1);
        }
    }
}

    

