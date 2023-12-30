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
    public class RemaindersController : Controller
    {
        
        private readonly IAppBLL _bll;
        private readonly UserManager<AppUser> _userManager;
        
        public RemaindersController(IAppBLL bll, UserManager<AppUser> userManager)
        {
            _bll = bll;
            _userManager = userManager;
        }

        // GET: Remainders
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.RemaindersService.AllAsync();

            return View(vm);

        }

        // GET: Remainders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remainders = await _bll.RemaindersService.FindAsync(id.Value);
            if (remainders == null)
            {
                return NotFound();
            }

            return View(remainders);
        }

        // GET: Remainders/Create
        public Task<IActionResult> Create()
        {
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName));
            var vm = new RemaindersVM();
            vm.RemaindersUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return Task.FromResult<IActionResult>(View(vm));
        }

        // POST: Remainders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RemaindersVM remainders)
        {
            if (ModelState.IsValid)
            {
                _bll.RemaindersService.Add(remainders.RemaindersVm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), remainders.AppUserId);
            var vm = new RemaindersVM();
            vm.RemaindersUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // GET: Remainders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remainders = await _bll.RemaindersService.FindAsync(id.Value);
            if (remainders == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), remainders.AppUserId);
            var vm = new RemaindersVM()
            {
                RemaindersVm = remainders
            };
            vm.RemaindersUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // POST: Remainders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RemaindersVM remainders)
        {
            if (id != remainders.RemaindersVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.RemaindersService.Update(remainders.RemaindersVm);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_userManager.Users, nameof(AppUser.Id), nameof(AppUser.FullName), remainders.AppUserId);
            var vm = new RemaindersVM();
            vm.RemaindersUserSelectList = new SelectList(_userManager.Users,
                nameof(vm.AppUser.Id),
                nameof(vm.AppUser.FirstName));
            return View(vm);
        }

        // GET: Remainders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remainders = await _bll.RemaindersService.FindAsync(id.Value);
            if (remainders == null)
            {
                return NotFound();
            }

            return View(remainders);
        }

        // POST: Remainders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.RemaindersService.RemoveAsync(id);
            
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
