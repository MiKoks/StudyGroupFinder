using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Contracts.App;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.EF.App;
using DAL.EF.App.Repositories;
using Domain.App;
using Domain.App.Identity;
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels.Admin;
#pragma warning disable 1591

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudyGroupsController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;
        
        public StudyGroupsController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }
        
        // GET: StudyGroups/MyStudyGroups
        public async Task<IActionResult> MyStudyGroups()
        {
            var userStudyGroups = await _bll.StudyGroupsService.AllAsync();
            return View(userStudyGroups);
        }

        // GET: StudyGroups
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.StudyGroupsService.AllAsync();
            return View(vm);
        }

        // GET: StudyGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroups = await _bll.StudyGroupsService.FindAsync(id.Value);
            
            if (studyGroups == null)
            {
                return NotFound();
            }

            return View(studyGroups);
        }

        // GET: StudyGroups/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email));
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName));
            var vm = new StudyGroupsVM();
            vm.StudyGroupsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.StudyGroupsCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.StudyGroupsVm.Course.Id),
                nameof(vm.StudyGroupsVm.Course.CourseName));
            return View(vm);
        }

        // POST: StudyGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudyGroupsVM studyGroups)
        {
            studyGroups.StudyGroupsVm.AppUserId = User.GetUserId();
            if (ModelState.IsValid)
            {
                _bll.StudyGroupsService.Add(studyGroups.StudyGroupsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName), studyGroups.CourseId);
            var vm = new StudyGroupsVM();
            vm.StudyGroupsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.StudyGroupsCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.StudyGroupsVm.Course.Id),
                nameof(vm.StudyGroupsVm.Course.CourseName));
            return View(vm);
        }

        // GET: StudyGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroups = await _bll.StudyGroupsService.FindAsync(id.Value);
            if (studyGroups == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email), studyGroups.AppUserId);
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName), studyGroups.CourseId);
            var vm = new StudyGroupsVM()
            {
                StudyGroupsVm = studyGroups
            };
            vm.StudyGroupsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.StudyGroupsCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.StudyGroupsVm.Course.Id),
                nameof(vm.StudyGroupsVm.Course.CourseName));
            return View(vm);
        }

        // POST: StudyGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StudyGroupsVM studyGroups)
        {
            if (id != studyGroups.StudyGroupsVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.StudyGroupsService.Update(studyGroups.StudyGroupsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email), studyGroups.AppUserId);
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName), studyGroups.CourseId);
            var vm = new StudyGroupsVM();
            vm.StudyGroupsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.StudyGroupsCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.StudyGroupsVm.Course.Id),
                nameof(vm.StudyGroupsVm.Course.CourseName));
            return View(vm);
        }

        // GET: StudyGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroups = await _bll.StudyGroupsService.FindAsync(id.Value);
            
            if (studyGroups == null)
            {
                return NotFound();
            }

            return View(studyGroups);
        }

        // POST: StudyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.StudyGroupsService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
