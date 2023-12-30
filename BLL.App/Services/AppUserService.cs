using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO.Identity;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO.Identity;

namespace BLL.App.Services;

public class AppUserService : BaseEntityService<BLL.DTO.Identity.AppUser, DAL.DTO.Identity.DALAppUserDTO, IAppUserRepository>, IAppUserService
{
    protected IAppUOW Uow;
    public AppUserService(IAppUOW uow,IMapper<AppUser, DALAppUserDTO> mapper) : base(uow.AppUserRepository, mapper)
    {
        Uow = uow;
    }
    public new async Task<IEnumerable<AppUser>> AllAsync()
    {
        return (await Uow.AppUserRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<AppUser?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.AppUserRepository.FindAsync(id));
    }
}