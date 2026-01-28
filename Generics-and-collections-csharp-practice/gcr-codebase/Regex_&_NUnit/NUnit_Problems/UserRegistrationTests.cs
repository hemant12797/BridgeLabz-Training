using NUnit.Framework;
using System;

class UserRegistration {
 public void RegisterUser(string u,string e,string p){
  if(string.IsNullOrEmpty(u)||string.IsNullOrEmpty(e)||string.IsNullOrEmpty(p))
   throw new ArgumentException();
 }
}

[TestFixture]
class UserTests {
 [Test]
 public void InvalidUser(){
  Assert.Throws<ArgumentException>(()=>new UserRegistration().RegisterUser("","a@b.com","123"));
 }
}