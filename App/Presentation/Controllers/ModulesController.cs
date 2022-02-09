using System.Diagnostics;
using Application.Interfaces;
using Application.ViewModels;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers;

[Authorize]
public class ModulesController : Controller
{
    private readonly ICourseService _courseService;
    private readonly IModuleService _moduleService;

    public ModulesController(ICourseService courseService, IModuleService moduleService)
    {
        _courseService = courseService;
        _moduleService = moduleService;
    }

    [HttpGet]
    public IActionResult Add()
    {
        var courses = _courseService.GetCourses(User.Identity!.Name!);
        if (courses.IsNullOrEmpty())
            RedirectToAction("Add", "Courses");

        ViewBag.Years = new List<SelectListItem>();
        ViewBag.Courses = new List<SelectListItem>();
        foreach (var (course, years) in courses)
        {
            for (var year = 1; year <= years; year++)
                ViewBag.Years.Add(new SelectListItem($"Year {year}", year.ToString()));    
            
            ViewBag.Courses.Add(new SelectListItem(course.CourseName, course.CourseName));
        }

        return View(new AddModuleViewModel { SemesterNumber = DateTime.Now.Month is >= 10 or < 2 ? 1 : 2 });
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