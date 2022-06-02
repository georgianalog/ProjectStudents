using Cinema.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectStudents.Models.Entities;
using ProjectStudents.Models.View;
using ProjectStudents.Services.Concrete;
using ProjectStudents.Services.Interfaces;
using System.Security.Claims;

namespace ProjectStudents.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        private readonly IStudentService _studentService;

        public AccountsController(IUserService userService, IStudentService studentService)
        {
            _userService = userService;
            _studentService = studentService;
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RegisterStudent()
        {
            var student = new User()
            {
                Email = "gb2@edu.ro",
                FirstName = "Test",
                SecondName = "LTest",
                DateOfBirth = new DateTime(),
                Role = "Student"
            };

            _userService.Register(student);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Register()
        {
            if (_userService.IsUserLoggedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Accounts/Register.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.Register(model);
                    if (result.Succeeded)
                    {
                       
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                
                return View(model);
            }
            catch (Exception e)
            {
                
                return View("~/Views/Accounts/Register.cshtml");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_userService.IsUserLoggedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Accounts/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.Login(model);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid login attempt");
                }
                return RedirectToAction("Login");
            }
            catch
            {
                return View("~/Views/Accounts/Login.cshtml");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            var user = _userService.getUser(userId);
            

            if(user.Role == "Student")
            {
                var student = _studentService.GetStudent(userId);
                var model = new StudentProfileModelView
                {
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    GDPR = student.GDPR,
                    Specialization = student.Specialization,
                    Year = student.Year
                };
                return View("~/Views/Accounts/StudentProfile.cshtml", model);
            }
            if (user.Role == "Teacher")
            {
                var model = new TeacherProfileModelView
                {
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName
                };
                return View("~/Views/Accounts/TeacherProfile.cshtml", model);
            }

            return View();
        }

    }
}
