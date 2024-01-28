using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;
        private readonly AccountService _accountService;
        public ChatHub(ChatService chatService, AccountService accountService)
        {
            _chatService = chatService;
            _accountService = accountService;
        }
        public async Task SendMessage(Guid senderId, Guid receiverId, string message)
        {
            await _chatService.SaveChatLog(message, senderId, receiverId);
            var sender = await _accountService.GetAccount(senderId);
            var receiver = await _accountService.GetAccount(receiverId);
            if(sender != null && receiver != null)
            {
                await Clients.User(receiver.FirstName + " " + receiver.LastName).SendAsync("ReceiveMessage", sender.FirstName + " " + sender.LastName, message);
            }
        }
        public async Task GetChatHistory(Guid senderId, Guid receiverId)
        {
            var chatHistory = await _chatService.GetChatLogs(senderId, receiverId);
            var sender = await _accountService.GetAccount(senderId);
            var receiver = await _accountService.GetAccount(receiverId);
            if(sender != null && receiver != null)
            {
                await Clients.User(sender.FirstName + " " + sender.LastName).SendAsync("ReceiveChatHistory", chatHistory);
            }
        }
    }
}
