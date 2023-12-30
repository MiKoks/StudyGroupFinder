using BLL.Contracts.Base;
using DAL.Contracts.App;

namespace BLL.Contracts.App;

public interface IAppBLL : IBaseBLL
{
    IAppUserService AppUserService { get; }
    ICoursesService CoursesService { get; }
    IGroupJoinRequestsService GroupJoinRequestsService { get; }
    IGroupMeetingsService GroupMeetingsService { get; }
    IGroupMessagesService GroupMessagesService { get; }
    INotificationsService NotificationsService { get; }
    IRemaindersService RemaindersService { get; }
    IRoleWithinGroupService RoleWithinGroupService { get; }
    IStudyGroupsService StudyGroupsService { get; }
    IUserAvailabilitiesService UserAvailabilitiesService { get; }
    IUserCoursesService UserCoursesService { get; }
    IUserStudyGroupsService UserStudyGroupsService  { get; }
    IAppRefreshTokenService AppRefreshTokenService  { get; }
}