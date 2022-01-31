using System.Diagnostics;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers;

public class ModulesController : Controller
{
    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Years = new[]
        {
            new SelectListItem("Year 1", "1"),
            new SelectListItem("Year 2", "2"),
            new SelectListItem("Year 3", "3")
        };
        
        ViewBag.Courses = new[]
        {
            new SelectListItem("BSc in Software", "BSc in Software"),
            new SelectListItem("BSc in Multimedia", "BSc in Multimedia")
        };
        
        return View(new AddModuleViewModel { SemesterNumber = DateTime.Now.Month is >= 10 or < 2 ? 1 : 2 } );
    }

    public IActionResult Add(AddModuleViewModel addModuleModel)
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}