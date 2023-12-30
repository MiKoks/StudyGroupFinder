using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.DTO.Identity;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class RoleWithinGroupRepository : EFBaseRepository<DALRoleWithinGroupDTO, RoleWithinGroup, ApplicationDbContext>, IRoleWithinGroupRepository
{
    public RoleWithinGroupRepository(ApplicationDbContext dataContext,IMapper<DALRoleWithinGroupDTO, Domain.App.RoleWithinGroup> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALRoleWithinGroupDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .OrderBy(e => e.RoleName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALRoleWithinGroupDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id));
    }
}