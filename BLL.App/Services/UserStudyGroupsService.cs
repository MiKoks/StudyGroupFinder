using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using DAL.DTO;

namespace BLL.App.Services;

public class UserStudyGroupsService : BaseEntityService<BLL.DTO.UserStudyGroups, DALUserStudyGroupsDTO, IUserStudyGroupsRepository>, IUserStudyGroupsService
{
    protected IAppUOW Uow;

    public UserStudyGroupsService(IAppUOW uow, IMapper<UserStudyGroups, DALUserStudyGroupsDTO> mapper) : base(uow.UserStudyGroupsRepository, mapper)
    {
        Uow = uow;
    }
    
    public new async Task<IEnumerable<UserStudyGroups>> AllAsync()
    {
        return (await Uow.UserStudyGroupsRepository.AllAsync()).Select(e => Mapper.Map(e))!;
    }

    public new async Task<UserStudyGroups?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.UserStudyGroupsRepository.FindAsync(id));
    }

    public async Task<IEnumerable<UserStudyGroups>> GetAllForStudyGroupAsync(Guid studyGroupId)
    {
        // Assuming that you have a repository method that can filter by StudyGroupId
        return (await Uow.UserStudyGroupsRepository.FindAllByStudyGroupIdAsync(studyGroupId)).Select(e => Mapper.Map(e))!;
    }
}