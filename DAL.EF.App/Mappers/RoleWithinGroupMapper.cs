using AutoMapper;
using DAL.Base;
using DAL.DTO;
using DAL.DTO.Identity;

namespace DAL.EF.App.Mappers;

public class RoleWithinGroupMapper : BaseMapper<DALRoleWithinGroupDTO, Domain.App.RoleWithinGroup>
{
    public RoleWithinGroupMapper(IMapper mapper) : base(mapper)
    {
    }
}