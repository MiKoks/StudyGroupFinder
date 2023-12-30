using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class GroupMeetingsService : BaseEntityService<BLL.DTO.GroupMeetings, DAL.DTO.DALGroupMeetingsDTO, IGroupMeetingsRepository>, IGroupMeetingsService
{
    protected IAppUOW Uow;

    public GroupMeetingsService(IAppUOW uow, IMapper<BLL.DTO.GroupMeetings, DAL.DTO.DALGroupMeetingsDTO> mapper)
        : base(uow.GroupMeetingsRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<GroupMeetings>> AllAsync()
    {
        return (await Uow.GroupMeetingsRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }
    
    public async Task<IEnumerable<GroupMeetings>> AllAsync(Guid id)
    {
        return (await Uow.GroupMeetingsRepository.AllAsync(id)).Select(e => Mapper.Map(e))!;
    }

    public new async Task<GroupMeetings?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.GroupMeetingsRepository.FindAsync(id));
    }

}