using System;
using FluentAssertions;
using SquareCalculator.Figures;
using Xunit;

namespace SquareCalculator.Tests
{
    public class CircleTests
    {
        [Fact]
        private void CircleFigure_CorrectRadius_ShouldCalculateSqure()
        {
            var radius = 10d;

            var circle = new CircleFigure(radius);

            circle.Radius.Should().Be(radius);

            circle.GetSquare().Should().Be(Math.PI * Math.Pow(radius, 2));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(double.Epsilon)]
        private void CircleFigure_IncorrectRadius_ShouldThrow(double radius)
        {
            var action = () => new CircleFigure(radius);

            action.Should().Throw<ArgumentException>();
        }
    }
}