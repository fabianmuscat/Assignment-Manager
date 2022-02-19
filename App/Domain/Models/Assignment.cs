using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable all

namespace Domain.Models { 
    public class Assignment 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentID { get; set; }

        [Required] [StringLength(255)] public string AssignmentName { get; set; } = null!;

        [Required] [ForeignKey("Module")] public int ModuleId { get; set; }

        [Required] public byte MaxMark { get; set; }

        [Required] public int Semester { get; set; }

        [Required] public DateTime DateIssued { get; set; }

        [Required] public DateTime DeadlineDate { get; set; }

        [Required] [ForeignKey("Type")] public int TypeId { get; set; }

        public virtual Type Type { get; set; } = null!;

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; } = null!;
    }
}
