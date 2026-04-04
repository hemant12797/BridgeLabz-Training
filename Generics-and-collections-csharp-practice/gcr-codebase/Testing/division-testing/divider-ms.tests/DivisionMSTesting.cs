using Microsoft.VisualStudio.TestTools.UnitTesting;
using DivisionTesting;

namespace DividerMS.Tests
{
    [TestClass]
    public sealed class DivisionMSTesting
    {
        private Divider divider;

        [TestInitialize]
        public void Init()
        {
            divider = new Divider();
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            try
            {
                divider.Divide(10, 0);
                Assert.Fail();
            }
            catch (ArithmeticException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
