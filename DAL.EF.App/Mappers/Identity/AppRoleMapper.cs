using AutoMapper;
using DAL.Base;

namespace DAL.EF.App.Mappers.Identity;

public class AppRoleMapper : BaseMapper<DAL.DTO.Identity.DALAppRoleDTO, Domain.App.Identity.AppRole>
{
    public AppRoleMapper(IMapper mapper) : base(mapper)
    {
    }
}