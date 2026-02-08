using CalculatorTesting;

namespace CalculatorNUnit.Tests
{
    public class CalculatorNUnitTests
    {
        private Calculator calc;

        [SetUp]
        public void Init()
        {
            calc = new Calculator();
        }

        [Test]
        public void Add_Works()
        {
            Assert.That(calc.Add(2, 3), Is.EqualTo(5));
        }

        [Test]
        public void Subtract_Works()
        {
            Assert.That(calc.Subtract(5, 3), Is.EqualTo(2));
        }

        [Test]
        public void Multiply_Works()
        {
            Assert.That(calc.Multiply(4, 3), Is.EqualTo(12));
        }

        [Test]
        public void Divide_Works()
        {
            Assert.That(calc.Divide(10, 2), Is.EqualTo(5));
        }

        [Test]
        public void Divide_ByZero_Throws()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Divide(5, 0));
        }
    }
}