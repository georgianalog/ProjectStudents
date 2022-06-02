using ProjectStudents.Models.Entities;

namespace ProjectStudents.Services.Interfaces
{
    public interface IStudentService
    {
        public List<Student> getAllBySpecializationAndYear(String specialization, int year);

        public Student GetStudent(string id);
    }
}
