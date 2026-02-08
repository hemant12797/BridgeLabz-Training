using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListManagerTesting;
using System.Collections.Generic;

namespace ListManagerMS.Tests
{
    [TestClass]
    public class ListManagerMSTests
    {
        private ListManager manager;
        private List<int> numbers;

        [TestInitialize]
        public void Init()
        {
            manager = new ListManager();
            numbers = new List<int>();
        }

        [TestMethod]
        public void AddElement_AddsItem()
        {
            manager.AddElement(numbers, 10);
            Assert.IsTrue(numbers.Contains(10));
        }

        [TestMethod]
        public void RemoveElement_RemovesItem()
        {
            numbers.Add(5);
            manager.RemoveElement(numbers, 5);
            Assert.IsFalse(numbers.Contains(5));
        }

        [TestMethod]
        public void GetSize_ReturnsCorrectCount()
        {
            manager.AddElement(numbers, 1);
            manager.AddElement(numbers, 2);
            Assert.AreEqual(2, manager.GetSize(numbers));
        }
    }
}
