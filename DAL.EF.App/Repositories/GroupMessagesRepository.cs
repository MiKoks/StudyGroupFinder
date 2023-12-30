using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class GroupMessagesRepository  : EFBaseRepository<DALGroupMessagesDTO, Domain.App.GroupMessages, ApplicationDbContext>, IGroupMessagesRepository
{
    public GroupMessagesRepository(ApplicationDbContext dataContext,IMapper<DALGroupMessagesDTO, Domain.App.GroupMessages> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALGroupMessagesDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.StudyGroup)
            .Include(e => e.SenderUser)
            .OrderBy(f => f.StudyGroup)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALGroupMessagesDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(g => g.StudyGroup)
            .Include(g => g.SenderUser)
            .FirstOrDefaultAsync(m => m.Id == id));
    }
}