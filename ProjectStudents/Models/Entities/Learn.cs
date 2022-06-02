using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStudents.Models.Entities
{
    public class Learn
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        [ForeignKey("Discipline")]
        public int DisciplineId { get; set; }

        public DateTime? DateOfGrade { get; set; }

        public string Grade { get; set; } = "Not graded yet";


    }
}
