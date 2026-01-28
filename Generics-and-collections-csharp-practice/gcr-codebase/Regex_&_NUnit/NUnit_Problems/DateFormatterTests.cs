using NUnit.Framework;
using System;

class DateFormatter {
 public string FormatDate(string d){
  return DateTime.Parse(d).ToString("dd-MM-yyyy");
 }
}

[TestFixture]
class DateTests {
 [Test]
 public void ValidDate(){
  Assert.AreEqual("31-12-2023",new DateFormatter().FormatDate("2023-12-31"));
 }
}