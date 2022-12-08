namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class CourseService
{
    private readonly DataContext _context;

    public CourseService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<GetCourse>> GetCourses()
    {
        var list = await _context.Courses.Select(s => new GetCourse()
        {
            Id = s.Id,
            CourseName = s.CourseName,
            Description  = s.Description
            

        }).ToListAsync();

        return list;

    }
    public async Task<AddCourse> Add(AddCourse course)
    {
        var newCourse = new Course()
        {
            CourseName = course.CourseName,
            Description  = course.Description
        };
        _context.Courses.Add(newCourse);
        await _context.SaveChangesAsync();
        return course;
    }
    public async Task<GetCourse> Update(GetCourse course)
    {
        var find = await _context.Courses.FindAsync(course.Id);

        if(find == null) return new GetCourse();
        find.CourseName = course.CourseName;
        find.Description = course.Description;

        await _context.SaveChangesAsync();

        return course;
    }
    public async Task<string> Delete(int id)
    {
        var find = await _context.Courses.FindAsync(id);

        _context.Courses.Remove(find);
        await _context.SaveChangesAsync();

        return "Deleted";
    }
}