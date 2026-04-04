using System;

namespace HealthCheckPro.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PublicAPIAttribute : Attribute
    {
        public string Description { get; set; } = string.Empty;

        public PublicAPIAttribute() { }

        public PublicAPIAttribute(string description)
        {
            Description = description;
        }
    }
}
