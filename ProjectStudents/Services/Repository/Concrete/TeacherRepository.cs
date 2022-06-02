using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Repository.Concrete
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(Context context) : base(context)
        {
        }
    }
}
