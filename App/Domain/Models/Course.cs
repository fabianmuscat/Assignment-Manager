using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// Resharper Disable All

namespace Domain.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [Required] [StringLength(255)] public string CourseName { get; set; } = null!;

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Module> Modules { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = null!;
    }
}

