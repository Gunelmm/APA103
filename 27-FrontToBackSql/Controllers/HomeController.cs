using _27_FrontToBackSql.Data;
using _27_FrontToBackSql.Models;
using _27_FrontToBackSql.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSql.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders
            .OrderBy(p => p.Order)
            .Where(p=>!p.IsDeleted)
            .Take(2)
            .ToListAsync();
        
        List<Product> products = await _context.Products
            .Where(p => !p.IsDeleted)
            .Include(p => p.ProductImages.Where(p=>p.IsPrimary != null))
            .ToListAsync();

        HomeVM homeVM = new HomeVM()
        {
            Sliders = sliders,
            Products = products
        };
        return View(homeVM);
    }
}
