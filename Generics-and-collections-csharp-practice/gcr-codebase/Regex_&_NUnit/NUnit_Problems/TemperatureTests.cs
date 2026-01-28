using NUnit.Framework;

class TemperatureConverter {
 public double CtoF(double c)=>c*9/5+32;
 public double FtoC(double f)=>(f-32)*5/9;
}

[TestFixture]
class TempTests {
 [Test] public void CtoFTest(){ Assert.AreEqual(32,new TemperatureConverter().CtoF(0)); }
}