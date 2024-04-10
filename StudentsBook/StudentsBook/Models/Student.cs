using System.ComponentModel;

namespace StudentsBook.Models
{
    public class Student
    {

        //public int Sum(int b, int c, int d, int e)
        //{ 
        //    int a = b + c + d + e;
        //    return a; 
        //}

        [DisplayName("ID студента")]
        public int Id { get; set; }
        [DisplayName("Имя студента")]
        public string Name { get; set; }
        [DisplayName("Предмет 1")]
        public int Subject1 { get; set; }
        [DisplayName("Предмет 2")]
        public int Subject2 { get; set; }
        [DisplayName("Предмет 3")]
        public int Subject3 { get; set; }
        [DisplayName("Предмет 4")]
        public int Subject4 { get; set; }
        [DisplayName("Рейтинг студента")]
        public int Rating { get; set; }

        //public int Rating = Sum(Subject1 + Subject2 + Subject3 + Subject4);

    }
}
