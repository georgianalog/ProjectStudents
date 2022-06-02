using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Repository.Concrete
{
    public class DisciplineRepository : RepositoryBase<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(Context context) : base(context)
        {
        }
    }
}
