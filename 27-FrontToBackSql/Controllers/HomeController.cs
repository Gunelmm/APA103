using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSql.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}