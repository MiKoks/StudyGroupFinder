using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class RemaindersService : BaseEntityService<BLL.DTO.Remainders, DALRemaindersDTO, IRemaindersRepository>, IRemaindersService
{
    protected IAppUOW Uow;

    public RemaindersService(IAppUOW uow,IMapper<Remainders, DALRemaindersDTO> mapper) : base(uow.RemaindersRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<Remainders>> AllAsync()
    {
        return (await Uow.RemaindersRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<Remainders?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.RemaindersRepository.FindAsync(id));
    }
}