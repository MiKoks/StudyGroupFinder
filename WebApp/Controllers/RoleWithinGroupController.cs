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
using Microsoft.AspNetCore.Authorization;
using RoleWithinGroup = BLL.DTO.RoleWithinGroup;
#pragma warning disable 1591

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleWithinGroupController : Controller
    {
        
        private readonly IAppBLL _bll;
        
        public RoleWithinGroupController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: RoleWithinGroup
        public async Task<IActionResult> Index()
        {
            var vm = await _bll.RoleWithinGroupService.AllAsync();

            return View(vm);
        }

        // GET: RoleWithinGroup/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleWithinGroup = await _bll.RoleWithinGroupService.FindAsync(id.Value);
            if (roleWithinGroup == null)
            {
                return NotFound();
            }

            return View(roleWithinGroup);
        }

        // GET: RoleWithinGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleWithinGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BLL.DTO.RoleWithinGroup roleWithinGroup)
        {
            if (ModelState.IsValid)
            {
                _bll.RoleWithinGroupService.Add(roleWithinGroup);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleWithinGroup);
        }

        // GET: RoleWithinGroup/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleWithinGroup = await _bll.RoleWithinGroupService.FindAsync(id.Value);
            if (roleWithinGroup == null)
            {
                return NotFound();
            }
            return View(roleWithinGroup);
        }

        // POST: RoleWithinGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RoleWithinGroup roleWithinGroup)
        {
            if (id != roleWithinGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _bll.RoleWithinGroupService.Update(roleWithinGroup);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleWithinGroup);
        }

        // GET: RoleWithinGroup/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleWithinGroup = await _bll.RoleWithinGroupService.FindAsync(id.Value);
            
            if (roleWithinGroup == null)
            {
                return NotFound();
            }

            return View(roleWithinGroup);
        }

        // POST: RoleWithinGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.RoleWithinGroupService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
