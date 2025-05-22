using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Simple_API.models;

namespace Simple_API.data
{
    public class CourseEF : InterfaceCourse
    {
        private readonly ApplicationDBContext _context;
        public CourseEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public Course? AddCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return course;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving course: {ex.Message}");
                throw;
            }
        }
        public void DeleteCourse(int CourseId)
        {
            var course = GetCourse(CourseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Course not found");
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = from c in _context.Courses.Include(c => c.Category).Include(c => c.Instructor)
                          select c;
            return courses.ToList();
        }

        public Course GetCourse(int CourseId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == CourseId);
            if (course != null)
            {
                return course;
            }
            try
            {
                throw new Exception("Course not found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SQL: " + ex.Message);
            }
        }

        public Course GetCourseById(int CourseId)
        {
            var course = _context.Courses
                .FirstOrDefault(c => c.CourseId == CourseId);
            if (course != null)
            {
                return course;
            }
            throw new Exception("Course not found");
        }

        public Course GetCoursebyIdCourse(int CourseId)
        {
            var course = _context.Courses.Include(c => c.Category).Include(c => c.Instructor)
                .FirstOrDefault(c => c.CourseId == CourseId);
            if (course != null)
            {
                return course;
            }
            throw new Exception("Course not found");
        }

        public Course UpdateCourse(Course course)
        {
            var existingCourse = GetCourseById(course.CourseId);
            if (existingCourse == null)
            {
                throw new Exception($"Course dengan ID {course.CourseId} gak ditemuin!.");
            }
            try
            {
                existingCourse.CourseName = course.CourseName;
                existingCourse.CourseDescription = course.CourseDescription;
                existingCourse.Duration = course.Duration;
                existingCourse.CategoryId = course.CategoryId;
                existingCourse.InstructorId = course.InstructorId;

                _context.Courses.Update(existingCourse);
                _context.SaveChanges();
                return existingCourse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengubah course: {ex.Message}");
            }


        }
    }
}