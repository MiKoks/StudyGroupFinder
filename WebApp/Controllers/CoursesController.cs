using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contracts.App;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.EF.App;
using DAL.EF.App.Repositories;
using Microsoft.AspNetCore.Authorization;
using Courses = BLL.DTO.Courses;
#pragma warning disable 1591

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class CoursesController : Controller
    {
        
        private readonly IAppBLL _bll;

        public CoursesController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {

            var vm = await _bll.CoursesService.AllAsync();
            return View(vm);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _bll.CoursesService.FindAsync(id.Value);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoursesDTO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BLL.DTO.Courses courses)
        {
            if (ModelState.IsValid)
            {

                _bll.CoursesService.Add(courses);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _bll.CoursesService.FindAsync(id.Value);
            if (courses == null)
            {
                return NotFound();
            }
            return View(courses);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Courses courses)
        {
            if (id != courses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.CoursesService.Update(courses);

                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _bll.CoursesService.FindAsync(id.Value);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.CoursesService.RemoveAsync(id);
            
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
