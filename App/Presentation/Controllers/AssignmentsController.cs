using System.Diagnostics;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IAssignmentService _assignmentService;

    public HomeController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }
    
    public IActionResult Index()
    {
        return View(_assignmentService.GetAssignments());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}