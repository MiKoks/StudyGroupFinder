using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IUserAvailabilitiesService : IBaseRepository<BLL.DTO.UserAvailabilities>, IUserAvailabilitiesRepositoryCustom<BLL.DTO.UserAvailabilities>
{
    // add your custom service methods here
}