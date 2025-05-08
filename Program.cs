using Microsoft.EntityFrameworkCore;
using Simple_API.data;
using Simple_API.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//add ef core
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddScoped<InterfaceCategory, CategoryEF>();
//builder.Services.AddSingleton<InterfaceInstructor, InstructorDataAccessLayer_DAL>();
builder.Services.AddScoped<InterfaceCourse, CourseEF>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

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

// app.MapGet("api/v1/categories", ( InterfaceCategory category) =>
// {
//     return category.GetCategories();
// });

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
//     return instructor.GetInstructors();
// });

// app.MapGet("api/v1/instructors/{id}", (InterfaceInstructor instructor, int id) =>
// {
//     return instructor.GetInstructor(id);
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

app.MapGet("api/v1/courses", (InterfaceCourse kors) =>
{
    return kors.GetCourses();
});

app.MapGet("api/v1/courses/{id}", (InterfaceCourse course, int id) =>
{
    return course.GetCourse(id);
});

app.MapPost("api/v1/courses", (InterfaceCourse courseData, Course course) =>
{
    return courseData.AddCourse(course);
});


app.MapPut("api/v1/courses", (InterfaceCourse courseData, Course course) =>
{
    return courseData.UpdateCourse(course);
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
