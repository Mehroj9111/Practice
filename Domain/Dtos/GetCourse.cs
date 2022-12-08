using Domain.Entities;
namespace Domain.Dtos;
public class GetCourse
{
     public int Id { get; set; }
    public string? CourseName { get; set; }
    public string? Description { get; set; }
}
