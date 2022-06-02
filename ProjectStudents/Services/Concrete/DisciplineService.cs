using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Interfaces;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Concrete
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineService(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        public Discipline GetDiscipline(int Id)
        {
            return _disciplineRepository.FindByCondition(discipline => discipline.Id == Id).ToList().FirstOrDefault();   
        }

        public List<Discipline> GetDisciplineBySpecializationAndYear(string specialization, int year)
        {
            return _disciplineRepository.FindByCondition(d => d.Specialization == specialization
            && d.Year == year).ToList();
        }

        public List<Discipline> GetDisciplineByTeacher(string teacherId)
        {
            return _disciplineRepository.FindByCondition(discipline => discipline.TeacherId == teacherId).ToList();
        }
    }
}
