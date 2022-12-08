using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CourseController
{
    private readonly CourseService _todoService;

    public CourseController(CourseService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpGet]
    public async Task<List<GetCourse>> Get()
    {
        return  await _todoService.GetCourses();
    }
    
    [HttpPost]
    public async Task<AddCourse> Post(AddCourse Todo)
    {
        return await _todoService.Add(Todo);
    }
    [HttpPut]
    public async Task<GetCourse> Update(GetCourse todo)
    {
        return await _todoService.Update(todo);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _todoService.Delete(id);
    }
   
    
}