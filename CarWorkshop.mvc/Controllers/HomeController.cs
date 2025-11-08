using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.mvc.Models;

namespace CarWorkshop.mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person() { FirstName = "John", LastName = "Doe" },
            new Person() { FirstName = "Jane", LastName = "Smith" },
            new Person() { FirstName = "Michael", LastName = "Johnson" }
        };
        
        
        return View(model);
    }
    
    public IActionResult About()
    {
        var model = new About()
        {
            Title = "About Car Workshop",
            Description = "This is a car workshop management application.",
            Tags = new[] { "Cars", "Workshop", "Management", "Service" }
        };
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
