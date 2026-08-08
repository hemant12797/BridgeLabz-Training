using System;
using Microsoft.AspNetCore.Mvc;
using GretingsApp.Models;
namespace GretingsApp.Controllers
{
    public class GreetingsController : Controller
    {
        // GET :/Greatings 
        // Show the form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Receive user's input
        [HttpPost]
        public IActionResult Index(Greeting greeting)
        {
            greeting.Message = $"Hello, {greeting.Name}!";

            return View(greeting);
        }
    }    
}