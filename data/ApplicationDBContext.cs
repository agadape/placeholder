using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple_API.models;

namespace Simple_API.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;
        //public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<AspUsers> AspUsers { get; set; } = null!;
    }
    
}