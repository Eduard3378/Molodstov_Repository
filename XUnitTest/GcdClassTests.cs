using GcdCalculationsLib;
using FluentAssertions;
using Xunit;

namespace XUnitTest
{
    public class GcdClassTests
    {
        [Theory]       
        [InlineData(75, 625, 25)]
        [InlineData(665, 1029, 7)]
        public void FindGcdMod_75and625_25(int a, int b, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcd(a, b);
            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(11, 7, 1)]
        [InlineData(15, 25, 5)]       
        public void FindGcdStev_11and7_1(int a, int b, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcdStev(a, b);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]       
        
        [InlineData(7, 5, 9, 1)]
        [InlineData(15, 25, 35, 5)]
        public void FindGcdMod_7and5and9_1(int a, int b, int d, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcd(a, b, d);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(11, 13, 15, 1)]        
        [InlineData(50, 625, 75, 25)]
        public void FindGcdStev_11and13and15_1(int a, int b, int d, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcdStev(a, b, d);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 7, 9, 11, 1)]
        [InlineData(5, 25, 30, 75, 5)]        
        public void FindGcdMod_5and7and9and11_1(int a, int b, int d, int e, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcd(a, b, d, e);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(11, 13, 15, 17, 1)]        
        [InlineData(125, 100, 75, 50, 25)]
        public void FindGcdStev_11and13and15and17_1(int a, int b, int d, int e, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcdStev(a, b, d, e);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(9, 11, 13, 15, 17, 1)]
        [InlineData(5, 25, 30, 45, 75, 5)]        
        public void FindGcdMod_9and11and13and15and17_1(int a, int b, int d, int e, int j, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcd(a, b, d, e, j);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(9, 11, 13, 15, 17, 1)]
        [InlineData(5, 25, 30, 45, 75, 5)]       
        public void FindGcdStev_9and11and13and15and17_1(int a, int b, int d, int e, int j, int expected)
        {
            // Arange 
            //  int expected
            //Act
            var result = GcdClass.FindGcdStev(a, b, d, e, j);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1995, 2156)]
        [InlineData(130, 728)]
        public void FindGcdMod_FindGcdStev_Difference(int a, int b)
        {
            // Arange                        
            double time;
            double timeBinary;

            // Act
            var gcd = GcdClass.FindGcd(a, b, out time);
            var gcdBiinary = GcdClass.FindGcdStev(a, b, out timeBinary);

            // Assert
            gcd.Should().Be(gcdBiinary);
            time.Should().NotBe(timeBinary);
        }
    }
}
