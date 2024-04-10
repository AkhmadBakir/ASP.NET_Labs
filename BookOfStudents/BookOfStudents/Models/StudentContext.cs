using Microsoft.EntityFrameworkCore;
using BookOfStudents.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Cryptography;


namespace BookOfStudents.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
    }
}
