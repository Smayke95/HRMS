using AutoMapper;
using HRMS.Core.Interfaces.Repositories;
using HRMS.Core.Models;
using HRMS.Models;
using Microsoft.AspNetCore.SignalR;
using Task = System.Threading.Tasks.Task;

namespace HRMS.Hubs;

public class ChatHub : Hub
{
    private readonly IMapper Mapper;
    private readonly IMessageRepository MessageRepository;

    public ChatHub(
        IMapper mapper,
        IMessageRepository messageRepository)
    {
        Mapper = mapper;
        MessageRepository = messageRepository;
    }

    public async Task JoinRoom(string room)
        => await Groups.AddToGroupAsync(Context.ConnectionId, room);

    public async Task UserTyping(string room, int employeeId, string employeeName)
        => await Clients.Group(room).SendAsync("UserTyping", room, employeeId, employeeName);

    public async Task SendMessage(MessageInsert messageInsert)
    {
        var insertedMessage = await MessageRepository.InsertAsync(Mapper.Map<Message>(messageInsert));
        var message = await MessageRepository.GetAsync(insertedMessage.Id);

        await Clients.Group(messageInsert.Room).SendAsync("ReceiveMessage", message);
    }
}