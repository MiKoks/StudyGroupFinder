using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers;

public class NotificationsMapper : BaseMapper<DAL.DTO.DALNotificationsDTO, Domain.App.Notifications>
{
    public NotificationsMapper(IMapper mapper) : base(mapper)
    {
    }
}