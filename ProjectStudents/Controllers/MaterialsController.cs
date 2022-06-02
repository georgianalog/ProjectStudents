using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectStudents.DataAccess;
using ProjectStudents.Models.Entities;
using ProjectStudents.Services.Interfaces;

namespace ProjectStudents.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class MaterialsController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // GET: Materials/Create
        public IActionResult Create(int disciplineId)
        {
            var material = new Material()
            {
                DisciplineId = disciplineId
            };
            return View(material);
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material)
        {
            _materialService.Add(material);

            return RedirectToAction("Materials", new RouteValueDictionary(
                             new { controller = "Disciplines", action = "Materials", disciplineId = material.DisciplineId }));

        }

        
        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            return View(_materialService.GetMaterial(Id));
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Material material)
        {
            _materialService.Edit(material);
            return RedirectToAction("Materials", new RouteValueDictionary(
                             new { controller = "Disciplines", action = "Materials", disciplineId = material.DisciplineId }));
        }
        

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int id)
        {            
            return View(_materialService.GetMaterial(id));
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = _materialService.GetMaterial(id);
            _materialService.Delete(material);
            return RedirectToAction("Materials", new RouteValueDictionary(
                             new { controller = "Disciplines", action = "Materials", disciplineId = material.DisciplineId }));
        }
       
    }
}
