using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Test]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedLessThanOrEqualsSpeedLimit_ReturnZero(int speed, int expectedResult)
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedHigherThanSpeedLimit_ReturnDemeritPoints()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(70);
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
