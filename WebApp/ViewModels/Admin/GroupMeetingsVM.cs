using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.Admin;
#pragma warning disable 1591
public class GroupMeetingsVM
{
    public BLL.DTO.GroupMeetings GroupMeetingsVm { get; set; } = default!;
    
    public SelectList? GroupMeetingsStudyGroupsSelectList { get; set; }
}