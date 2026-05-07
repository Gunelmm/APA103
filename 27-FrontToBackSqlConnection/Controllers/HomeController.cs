using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _dbContext;

    public HomeController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    List<Slider> sliders = new List<Slider>
    {
        new Slider{Id = 1, Title =  "Slider 1", Subtitle = "Subtitle 1", Description = "Description 1", Image = "1-1-524x617.png", Order = 3, IsDeleted = false},
        new Slider{Id = 2, Title = "Slider 2",  Subtitle = "Subtitle 2", Description = "Description 2", Image = "1-2-524x617.png", Order = 2, IsDeleted = true},
        new Slider{Id = 3, Title = "Slider 3",   Subtitle = "Subtitle 3",  Description = "Description 3", Image = "blueRose.jpg", Order = 1, IsDeleted = false},
    };
    public IActionResult Index()
    {
        HomeVM homeVM = new()
            {Sliders = sliders.OrderBy(s=>s.Order).Where(s=>!s.IsDeleted).Take(2).ToList()};
        return View(homeVM);
    }
}
