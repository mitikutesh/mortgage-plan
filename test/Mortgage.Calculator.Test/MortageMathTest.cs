using NUnit.Framework;

namespace Mortgage.Calculator.Test
{
    [TestFixture]
    public class MortageMathTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Power_Of_Integer_should_Work()
        {
            var result = MortgageMath.Power(2, 2);
            Assert.AreEqual(4, result);
        }

        [Test]
        [TestCase(1000, 5, 2, 43.87)]
        [TestCase(4356, 1.27, 6, 62.87)]
        [TestCase(1300.55, 8.67, 2, 59.22)]
        [TestCase(2000, 6, 4, 46.97)]
        public void Fixed_Monthly_Payment_should_Work(decimal totalLoan, decimal interest, int years, decimal expected)
        {
            var result = MortgageMath.FixedMonthlyPayment(totalLoan, interest, years);
            Assert.AreEqual(expected, result);
        }
    }
}