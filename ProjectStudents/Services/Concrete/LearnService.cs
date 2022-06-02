using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Interfaces;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Concrete
{
    public class LearnService : ILearnService
    {
        private readonly ILearnRepository _learnRepository;   
        public LearnService(ILearnRepository learnRepository)
        {
            _learnRepository = learnRepository;
        }

        public void Add(Learn learn)
        {
            _learnRepository.Create(learn);
            _learnRepository.Save();
        }

        public void Delete(Learn learn)
        {
            _learnRepository.Delete(learn);
            _learnRepository.Save();
        }

        public void Edit(Learn learn)
        {
            _learnRepository.Update(learn);
            _learnRepository.Save();
        }

        public Learn Get(string studentId, int disciplineId)
        {
            return _learnRepository.FindByCondition(l => l.StudentId == studentId && l.DisciplineId == disciplineId).FirstOrDefault();
        }

        public List<Learn> GetByDiscipline(int disciplineId)
        {
            return _learnRepository.FindByCondition(l => l.DisciplineId == disciplineId).ToList();
        }

        public List<Learn> GetByStudent(string studentId)
        {
            return _learnRepository.FindByCondition(l => l.StudentId == studentId).ToList();
        }
    }
}
