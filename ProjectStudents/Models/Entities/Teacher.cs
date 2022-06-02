using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStudents.Models.Entities
{
    [Table("Teacher")]
    public class Teacher 
    {
        [ForeignKey("AspNetUsers")]
        [Key]
        public string Id { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}
