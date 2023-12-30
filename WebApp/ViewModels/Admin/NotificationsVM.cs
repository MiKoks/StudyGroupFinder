using BLL.DTO.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable 1591
namespace WebApp.ViewModels.Admin;

public class NotificationsVM
{
    public BLL.DTO.Notifications NotificationsVm { get; set; } = default!;
    
    public AppUser? AppUser { get; set; } = default!;
    public SelectList? NotificationsUserSelectList { get; set; }
}