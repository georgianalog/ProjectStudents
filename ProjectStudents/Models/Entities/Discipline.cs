using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStudents.Models.Entities
{
    [Table("Discipline")]
    public class Discipline
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }

        public string Name { get; set; }
        public string Specialization { get; set; }

        public int Year { get; set; }

        public int NoOfHours { get; set; }

        public int NoOfCredits { get; set; }
        public List<Material>? Materials { get; set; }

        public List<Student>? Students { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
