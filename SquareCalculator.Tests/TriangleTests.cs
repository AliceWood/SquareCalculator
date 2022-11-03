using System;
using FluentAssertions;
using SquareCalculator.Figures;
using Xunit;

namespace SquareCalculator.Tests
{
    public class TriangleTests
    {
        [Fact]
        private void TriangleFigure_CorrectDataRightTriangle_ShouldContainExpectedData()
        {
            var firstSide = 15;
            var secondSide = 8;
            var thirdSide = 17;

            var square = CalculateSquare(firstSide, secondSide, thirdSide);

            var triangle = new TriangleFigure(firstSide, secondSide, thirdSide);

            triangle.IsRightTriangle.Should().BeTrue();
            triangle.GetSquare().Should().Be(square);
            triangle.FirstSide .Should().Be(firstSide);
            triangle.SecondSide.Should().Be(secondSide);
            triangle.ThirdSide.Should().Be(thirdSide);
        }

        [Fact]
        private void TriangleFigure_CorrectDataNotRightTriangle_ShouldContainExpectedData()
        {
            var firstSide = 15;
            var secondSide = 8;
            var thirdSide = 15;

            var square = CalculateSquare(firstSide, secondSide, thirdSide);

            var triangle = new TriangleFigure(firstSide, secondSide, thirdSide);

            triangle.IsRightTriangle.Should().BeFalse();
            triangle.GetSquare().Should().Be(square);
            triangle.FirstSide.Should().Be(firstSide);
            triangle.SecondSide.Should().Be(secondSide);
            triangle.ThirdSide.Should().Be(thirdSide);
        }

        [Fact]
        private void TriangleFigure_IncorrectData_ShouldThrow()
        {
            var firstSide = 15;
            var secondSide = 8;
            var thirdSide = 30;

            var triangle = () => new TriangleFigure(firstSide, secondSide, thirdSide);

            triangle.Should().Throw<ArgumentException>();
        }

        private double CalculateSquare(double firstSide, double secondSide, double thirdSide)
        {
            var halfPerimeter = (firstSide + secondSide + thirdSide) / 2;

            return Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - firstSide) *
                (halfPerimeter - secondSide) *
                (halfPerimeter - thirdSide));
        }
    }
}