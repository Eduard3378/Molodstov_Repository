using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresForTheBox.FigureCircle;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FiguresForTheBox.FigureCircle.Tests
{
    [TestClass()]
    public class PaperCircleBuilderTests
    {
        [TestMethod()]
        public void PaperCircleBuilder_Name_CreateObject()
        {
            // Arange               
            FigureBuilder circleBuilder2 = new PaperCircleBuilder("Circle", Color.Green);
            Figures circleFigure3 = circleBuilder2.Create(12.0);
            // Assert            
            Assert.IsNotNull(circleFigure3);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void PaperCircleBuilder_Thesize1_CreateObject()
        {
            //Arange
            double[] thesize1 = { 7.0 };
            double[] thesize2 = { 9.0 };
            PaperCircleBuilder circleBuilder4 = new PaperCircleBuilder(thesize1, thesize2);
        }
        [TestMethod()]
        public void Create_Thesize1_CreateObject()
        {
            //Arange
            double[] v = { 9.0 };
            PaperCircleBuilder circleFigure7 = new PaperCircleBuilder("Circle", Color.Green);
            CircleFigure circleFigure6 = new CircleFigure(v, "Green");
            //Act
            var result = circleFigure7.Create(v);
            // Assert 
            result.Should().Equals(circleFigure6);
        }
    }
}