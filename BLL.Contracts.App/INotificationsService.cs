using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface INotificationsService : IBaseRepository<BLL.DTO.Notifications>, INotificationsRepositoryCustom<BLL.DTO.Notifications>
{
    // add your custom service methods here
}