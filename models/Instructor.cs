using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_API.models
{
    [Table("Instructor")]
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = null!;
        public string InstructorEmail { get; set; } = null!;
        public string InstructorPhone { get; set; } = null!;
        public string InstructorAddress { get; set; } = null!;
        public string InstructorCity { get; set; } = null!;

    }
}