using _27_FrontToBackSql.Data;
using _27_FrontToBackSql.Models;
using _27_FrontToBackSql.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSql.Controllers;

public class ShopController : Controller
{
    public readonly AppDbContext _context;
    public ShopController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        List<Product> products = await _context.Products
            .Where(p=>!p.IsDeleted)
            .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary!=null))
            .ToListAsync();
        ShopVM shopVm = new ShopVM()
        {
            Products = products
        };
        return View(shopVm);
    }

    public IActionResult Details(int? id)
    {
        if (id == null || id < 1) return BadRequest();
        
        Product? product =  _context.Products
            .Where(p => !p.IsDeleted)
            .Include(p=>p.ProductImages)
            .Include(p => p.Category)
            .Include(p=>p.ProductTags)
            .ThenInclude(p=>p.Tag)
            .FirstOrDefault(p=>p.Id == id);
        
        List<Product> relatedProducts = _context.Products
            .Where(p=>!p.IsDeleted)
            .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary!=null))
            .Where(p => p.CategoryId == product.CategoryId && p.Id != id)
            .Take(4)
            .ToList();
        
        if (product == null) return NotFound();

        DetailsVM detailsVm = new DetailsVM()
        {
            Product = product
        };
        
        return View(detailsVm);
    }
}