using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class RoleWithinGroupMapper : BaseMapper<BLL.DTO.RoleWithinGroup,Public.DTO.v1.RoleWithinGroupDTO>
{
    public RoleWithinGroupMapper(IMapper mapper) : base(mapper)
    {
    }
}