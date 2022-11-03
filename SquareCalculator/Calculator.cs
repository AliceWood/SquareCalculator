using SquareCalculator.Figures;

namespace SquareCalculator
{
    public static class Calculator // this was added in case user didnt want to create figure by themselves, as it wasnt clear from task for me.
    {
        public static double GetCircleSquare(double radius)
        {
            var circle = new CircleFigure(radius);

            return circle.GetSquare();
        }

        public static double GetTriangleSquare(double firstSide, double secondSide, double thirdSide)
        {
            var triangle = new TriangleFigure(firstSide, secondSide, thirdSide);

            return triangle.GetSquare();
        }

        public static bool IsRightTriangle(double firstSide, double secondSide, double thirdSide)
        {
            var triangle = new TriangleFigure(firstSide, secondSide, thirdSide);

            return triangle.IsRightTriangle;
        }
    }
}