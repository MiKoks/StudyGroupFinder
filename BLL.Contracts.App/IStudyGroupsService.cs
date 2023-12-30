using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IStudyGroupsService : IBaseRepository<BLL.DTO.StudyGroups>, IStudyGroupsRepositoryCustom<BLL.DTO.StudyGroups>
{
    // add your custom service methods here
}