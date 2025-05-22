using AutoMapper;
using Simple_API.models;
using Simple_API.DTO;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Model ke DTO
        CreateMap<Course, CourseDTO>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<Instructor, InstructorDTO>();

        // DTO ke Model
        CreateMap<CourseAddDTO, Course>();
        CreateMap<CourseUpdateDTO, Course>();
    }
}
