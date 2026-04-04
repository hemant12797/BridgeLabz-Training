using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTesting;

namespace StringMS.Tests
{
    [TestClass]
    public sealed class StringMSTesting
    {
        private StringUtils utils;

        [TestInitialize]
        public void Init()
        {
            utils = new StringUtils();
        }

        [TestMethod]
        public void Reverse_Works()
        {
            Assert.AreEqual("cba", utils.Reverse("abc"));
        }

        [TestMethod]
        public void IsPalindrome_TrueCase()
        {
            Assert.IsTrue(utils.IsPalindrome("level"));
        }

        [TestMethod]
        public void IsPalindrome_FalseCase()
        {
            Assert.IsFalse(utils.IsPalindrome("hello"));
        }

        [TestMethod]
        public void ToUpperCase_Works()
        {
            Assert.AreEqual("TEST", utils.ToUpperCase("test"));
        }
    }
}
