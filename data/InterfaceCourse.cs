using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public interface InterfaceCourse
    {
        IEnumerable<ViewCourseWithCategories> GetCourses();
        ViewCourseWithCategories GetCourse(int CourseId);
        Course AddCourse(Course course);
        Course UpdateCourse(Course course);
        void DeleteCourse(int CourseId);
    }
}