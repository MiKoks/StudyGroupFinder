using BLL.DTO.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable 1591
namespace WebApp.ViewModels.Admin;

public class UserAvailabilitiesVM
{
    public BLL.DTO.UserAvailabilities UserAvailabilitiesVm { get; set; } = default!;

    public AppUser? AppUser { get; set; } = default!;
    
    public SelectList? UserAvailabilitiesUserSelectList { get; set; }
}