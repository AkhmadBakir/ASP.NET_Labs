using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using StudentsBook.Models;
using System.Security.Cryptography;


namespace StudentsBook.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }
    }
}
