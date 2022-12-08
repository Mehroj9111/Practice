namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class StudentService
{
    private readonly DataContext _context;

    public StudentService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<GetStudent>> GetStudent()
    {
        var list = await _context.Students.Select(s => new GetStudent()
        {
            Id = s.Id,
            Name = s.Name
        }).ToListAsync();

        return list;

    }
    public async Task<AddStudent> Add(AddStudent student)
    {
        var newStudent = new Student()
        {
            Name = student.Name,
        };
        _context.Students.Add(newStudent);
        await _context.SaveChangesAsync();
        return student;
    }
    public async Task<GetStudent> Update(GetStudent student)
    {
        var find = await _context.Students.FindAsync(student.Id);

        if(find == null) return new GetStudent();
        find.Name = student.Name;
        await _context.SaveChangesAsync();

        return student;
    }
    public async Task<string> Delete(int id)
    {
        var find = await _context.Students.FindAsync(id);

        _context.Students.Remove(find);
        await _context.SaveChangesAsync();

        return "Response Deleted";
    }
}