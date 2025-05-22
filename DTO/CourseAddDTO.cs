using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_API.DTO
{
    public class CourseAddDTO
    {
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public double Duration { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
    }
}