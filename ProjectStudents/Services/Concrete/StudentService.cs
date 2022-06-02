using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Interfaces;
using ProjectStudents.Services.Repository.Interfaces;

namespace ProjectStudents.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository; 
        }

        public List<Student> getAllBySpecializationAndYear(string specialization, int year)
        {
           return _studentRepository.FindByCondition(student => student.Specialization 
           == specialization && student.Year == year).ToList();
        }

        public Student GetStudent(string id)
        {
            return _studentRepository.FindByCondition(student => student.Id == id).FirstOrDefault();
        }
    }
}
