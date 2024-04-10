using Microsoft.EntityFrameworkCore;
using BookOfStudents.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;

namespace BookOfStudents.Models
{
    public class SeedData
    {
        //public int Sum(int b, int c, int d, int e)
        //{
        //    int a = b + c + d + e;
        //    return a;
        //}


        public static void Initialize(IServiceProvider serviceProvider)
        {


            using (var context = new StudentContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<StudentContext>>()))
            {
                if (context == null || context.Students == null)
                {
                    throw new ArgumentNullException("Null StudentContext");
                }
                // Если в базе данных уже есть кредиты,
                // то возвращается инициализатор заполнения и кредиты не добавляются
                if (context.Students.Any())
                {
                    return;
                }


                context.Students.AddRange(
                    new Student
                    {
                        Id = 1,
                        Name = "Иванов Иван",
                        Subject1 = 5,
                        Subject2 = 5,
                        Subject3 = 5,
                        Subject4 = 5,
                        //Rating = Subject1 + Subject2 + Subject3 + Subject4
                    },
                    new Student
                    {
                        Id = 2,
                        Name = "Петров Петр",
                        Subject1 = 5,
                        Subject2 = 5,
                        Subject3 = 5,
                        Subject4 = 5,
                        //Rating = Subject1 + Subject2 + Subject3 + Subject4
                    },
                    new Student
                    {
                        Id = 3,
                        Name = "Сидоров Сидр",
                        Subject1 = 5,
                        Subject2 = 5,
                        Subject3 = 5,
                        Subject4 = 5,
                        //Rating = Subject1 + Subject2 + Subject3 + Subject4
                    }

                    );
                context.SaveChanges();
            }
        }

    }
}
