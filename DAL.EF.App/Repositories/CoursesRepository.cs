using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositories;

public class CoursesRepository : EFBaseRepository<DAL.DTO.DALCoursesDTO, Domain.App.Courses, ApplicationDbContext>, ICoursesRepository
{
    public CoursesRepository(ApplicationDbContext dataContext, IMapper<DAL.DTO.DALCoursesDTO, Domain.App.Courses> mapper) : base(dataContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<DALCoursesDTO>> AllAsync()
    {
        return await RepositoryDbSet
            .OrderBy(f => f.CourseName)
            .Select(x=>Mapper.Map(x)!)
            .ToListAsync();
    }

    public Task<IEnumerable<DALCoursesDTO>> AllAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public override async Task<DALCoursesDTO?> FindAsync(Guid id)
    {
        var res =  await RepositoryDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(res);
    }
    /*
    public virtual async Task<DALCoursesDTO?> FindAsync(Guid id, Guid userId)
    {
        return await RepositoryDbSet
            .Include(t => t.AppUser)
            .FirstOrDefaultAsync(m => m.Id == id && m.AppUserId == userId);
    }
    */
    /*
    public async Task<DALCoursesDTO?> RemoveAsync(Guid id, Guid userId)
    {
        var course = await FindAsync(id, userId);
        return course == null ? null : Remove(course);

    }
    */
    public Task<bool> IsOwnedByUserAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }

    public override async Task<DALCoursesDTO?> RemoveAsync(Guid id)
    {
        var courses = await FindAsync(id);
        return courses == null ? null : Remove(courses);
    }

}