using Microsoft.AspNetCore.Mvc;

namespace _25_MVCIntro.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // return Content("Hello");

        // var student = new JsonResult(new { id = 1, name = "Ali", surname = "Quliyev" });
        // return student;

        return View("Index");
    }

    public IActionResult Detail(int? id)
    {
        if (id is null || id < 1)
        {
            return RedirectToAction(nameof(Error));
        }
        return RedirectToAction("Index", "Product");
    }
    
    public IActionResult Error()
    {
        return View();
    }
}