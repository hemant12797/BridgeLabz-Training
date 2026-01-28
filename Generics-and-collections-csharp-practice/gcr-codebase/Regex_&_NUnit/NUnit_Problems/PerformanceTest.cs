using NUnit.Framework;
using System.Threading;

class Performance {
 public void LongRunningTask(){ Thread.Sleep(3000); }
}

[TestFixture]
class TimeoutTest {
 [Test, Timeout(2000)]
 public void PerformanceFail(){
  new Performance().LongRunningTask();
 }
}