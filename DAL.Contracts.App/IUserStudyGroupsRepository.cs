using DAL.Contracts.Base;
using DAL.DTO;
using Domain.App;

namespace DAL.Contracts.App;

public interface IUserStudyGroupsRepository  : IBaseRepository<DALUserStudyGroupsDTO>,IUserStudyGroupsRepositoryCustom<DALUserStudyGroupsDTO>
{
    // add here custom methods for repo only
    Task<IEnumerable<DALUserStudyGroupsDTO>> FindAllByStudyGroupIdAsync(Guid studyGroupId);
    Task<IEnumerable<UserStudyGroups>> GetAllForStudyGroupAsync(Guid studyGroupId);
}

public interface IUserStudyGroupsRepositoryCustom<TEntity>
{
    // add here shared custom methods between repo and service that are not in IBaseRepository
    //Task<StudyGroups> FindAsyncWithAppUsers(Guid studyGroupId);
}