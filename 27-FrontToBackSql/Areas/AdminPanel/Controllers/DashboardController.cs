using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSql.Areas.AdminPanel.Controllers;
[Area("AdminPanel")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}