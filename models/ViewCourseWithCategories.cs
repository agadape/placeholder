using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_API.models
{
    public class ViewCourseWithCategories
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Duration {get; set;}
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        
    }
}