using System.Security.Claims;
using BLL.Contracts.App;
using BLL.DTO;
using DAL.DTO;
using DAL.DTO.Identity;
using Domain.App.Identity;
using Helpers.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using AppUser = BLL.DTO.Identity.AppUser;
#pragma warning disable 1591
namespace WebApp.Hubs;
public class MyHub : Hub
{
    //private readonly IGroupMessagesService _groupMessagesService;
    private readonly UserManager<Domain.App.Identity.AppUser> _userManager;
    private readonly SignInManager<Domain.App.Identity.AppUser> _signInManager;

    public MyHub(UserManager<Domain.App.Identity.AppUser> userManager, SignInManager<Domain.App.Identity.AppUser> signInManager)
    {
        _userManager = userManager;
        //_groupMessagesService = groupMessagesService;
        _signInManager = signInManager;
    }

    
    /*public override async Task OnConnectedAsync()
    {
        //await Clients.All.SendAsync("ReceiveMessage",$"{Context.ConnectionId} has joined");
    }*/
    
    public async Task SendMessageToAll(string message)
    {
        //var userId = Context.User!.GetUserId();
        //var user = _userManager.
        //var user = _userManager.FindByIdAsync(userId);
        //var user2 = await _signInManager.IsSignedIn(Context.User!);
        var userName = "Mihkel";
        var timeStamp = DateTime.UtcNow;
        
        /*var groupMessage = new Domain.App.GroupMessages()
        {
            Id = Guid.NewGuid(),
            Message = message,
            TimeStamp = timeStamp,
            // Assuming SenderUser is of type AppUser or similar
            SenderUser = user,
            // Other properties like GroupId, etc.
        };*/
        
        //await _groupMessagesService.SaveChatMessageAsync(groupMessage);
        var formattedMessage = $"{userName} at {timeStamp:g} : {message}";
        await Clients.All.SendAsync("ReceiveMessage", formattedMessage);
    }

}