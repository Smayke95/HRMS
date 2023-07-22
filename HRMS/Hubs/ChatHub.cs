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

    public async Task SendMessage(MessageInsert messageInsert)
    {
        var insertedMessage = await MessageRepository.InsertAsync(Mapper.Map<Message>(messageInsert));
        var message = await MessageRepository.GetAsync(insertedMessage.Id);

        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}