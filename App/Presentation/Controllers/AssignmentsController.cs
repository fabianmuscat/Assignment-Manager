using System.Diagnostics;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class AssignmentsController : Controller
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentsController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }
    
    public IActionResult Index()
    {
        return View(_assignmentService.GetAssignments());
    }

    [HttpGet]
    public IActionResult Add() => DateTime.Now.Month is >= 10 or < 2 // >= October && < February
        ? View(new AddAssignmentViewModel { SemesterNumber = 1 })
        : View(new AddAssignmentViewModel { SemesterNumber = 2 });

    [HttpPost]
    public IActionResult Add(AddAssignmentViewModel addModel)
    {
        return View();
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Redirect()
    {
        return User.Identity is { IsAuthenticated: false }
            ? Redirect("/Identity/Account/Login")
            : Redirect("/Assignments/Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}