using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ChatService
    {
        private readonly ChatRepository _chatRepository;
        public ChatService(ChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task SaveChatLog(string chatMessage, Guid senderId, Guid receiverId) => await _chatRepository.SaveChatLog(chatMessage, senderId, receiverId);

        public async Task<List<Chat>> GetChatLogs(Guid senderId, Guid receiverId) => await _chatRepository.GetChatLogs(senderId, receiverId);
    }
}
