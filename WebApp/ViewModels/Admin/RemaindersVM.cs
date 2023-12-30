using BLL.DTO.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable 1591
namespace WebApp.ViewModels.Admin;

public class RemaindersVM
{
    public BLL.DTO.Remainders RemaindersVm { get; set; } = default!;
    
    public AppUser? AppUser { get; set; } = default!;
    public SelectList? RemaindersUserSelectList { get; set; }
}