using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Interfaces;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Concrete
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public Material GetMaterial(int id)
        {
            return _materialRepository.FindByCondition(x => x.Id == id).ToList().FirstOrDefault();
        }

        public List<Material> GetMaterialsByDisciplineId(int id)
        {
            return _materialRepository.FindByCondition(mat => mat.DisciplineId == id).ToList();
        }

        void IMaterialService.Add(Material material)
        {
            _materialRepository.Create(material);
            _materialRepository.Save();
        }

        void IMaterialService.Delete(Material material)
        {
            _materialRepository.Delete(material);
            _materialRepository.Save();
        }

        void IMaterialService.Edit(Material material)
        {
            _materialRepository.Update(material);
            _materialRepository.Save();
        }


    }
}
