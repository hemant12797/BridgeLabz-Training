using DivisionTesting;
using NUnit.Framework;
namespace DividerNUnit.Tests
{
    public class Tests
    {
        private Divider divider;

        [SetUp]
        public void Init()
        {
            divider = new Divider();
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            try
            {
                divider.Divide(10, 0);
                Assert.Fail();
            }
            catch (ArithmeticException)
            {
                Assert.Pass();
            }
        }
    }
}