using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_API.models
{
    public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public double Duration { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public int InstructorId { get; set; }
    
    [ForeignKey("InstructorId")]
    public Instructor? Instructor { get; set; }
}
}