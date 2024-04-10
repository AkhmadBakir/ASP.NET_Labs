namespace BookOfSubjects.Models
{
    public class Student
    {
        public virtual int StudentId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Mark { get; set; }
        public virtual int AcademicPerformance { get; set; }

    }
}
