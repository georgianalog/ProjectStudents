using ProjectStudents.Models.Entities;

namespace ProjectStudents.Models.View
{
    public class MaterialsModelView
    {
        public IEnumerable<ProjectStudents.Models.Entities.Material> materials { get; set; }

        public Discipline discipline { get; set; }

    }
}
