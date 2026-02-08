using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParameterizedTesting;

namespace ParameterizedMS.Tests
{
    [TestClass]
    public sealed class ParameterizedMSTesting
    {
        private NumberUtils utils;

        [TestInitialize]
        public void Init()
        {
            utils = new NumberUtils();
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_WorksForMultipleValues(int input, bool expected)
        {
            bool result = utils.IsEven(input);
            Assert.AreEqual(expected, result);
        }
    }
}
