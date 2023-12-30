using AutoMapper;
using DAL.Base;
using DAL.DTO;

namespace BLL.App.Mappers;

public class NotificationsMapper : BaseMapper<BLL.DTO.Notifications, DALNotificationsDTO>
{
    public NotificationsMapper(IMapper mapper) : base(mapper)
    {
    }
}