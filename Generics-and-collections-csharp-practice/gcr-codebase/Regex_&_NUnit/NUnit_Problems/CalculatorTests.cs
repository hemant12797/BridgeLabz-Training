using NUnit.Framework;
using System;

class Calculator {
 public int Add(int a,int b)=>a+b;
 public int Subtract(int a,int b)=>a-b;
 public int Multiply(int a,int b)=>a*b;
 public int Divide(int a,int b){
  if(b==0) throw new DivideByZeroException();
  return a/b;
 }
}

[TestFixture]
class CalculatorTests {
 Calculator c;
 [SetUp] public void Init(){ c=new Calculator(); }

 [Test] public void AddTest(){ Assert.AreEqual(5,c.Add(2,3)); }
 [Test] public void SubTest(){ Assert.AreEqual(1,c.Subtract(3,2)); }
 [Test] public void MulTest(){ Assert.AreEqual(6,c.Multiply(2,3)); }
 [Test] public void DivTest(){ Assert.AreEqual(2,c.Divide(4,2)); }
 [Test] public void DivByZero(){ Assert.Throws<DivideByZeroException>(()=>c.Divide(4,0)); }
}