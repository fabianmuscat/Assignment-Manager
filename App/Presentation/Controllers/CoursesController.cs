using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class CoursesController : Controller
{
    public IActionResult Add()
    {
        return View();
    }
}