using AutoMapper;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class StudyGroupsRepository : EFBaseRepository<DALStudyGroupsDTO, Domain.App.StudyGroups, ApplicationDbContext>, IStudyGroupsRepository
{
    public StudyGroupsRepository(ApplicationDbContext dataContext,IMapper<DALStudyGroupsDTO, Domain.App.StudyGroups> mapper) : base(dataContext, mapper)
    {
    }
    
    public async Task<IEnumerable<DALStudyGroupsDTO>> GetStudyGroupsByUserId(Guid userId)
    {
        return await RepositoryDbSet
            .Include(s => s.AppUser)
            .Include(s => s.Course)
            .Where(s => s.AppUserId == userId)
            .OrderBy(e => e.GroupName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<IEnumerable<DALStudyGroupsDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .Include(f => f.Course)
            .OrderBy(e => e.GroupName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }
    public virtual async Task<IEnumerable<DALStudyGroupsDTO>> AllAsync(Guid userId)
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .Include(f => f.Course)
            .OrderBy(e => e.GroupName)
            .Select(x=>Mapper.Map(x)!)
            .Where(t => t.AppUserId == userId)
            .ToListAsync();
    }

    public override async Task<DALStudyGroupsDTO?> FindAsync(Guid id)
    {
        var res = await RepositoryDbSet
            .Include(s => s.AppUser)
            .Include(s => s.Course)
            .FirstOrDefaultAsync(m => m.Id == id);

        return Mapper.Map(res);
    }
    
    
}