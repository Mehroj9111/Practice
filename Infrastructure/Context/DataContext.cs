using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext:DbContext
{
 public DataContext(DbContextOptions<DataContext> options) : base(options)
 {

 }
 protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        modelBuilder.Entity<StudentCourse>()
       .HasOne<Student>(sc => sc.Student)
       .WithMany(s => s.StudentCourses)
       .HasForeignKey(sc => sc.StudentId);


       modelBuilder.Entity<StudentCourse>()
      .HasOne<Course>(sc => sc.Course)
      .WithMany(s => s.StudentCourses)
      .HasForeignKey(sc => sc.CourseId);

}
 public DbSet<Student> Students {get; set;}
 public DbSet<Course> Courses {get; set;}
 public DbSet<StudentCourse> StudentCourses {get; set;}

}