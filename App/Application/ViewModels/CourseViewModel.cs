using System;
// Resharper Disable All

namespace Application.ViewModels
{
    public class CourseViewModel
    {
        public string CourseName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public DateTime EndDate { get; set; }
    }    
}