using _27_FrontToBackSql.Data;
using _27_FrontToBackSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSql.Areas.AdminPanel.Controllers;

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
        List<Category> categories = await _dbContext.Categories
            .Include(c=>c.Products)
            .Where(c => c.IsDeleted == false)
            .ToListAsync();
        
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
        if(!ModelState.IsValid) return View();
        bool existcategories = await _dbContext.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim());
        if (existcategories)
        {
            ModelState.AddModelError("Name", "Category already exists");
            return View();
        }
        await _dbContext.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int? id)
    {
        if (id is null || id < 1) return BadRequest();
        
        Category? category = await  _dbContext.Categories
            .Where(c => !c.IsDeleted)
            .FirstOrDefaultAsync(c => c.Id == id);
        
        if (category == null) return NotFound();
        
        return  View(category);
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id is null || id <1) return BadRequest();

        Category? existCategory =
            await _dbContext.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        
        if (existCategory == null) return NotFound();
        

        return View(existCategory);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id,  Category category)
    {
        if (id is null || id <1) return BadRequest();

        Category? existCategory =
            await _dbContext.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        
        if (existCategory == null) return NotFound();
        
        if (!ModelState.IsValid) return View();
        
        bool result = await _dbContext.Categories.AnyAsync(c => c.Name == category.Name);

        if (result)
        {
            ModelState.AddModelError(nameof(Category.Name), "Category already exists");
            return View();
        }
        
        existCategory.Name = category.Name;
        
        await _dbContext.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || id <1) return BadRequest();

        Category? existCategory =
            await _dbContext.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        
        if (existCategory == null) return NotFound();
        
        _dbContext.Categories.Remove(existCategory);
        await _dbContext.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
}