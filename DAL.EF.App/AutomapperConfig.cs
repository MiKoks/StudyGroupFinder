using AutoMapper;
using DAL.DTO;
using DAL.DTO.Identity;

namespace DAL.EF.App;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<DALCoursesDTO, Domain.App.Courses>().ReverseMap();
        CreateMap<DALGroupJoinRequestsDTO, Domain.App.GroupJoinRequests>().ReverseMap();
        CreateMap<DALGroupMeetingsDTO, Domain.App.GroupMeetings>().ReverseMap();
        CreateMap<DALGroupMessagesDTO, Domain.App.GroupMessages>().ReverseMap();
        CreateMap<DALNotificationsDTO, Domain.App.Notifications>().ReverseMap();
        CreateMap<DALRemaindersDTO, Domain.App.Remainders>().ReverseMap();
        CreateMap<DALRoleWithinGroupDTO, Domain.App.RoleWithinGroup>().ReverseMap();
        CreateMap<DALStudyGroupsDTO, Domain.App.StudyGroups>().ReverseMap();
        CreateMap<DALUserAvailabilitiesDTO, Domain.App.UserAvailabilities>().ReverseMap();
        CreateMap<DALUserCoursesDTO, Domain.App.UserCourses>().ReverseMap();
        CreateMap<DALUserStudyGroupsDTO, Domain.App.UserStudyGroups>().ReverseMap();
        
        CreateMap<DALAppRefreshTokenDTO, Domain.App.Identity.AppRefreshToken>().ReverseMap();
        CreateMap<DALAppUserDTO, Domain.App.Identity.AppUser>().ReverseMap();
        CreateMap<DALAppRoleDTO, Domain.App.Identity.AppUser>().ReverseMap();
    }
}