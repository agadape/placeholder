using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Simple_API.models;

namespace Simple_API.data
{
    public class CourseADO : InterfaceCourse
    {
        private readonly IConfiguration _configuration;
        private string connstr = string.Empty;
        public CourseADO(IConfiguration configuration)
        {
            _configuration = configuration;
            this.connstr = _configuration.GetConnectionString("DefaultConnection");

        }

        public Course AddCourse(Course course)
        {
            using(SqlConnection conn = new SqlConnection(connstr))
            {
                string strsql = @"INSERT INTO Courses (CourseName, CourseDescription, Duration, CategoryId) 
                                  VALUES (@CourseName, @CourseDescription, @Duration, @CategoryId);
                                  SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseDescription", course.Description);
                    cmd.Parameters.AddWithValue("@Duration", course.Duration);
                    cmd.Parameters.AddWithValue("@CategoryId", course.CategoryId);
                    conn.Open();
                    int CourseId = Convert.ToInt32(cmd.ExecuteScalar());
                    course.CourseId = CourseId;
                    return course;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in SQL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeleteCourse(int CourseId)
        {
            using(SqlConnection conn = new SqlConnection(connstr))
            {
                string strsql = @"DELETE FROM Courses WHERE CourseId = @CourseId";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.Parameters.AddWithValue("@CourseId", CourseId);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("No records found");
                }
            }
        }

        public ViewCourseWithCategories GetCourse(int CourseId)
        {
            using(SqlConnection conn = new SqlConnection(connstr))
            {
                string strsql = @"SELECT dbo.Courses.CourseName, dbo.Courses.CourseId, dbo.Courses.CourseDescription, dbo.Courses.Duration, dbo.Categories.CategoryId, dbo.Categories.CategoryName
                                FROM dbo.Categories INNER JOIN
                                dbo.Courses ON dbo.Categories.CategoryId = dbo.Courses.CategoryId";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.Parameters.AddWithValue("@CourseId", CourseId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ViewCourseWithCategories course = new ViewCourseWithCategories();
                try
                {
                    if (reader.Read())
                    {
                        course.CourseId = Convert.ToInt32(reader["CourseId"]);
                        course.CourseName = reader["CourseName"].ToString()!;
                        course.Description = reader["CourseDescription"].ToString()!;
                        course.Duration = Convert.ToDouble(reader["Duration"]);
                        course.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        course.CategoryName = reader["CategoryName"].ToString()!;
                    }
                    return course;
                }
                catch(SqlException sqlex)
                {
                    throw new Exception("Error in SQL: " + sqlex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public IEnumerable<ViewCourseWithCategories> GetCourses()
        {
            using var conn = new SqlConnection(connstr);
            string strsql = @"SELECT dbo.Courses.CourseName, dbo.Courses.CourseId, dbo.Courses.CourseDescription, dbo.Courses.Duration, dbo.Categories.CategoryId, dbo.Categories.CategoryName
                                FROM dbo.Categories INNER JOIN
                                dbo.Courses ON dbo.Categories.CategoryId = dbo.Courses.CategoryId";
            using var cmd = new SqlCommand(strsql, conn);
            conn.Open();
            using var dr = cmd.ExecuteReader();
            var courses = new List<ViewCourseWithCategories>();
            try
            {
                while (dr.Read())
                {
                    var course = new ViewCourseWithCategories
                    {
                        CourseId = Convert.ToInt32(dr["CourseId"]),
                        CourseName = dr["CourseName"].ToString()!,
                        Description = dr["CourseDescription"].ToString()!,
                        Duration = Convert.ToDouble(dr["Duration"]),
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        CategoryName = dr["CategoryName"].ToString()!
                    };
                    courses.Add(course);
                }
                return courses;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Error in SQL: " + sqlex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public Course UpdateCourse(Course course)
        {
            using(SqlConnection conn = new SqlConnection(connstr))
            {
                string strsql = @"UPDATE Courses SET CourseName = @CourseName, CourseDescription = @CourseDescription, Duration = @Duration, CategoryId = @CategoryId
                                WHERE CourseId = @CourseId";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseDescription", course.Description);
                    cmd.Parameters.AddWithValue("@Duration", course.Duration);
                    cmd.Parameters.AddWithValue("@CategoryId", course.CategoryId);
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No records found");
                    }
                    return course;
                }
                catch (SqlException sqlex)
                {
                    throw new Exception("Error in SQL: " + sqlex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}