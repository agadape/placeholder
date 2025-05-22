using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.DTO
{
    public class InstructorDTO
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = null!;
        public string InstructorEmail { get; set; } = null!;
        public string InstructorPhone { get; set; } = null!;
        public string InstructorAddress { get; set; } = null!;
        public string InstructorCity { get; set; } = null!;
    }
}