using NUnit.Framework;

class BankAccount {
 double bal;
 public void Deposit(double a)=>bal+=a;
 public bool Withdraw(double a){
  if(a>bal) return false;
  bal-=a; return true;
 }
 public double GetBalance()=>bal;
}

[TestFixture]
class BankTests {
 BankAccount b;

 [SetUp] public void Init(){ b=new BankAccount(); }

 [Test]
 public void DepositTest(){
  b.Deposit(100);
  Assert.AreEqual(100,b.GetBalance());
 }

 [Test]
 public void WithdrawFail(){
  Assert.IsFalse(b.Withdraw(50));
 }
}