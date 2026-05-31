using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers;

public class SliderController : Controller
{
    private readonly AppDbContext _dbContext;

    public SliderController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _dbContext.Sliders.Where(s => !s.IsDeleted).ToListAsync();
        
        return View(sliders);
    }
}