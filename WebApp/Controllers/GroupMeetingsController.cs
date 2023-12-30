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
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;
using Public.DTO.v1;
using WebApp.ViewModels.Admin;
#pragma warning disable 1591

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class GroupMeetingsController : Controller
    {
        
        private readonly IAppBLL _bll;

        public GroupMeetingsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: GroupMeetings
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.GroupMeetingsService.AllAsync();

            return View(vm);

        }

        // GET: GroupMeetings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMeetings = await _bll.GroupMeetingsService.FindAsync(id.Value);
            if (groupMeetings == null)
            {
                return NotFound();
            }

            return View(groupMeetings);
        }

        // GET: GroupMeetings/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName));
            var vm = new GroupMeetingsVM();
            vm.GroupMeetingsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMeetingsVm.StudyGroup.Id),
                nameof(vm.GroupMeetingsVm.StudyGroup.GroupName));
            return View(vm);
        }

        // POST: GroupMeetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupMeetingsVM groupMeetings)
        {
            
            if (ModelState.IsValid)
            {
                _bll.GroupMeetingsService.Add(groupMeetings.GroupMeetingsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupMeetings.StudyGroupId);

            var vm = new GroupMeetingsVM();
            vm.GroupMeetingsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMeetingsVm.StudyGroup.Id),
                nameof(vm.GroupMeetingsVm.StudyGroup.GroupName));

            return View(vm);
            
        }

        // GET: GroupMeetings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMeetings = await _bll.GroupMeetingsService.FindAsync(id.Value);
            if (groupMeetings == null)
            {
                return NotFound();
            }
            var vm = new GroupMeetingsVM()
            {
                GroupMeetingsVm = groupMeetings
            };
            vm.GroupMeetingsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMeetingsVm.StudyGroup.Id),
                nameof(vm.GroupMeetingsVm.StudyGroup.GroupName));

            return View(vm);
        }

        // POST: GroupMeetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GroupMeetingsVM groupMeetings)
        {
            if (id != groupMeetings.GroupMeetingsVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _bll.GroupMeetingsService.Update(groupMeetings.GroupMeetingsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupMeetings.StudyGroupId);
            var vm = new GroupMeetingsVM();
            vm.GroupMeetingsStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMeetingsVm.StudyGroup.Id),
                nameof(vm.GroupMeetingsVm.StudyGroup.GroupName));

            return View(vm);
        }

        // GET: GroupMeetings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMeetings = await _bll.GroupMeetingsService.FindAsync(id.Value);
            if (groupMeetings == null)
            {
                return NotFound();
            }

            return View(groupMeetings);
        }

        // POST: GroupMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.GroupMeetingsService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
