using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public interface InterfaceInstructor
    {
        public List<Instructor> GetAllInstructors();
        public Instructor GetInstructorbyid(int id);
        public Instructor AddInstructor(Instructor instructor);
        public Instructor UpdateInstructor(Instructor instructor);
        public void DeleteInstructor(int id);

        public List<Instructor> GetInstructorsByCourse(int courseId);

    }
}