using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple_API.models;

namespace Simple_API.data
{
    public class IntructorEF : InterfaceInstructor
    {
        private readonly ApplicationDBContext _context;
        public IntructorEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public Instructor AddInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public void DeleteInstructor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Instructor> GetAllInstructors()
        {
            // var instructors = from i in _context.Instructors.Include(i => i.Courses)
            //                   orderby i.InstructorName descending
            //                   select i;
            // return instructors.ToList();
            throw new NotImplementedException();
        }

        public Instructor GetInstructorbyid(int id)
        {
            // var instructor = _context.Instructors.Include(i => i.Courses)
            //     .FirstOrDefault(i => i.InstructorId == id);
            // if (instructor != null)
            // {
            //     return instructor;
            // }
            // try
            // {
            //     throw new Exception("Instructor not found");
            // }
            // catch (Exception ex)
            // {
            //     throw new Exception("Error retrieving instructor", ex);
            // }
            throw new NotImplementedException();
        }

        public List<Instructor> GetInstructorsByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Instructor UpdateInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }
}