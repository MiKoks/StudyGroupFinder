using AutoMapper;

namespace BLL.App;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<BLL.DTO.Courses, DAL.DTO.DALCoursesDTO>().ReverseMap();
        CreateMap<BLL.DTO.GroupMeetings, DAL.DTO.DALGroupMeetingsDTO>().ReverseMap();
        CreateMap<BLL.DTO.GroupJoinRequests, DAL.DTO.DALGroupJoinRequestsDTO>().ReverseMap();
        CreateMap<BLL.DTO.GroupMessages, DAL.DTO.DALGroupMessagesDTO>().ReverseMap();
        CreateMap<BLL.DTO.Notifications, DAL.DTO.DALNotificationsDTO>().ReverseMap();
        CreateMap<BLL.DTO.Remainders, DAL.DTO.DALRemaindersDTO>().ReverseMap();
        CreateMap<BLL.DTO.RoleWithinGroup, DAL.DTO.DALRoleWithinGroupDTO>().ReverseMap();
        CreateMap<BLL.DTO.StudyGroups, DAL.DTO.DALStudyGroupsDTO>().ReverseMap();
        CreateMap<BLL.DTO.UserAvailabilities, DAL.DTO.DALUserAvailabilitiesDTO>().ReverseMap();
        CreateMap<BLL.DTO.UserCourses, DAL.DTO.DALUserCoursesDTO>().ReverseMap();
        CreateMap<BLL.DTO.UserStudyGroups, DAL.DTO.DALUserStudyGroupsDTO>().ReverseMap();
        CreateMap<BLL.DTO.Identity.AppRefreshToken, DAL.DTO.Identity.DALAppRefreshTokenDTO>().ReverseMap();
        CreateMap<BLL.DTO.Identity.AppUser, DAL.DTO.Identity.DALAppUserDTO>().ReverseMap();
        CreateMap<BLL.DTO.Identity.AppRole, DAL.DTO.Identity.DALAppRoleDTO>().ReverseMap();
    }
}
