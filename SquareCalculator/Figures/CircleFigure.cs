using System;
using SquareCalculator.Interfaces;

namespace SquareCalculator.Figures
{
    public class CircleFigure : IFigure
    {
        public double Radius { get; }

        private readonly double _square;

        public CircleFigure(double radius)
        {
            if (radius < double.Epsilon)
                throw new ArgumentException($"Radius cannot be 0 or less then 0. Specified radius : {radius}", nameof(radius));

            Radius = radius;

            _square = Math.PI * Math.Pow(Radius, 2);
        }

        public double GetSquare()
        {
            return _square;
        }
    }
}