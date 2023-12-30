using Microsoft.AspNetCore.Mvc.Rendering;
using Public.DTO.v1;
#pragma warning disable 1591
namespace WebApp.ViewModels.Admin;

public class GroupMessagesVM
{
    public BLL.DTO.GroupMessages GroupMessagesVm { get; set; } = default!;
    
    public AppUser? AppUser { get; set; } = default!;
    
    public SelectList? GroupMessagesStudyGroupsSelectList { get; set; }
    public SelectList? GroupMessagesSenderUserSelectList { get; set; }
}