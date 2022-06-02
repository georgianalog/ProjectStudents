using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Repository.Concrete
{
    public class LearnRepository : RepositoryBase<Learn>, ILearnRepository
    {
        public LearnRepository(Context context) : base(context)
        {
        }
    }
}
