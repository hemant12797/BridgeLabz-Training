using NUnit.Framework;
using System.Text.RegularExpressions;

class PasswordValidator {
 public bool IsValid(string p){
  return p.Length>=8 &&
   Regex.IsMatch(p,"[A-Z]") &&
   Regex.IsMatch(p,"\\d");
 }
}

[TestFixture]
class PasswordTests {
 PasswordValidator v=new PasswordValidator();

 [Test] public void Valid(){ Assert.IsTrue(v.IsValid("Test1234")); }
 [Test] public void Invalid(){ Assert.IsFalse(v.IsValid("test")); }
}