using FigureSquareCalc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquareCalcTests
{
    class TiangleTests
    {
		[TestCase(-1, 1, 1)]
		[TestCase(1, -1, 1)]
		[TestCase(1, 1, -1)]
		[TestCase(0, 0, 0)]
		public void InitTriangleWithErrorTest(double a, double b, double c)
		{
			Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
		}

		[Test]
		public void InitTriangleTest()
		{
			// Data.
			double a = 5d, b = 6d, c = 7d;

			// Act.
			var triangle = new Triangle(a, b, c);

			// Assert.
			Assert.NotNull(triangle);
			Assert.Less(Math.Abs(triangle.SideA - a), Constants.CalculationAccuracy);
			Assert.Less(Math.Abs(triangle.SideB - b), Constants.CalculationAccuracy);
			Assert.Less(Math.Abs(triangle.SideC - c), Constants.CalculationAccuracy);
		}

		[Test]
		public void GetSquareTest()
		{
			// Data.
			double a = 3d, b = 4d, c = 5d;
			double result = 6d;
			var triangle = new Triangle(a, b, c);

			// Act.
			var square = triangle?.GetFigureSquare();

			// Assert.
			Assert.NotNull(square);
			Assert.Less(Math.Abs(square.Value - result), Constants.CalculationAccuracy);
		}

		[Test]
		public void IsNotTriangleTest()
		{
			Assert.Catch<ArgumentException>(() => new Triangle(1, 1, 4));
		}

		
		[TestCase(3, 4, 5 + 2e-7, ExpectedResult = false)]
		[TestCase(3, 4, 5.000000001, ExpectedResult = true)]
		public bool NotRightTriangle(double a, double b, double c)
		{
			// Data.
			var triangle = new Triangle(a, b, c);

			// Act.
			var isRight = triangle.IsRightTriangle;

			// Assert. 
			return isRight;
		}
	}
}
