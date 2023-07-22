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

    public void UserTyping()
    {
        Clients.All.SendAsync("IsTyping");
        Console.WriteLine("Connection received");
    }

    public async Task SendMessage(MessageInsert message)
    {
        var insertedMessage = await MessageRepository.InsertAsync(Mapper.Map<Message>(message));

        //await Clients.Group(message.Room).SendAsync("ReceiveMessage", sender, message, time, image);
    }
}