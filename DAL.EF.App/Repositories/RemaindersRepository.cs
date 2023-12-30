using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class RemaindersRepository  : EFBaseRepository<DALRemaindersDTO,Remainders, ApplicationDbContext>, IRemaindersRepository
{
    public RemaindersRepository(ApplicationDbContext dataContext,IMapper<DALRemaindersDTO, Domain.App.Remainders> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALRemaindersDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .OrderBy(e => e.ReminderAt)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALRemaindersDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(g => g.AppUser)
            .FirstOrDefaultAsync(m => m.Id == id));
    }
}