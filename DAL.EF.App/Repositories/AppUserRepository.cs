using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.DTO.Identity;
using DAL.EF.Base;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class AppUserRepository : EFBaseRepository<DAL.DTO.Identity.DALAppUserDTO, Domain.App.Identity.AppUser, ApplicationDbContext>, IAppUserRepository
{
    public AppUserRepository(ApplicationDbContext dataContext, IMapper<DALAppUserDTO, AppUser> mapper) : base(dataContext, mapper)
    {
    }
    
    
    public override async Task<IEnumerable<DALAppUserDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .OrderBy(f => f.FirstName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALAppUserDTO?> FindAsync(Guid id)
    {
        var res =  await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(res);
    }
}