using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Repository.Concrete
{
    public class MaterialRepository : RepositoryBase<Material>, IMaterialRepository
    {
        public MaterialRepository(Context context) : base(context)
        {
        }
    }
}
