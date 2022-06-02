namespace ProjectStudents.Models.View
{
    public class StudentDisciplineModelView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateOfGrade { get; set; }
        public string Grade { get; set; }

        public int NoOfHours { get; set; }

        public int NoOfCredits { get; set; }
    }
}
