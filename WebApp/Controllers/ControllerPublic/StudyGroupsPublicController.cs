using BLL.Contracts.App;
using BLL.DTO;
using BLL.DTO.Identity;
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels.StudentUser.Test;
using AppUser = Domain.App.Identity.AppUser;

#pragma warning disable 1591
namespace WebApp.Controllers.ControllerPublic;

[Authorize]
public class StudyGroupsPublicController : Controller
{

private readonly IAppBLL _bll;
private readonly UserManager<AppUser> _userManager;

    public StudyGroupsPublicController(IAppBLL bll, UserManager<Domain.App.Identity.AppUser> userManager)
    {
        _bll = bll;
        _userManager = userManager;
    }

    // GET: Courses
    public async Task<IActionResult> Index()
    {
        
        var vm = new StudyGroupsPublicVM();
        vm.StudyGroupsPublicVmLoading = new StudyGroupsPublicVMLoading(); 
        vm.StudyGroupsPublicVmLoading.StudyGroupsPublic = await _bll.StudyGroupsService.AllAsync();
        
        // Load AppUsers
        vm.StudyGroupsPublicVmLoading.AppUsers = await _bll.AppUserService.AllAsync(); // Assuming you have a service for AppUsers
    
        // Load Courses
        vm.StudyGroupsPublicVmLoading.Courses = await _bll.CoursesService.AllAsync(); // Assuming you have a service for Courses
        
        /*vm.StudyGroupsUserSelectList = new SelectList(_userManager.Users,
            nameof(vm.AppUser.Id),
            nameof(vm.AppUser.FirstName));
        vm.StudyGroupsCoursesSelectList = new SelectList(await _bll.CoursesService.AllAsync(),
            nameof(vm.StudyGroupsVm.Course.Id),
            nameof(vm.StudyGroupsVm.Course.CourseName));*/
        
        return View(vm);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudyGroupsPublicVM studyGroupsPublic)
    {
        
        //studyGroupsPublic.StudyGroupsVm.AppUserId = User.GetUserId();
        
        studyGroupsPublic.StudyGroupsPublicVmUpdateData!.StudyGroupsPublic.CreatedAt = DateTime.Now;
        if (ModelState.IsValid)
        {
            {
                _bll.StudyGroupsService.Add(studyGroupsPublic.StudyGroupsPublicVmUpdateData.StudyGroupsPublic);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
        }

        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddNewUserToStudyGroup(GetStudyGroupsPublicVM studyGroupsPublic)
    {
        
        //studyGroupsPublic.StudyGroupsVm.AppUserId = User.GetUserId();
        
        studyGroupsPublic.GetStudyGroupsPublicVmUpdateData!.GetStudyGroupsPublic.CreatedAt = DateTime.Now;
        if (ModelState.IsValid)
        {
            var Muutuja = (await _bll.UserStudyGroupsService.AllAsync())
                .Where(x => x.StudyGroupsId.Equals(studyGroupsPublic.StudyGroupId))
                .Select(x => x.AppUser);
            
            if (!(studyGroupsPublic.GetStudyGroupsVm!.MaxGroupSize >= Muutuja.Count()))
            {
                _bll.StudyGroupsService.Add(studyGroupsPublic.GetStudyGroupsPublicVmUpdateData.GetStudyGroupsPublic);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
        }

        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> GetStudyGroupsInfo(Guid id)
    {
        var Muutuja = (await _bll.UserStudyGroupsService.AllAsync())
            .Where(x => x.StudyGroupsId.Equals(id))
            .Select(x => x.AppUser);
        var vm = new GetStudyGroupsPublicVM();

        vm.UsersSelectList = new SelectList(_userManager.Users,
            nameof(vm.AppUser.Id),
            nameof(vm.AppUser.FirstName));
        
        vm.GetStudyGroupsPublicVMLoading = new GetStudyGroupsPublicVMLoading
        {
            GetStudyGroupsPublicVM = await _bll.StudyGroupsService.FindAsync(id),
            GroupMembers = Muutuja,
        };
        vm.StudyGroupId = vm.GetStudyGroupsPublicVMLoading!.GetStudyGroupsPublicVM!.Id;
        return View(vm);
    }
    
}