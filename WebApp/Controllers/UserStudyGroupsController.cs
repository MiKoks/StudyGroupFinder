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

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserStudyGroupsController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;
        
        public UserStudyGroupsController( IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: UserStudyGroups
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.UserStudyGroupsService.AllAsync();

            return View(vm);

        }

        // GET: UserStudyGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStudyGroups = await _bll.UserStudyGroupsService.FindAsync(id.Value);
            if (userStudyGroups == null)
            {
                return NotFound();
            }

            return View(userStudyGroups);
        }

        // GET: UserStudyGroups/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["RoleWithinGroupId"] = new SelectList(_context.RolesWithinGroup, nameof(RoleWithinGroup.Id), nameof(RoleWithinGroup.RoleName));
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FirstName));
            //ViewData["StudyGroupsId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName));
            var vm = new UserStudyGroupsVM();
            vm.UserStudyGroupsAppUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserStudyGroupsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.StudyGroups.Id),
                nameof(vm.UserStudyGroupsVm.StudyGroups.GroupName));
            vm.UserStudyGroupsRoleWithinGroupSelectList = new SelectList(await _bll.RoleWithinGroupService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.Id),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.RoleName));
            return View(vm);
        }

        // POST: UserStudyGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserStudyGroupsVM userStudyGroups)
        {
            if (ModelState.IsValid)
            {
                _bll.UserStudyGroupsService.Add(userStudyGroups.UserStudyGroupsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoleWithinGroupId"] = new SelectList(_context.RolesWithinGroup, nameof(RoleWithinGroup.Id), nameof(RoleWithinGroup.RoleName), userStudyGroups.RoleWithinGroupId);
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FirstName), userStudyGroups.AppUserId);
            //ViewData["StudyGroupsId"] = new SelectList(_context.UserStudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), userStudyGroups.StudyGroupsId);
            var vm = new UserStudyGroupsVM();
            vm.UserStudyGroupsAppUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserStudyGroupsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.StudyGroups.Id),
                nameof(vm.UserStudyGroupsVm.StudyGroups.GroupName));
            vm.UserStudyGroupsRoleWithinGroupSelectList = new SelectList(await _bll.RoleWithinGroupService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.Id),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.RoleName));
            return View(vm);
        }

        // GET: UserStudyGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStudyGroups = await _bll.UserStudyGroupsService.FindAsync(id.Value);
            if (userStudyGroups == null)
            {
                return NotFound();
            }
            //ViewData["RoleWithinGroupId"] = new SelectList(_context.RolesWithinGroup, nameof(RoleWithinGroup.Id), nameof(RoleWithinGroup.RoleName), userStudyGroups.RoleWithinGroupId);
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FirstName), userStudyGroups.AppUserId);
            //ViewData["StudyGroupsId"] = new SelectList(_context.UserStudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), userStudyGroups.StudyGroupsId);
            var vm = new UserStudyGroupsVM()
            {
                UserStudyGroupsVm = userStudyGroups
            };
            vm.UserStudyGroupsAppUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserStudyGroupsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.StudyGroups.Id),
                nameof(vm.UserStudyGroupsVm.StudyGroups.GroupName));
            vm.UserStudyGroupsRoleWithinGroupSelectList = new SelectList(await _bll.RoleWithinGroupService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.Id),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.RoleName));
            return View(vm);
        }

        // POST: UserStudyGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,UserStudyGroupsVM userStudyGroups)
        {
            if (id != userStudyGroups.UserStudyGroupsVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.UserStudyGroupsService.Update(userStudyGroups.UserStudyGroupsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoleWithinGroupId"] = new SelectList(_context.RolesWithinGroup, nameof(RoleWithinGroup.Id), nameof(RoleWithinGroup.RoleName), userStudyGroups.RoleWithinGroupId);
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FirstName), userStudyGroups.AppUserId);
            //ViewData["StudyGroupsId"] = new SelectList(_context.UserStudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), userStudyGroups.StudyGroupsId);
            var vm = new UserStudyGroupsVM();
            vm.UserStudyGroupsAppUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.UserStudyGroupsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.StudyGroups.Id),
                nameof(vm.UserStudyGroupsVm.StudyGroups.GroupName));
            vm.UserStudyGroupsRoleWithinGroupSelectList = new SelectList(await _bll.RoleWithinGroupService.AllAsync(),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.Id),
                nameof(vm.UserStudyGroupsVm.RoleWithinGroup.RoleName));
            return View(vm);
        }

        // GET: UserStudyGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userStudyGroups = await _bll.UserStudyGroupsService.FindAsync(id.Value);
            if (userStudyGroups == null)
            {
                return NotFound();
            }

            return View(userStudyGroups);
        }

        // POST: UserStudyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.UserStudyGroupsService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
