using Microsoft.AspNetCore.Mvc.Rendering;
using Public.DTO.v1;
#pragma warning disable 1591
namespace WebApp.ViewModels.Admin;

public class UserStudyGroupsVM
{
    public BLL.DTO.UserStudyGroups UserStudyGroupsVm { get; set; } = default!;

    public AppUser? AppUser { get; set; } = default!;
    public SelectList? UserStudyGroupsRoleWithinGroupSelectList { get; set; }
    public SelectList? UserStudyGroupsAppUserSelectList { get; set; }
    public SelectList? UserStudyGroupsStudyGroupsSelectList { get; set; }
}