using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Repository.Concrete
{
    public class UserBaseRepository : RepositoryBase<User>, IUserBaseRepository
    {
        public UserBaseRepository(Context context) : base(context)
        {
        }
    }
}
