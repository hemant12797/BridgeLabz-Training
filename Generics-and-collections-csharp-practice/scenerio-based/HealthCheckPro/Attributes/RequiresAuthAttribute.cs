using System;

namespace HealthCheckPro.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequiresAuthAttribute : Attribute
    {
        public string Role { get; set; } = string.Empty;

        public RequiresAuthAttribute() { }

        public RequiresAuthAttribute(string role)
        {
            Role = role;
        }
    }
}
