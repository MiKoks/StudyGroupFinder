using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class GroupMeetingsRepository : EFBaseRepository<DALGroupMeetingsDTO,Domain.App.GroupMeetings, ApplicationDbContext>, IGroupMeetingsRepository
{
    public GroupMeetingsRepository(ApplicationDbContext dataContext,IMapper<DAL.DTO.DALGroupMeetingsDTO, Domain.App.GroupMeetings> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALGroupMeetingsDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.StudyGroup)
            .OrderBy(f => f.StudyGroup)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALGroupMeetingsDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(g => g.StudyGroup)
            .FirstOrDefaultAsync(m => m.Id == id));
    }
    
    public virtual async Task<IEnumerable<DALGroupMeetingsDTO>> AllAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.StudyGroup)
            .OrderBy(e => e.StudyGroup)
            .Where(e => e.StudyGroupId == id)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }
}