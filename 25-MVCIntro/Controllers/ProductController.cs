using Microsoft.AspNetCore.Mvc;

namespace _25_MVCIntro.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
        
    }
}