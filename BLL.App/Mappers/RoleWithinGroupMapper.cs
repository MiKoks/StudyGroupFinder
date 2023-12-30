using AutoMapper;
using DAL.Base;
using DAL.DTO;
using DAL.DTO.Identity;

namespace BLL.App.Mappers;

public class RoleWithinGroupMapper : BaseMapper<BLL.DTO.RoleWithinGroup, DALRoleWithinGroupDTO>
{
    public RoleWithinGroupMapper(IMapper mapper) : base(mapper)
    {
    }
}