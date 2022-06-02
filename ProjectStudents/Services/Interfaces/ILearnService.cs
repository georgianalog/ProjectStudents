using ProjectStudents.Models.Entities;

namespace ProjectStudents.Services.Interfaces
{
    public interface ILearnService
    {
        public void Add(Learn learn);

        public void Edit(Learn learn);

        public void Delete(Learn learn);

        public Learn Get(string studentId, int disciplineId);

        public List<Learn> GetByStudent(string studentId);

        public List<Learn> GetByDiscipline(int disciplineId);
    }
}
