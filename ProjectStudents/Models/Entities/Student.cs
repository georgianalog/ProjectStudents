using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStudents.Models.Entities
{
    [Table("Student")]
    public class Student
    {
        [ForeignKey("AspNetUsers")] [Key]
        public string Id { get; set; }

        public string Specialization { get; set; }

        public string GDPR { get; set; }

        public int Year { get; set; }

        public List<Discipline> Disciplines { get; set; }
    }
}
