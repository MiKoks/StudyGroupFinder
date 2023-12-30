using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class NotificationsService   : BaseEntityService<BLL.DTO.Notifications, DALNotificationsDTO, INotificationsRepository>, INotificationsService
{
    protected IAppUOW Uow;

    public NotificationsService(IAppUOW uow,IMapper<Notifications, DALNotificationsDTO> mapper) : base(uow.NotificationsRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<Notifications>> AllAsync()
    {
        return (await Uow.NotificationsRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<Notifications?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.NotificationsRepository.FindAsync(id));
    }
}