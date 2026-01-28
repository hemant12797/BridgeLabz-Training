using NUnit.Framework;
using System.Collections.Generic;

class ListManager {
 public void AddElement(List<int> l,int e)=>l.Add(e);
 public void RemoveElement(List<int> l,int e)=>l.Remove(e);
 public int GetSize(List<int> l)=>l.Count;
}

[TestFixture]
class ListManagerTests {
 List<int> list;
 ListManager m;

 [SetUp] public void Init(){ list=new List<int>(); m=new ListManager(); }

 [Test] public void AddTest(){
  m.AddElement(list,1);
  Assert.AreEqual(1,m.GetSize(list));
 }

 [Test] public void RemoveTest(){
  list.Add(1);
  m.RemoveElement(list,1);
  Assert.AreEqual(0,m.GetSize(list));
 }
}