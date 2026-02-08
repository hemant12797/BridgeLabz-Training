using NUnit.Framework;
using StringTesting;
namespace StringNUnit.Tests
{
    public class StringNUnitTesting
    {
        private StringUtils utils;

        [SetUp]
        public void Init()
        {
            utils = new StringUtils();
        }

        [Test]
        public void Reverse_Works()
        {
            Assert.That(utils.Reverse("abc"), Is.EqualTo("cba"));
        }

        [Test]
        public void IsPalindrome_TrueCase()
        {
            Assert.That(utils.IsPalindrome("level"), Is.True);
        }

        [Test]
        public void IsPalindrome_FalseCase()
        {
            Assert.That(utils.IsPalindrome("hello"), Is.False);
        }

        [Test]
        public void ToUpperCase_Works()
        {
            Assert.That(utils.ToUpperCase("test"), Is.EqualTo("TEST"));
        }
    }
}