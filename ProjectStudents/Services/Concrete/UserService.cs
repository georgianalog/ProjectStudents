using Cinema.Models.Views;
using Microsoft.AspNetCore.Identity;
using ProjectStudents.Models.Entities;
using ProjectStudents.Models.View;
using ProjectStudents.Services.Interfaces;
using ProjectStudents.Services.Repository.Interfaces;
using System.Security.Claims;

namespace ProjectStudents.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserBaseRepository _userBaseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public UserService(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IUserBaseRepository userBaseRepositor,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userBaseRepository = userBaseRepositor;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public bool IsUserLoggedIn(ClaimsPrincipal User)
        {
            return _signInManager.IsSignedIn(User);
        }

        public async Task<SignInResult> Login(LoginModelView model)
        {
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            return signInResult;
        }

        public async Task<IdentityResult> Register(User student)
        {
            _userBaseRepository.Create(student);
            _userBaseRepository.Save();
            var std = new Student
            {
                Id = student.Id,
                GDPR = "aa",
                Specialization = "CR",
                Year = 3
            };
            _studentRepository.Create(std);
            _studentRepository.Save();
            var result = await _userManager.CreateAsync(student, "AbchdeF15");
            await _userManager.AddToRoleAsync(student, "Student");
            return result;
        }

        public async Task<IdentityResult> Register(RegisterModelView model)
        {

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                SecondName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
            }

            return result;
        }

        /*
        public async Task<IdentityResult> Register(User teacher)
        {
            var result = await _userManager.CreateAsync(teacher, "AbcdeF15");
            if (result.Succeeded)
            {
                _userBaseRepository.Create(teacher);
                _userBaseRepository.Save();
                var tchr = new Teacher
                {
                    Id = teacher.Id
                };
                _teacherRepository.Create(tchr);            
                _teacherRepository.Save();
                await _userManager.AddToRoleAsync(teacher, "Teacher");
            }

            return result;
        }
        */

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public User getUser(string id)
        {
            return _userBaseRepository.FindByCondition(u => u.Id == id).ToList().FirstOrDefault();
        }
    }
}
