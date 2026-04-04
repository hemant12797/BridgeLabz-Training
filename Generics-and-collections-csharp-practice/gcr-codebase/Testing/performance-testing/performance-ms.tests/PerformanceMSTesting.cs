using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTesting;

namespace PerformanceMS.Tests
{
    [TestClass]
    public sealed class PerformanceMSTesting
    {
        private PerformanceTestingUtil worker;

        [TestInitialize]
        public void Init()
        {
            worker = new PerformanceTestingUtil();
        }

        [TestMethod]
        [Timeout(2000)]
        public void LongRunningTask_ExceedsTimeout()
        {
            worker.LongRunningTask();
        }
    }
}
