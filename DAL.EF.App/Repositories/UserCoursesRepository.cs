using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class UserCoursesRepository  : EFBaseRepository<DALUserCoursesDTO, UserCourses, ApplicationDbContext>, IUserCoursesRepository
{
    public UserCoursesRepository(ApplicationDbContext dataContext,IMapper<DALUserCoursesDTO, Domain.App.UserCourses> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALUserCoursesDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .Include(e => e.Course)
            .OrderBy(e => e.Course!.CourseName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public override async Task<DALUserCoursesDTO?> FindAsync(Guid id)
    {
        return Mapper.Map(await RepositoryDbSet
            .Include(g => g.AppUser)
            .Include(g => g.Course)
            
            .FirstOrDefaultAsync(m => m.Id == id));
    }
    
    public async Task<IEnumerable<DALUserCoursesDTO>> AllAsyncUserCourses(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.AppUser)
            .Include(e => e.Course)
            .OrderBy(e => e.Course!.CourseName)
            .Where(e => e.Course!.Id == id)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }
}