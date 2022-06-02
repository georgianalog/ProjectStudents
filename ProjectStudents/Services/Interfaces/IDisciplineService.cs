using ProjectStudents.Models.Entities;

namespace ProjectStudents.Services.Interfaces
{
    public interface IDisciplineService
    {
        public Discipline GetDiscipline(int Id);

        public List<Discipline> GetDisciplineByTeacher(string teacherId);

        public List<Discipline> GetDisciplineBySpecializationAndYear(
            string specialization, int year);

    }
}
