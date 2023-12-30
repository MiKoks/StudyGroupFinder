using BLL.Contracts.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.StudentUser.Test;
using Courses = BLL.DTO.Courses;
#pragma warning disable 1591

namespace WebApp.Controllers.ControllerRepositroy
{
    [Authorize]
    public class TestController : Controller
    {

        private readonly IAppBLL _bll;

        public TestController(IAppBLL bll)
        {

            _bll = bll;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            
            var vm = new TestVM();
            vm.TestVmLoading = new TestVMLoading(); 
            vm.TestVmLoading.Courses = await _bll.CoursesService.AllAsync();
            
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestVM courses)
        {
            if (ModelState.IsValid)
            {

                _bll.CoursesService.Add(courses.TestVmUpdateData.Courses);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
