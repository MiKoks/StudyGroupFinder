using AutoMapper;
using BLL.App.Mappers;
using BLL.App.Services;
using BLL.Base;
using BLL.Contracts.App;
using DAL.Contracts.App;

namespace BLL.App;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
{
    protected IAppUOW Uow;
    private readonly IMapper _mapper;

    public AppBLL(IAppUOW uow, IMapper mapper) : base(uow)
    {
        Uow = uow;
        _mapper = mapper;
    }
    
    private ICoursesService? _courses;
    private IGroupJoinRequestsService? _groupJoinRequests;
    private IGroupMeetingsService? _groupMeetings;
    private IGroupMessagesService? _groupMessages;
    private INotificationsService? _notifications;
    private IRemaindersService? _remainders;
    private IRoleWithinGroupService? _roleWithinGroup;
    private IStudyGroupsService? _studyGroups;
    private IUserAvailabilitiesService? _userAvailabilities;
    private IUserCoursesService? _userCourses;
    private IUserStudyGroupsService? _userStudyGroups;
    private IAppRefreshTokenService? _appRefreshToken;
    private IAppUserService? _appUserService;
    
    public IAppUserService AppUserService => _appUserService ??= new AppUserService(Uow, new AppUserMapper(_mapper));
    public ICoursesService CoursesService => _courses ??= new CoursesService(Uow, new CoursesMapper(_mapper));
    public IGroupJoinRequestsService GroupJoinRequestsService => _groupJoinRequests ??= new GroupJoinRequestsService(Uow, new GroupJoinRequestsMapper(_mapper));
    public IGroupMeetingsService GroupMeetingsService => _groupMeetings ??= new GroupMeetingsService(Uow, new GroupMeetingsMapper(_mapper));
    public IGroupMessagesService GroupMessagesService => _groupMessages ??= new GroupMessagesService(Uow, new GroupMessagesMapper(_mapper));
    public INotificationsService NotificationsService => _notifications ??= new NotificationsService(Uow, new NotificationsMapper(_mapper));
    public IRemaindersService RemaindersService => _remainders ??= new RemaindersService(Uow, new RemaindersMapper(_mapper));
    public IRoleWithinGroupService RoleWithinGroupService => _roleWithinGroup ??= new RoleWithinGroupService(Uow, new RoleWithinGroupMapper(_mapper));
    public IStudyGroupsService StudyGroupsService => _studyGroups ??= new StudyGroupsService(Uow, new StudyGroupsMapper(_mapper));
    public IUserAvailabilitiesService UserAvailabilitiesService => _userAvailabilities ??= new UserAvailabilitiesService(Uow, new UserAvailabilitiesMapper(_mapper));
    public IUserCoursesService UserCoursesService => _userCourses ??= new UserCoursesService(Uow, new UserCoursesMapper(_mapper));
    public IUserStudyGroupsService UserStudyGroupsService => _userStudyGroups ??= new UserStudyGroupsService(Uow, new UserStudyGroupsMapper(_mapper));
    public IAppRefreshTokenService AppRefreshTokenService => _appRefreshToken ??= new AppRefreshTokenService(Uow, new AppRefreshTokenMapper(_mapper));
}
