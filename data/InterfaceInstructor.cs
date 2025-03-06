using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public interface InterfaceInstructor
    {
        public List<Instructor> GetInstructors();
        public Instructor GetInstructor(int id);
        public Instructor AddInstructor(Instructor instructor);
        public Instructor UpdateInstructor(Instructor instructor);
        public void DeleteInstructor(int id);
    }
}