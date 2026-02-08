using NUnit.Framework;
using ListManagerTesting;

namespace ListManagerNUnit.Tests
{
    public class ListManagerNUnit
    {
        private ListManager manager;
        private List<int> numbers;

        [SetUp]
        public void Init()
        {
            manager = new ListManager();
            numbers = new List<int>();
        }

        [Test]
        public void AddElement_AddsItem()
        {
            manager.AddElement(numbers, 10);
            Assert.That(numbers.Contains(10), Is.True);
        }

        [Test]
        public void RemoveElement_RemovesItem()
        {
            numbers.Add(5);
            manager.RemoveElement(numbers, 5);
            Assert.That(numbers.Contains(5), Is.False);
        }

        [Test]
        public void GetSize_ReturnsCorrectCount()
        {
            manager.AddElement(numbers, 1);
            manager.AddElement(numbers, 2);
            Assert.That(manager.GetSize(numbers), Is.EqualTo(2));
        }
    }
}