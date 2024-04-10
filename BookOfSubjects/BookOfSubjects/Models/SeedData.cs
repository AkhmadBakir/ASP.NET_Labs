using Microsoft.EntityFrameworkCore;
using BookOfSubjects;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;

namespace BookOfSubjects.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SubjectContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<SubjectContext>>()))
            {
                if (context == null || context.Subjects == null)
                {
                    throw new ArgumentNullException("Null CreditContext");
                }
                if (context.Subjects.Any())
                {
                    return;
                }
                context.Subjects.AddRange(
                    new Subject
                    {
                        SubjectId = 1,
                        Title = "Математика"
                    },
                    new Subject
                    {
                        SubjectId = 2,
                        Title = "Физика"
                    },
                    new Subject
                    {
                        SubjectId = 3,
                        Title = "Химия"
                    },
                    new Subject
                    {
                        SubjectId = 1,
                        Title = "История"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
