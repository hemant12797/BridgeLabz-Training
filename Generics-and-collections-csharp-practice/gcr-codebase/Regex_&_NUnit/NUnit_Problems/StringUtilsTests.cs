using NUnit.Framework;

class StringUtils {
 public string Reverse(string s)=>new string(s.ToCharArray().Reverse().ToArray());
 public bool IsPalindrome(string s)=>s==Reverse(s);
 public string ToUpperCase(string s)=>s.ToUpper();
}

[TestFixture]
class StringUtilsTests {
 StringUtils u=new StringUtils();

 [Test] public void ReverseTest(){ Assert.AreEqual("cba",u.Reverse("abc")); }
 [Test] public void PalindromeTest(){ Assert.IsTrue(u.IsPalindrome("madam")); }
 [Test] public void UpperTest(){ Assert.AreEqual("HELLO",u.ToUpperCase("hello")); }
}