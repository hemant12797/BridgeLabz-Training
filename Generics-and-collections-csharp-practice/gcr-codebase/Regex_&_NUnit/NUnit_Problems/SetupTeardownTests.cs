using NUnit.Framework;

class DatabaseConnection {
 public bool Connected;
 public void Connect(){ Connected=true; }
 public void Disconnect(){ Connected=false; }
}

[TestFixture]
class DbTests {
 DatabaseConnection db;

 [SetUp] public void Open(){ db=new DatabaseConnection(); db.Connect(); }
 [TearDown] public void Close(){ db.Disconnect(); }

 [Test] public void ConnectionTest(){
  Assert.IsTrue(db.Connected);
 }
}