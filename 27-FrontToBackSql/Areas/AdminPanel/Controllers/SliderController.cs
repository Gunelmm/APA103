using _27_FrontToBackSql.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSql.Data;
using _27_FrontToBackSql.Models;
using _27_FrontToBackSql.Utilities.Enums;
using _27_FrontToBackSql.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSql.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class SliderController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;
    public SliderController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders
            .Where(s => !s.IsDeleted)
            .ToListAsync();
        
        return View(sliders);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || id <1) return BadRequest();
        
        Slider? slider = await _context.Sliders
            .Where(s => !s.IsDeleted)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if (slider == null) return NotFound();
        
        return View(slider);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderCreateVM sliderCreateVm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        if (!sliderCreateVm.Photo.CheckFileType("image/"))
        {
            ModelState.AddModelError(nameof(sliderCreateVm.Photo), "File type is incorrect");
            return View();
        }

        if (!sliderCreateVm.Photo.CheckFileSize(FileSize.MB, 2))
        {
            ModelState.AddModelError(nameof(sliderCreateVm.Photo), "File is too large");
            return View();
        }

        Slider slider = new Slider()
        {
            Title = sliderCreateVm.Title,
            Subtitle = sliderCreateVm.Subtitle,
            Description = sliderCreateVm.Description,
            Image = await sliderCreateVm.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
            Order = sliderCreateVm.Order
        };
            
        await _context.AddAsync(slider);
        
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id < 1) return BadRequest();
        
        Slider? slider = await  _context.Sliders
            .Where(s => !s.IsDeleted)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        if (slider == null) return NotFound();

        SliderUpdateVM sliderUpdateVm = new SliderUpdateVM()
        {
            Title = slider.Title,
            Subtitle = slider.Subtitle,
            Description = slider.Description,
            Order = slider.Order,
            Image = slider.Image
        };
        
        return View(sliderUpdateVm);
        
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null || id < 1) return BadRequest();
        
        Slider? slider = await _context.Sliders
            .Where(s => !s.IsDeleted)
            .FirstOrDefaultAsync(s=>s.Id == id);
        
        if (slider == null) return NotFound();
        
        slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
        
        _context.Remove(slider);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

}