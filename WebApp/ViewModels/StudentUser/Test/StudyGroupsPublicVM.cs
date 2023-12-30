using BLL.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using Public.DTO.v1;
#pragma warning disable 1591
namespace WebApp.ViewModels.StudentUser.Test;

public class StudyGroupsPublicVM
{

    public AppUser? AppUser { get; set; }
    public IEnumerable<AppUser>? AppUsers { get; set; }
    public IEnumerable<Courses>? Courses { get; set; }
    public BLL.DTO.StudyGroups? StudyGroupsVm { get; set; }
    
    //public SelectList? StudyGroupsUserSelectList { get; set; }
    //public SelectList? StudyGroupsCoursesSelectList { get; set; }

    public StudyGroupsPublicVMLoading? StudyGroupsPublicVmLoading { get; set; }
    public StudyGroupsPublicVMUpdateData? StudyGroupsPublicVmUpdateData { get; set; } = default!;
}

public class StudyGroupsPublicVMLoading
{
    public System.Collections.Generic.IEnumerable<BLL.DTO.StudyGroups>? StudyGroupsPublic { get; set; }
    public IEnumerable<BLL.DTO.Identity.AppUser> AppUsers { get; set; } = default!;
    public IEnumerable<Courses> Courses { get; set; } = default!;
}

public class StudyGroupsPublicVMUpdateData
{
    public BLL.DTO.StudyGroups StudyGroupsPublic { get; set; } = default!;
}