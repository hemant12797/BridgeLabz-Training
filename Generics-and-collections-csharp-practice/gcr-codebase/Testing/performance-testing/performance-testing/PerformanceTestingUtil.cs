using System.Threading;
namespace PerformanceTesting
{
    public class PerformanceTestingUtil
    {
        public int LongRunningTask()
        {
            Thread.Sleep(3000);
            return 1;
        }
    }
}
