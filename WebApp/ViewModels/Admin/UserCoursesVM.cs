using BLL.DTO.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable 1591
namespace WebApp.ViewModels.Admin;

public class UserCoursesVM
{
    public BLL.DTO.UserCourses UserCoursesVm { get; set; } = default!;
    
    public AppUser? AppUser { get; set; } = default!;
    
    public SelectList? UserCoursesUserSelectList { get; set; }
    public SelectList? UserCoursesCoursesSelectList { get; set; }
}