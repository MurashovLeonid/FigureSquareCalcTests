using FigureSquareCalc;
using NUnit.Framework;
using System;

namespace FigureSquareCalcTests
{
    public class CircleTests
    {
        private double minvalue = 1e-7;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroRadiusTest()
        {
            Assert.Catch<System.ArgumentException>(() => new Circle(0d));
        }
        [Test]
        public void NegativeRadiusTest()
        {
            Assert.Catch<System.ArgumentException>(() => new Circle(-1d));
        }

        [Test]
        public void GetSquareTest()
        {
            
            var radius = 10;
            var circle = new Circle(radius);
            var expectedValue = Math.PI * Math.Pow(radius, 2d);

            var square = circle.GetFigureSquare();

            Assert.Less(Math.Abs(square - expectedValue), minvalue);
        }
    }
}