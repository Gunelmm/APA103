using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}