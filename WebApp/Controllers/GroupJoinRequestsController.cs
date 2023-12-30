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
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels.Admin;
#pragma warning disable 1591

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class GroupJoinRequestsController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;

        public GroupJoinRequestsController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: GroupJoinRequests
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.GroupJoinRequestsService.AllAsync();
            return View(vm);
        }

        // GET: GroupJoinRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupJoinRequests = await _bll.GroupJoinRequestsService.FindAsync(id.Value);
            if (groupJoinRequests == null)
            {
                return NotFound();
            }

            return View(groupJoinRequests);
        }

        // GET: GroupJoinRequests/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["SenderUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email));
            //ViewData["StudyGroupsId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName));

            var vm = new GroupJoinRequestsVM();
            vm.GroupJoinRequestsSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupJoinRequestsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.Id),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.GroupName));
            return View(vm);
        }

        // POST: GroupJoinRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupJoinRequestsVM groupJoinRequests)
        {
            
            if (ModelState.IsValid)
            {
                _bll.GroupJoinRequestsService.Add(groupJoinRequests.GroupJoinRequestsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var vm = new GroupJoinRequestsVM();
            vm.GroupJoinRequestsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.Id),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.GroupName));
            vm.GroupJoinRequestsSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
            
        }

        // GET: GroupJoinRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupJoinRequests = await _bll.GroupJoinRequestsService.FindAsync(id.Value);
            if (groupJoinRequests == null)
            {
                return NotFound();
            }
            //ViewData["SenderUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email), groupJoinRequests.Id);
            //ViewData["StudyGroupsId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupJoinRequests.Id);
            var vm = new GroupJoinRequestsVM()
            {
                GroupJoinRequestsVm = groupJoinRequests
            };
            vm.GroupJoinRequestsSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupJoinRequestsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.Id),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.GroupName));
            return View(vm);
        }

        // POST: GroupJoinRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GroupJoinRequestsVM groupJoinRequests)
        {
            if (id != groupJoinRequests.GroupJoinRequestsVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                _bll.GroupJoinRequestsService.Update(groupJoinRequests.GroupJoinRequestsVm);
                await _bll.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SenderUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email), groupJoinRequests.Id);
            //ViewData["StudyGroupsId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupJoinRequests.Id);
            var vm = new GroupJoinRequestsVM();
            vm.GroupJoinRequestsSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupJoinRequestsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.Id),
                nameof(vm.GroupJoinRequestsVm.StudyGroups.GroupName));
            return View(vm);
        }

        // GET: GroupJoinRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupJoinRequests = await _bll.GroupJoinRequestsService.FindAsync(id.Value);
            if (groupJoinRequests == null)
            {
                return NotFound();
            }

            return View(groupJoinRequests);
        }

        // POST: GroupJoinRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.GroupJoinRequestsService.RemoveAsync(id);
            
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
