using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class StudentController
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet]
    public async Task<List<GetStudent>> GetStudent()
    {
        return  await _studentService.GetStudent();
    }
    
    [HttpPost]
    public async Task<AddStudent> Post(AddStudent  student)
    {
        return await _studentService.Add(student);
    }
    [HttpPut]
    public async Task<GetStudent> Update(GetStudent student)
    {
        return await _studentService.Update(student);
    }
    [HttpDelete]
    public async Task<string> Delete(int id)
    {
        return await _studentService.Delete(id);
    }
   
    
}