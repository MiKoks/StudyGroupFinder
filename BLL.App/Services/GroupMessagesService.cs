using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class GroupMessagesService  : BaseEntityService<BLL.DTO.GroupMessages, DALGroupMessagesDTO, IGroupMessagesRepository>, IGroupMessagesService
{
    protected IAppUOW Uow;


    public GroupMessagesService(IAppUOW uow, IMapper<GroupMessages, DALGroupMessagesDTO> mapper) : base(uow.GroupMessagesRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<GroupMessages>> AllAsync()
    {
        return (await Uow.GroupMessagesRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<GroupMessages?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.GroupMessagesRepository.FindAsync(id));
    }
    
    public async Task SaveChatMessageAsync(DALGroupMessagesDTO message)
    {
        Uow.GroupMessagesRepository.Add(message);
        await Uow.SaveChangesAsync();
    }
}