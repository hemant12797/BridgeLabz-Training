using NUnit.Framework;
using System.IO;

class FileProcessor {
 public void WriteToFile(string f,string c)=>File.WriteAllText(f,c);
 public string ReadFromFile(string f)=>File.ReadAllText(f);
}

[TestFixture]
class FileTests {
 string file="test.txt";
 FileProcessor fp=new FileProcessor();

 [Test]
 public void FileReadWrite(){
  fp.WriteToFile(file,"hello");
  Assert.IsTrue(File.Exists(file));
  Assert.AreEqual("hello",fp.ReadFromFile(file));
 }

 [Test]
 public void FileNotFound(){
  Assert.Throws<FileNotFoundException>(()=>fp.ReadFromFile("nofile.txt"));
 }
}