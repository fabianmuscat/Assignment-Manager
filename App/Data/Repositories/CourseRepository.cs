using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Domain.Models;
// Resharper Disable All

namespace Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AssignmentsContext _context;

        public CourseRepository(AssignmentsContext context)
        {
            _context = context;
        }
    
        public IQueryable<Course> GetCourses(string user)
        {
            var student = _context.Students.FirstOrDefault(s => s.Email.Equals(user));
            var studentCourses = _context.StudentCourses.Where(c => c.StudentId == student!.Id);

            ICollection<Course> courses = new List<Course>();
            foreach (var studentCourse in studentCourses)
            {
                var course = _context.Courses.FirstOrDefault(c => c.CourseID == studentCourse.CourseId);
                if (course == null) continue;;
                courses.Add(course);
            }

            return courses.AsQueryable();
        }

        public int GetYearsForCourse(string courseName)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseName.ToLower().Equals(courseName.ToLower()));
            if (course == null) return -1;
            return course.EndDate.Year - course.EnrollmentDate.Year;
        }

        public string AddCourse(string name, DateTime enrollmentDate, DateTime finalDate, string userEmail)
        {
            var course = new Course { CourseName = name, EnrollmentDate = enrollmentDate, EndDate = finalDate };
            var studentId = GetStudentId(userEmail).Id;
        
            _context.Courses.Add(course);
            _context.StudentCourses.Add(new StudentCourse { Course = course, StudentId = studentId });

            _context.SaveChanges();
            return string.Empty;
        }
    
        public Student GetStudentId(string email) => _context.Students!.FirstOrDefault(s => s.Email.Equals(email))!;
    }
}

