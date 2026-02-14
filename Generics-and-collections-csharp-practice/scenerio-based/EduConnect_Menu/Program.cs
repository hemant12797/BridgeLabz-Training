
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EduConnect
{
    class Program
    {
        static string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,6}$";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1. Register Email");
                Console.WriteLine("2. Exit");
                Console.Write("Choose option: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter Email: ");
                    var email = Console.ReadLine();

                    try
                    {
                        if (Regex.IsMatch(email ?? "", regex))
                        {
                            File.AppendAllText("valid_emails.txt", email + Environment.NewLine);
                            Console.WriteLine("Valid Email Registered.");
                        }
                        else
                        {
                            File.AppendAllText("invalid_emails.txt", email + Environment.NewLine);
                            Console.WriteLine("Invalid Email.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else if (choice == "2")
                {
                    break;
                }
            }
        }
    }
}