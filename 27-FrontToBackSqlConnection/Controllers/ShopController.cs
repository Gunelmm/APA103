using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers;

public class ShopController : Controller
{
    private readonly AppDbContext _dbContext;
    public ShopController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int? id)
    {
        if (id is null || id < 1)
        {
            return BadRequest();
        }
        Product? product = _dbContext.Products
            .Where(p => !p.IsDeleted)
            .Include(p=>p.ProductImages)
            .Include(p=>p.Category)
            .FirstOrDefault(p=>p.Id == id);
        
        List<Product>? relatedProduct = _dbContext.Products
            .Where(p => !p.IsDeleted)
            .Include(p=>p.ProductImages.Where(pi => pi.IsPrimary != null))
            .Where(p => p.CategoryId == product.CategoryId && p.Id != id)
            .Take(4)
            .ToList();
        
        if (product is null) return NotFound();
        
        DetailsVM detailsVm = new()
        {
            Product = product,
            RelatedProducts = relatedProduct,
        };
        
        return View(detailsVm);
    }
}