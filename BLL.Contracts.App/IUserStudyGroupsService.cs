using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IUserStudyGroupsService : IBaseRepository<BLL.DTO.UserStudyGroups>, IUserStudyGroupsRepositoryCustom<BLL.DTO.UserStudyGroups>
{
    // add your custom service methods here
    Task<IEnumerable<UserStudyGroups>> GetAllForStudyGroupAsync(Guid studyGroupId);
    
}