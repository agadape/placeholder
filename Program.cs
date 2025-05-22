using System;
using Microsoft.EntityFrameworkCore;
using Simple_API.data;
using Simple_API.DTO;
using Simple_API.models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
//add ef core
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));



builder.Services.AddScoped<InterfaceCategory, CategoryEF>();
builder.Services.AddScoped<InterfaceCourse, CourseEF>();
builder.Services.AddScoped<InterfaceInstructor, IntructorEF>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("api/v1/helloservices", (string? id) =>
{
    return $"Hello ASP Web API: id= {id}";
});

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("api/v1/categories", (InterfaceCategory category) =>
{
    return category.GetCategories();
});

// app.MapGet("api/v1/categories/{id}", (InterfaceCategory category, int id) =>
// {
//     return category.GetCategory(id);
// });

// app.MapPost("api/v1/categories/", (InterfaceCategory categoryData, Category category) =>
// {
//     return categoryData.AddCategory(category);
// });

// app.MapPut("api/v1/categories/", (InterfaceCategory categoryData, Category category) =>
// {
//     return categoryData.UpdateCategory(category);
// });

// app.MapDelete("api/v1/categories/{id}", (InterfaceCategory categoryData, int id) =>
// {
//     categoryData.DeleteCategory(id);
//     return "Category deleted successfully";
// });

// app.MapGet("api/v1/instructors", (InterfaceInstructor instructor) =>
// {
//     List<InstructorDTO> instructorsDTOs = new List<InstructorDTO>();
//     var instructors = instructor.GetAllInstructors();
//     foreach (var instructorData in instructors)
//     {
//         InstructorDTO instructorDTO = new InstructorDTO
//         {
//             InstructorId = instructorData.InstructorId,
//             InstructorName = instructorData.InstructorName,
//             Course = instructorData.Courses != null ? new CourseDTO
//             {
//             CourseId = instructorData.Course.CourseId,
//             CourseName = instructorData.Course.CourseName
//             } : null
//         };
//         instructorsDTOs.Add(instructorDTO);
//     }
//     return instructorsDTOs;
// });

// app.MapGet("api/v1/instructors/{id}", (InterfaceInstructor instructor, int id) =>
// {
//     var instructorData = instructor.GetInstructorbyid(id);
//     if (instructorData != null)
//     {
//         InstructorDTO instructorDTO = new InstructorDTO
//         {
//             InstructorId = instructorData.InstructorId,
//             InstructorName = instructorData.InstructorName,
//             Course = instructorData.Course != null ? new CourseDTO
//             {
//                 CourseId = instructorData.Course.CourseId,
//                 CourseName = instructorData.Course.CourseName
//             } : null
//         };
//         return instructorDTO;
//     }
//     else
//     {
//         throw new Exception("Instructor not found");
//     }
// });

// app.MapPost("api/v1/instructors", (InterfaceInstructor instructorData, Instructor instructor) =>
// {
//     return instructorData.AddInstructor(instructor);
// });

// app.MapPut("api/v1/instructors", (InterfaceInstructor instructorData, Instructor instructor) =>
// {
//     return instructorData.UpdateInstructor(instructor);
// });

// app.MapDelete("api/v1/instructors/{id}", (InterfaceInstructor instructorData, int id) =>
// {
//     instructorData.DeleteInstructor(id);
//     return "Instructor deleted successfully";
// });

app.MapGet("api/v1/courses", (InterfaceCourse kors, IMapper mapper) =>
{
    var courses = kors.GetAllCourses();
    // List<CourseDTO> coursesDTOs = new List<CourseDTO>();
    var result = mapper.Map<List<CourseDTO>>(courses);
    return Results.Ok(result);

});

app.MapGet("api/v1/courses/{id}", (InterfaceCourse course, int id, IMapper mapper) =>
{
    var courseData = course.GetCoursebyIdCourse(id);
    if (courseData == null)
    {
        return Results.NotFound();
    }

    var result = mapper.Map<CourseDTO>(courseData);
    return Results.Ok(result);
});


app.MapPost("api/v1/courses", (InterfaceCourse courseData, CourseAddDTO courseAddDTO, IMapper mapper) =>
{
    var courseEntity = mapper.Map<Course>(courseAddDTO);
    var course = courseData.AddCourse(courseEntity);
    var result = mapper.Map<CourseDTO>(course);
    return Results.Created($"/api/v1/courses/{course.CourseId}", result);
});


app.MapPut("api/v1/courses", (InterfaceCourse courseData, CourseUpdateDTO courseUpdateDTO, IMapper mapper) =>
{
    var courseEntity = mapper.Map<Course>(courseUpdateDTO);
    var course = courseData.UpdateCourse(courseEntity);
    var result = mapper.Map<CourseDTO>(course);
    return Results.Ok(result);
});

app.MapDelete("api/v1/courses/{id}", (InterfaceCourse courseData, int id) =>
{
    courseData.DeleteCourse(id);
    return "Course deleted successfully";
});



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
