using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class UserAvailabilitiesRepository  : EFBaseRepository<DALUserAvailabilitiesDTO, UserAvailabilities, ApplicationDbContext>, IUserAvailabilitiesRepository
{
    public UserAvailabilitiesRepository(ApplicationDbContext dataContext,IMapper<DALUserAvailabilitiesDTO, Domain.App.UserAvailabilities> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALUserAvailabilitiesDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(f => f.User)
            .OrderBy(f => f.User!.FirstName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALUserAvailabilitiesDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(s => s.User)
            .FirstOrDefaultAsync(m => m.Id == id));
    }
}