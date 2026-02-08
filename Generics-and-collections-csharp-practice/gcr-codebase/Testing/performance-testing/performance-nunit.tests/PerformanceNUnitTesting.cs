using NUnit.Framework;
using PerformanceTesting;

namespace PerformanceNUnit.Tests
{
    public class PerformanceNUnitTesting
    {
        private PerformanceTestingUtil worker;

        [SetUp]
        public void Init()
        {
            worker = new PerformanceTestingUtil();
        }

        [Test]
        [Timeout(2000)]
        public void LongRunningTask_ExceedsTimeout()
        {
            worker.LongRunningTask();
        }
    }
}