using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _dbContext;

    public HomeController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        List<Slider> sliders = _dbContext.Sliders
            .OrderBy(s=>s.Order)
            .Where(s=>!s.IsDeleted)
            .Take(2)
            .ToList();
        
        List<Product> products = _dbContext.Products
            .Where(p=>!p.IsDeleted)
            .Include(p => p.ProductImages.Where(pi=> pi.IsPrimary != null))
            .ToList();
        
        HomeVM homeVM = new()
            {Sliders = sliders, Products = products, };
        return View(homeVM);
    }
}
