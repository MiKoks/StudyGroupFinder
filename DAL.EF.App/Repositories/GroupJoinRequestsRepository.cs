using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class GroupJoinRequestsRepository : EFBaseRepository<DALGroupJoinRequestsDTO, Domain.App.GroupJoinRequests, ApplicationDbContext>, IGroupJoinRequestsRepository
{
    public GroupJoinRequestsRepository(ApplicationDbContext dataContext,IMapper<DAL.DTO.DALGroupJoinRequestsDTO, Domain.App.GroupJoinRequests> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALGroupJoinRequestsDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.StudyGroups)
            .Include(e => e.SenderUser)
            .OrderBy(e => e.StudyGroups)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALGroupJoinRequestsDTO?> FindAsync(Guid id)
    {
        var res =  await RepositoryDbSet
            .Include(e => e.SenderUser)
            .Include(e => e.StudyGroups)
            .FirstOrDefaultAsync(e => e.Id == id);
        return Mapper.Map(res);
    }

    public async Task<IEnumerable<DALGroupJoinRequestsDTO>> AllAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.StudyGroups)
            .Include(e => e.SenderUser)
            .OrderBy(e => e.StudyGroups)
            .Where(e => e.StudyGroupsId == id)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public async Task<DALGroupJoinRequestsDTO?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.SenderUser)
            .Select(x=>Mapper.Map(x)!)
            .FirstOrDefaultAsync(e => e.Id == id && e.SenderUserId == userId);
    }

    public async Task<DALGroupJoinRequestsDTO?> RemoveAsync(Guid id, Guid userId)
    {
        var groupJoinRequest = await FindAsync(id, userId);
        return groupJoinRequest == null ? null : Remove(groupJoinRequest);
    }

    public async Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet.AnyAsync(e => e.Id == id && e.SenderUserId == userId);
    }
}