using BLL.DTO;
using BLL.DTO.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.StudentUser.Test;

public class GetStudyGroupsPublicVM

{
    public GetStudyGroupsPublicVMLoading? GetStudyGroupsPublicVMLoading { get; set; }
    public GetStudyGroupsPublicVMUpdateData? GetStudyGroupsPublicVmUpdateData { get; set; }
    
    public BLL.DTO.StudyGroups? GetStudyGroupsVm { get; set; }
    public SelectList? UsersSelectList { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid StudyGroupId { get; set; }
}

public class GetStudyGroupsPublicVMLoading
{
    
    public BLL.DTO.StudyGroups? GetStudyGroupsPublicVM { get; set; }
    public IEnumerable<AppUser>? GroupMembers { get; set; }
}

public class GetStudyGroupsPublicVMUpdateData
{
    public BLL.DTO.StudyGroups GetStudyGroupsPublic { get; set; } = default!;
}