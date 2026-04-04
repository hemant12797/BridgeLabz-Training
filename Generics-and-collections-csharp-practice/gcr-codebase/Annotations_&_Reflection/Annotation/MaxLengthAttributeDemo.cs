using System;

[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Length;
    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

class User
{
    [MaxLength(8)]
    public string Username;

    public User(string username)
    {
        if (username.Length > 8)
            throw new ArgumentException("Username too long");
        Username = username;
    }
}

class MaxLengthAttributeDemo
{
    static void Main()
    {
        User u = new User("Ashish");
        Console.WriteLine(u.Username);
    }
}