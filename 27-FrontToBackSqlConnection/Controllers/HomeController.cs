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
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _dbContext.Sliders
            .OrderBy(s=>s.Order)
            .Where(s=>!s.IsDeleted)
            .Take(2)
            .ToListAsync();
        
        List<Product> products = await _dbContext.Products
            .Where(p=>!p.IsDeleted)
            .Include(p => p.ProductImages.Where(pi=> pi.IsPrimary != null))
            .ToListAsync();
        
        HomeVM homeVM = new()
            {Sliders = sliders, Products = products };
        return View(homeVM);
    }
}
