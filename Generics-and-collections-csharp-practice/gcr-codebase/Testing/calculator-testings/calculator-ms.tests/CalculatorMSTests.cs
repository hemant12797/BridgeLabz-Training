using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorTesting;

namespace CalculatorMS.Tests
{
    [TestClass]
    public class CalculatorMSTests
    {
        private Calculator calc;

        [TestInitialize]
        public void Init()
        {
            calc = new Calculator();
        }

        [TestMethod]
        public void Add_Works()
        {
            Assert.AreEqual(5, calc.Add(2, 3));
        }

        [TestMethod]
        public void Subtract_Works()
        {
            Assert.AreEqual(2, calc.Subtract(5, 3));
        }

        [TestMethod]
        public void Multiply_Works()
        {
            Assert.AreEqual(12, calc.Multiply(4, 3));
        }

        [TestMethod]
        public void Divide_Works()
        {
            Assert.AreEqual(5, calc.Divide(10, 2));
        }

        [TestMethod]
        public void Divide_ByZero_Throws()
        {
            try
            {
                calc.Divide(5, 0);
                Assert.Fail("No exception thrown");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
