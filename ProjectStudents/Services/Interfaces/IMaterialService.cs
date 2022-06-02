using ProjectStudents.Models.Entities;

namespace ProjectStudents.Services.Interfaces
{
    public interface IMaterialService
    {
        public Material GetMaterial(int id);

        public void Add(Material material);

        public void Edit(Material material);

        public void Delete(Material material);

        public List<Material> GetMaterialsByDisciplineId(int id);
    }
}
