using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class GroupJoinRequestsService : BaseEntityService<BLL.DTO.GroupJoinRequests, DAL.DTO.DALGroupJoinRequestsDTO, IGroupJoinRequestsRepository>, IGroupJoinRequestsService
{
    protected IAppUOW Uow;

    public GroupJoinRequestsService(IAppUOW uow, IMapper<BLL.DTO.GroupJoinRequests, DAL.DTO.DALGroupJoinRequestsDTO> mapper)
        : base(uow.GroupJoinRequestsRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<GroupJoinRequests>> AllAsync(Guid userId)
    {
        return (await Uow.GroupJoinRequestsRepository.AllAsync(userId)).Select(e => Mapper.Map(e))!;
    }

    public async Task<GroupJoinRequests?> FindAsync(Guid id, Guid userId)
    {
        return Mapper.Map(await Uow.GroupJoinRequestsRepository.FindAsync(id, userId));
    }

    public async Task<GroupJoinRequests?> RemoveAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }
}