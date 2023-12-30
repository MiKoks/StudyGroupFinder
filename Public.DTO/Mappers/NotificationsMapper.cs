using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class NotificationsMapper : BaseMapper<BLL.DTO.Notifications,Public.DTO.v1.NotificationsDTO>
{
    public NotificationsMapper(IMapper mapper) : base(mapper)
    {
    }
}