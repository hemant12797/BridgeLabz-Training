using HealthCheckPro.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HealthCheckPro
{
    public class HealthCheckScanner
    {
        public void ScanAndValidate()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var controllerTypes = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.Namespace.Contains("Controllers") && t.IsClass);

            var missingAnnotations = new List<string>();
            var apiDocs = new List<string>();

            foreach (var controllerType in controllerTypes)
            {
                var methods = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (var method in methods)
                {
                    var hasPublicAPI = method.GetCustomAttribute<PublicAPIAttribute>() != null;
                    var hasRequiresAuth = method.GetCustomAttribute<RequiresAuthAttribute>() != null;

                    if (!hasPublicAPI && !hasRequiresAuth)
                    {
                        missingAnnotations.Add($"{controllerType.Name}.{method.Name}");
                    }

                    if (hasPublicAPI)
                    {
                        var attr = method.GetCustomAttribute<PublicAPIAttribute>();
                        apiDocs.Add($"Public API: {controllerType.Name}.{method.Name} - {attr.Description}");
                    }

                    if (hasRequiresAuth)
                    {
                        var attr = method.GetCustomAttribute<RequiresAuthAttribute>();
                        apiDocs.Add($"Requires Auth: {controllerType.Name}.{method.Name} - Role: {attr.Role}");
                    }
                }
            }

            Console.WriteLine("=== API Metadata Validation Report ===");
            Console.WriteLine("\nMissing Annotations:");
            if (missingAnnotations.Any())
            {
                foreach (var item in missingAnnotations)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("\nAuto-Generated API Documentation:");
            foreach (var doc in apiDocs)
            {
                Console.WriteLine($"- {doc}");
            }
        }
    }
}
