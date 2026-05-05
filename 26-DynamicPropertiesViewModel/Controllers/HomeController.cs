using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModel.Controllers;

public class HomeController : Controller
{
    List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "Harry Potter", Age = 16 },
        new Student { Id = 2, Name = "Hermione Granger", Age = 16},
        new Student { Id = 3, Name = "Ron Uizli",  Age = 16 },
    };

    private List<Teacher> teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Name = "Severus Sneyp", Salary = 5000},
        new Teacher { Id = 2, Name = "Albus Dambldor", Salary = 10000},
    };
    
    public IActionResult Index()
    {
        ViewBag.Students = students;
        ViewData["Students"] = students;
        TempData["Name"] = "Harry Potter";

        HomeVM homeVM = new()
        {
            Teachers = teachers,
            Students = students
        };
        
        return View(homeVM);
    }

    public IActionResult Detail(int id)
    {
        return View(students[id]);
    }
    
    [Route("korporativ-satislar")]
    public IActionResult CorporativeSales()
    {
        return View();
    }
}