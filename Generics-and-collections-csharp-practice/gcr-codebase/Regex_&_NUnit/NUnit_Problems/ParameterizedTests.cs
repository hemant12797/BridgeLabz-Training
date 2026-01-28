using NUnit.Framework;

class NumberUtils {
 public bool IsEven(int n)=>n%2==0;
}

[TestFixture]
class EvenTests {
 NumberUtils n=new NumberUtils();

 [TestCase(2,true)]
 [TestCase(4,true)]
 [TestCase(7,false)]
 public void EvenCheck(int v,bool e){
  Assert.AreEqual(e,n.IsEven(v));
 }
}