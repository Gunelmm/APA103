using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers;

public class SliderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}