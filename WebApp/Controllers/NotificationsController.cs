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
    public class NotificationsController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;

        public NotificationsController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.NotificationsService.AllAsync();

            return View(vm);

        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _bll.NotificationsService.FindAsync(id.Value);
            if (notifications == null)
            {
                return NotFound();
            }

            return View(notifications);
        }

        // GET: Notifications/Create
        public Task<IActionResult> Create()
        {
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName));
            var vm = new NotificationsVM();
            vm.NotificationsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return Task.FromResult<IActionResult>(View(vm));
            
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( NotificationsVM notifications)
        {
            if (ModelState.IsValid)
            {
                _bll.NotificationsService.Add(notifications.NotificationsVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), notifications.UserId);
            var vm = new NotificationsVM();
            vm.NotificationsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _bll.NotificationsService.FindAsync(id.Value);
            if (notifications == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), notifications.UserId);
            var vm = new NotificationsVM()
            {
                NotificationsVm = notifications
            };
            vm.NotificationsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, NotificationsVM notifications)
        {
            if (id != notifications.NotificationsVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.NotificationsService.Update(notifications.NotificationsVm);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), notifications.UserId);
            var vm = new NotificationsVM();
            vm.NotificationsUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _bll.NotificationsService.FindAsync(id.Value);
            if (notifications == null)
            {
                return NotFound();
            }

            return View(notifications);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.NotificationsService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
