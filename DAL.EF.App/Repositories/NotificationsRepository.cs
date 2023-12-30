using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class NotificationsRepository  : EFBaseRepository<DALNotificationsDTO, Domain.App.Notifications, ApplicationDbContext>, INotificationsRepository
{
    public NotificationsRepository(ApplicationDbContext dataContext,IMapper<DALNotificationsDTO, Domain.App.Notifications> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALNotificationsDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.User)
            .OrderBy(f => f.User)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALNotificationsDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(g => g.User)
            
            .FirstOrDefaultAsync(m => m.Id == id));
    }
}