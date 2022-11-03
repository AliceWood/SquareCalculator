using System;
using SquareCalculator.Interfaces;

namespace SquareCalculator.Figures
{
    public class TriangleFigure
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }
        public bool IsRightTriangle { get; }

        private readonly double _square;

        public TriangleFigure(double firstSide, double secondSide, double thirdSide)
        {
            ValidateInputs(firstSide, secondSide, thirdSide);

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            _square = CalculateSquare();

            IsRightTriangle = GetIsRightTriangle();
        }

        public double GetSquare()
        {
            return _square;
        }

        private void ValidateInputs(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide < double.Epsilon)
                throw new ArgumentException($"Side length cannot be 0 or less then 0. Specified length : {firstSide}", nameof(firstSide));
            if (secondSide < double.Epsilon)
                throw new ArgumentException($"Side length cannot be 0 or less then 0. Specified length : {secondSide}", nameof(secondSide));
            if (thirdSide < double.Epsilon)
                throw new ArgumentException($"Side length cannot be 0 or less then 0. Specified length : {thirdSide}", nameof(thirdSide));

            if (firstSide > secondSide + thirdSide ||
                secondSide > firstSide + thirdSide ||
                thirdSide > firstSide + secondSide)
            {
                throw new ArgumentException($"Sum of lengths of any two sides should be greater than the length of the other one. first edge: {firstSide}, second edge: {secondSide}, third edge: {thirdSide}");
            }
        }

        private double CalculateSquare()
        {
            var halfPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

            return Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - FirstSide) *
                (halfPerimeter - SecondSide) *
                (halfPerimeter - ThirdSide));
        }

        private bool GetIsRightTriangle()
        {
            if (FirstSide > SecondSide && FirstSide > ThirdSide)
            {
                return Math.Abs(Math.Pow(FirstSide, 2) - (Math.Pow(SecondSide, 2) + Math.Pow(ThirdSide, 2))) < double.Epsilon;
            }

            if (SecondSide > FirstSide && SecondSide > ThirdSide)
            {
                return Math.Abs(Math.Pow(SecondSide, 2) - (Math.Pow(FirstSide, 2) + Math.Pow(ThirdSide, 2))) < double.Epsilon;
            }

            return Math.Abs(Math.Pow(ThirdSide, 2) - (Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2))) < double.Epsilon;
        }
    }
}