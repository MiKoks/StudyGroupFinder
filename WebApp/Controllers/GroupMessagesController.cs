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
    public class GroupMessagesController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;
        
        
        public GroupMessagesController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: GroupMessages
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.GroupMessagesService.AllAsync();

            return View(vm);

        }

        // GET: GroupMessages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMessages = await _bll.GroupMessagesService.FindAsync(id.Value);
            if (groupMessages == null)
            {
                return NotFound();
            }

            return View(groupMessages);
        }

        // GET: GroupMessages/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["SenderUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.Email));
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(GroupMessages.StudyGroup.Id), nameof(GroupMessages.StudyGroup.GroupName));
            var vm = new GroupMessagesVM();
            
            vm.GroupMessagesSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupMessagesStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMessagesVm.StudyGroup.Id),
                nameof(vm.GroupMessagesVm.StudyGroup.GroupName));
            return View(vm);
        }

        // POST: GroupMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupMessagesVM groupMessages)
        {
            groupMessages.GroupMessagesVm.SenderUserId = User.GetUserId();
            if (ModelState.IsValid)
            {
                
                _bll.GroupMessagesService.Add(groupMessages.GroupMessagesVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SenderUserId"] = new SelectList(_context.Users, nameof(AppUser.Id), nameof(AppUser.Email), groupMessages.SenderUserId);
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupMessages.StudyGroupId);
            var vm = new GroupMessagesVM();
            
            vm.GroupMessagesSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupMessagesStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMessagesVm.StudyGroup.Id),
                nameof(vm.GroupMessagesVm.StudyGroup.GroupName));
            return View(vm);
        }

        // GET: GroupMessages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMessages = await _bll.GroupMessagesService.FindAsync(id.Value);
            if (groupMessages == null)
            {
                return NotFound();
            }
            //ViewData["SenderUserId"] = new SelectList(_context.Users, nameof(AppUser.Id), nameof(AppUser.Email), groupMessages.SenderUserId);
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupMessages.StudyGroupId);
            var vm = new GroupMessagesVM()
            {
                GroupMessagesVm = groupMessages
            };
            
            vm.GroupMessagesSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupMessagesStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMessagesVm.StudyGroup.Id),
                nameof(vm.GroupMessagesVm.StudyGroup.GroupName));
            return View(vm);
        }

        // POST: GroupMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, GroupMessagesVM groupMessages)
        {
            if (id != groupMessages.GroupMessagesVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.GroupMessagesService.Update(groupMessages.GroupMessagesVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SenderUserId"] = new SelectList(_context.Users, nameof(AppUser.Id), nameof(AppUser.Email), groupMessages.SenderUserId);
            //ViewData["StudyGroupId"] = new SelectList(_context.StudyGroups, nameof(StudyGroups.Id), nameof(StudyGroups.GroupName), groupMessages.StudyGroupId);
            var vm = new GroupMessagesVM();
            
            vm.GroupMessagesSenderUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            vm.GroupMessagesStudyGroupsSelectList = new SelectList(await _bll.StudyGroupsService.AllAsync(),
                nameof(vm.GroupMessagesVm.StudyGroup.Id),
                nameof(vm.GroupMessagesVm.StudyGroup.GroupName));
            return View(vm);
        }

        // GET: GroupMessages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMessages = await _bll.GroupMessagesService.FindAsync(id.Value);
            if (groupMessages == null)
            {
                return NotFound();
            }

            return View(groupMessages);
        }

        // POST: GroupMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.GroupMessagesService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
