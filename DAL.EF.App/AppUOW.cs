using AutoMapper;
using DAL.Contracts.App;
using DAL.EF.App.Mappers;
using DAL.EF.App.Mappers.Identity;
using DAL.EF.App.Repositories;
using DAL.EF.Base;
using Public.DTO.Mappers;
using CoursesMapper = DAL.EF.App.Mappers.CoursesMapper;
using GroupMeetingsMapper = DAL.EF.App.Mappers.GroupMeetingsMapper;
using GroupMessagesMapper = DAL.EF.App.Mappers.GroupMessagesMapper;
using NotificationsMapper = DAL.EF.App.Mappers.NotificationsMapper;
using RemaindersMapper = DAL.EF.App.Mappers.RemaindersMapper;
using RoleWithinGroupMapper = DAL.EF.App.Mappers.RoleWithinGroupMapper;
using StudyGroupsMapper = DAL.EF.App.Mappers.StudyGroupsMapper;
using UserAvailabilitiesMapper = DAL.EF.App.Mappers.UserAvailabilitiesMapper;
using UserCoursesMapper = DAL.EF.App.Mappers.UserCoursesMapper;
using UserStudyGroupsMapper = DAL.EF.App.Mappers.UserStudyGroupsMapper;

namespace DAL.EF.App;

public class AppUOW :EFBaseUOW<ApplicationDbContext>, IAppUOW
{
    private readonly AutoMapper.IMapper _mapper;
    
    public AppUOW(ApplicationDbContext dataContext, IMapper mapper) : base(dataContext)
    {
        _mapper = mapper;
    }
    
    private IAppUserRepository? _appUserRepository;
    private ICoursesRepository? _courseRepository;
    private IGroupJoinRequestsRepository? _groupJoinRequestsRepository;
    private IGroupMeetingsRepository? _groupMeetingsRepository;
    private IGroupMessagesRepository? _groupMessagesRepository;
    private INotificationsRepository? _notificationsRepository;
    private IRemaindersRepository? _remaindersRepository;
    private IRoleWithinGroupRepository? _roleWithinGroupRepository;
    private IStudyGroupsRepository? _studyGroupsRepository;
    private IUserAvailabilitiesRepository? _userAvailabilitiesRepository;
    private IUserCoursesRepository? _userCoursesRepository;
    private IUserStudyGroupsRepository? _userStudyGroupsRepository;
    private IAppRefreshTokenRepository? _appRefreshTokenRepository;

    public IAppUserRepository AppUserRepository =>
        _appUserRepository ??= new AppUserRepository(UowDbContext, new AppUserMapper(_mapper));
    public ICoursesRepository CoursesRepository => _courseRepository ??= new CoursesRepository(UowDbContext, new CoursesMapper(_mapper));
    public IGroupJoinRequestsRepository GroupJoinRequestsRepository => _groupJoinRequestsRepository ??= new GroupJoinRequestsRepository(UowDbContext, new GroupJoinRequestMapper(_mapper));
    public IGroupMeetingsRepository GroupMeetingsRepository => _groupMeetingsRepository ??= new GroupMeetingsRepository(UowDbContext, new GroupMeetingsMapper(_mapper));
    public IGroupMessagesRepository GroupMessagesRepository => _groupMessagesRepository ??= new GroupMessagesRepository(UowDbContext, new GroupMessagesMapper(_mapper));
    public INotificationsRepository NotificationsRepository => _notificationsRepository ??= new NotificationsRepository(UowDbContext, new NotificationsMapper(_mapper));
    public IRemaindersRepository RemaindersRepository => _remaindersRepository ??= new RemaindersRepository(UowDbContext, new RemaindersMapper(_mapper));
    public IRoleWithinGroupRepository RoleWithinGroupRepository => _roleWithinGroupRepository ??= new RoleWithinGroupRepository(UowDbContext, new RoleWithinGroupMapper(_mapper));
    public IStudyGroupsRepository StudyGroupsRepository => _studyGroupsRepository ??= new StudyGroupsRepository(UowDbContext, new StudyGroupsMapper(_mapper));
    public IUserAvailabilitiesRepository UserAvailabilitiesRepository => _userAvailabilitiesRepository ??= new UserAvailabilitiesRepository(UowDbContext, new UserAvailabilitiesMapper(_mapper));
    public IUserCoursesRepository UserCoursesRepository => _userCoursesRepository ??= new UserCoursesRepository(UowDbContext, new UserCoursesMapper(_mapper));
    public IUserStudyGroupsRepository UserStudyGroupsRepository => _userStudyGroupsRepository ??= new UserStudyGroupsRepository(UowDbContext, new UserStudyGroupsMapper(_mapper));
    public IAppRefreshTokenRepository AppRefreshTokenRepository => _appRefreshTokenRepository ??= new AppRefreshTokenRepository(UowDbContext, new AppRefreshTokenMapper(_mapper));
    
}