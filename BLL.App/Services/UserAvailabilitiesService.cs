using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class UserAvailabilitiesService : BaseEntityService<BLL.DTO.UserAvailabilities, DALUserAvailabilitiesDTO, IUserAvailabilitiesRepository>, IUserAvailabilitiesService
{
    protected IAppUOW Uow;

    public UserAvailabilitiesService(IAppUOW uow, IMapper<UserAvailabilities, DALUserAvailabilitiesDTO> mapper) : base(uow.UserAvailabilitiesRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<UserAvailabilities>> AllAsync()
    {
        return (await Uow.UserAvailabilitiesRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<UserAvailabilities?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.UserAvailabilitiesRepository.FindAsync(id));
    }
}