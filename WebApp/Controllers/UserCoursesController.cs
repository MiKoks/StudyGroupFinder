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
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels.Admin;
#pragma warning disable 1591

namespace WebApp.Controllers;

[Authorize(Roles = "admin")]
    public class UserCoursesController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;
        
        public UserCoursesController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: UserCourses
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.UserCoursesService.AllAsync();

            return View(vm);

        }

        // GET: UserCourses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourses = await _bll.UserCoursesService.FindAsync(id.Value);
            if (userCourses == null)
            {
                return NotFound();
            }

            return View(userCourses);
        }

        // GET: UserCourses/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName));
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName));
            var vm = new UserCoursesVM();
            vm.UserCoursesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserCoursesCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.UserCoursesVm.Course.Id),
                nameof(vm.UserCoursesVm.Course.CourseName));
            return View(vm);
        }

        // POST: UserCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCoursesVM userCourses)
        {
            if (ModelState.IsValid)
            {
                _bll.UserCoursesService.Add(userCourses.UserCoursesVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), userCourses.AppUserId);
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName), userCourses.CourseId);
            var vm = new UserCoursesVM();
            vm.UserCoursesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserCoursesCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.UserCoursesVm.Course.Id),
                nameof(vm.UserCoursesVm.Course.CourseName));
            return View(vm);
        }

        // GET: UserCourses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourses = await _bll.UserCoursesService.FindAsync(id.Value);
            if (userCourses == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), userCourses.AppUserId);
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName), userCourses.CourseId);
            var vm = new UserCoursesVM()
            {
                UserCoursesVm = userCourses
            };
            vm.UserCoursesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserCoursesCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.UserCoursesVm.Course.Id),
                nameof(vm.UserCoursesVm.Course.CourseName));
            return View(vm);
        }

        // POST: UserCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserCoursesVM userCourses)
        {
            if (id != userCourses.UserCoursesVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.UserCoursesService.Update(userCourses.UserCoursesVm);
                await _bll.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), userCourses.AppUserId);
            //ViewData["CourseId"] = new SelectList(_context.Courses, nameof(Courses.Id), nameof(Courses.CourseName), userCourses.CourseId);
            var vm = new UserCoursesVM();
            vm.UserCoursesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserCoursesCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
                nameof(vm.UserCoursesVm.Course.Id),
                nameof(vm.UserCoursesVm.Course.CourseName));
            return View(vm);
        }

        // GET: UserCourses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCourses = await _bll.UserCoursesService.FindAsync(id.Value);
            if (userCourses == null)
            {
                return NotFound();
            }

            return View(userCourses);
        }

        // POST: UserCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.UserCoursesService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

