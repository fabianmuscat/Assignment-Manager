using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ModulesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}