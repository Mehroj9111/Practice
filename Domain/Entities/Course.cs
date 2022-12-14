namespace Domain.Entities;
public class Course
{
    public int Id { get; set; }
    public string? CourseName { get; set; }
    public string? Description { get; set; }
    public List<StudentCourse> StudentCourses {get; set;}
    public string? Name { get; set; }
}