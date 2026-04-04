using NUnit.Framework;
using System;

class MathOps {
 public int Divide(int a,int b){
  if(b==0) throw new ArithmeticException();
  return a/b;
 }
}

[TestFixture]
class ExceptionTest {
 [Test]
 public void ExceptionThrown(){
  var m=new MathOps();
  Assert.Throws<ArithmeticException>(()=>m.Divide(5,0));
 }
}