using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;
using DAL.DTO.Identity;

namespace BLL.App.Services;

public class RoleWithinGroupService  : BaseEntityService<BLL.DTO.RoleWithinGroup, DALRoleWithinGroupDTO, IRoleWithinGroupRepository>, IRoleWithinGroupService
{
    protected IAppUOW Uow;


    public RoleWithinGroupService(IAppUOW uow, IMapper<RoleWithinGroup, DALRoleWithinGroupDTO> mapper) : base(uow.RoleWithinGroupRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<RoleWithinGroup>> AllAsync()
    {
        return (await Uow.RoleWithinGroupRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<RoleWithinGroup?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.RoleWithinGroupRepository.FindAsync(id));
    }
}