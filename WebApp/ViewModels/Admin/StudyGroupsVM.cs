using Microsoft.AspNetCore.Mvc.Rendering;
using Public.DTO.v1;

namespace WebApp.ViewModels.Admin;
#pragma warning disable 1591
public class StudyGroupsVM
{
    public BLL.DTO.StudyGroups StudyGroupsVm { get; set; } = default!;
    
    public AppUser? AppUser { get; set; }
    
    public SelectList? StudyGroupsUserSelectList { get; set; }
    public SelectList? StudyGroupsCoursesSelectList { get; set; }
}