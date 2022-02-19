using System.Collections.Generic;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCourseViewModel addModel)
        {
            var addForm = new List<FormControl>
            {
                new() { Value = addModel.Name, Error = "Course Name cannot be empty", Validator = Validators.Required },
                new() { Value = addModel.EnrollmentDates, Error = "Enrollment Dates cannot be empty", Validator = Validators.Required }
            };

            dynamic form = Utils.ValidateForm(addForm);
            if (!form.valid)
            {
                ViewBag.Error = form.error;
                return View();
            }

            addModel.User = User.Identity!.Name;
            ViewBag.Error = _courseService.AddCourse(addModel);
            return View();
        }
    }
}