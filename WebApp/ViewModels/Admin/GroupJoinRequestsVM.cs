using Microsoft.AspNetCore.Mvc.Rendering;
using Public.DTO.v1;

namespace WebApp.ViewModels.Admin;
#pragma warning disable 1591
public class GroupJoinRequestsVM
{
    public BLL.DTO.GroupJoinRequests GroupJoinRequestsVm { get; set; } = default!;
    
    public AppUser? AppUser { get; set; }
    public SelectList? GroupJoinRequestsStudyGroupsSelectList { get; set; }
    public SelectList? GroupJoinRequestsSenderUserSelectList { get; set; }
}