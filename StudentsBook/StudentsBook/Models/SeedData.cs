using Microsoft.EntityFrameworkCore;
using StudentsBook.Data;


namespace StudentsBook.Models
{
    public class SeedData
    {

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
                            Name = "Иванов",
                            //Id = 1,
                            Subject1 = 5,
                            Subject2 = 5,
                            Subject3 = 5,
                            Subject4 = 5,
                            Rating = 5
                        },
                        new Student
                        {
                            Name = "Петров",
                            //Id = 2,
                            Subject1 = 5,
                            Subject2 = 5,
                            Subject3 = 5,
                            Subject4 = 5,
                            Rating = 5
                        },
                        new Student
                        {
                            Name = "Сидоров",
                            //Id = 3,
                            Subject1 = 5,
                            Subject2 = 5,
                            Subject3 = 5,
                            Subject4 = 5,
                            Rating = 5
                        }
                    );
                    context.SaveChanges();
            }
        }
    }
}
