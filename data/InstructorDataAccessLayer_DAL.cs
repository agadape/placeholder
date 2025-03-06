using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public class InstructorDataAccessLayer_DAL : InterfaceInstructor
    {
        private List<Instructor> _instructors = new List<Instructor>();
        public InstructorDataAccessLayer_DAL()
        {
            _instructors.AddRange(new Instructor
            {
                InstructorId = 1,
                InstructorName = "John Doe",
                InstructorEmail = "JohnDoe@gmail.com",
                InstructorPhone = "123-456-7890",
                InstructorAddress = "123 Main St",
                InstructorCity = "Anytown"
            },
            new Instructor
            {
                InstructorId = 2,
                InstructorName = "Jane Doe",
                InstructorEmail = "Janedoe@gmail.com",
                InstructorPhone = "123-456-7890",
                InstructorAddress = "123 Main St",
                InstructorCity = "Anytown"
            },
            new Instructor
            {
                InstructorId = 3,
                InstructorName = "John Smith",
                InstructorEmail = "JohnSmith@gmail.com",
                InstructorPhone = "123-456-7890",
                InstructorAddress = "123 Main St",
                InstructorCity = "Anytown"
            },
            new Instructor
            {
                InstructorId = 4,
                InstructorName = "Jane Smith",
                InstructorEmail = "JaneSmith@gmail.com",
                InstructorPhone = "123-456-7890",
                InstructorAddress = "123 Main St",
                InstructorCity = "Anytown"
            },
            new Instructor
            {
                InstructorId = 5,
                InstructorName = "John Johnson",
                InstructorEmail = "Johnson@gmail.com",
                InstructorPhone = "123-456-7890",
                InstructorAddress = "123 Main St",
                InstructorCity = "Anytown"
            },
            new Instructor
            {
                InstructorId = 6,
                InstructorName = "Dave Aryanda Agape",
                InstructorEmail = "dave.aryanda@si.ukdw.ac.id",
                InstructorPhone = "0821-2542-2017",
                InstructorAddress = "Jl. Kaliurang KM 14,5",
                InstructorCity = "Sleman"
            });
        }
        public Instructor AddInstructor(Instructor instructor)
        {
            _instructors.Add(instructor);
            return instructor;
        }

        public void DeleteInstructor(int id)
        {
            var instructor = GetInstructor(id);
            _instructors.Remove(instructor);
        }

        public Instructor GetInstructor(int id)
        {
            var instructor = _instructors.FirstOrDefault(i => i.InstructorId == id);
            if (instructor == null)
            {
                throw new Exception("Instructor not found");
            }
            return instructor;
        }

        public List<Instructor> GetInstructors()
        {
            return _instructors;
        }

        public Instructor UpdateInstructor(Instructor instructor)
        {
            var UpdateToInstructor = GetInstructor(instructor.InstructorId);
            UpdateToInstructor.InstructorName = instructor.InstructorName;
            UpdateToInstructor.InstructorEmail = instructor.InstructorEmail;
            UpdateToInstructor.InstructorPhone = instructor.InstructorPhone;
            UpdateToInstructor.InstructorAddress = instructor.InstructorAddress;
            UpdateToInstructor.InstructorCity = instructor.InstructorCity;
            return instructor;
        }
    }
}