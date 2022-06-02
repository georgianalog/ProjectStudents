using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStudents.Models.Entities
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Discipline")]
        public int DisciplineId { get; set; }

        public string URL { get; set; }

        public Discipline? Discipline { get; set; }
    }
}
