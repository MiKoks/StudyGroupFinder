using AutoMapper;

namespace Public.DTO;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<BLL.DTO.Identity.AppUser, v1.AppUser>().ReverseMap();
        CreateMap<BLL.DTO.Courses, v1.CoursesDTO>().ReverseMap();
        CreateMap<BLL.DTO.GroupJoinRequests, v1.GroupJoinRequestsDTO>().ReverseMap();
        CreateMap<BLL.DTO.GroupMeetings, v1.GroupMeetingsDTO>().ReverseMap();
        CreateMap<BLL.DTO.GroupMessages, v1.GroupMessagesDTO>().ReverseMap();
        CreateMap<BLL.DTO.Notifications, v1.NotificationsDTO>().ReverseMap();
        CreateMap<BLL.DTO.Remainders, v1.RemaindersDTO>().ReverseMap();
        CreateMap<BLL.DTO.RoleWithinGroup, v1.RoleWithinGroupDTO>().ReverseMap();
        CreateMap<BLL.DTO.StudyGroups, v1.StudyGroupsDTO>().ReverseMap();
        CreateMap<BLL.DTO.UserAvailabilities, v1.UserAvailabilitiesDTO>().ReverseMap();
        CreateMap<BLL.DTO.UserCourses, v1.UserCoursesDTO>().ReverseMap();
        CreateMap<BLL.DTO.UserStudyGroups, v1.UserStudyGroupsDTO>().ReverseMap();
        CreateMap<BLL.DTO.Identity.AppRefreshToken, v1.AppRefreshToken>().ReverseMap();
    }
    
}