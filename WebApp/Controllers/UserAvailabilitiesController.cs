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
    public class UserAvailabilitiesController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;
        
        public UserAvailabilitiesController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: UserAvailabilities
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.UserAvailabilitiesService.AllAsync();

            return View(vm);

        }

        // GET: UserAvailabilities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAvailabilities = await _bll.UserAvailabilitiesService.FindAsync(id.Value);
            if (userAvailabilities == null)
            {
                return NotFound();
            }

            return View(userAvailabilities);
        }

        // GET: UserAvailabilities/Create
        public Task<IActionResult> Create()
        {
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName));
            var vm = new UserAvailabilitiesVM();
            vm.UserAvailabilitiesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return Task.FromResult<IActionResult>(View(vm));
        }

        // POST: UserAvailabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( UserAvailabilitiesVM userAvailabilities)
        {
            if (ModelState.IsValid)
            {
                userAvailabilities.UserAvailabilitiesVm.Id = Guid.NewGuid();
                _bll.UserAvailabilitiesService.Add(userAvailabilities.UserAvailabilitiesVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), userAvailabilities.UserId);
            var vm = new UserAvailabilitiesVM();
            vm.UserAvailabilitiesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // GET: UserAvailabilities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAvailabilities = await _bll.UserAvailabilitiesService.FindAsync(id.Value);
            if (userAvailabilities == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), userAvailabilities.UserId);
            var vm = new UserAvailabilitiesVM()
            {
                UserAvailabilitiesVm = userAvailabilities
            };
            vm.UserAvailabilitiesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // POST: UserAvailabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,UserAvailabilitiesVM userAvailabilities)
        {
            if (id != userAvailabilities.UserAvailabilitiesVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.UserAvailabilitiesService.Update(userAvailabilities.UserAvailabilitiesVm);
                await _bll.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), userAvailabilities.UserId);
            var vm = new UserAvailabilitiesVM();
            vm.UserAvailabilitiesUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // GET: UserAvailabilities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAvailabilities = await _bll.UserAvailabilitiesService.FindAsync(id.Value);
            if (userAvailabilities == null)
            {
                return NotFound();
            }

            return View(userAvailabilities);
        }

        // POST: UserAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.UserAvailabilitiesService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
