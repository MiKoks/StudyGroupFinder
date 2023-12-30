using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IAppUOW : IBaseUOW
{
    IAppUserRepository AppUserRepository { get; }
    ICoursesRepository CoursesRepository { get; }
    IGroupJoinRequestsRepository GroupJoinRequestsRepository { get; }
    IGroupMeetingsRepository GroupMeetingsRepository { get; }
    IGroupMessagesRepository GroupMessagesRepository { get; }
    INotificationsRepository NotificationsRepository { get; }
    IRemaindersRepository RemaindersRepository { get; }
    IRoleWithinGroupRepository RoleWithinGroupRepository { get; }
    IStudyGroupsRepository StudyGroupsRepository { get; }
    IUserAvailabilitiesRepository UserAvailabilitiesRepository { get; }
    IUserCoursesRepository UserCoursesRepository { get; }
    IUserStudyGroupsRepository UserStudyGroupsRepository { get; }
    IAppRefreshTokenRepository AppRefreshTokenRepository { get; }
}
