using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Models.View;
using ProjectStudents.Services.Interfaces;

namespace ProjectStudents.Controllers
{
    
    public class DisciplinesController : Controller
    {
        private readonly IDisciplineService _disciplineService;

        private readonly IStudentService _studentService;

        private readonly IUserService _userService;

        private readonly ILearnService _learnService;

        private readonly IMaterialService _materialService;

        private static StudentOnDisciplineModelView mod;

        public DisciplinesController(IDisciplineService disciplineService,
            IStudentService studentService,
            IUserService userService,
            ILearnService learnService,
            IMaterialService materialService)
        {
            _disciplineService = disciplineService;
            _studentService = studentService;
            _userService = userService;
            _learnService = learnService;
            _materialService = materialService;
        }

        // GET: Disciplines
        
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.getUser(userId);
            if (user.Role == "Student")
            {
                return RedirectToAction("StudentViewDisciplines");
            } else
            {
                return RedirectToAction("TeacherViewDisciplines");
            }

        }

        // GET: Disciplines
        
        public async Task<IActionResult> StudentViewDisciplines()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var learns = _learnService.GetByStudent(userId);
            List<StudentDisciplineModelView> disciplines = new List<StudentDisciplineModelView>();
            for (int i = 0; i < learns.Count; i++)
            {
                Learn l = learns.ElementAt(i);
                var disc = _disciplineService.GetDiscipline(l.DisciplineId);
                var d = new StudentDisciplineModelView()
                {
                    Id = disc.Id,
                    DateOfGrade = l.DateOfGrade,
                    Grade = l.Grade,
                    Name = disc.Name,
                    NoOfCredits = disc.NoOfCredits,
                    NoOfHours = disc.NoOfHours
                };
                disciplines.Add(d);
            }
            return View(disciplines);
        }

        // GET: Disciplines
        
        public async Task<IActionResult> TeacherViewDisciplines()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_disciplineService.GetDisciplineByTeacher(userId));
        }

        [Authorize]
        public async Task<IActionResult> Materials(int disciplineId)
        {
            var discipline = _disciplineService.GetDiscipline(disciplineId);
            var materials = _materialService.GetMaterialsByDisciplineId(disciplineId);

            return View(new MaterialsModelView()
            {
                discipline = discipline,
                materials = materials
            });
        }

       
        public async Task<IActionResult> Students(int disciplineId)
        {
            var learns = _learnService.GetByDiscipline(disciplineId);
            List<StudentOnDisciplineModelView> students = new List<StudentOnDisciplineModelView>();
            for (int i = 0; i < learns.Count; i++)
            {
                var learn = learns.ElementAt(i);
                var student = _userService.getUser(learn.StudentId);
                var disc = _disciplineService.GetDiscipline(learn.DisciplineId);
                if (student != null)
                {
                    var sodmv = new StudentOnDisciplineModelView
                    {
                        studentId = student.Id,
                        Name = student.FirstName + " " + student.SecondName,
                        DateOfGrade = learn.DateOfGrade,
                        disciplineId = learn.DisciplineId,
                        Email = student.Email,
                        Grade = learn.Grade,
                        disciplineName = disc.Name
                    };

                    students.Add(sodmv);
                }
            }

            return View(students);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> EditStudentGrade(int disciplineId,
            string disciplineName, string studentId, string name,
            string Email, DateTime? DateOfGrade, string Grade)
        {
            mod = new StudentOnDisciplineModelView
            {
                disciplineId = disciplineId,
                disciplineName = disciplineName,
                Name = name,
                DateOfGrade = DateOfGrade,
                Email = Email,
                Grade = Grade,
                studentId = studentId

            };
            return View("~/Views/Disciplines/EditStudent.cshtml",
                new GradeModelView
                {
                    Grade = mod.Grade,
                    DateOfGrade = mod.DateOfGrade
                });
        }

        [Authorize(Roles = "Teacher")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> EditStudent(GradeModelView model)
        {

            var l = _learnService.Get(mod.studentId, mod.disciplineId);
            l.Grade = model.Grade;
            l.DateOfGrade = model.DateOfGrade;
            _learnService.Edit(l);
            return RedirectToAction("Students", new RouteValueDictionary(
                            new { controller = "Disciplines", action = "Students", disciplineId = mod.disciplineId }));
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> EditStudentGrade([Bind("Name, Email, disciplineName, disciplineId, studentId, DateOfGrade, Grade")] StudentOnDisciplineModelView model)
        {
            var l = _learnService.Get(mod.studentId, mod.disciplineId);
            l.Grade = mod.Grade;
            l.DateOfGrade = mod.DateOfGrade;
            return RedirectToAction("Students", new RouteValueDictionary(
                            new { controller = "Disciplines", action = "Students", disciplineId = mod.disciplineId }));
        }

        /*
        // GET: Disciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: Disciplines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disciplines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Specialization,Year,NoOfHours,NoOfCredits")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discipline);
        }

        // GET: Disciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            return View(discipline);
        }

        // POST: Disciplines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Specialization,Year,NoOfHours,NoOfCredits")] Discipline discipline)
        {
            if (id != discipline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineExists(discipline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(discipline);
        }

        // GET: Disciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: Disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disciplines == null)
            {
                return Problem("Entity set 'Context.Disciplines'  is null.");
            }
            var discipline = await _context.Disciplines.FindAsync(id);
            if (discipline != null)
            {
                _context.Disciplines.Remove(discipline);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineExists(int id)
        {
          return (_context.Disciplines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
