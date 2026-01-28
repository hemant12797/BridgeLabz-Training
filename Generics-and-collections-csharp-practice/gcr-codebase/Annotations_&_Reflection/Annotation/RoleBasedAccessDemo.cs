using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
class RoleAllowedAttribute : Attribute
{
    public string Role;
    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

[RoleAllowed("ADMIN")]
class AdminService
{
    public void DeleteData()
    {
        Console.WriteLine("Data Deleted");
    }
}

class RoleBasedAccessDemo
{
    static void Main()
    {
        string currentRole = "USER";

        var attr = (RoleAllowedAttribute)Attribute.GetCustomAttribute(typeof(AdminService), typeof(RoleAllowedAttribute));

        if (attr.Role == currentRole)
            new AdminService().DeleteData();
        else
            Console.WriteLine("Access Denied!");
    }
}