using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers;
[Area("AdminPanel")]
public class CategoryController : Controller
{
    private readonly AppDbContext _dbContext;
    public CategoryController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        List<Category> categories = await _dbContext.Categories.Include(c=>c.Products).Where(c => !c.IsDeleted).ToListAsync();
        
        return View(categories);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        bool existCategory = await _dbContext.Categories.AnyAsync(c => c.Name == category.Name);

        if (existCategory)
        {
            ModelState.AddModelError("Name", "Category already exists");
        }
        
        await _dbContext.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        
        // return View();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id, Category? category)
    {
        if (id == null || id < 1) return BadRequest();
        Category? existCategory = await _dbContext.Categories
            .Where(c=>!c.IsDeleted)
            .FirstOrDefaultAsync(c=>c.Id == id);
        if (existCategory == null) return NotFound();
        if(!ModelState.IsValid) return View();
        bool result = await _dbContext.Categories.AnyAsync(c => c.Name == category.Name);
        if (result)
        {
            ModelState.AddModelError(nameof(category.Name), "Category already exists");
        }
        existCategory.Name = category.Name;
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || id < 1) return BadRequest();
        Category? existCategory = await _dbContext.Categories
            .Where(c =>!c.IsDeleted)
            .FirstOrDefaultAsync(c=>c.Id == id);
        if (existCategory == null) return NotFound();
        _dbContext.Categories.Remove(existCategory);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}