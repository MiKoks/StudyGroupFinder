using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class UserStudyGroupsRepository  : EFBaseRepository<DALUserStudyGroupsDTO, UserStudyGroups, ApplicationDbContext>, IUserStudyGroupsRepository
{
    public UserStudyGroupsRepository(ApplicationDbContext dataContext,IMapper<DALUserStudyGroupsDTO, Domain.App.UserStudyGroups> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALUserStudyGroupsDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .Include(f => f.StudyGroups)
            .OrderBy(e => e.StudyGroups!.GroupName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALUserStudyGroupsDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(g => g.AppUser)
            .Include(g => g.StudyGroups)
            
            .FirstOrDefaultAsync(m => m.Id == id));
    }

    public Task<IEnumerable<UserStudyGroups>> GetAllForStudyGroupAsync(Guid studyGroupId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<DALUserStudyGroupsDTO>> FindAllByStudyGroupIdAsync(Guid studyGroupId)
    {
        var query = RepositoryDbSet
            .Where(usg => usg.StudyGroupsId == studyGroupId)
            .Include(e => e.AppUser)
            .Include(f => f.StudyGroups);
        
        var result = await query.ToListAsync();

        // Map the domain entities to DAL DTOs
        return result.Select(e => Mapper.Map(e)!);
    }
    
    /*public async Task<IEnumerable<DALUserStudyGroupsDTO>> AllAsyncUser()
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .Include(f => f.StudyGroups)
            .OrderBy(e => e.StudyGroups!.GroupName)
            .Where(e => e.AppUser ==)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }*/
    
}