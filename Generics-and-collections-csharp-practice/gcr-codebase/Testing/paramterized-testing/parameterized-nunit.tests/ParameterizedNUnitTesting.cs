using ParameterizedTesting;
using NUnit.Framework;

namespace ParameterizedNUnit.Tests
{
    public class Tests
    {
        private NumberUtils utils;

        [SetUp]
        public void Init()
        {
            utils = new NumberUtils();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_WorksForMultipleValues(int input, bool expected)
        {
            bool result = utils.IsEven(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}